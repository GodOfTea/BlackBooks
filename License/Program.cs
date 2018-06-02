using BookClass;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Xml;
using System.Xml.Serialization;

namespace LicenseGenerator
{
    class Program
    {
        private static void GenerateNewKeyPair()
        {

            string withSecret;

            string woSecret;

            using (var rsaCsp = new RSACryptoServiceProvider())
            {
                withSecret = rsaCsp.ToXmlString(true);
                woSecret = rsaCsp.ToXmlString(false);
            }
            File.WriteAllText("private.xml", withSecret);
            File.WriteAllText("public.xml", woSecret);
        }
        static void Main(string[] args)
        {
            if(args.Any(a => a == "--generate"))
            {
                GenerateNewKeyPair();
            }

            var dto = new BookClass.License()
            {
                ValidUntil = DateTime.Now.AddDays(31)
            };

            var fileName = string.Join("", DateTime.Now.ToString().Where(c => char.IsDigit(c)));
            new LicenceGenerator().CreateLicenseFile(dto, fileName + ".blk_licence");
        }

        class LicenceGenerator
        {
            private static string PrivateKey = @"<RSAKeyValue>
<Modulus>6Gc3RpvzB7YFSvWsy/zg2sIgpHgkfba7c+jU95L7UNUaipX6WY5Trby28usPnODsU5XRdnAlnKwVINPQkDdipRwTlH08uIHc0CrtVi+W/2zrxL4Fi8bAfme+FirVdEchMda1SNa7TqGWhRgoKN7QLjrlWCob6yUXspbnMMd9Zb8=</Modulus>
<Exponent>AQAB</Exponent>
<P>/piaIo9J5Ex+pEfuoUz41lcmWJaqCmo0v/jC2smkedTIhgdOVkvQolQ/HRSSt5l2Hd8EVVhNYkn9736Gt014uQ==</P>
<Q>6a9JEl/Aj0HhvZcnc1ooQXbMVzZe4lHbRJN5rs/vXoKslSJ7XLqzW5FwweKpLHhvnWV0mtmzpVnU52pWFNUmNw==</Q>
<DP>gUAJqBfkZHFtLYuTGvJPtckCn6DFbIokg30PtzD9PhiHQHu/ClJs9awdam8CWREghOOueIFer9Juh0JNtAsxiQ==</DP>
<DQ>qcxYCCXTQUTZxm0CmWq1PXwY1nYHU+Ous5GFJWSpxb6lsGexw5tVn/96MyeDTXDliTSjGbF+O3Oeo9g8XD7U2Q==</DQ>
<InverseQ>4SVJOGmlCYoXbSnbo7cEoGnP6St0OWelMLB66GN7ExvMn+xHFmSdee8oR00oS9WoL8ibDZ+F9MV74csb1CsCtw==</InverseQ>
<D>y9/gKd0c8iLHud6TW8/XIZEzOZT7zhzDjQcv7I/QUDTiN7kiCfZFiiAHDksPQzw9lYXUXuY62JpNXqLyT9GGgk0p37fiDVMXlBD4o1v+GTjqFB/Ni1zejkgOrzA2ashFyX9s/HfCXhIDSsoFFZ9R1h/AbJNNlMeJozu2TM4v8EE=</D>
</RSAKeyValue>";

            public void CreateLicenseFile(License dto, string fileName)
            {
                var ms = new MemoryStream();
                new XmlSerializer(typeof(BookClass.License)).Serialize(ms, dto);

                RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider();
                rsaKey.FromXmlString(PrivateKey);

                XmlDocument xmlDoc = new XmlDocument();

                xmlDoc.PreserveWhitespace = true;
                ms.Seek(0, SeekOrigin.Begin);
                xmlDoc.Load(ms);

                SignXml(xmlDoc, rsaKey);

                xmlDoc.Save(fileName);
            }

            public static void SignXml(XmlDocument xmlDoc, RSA Key)
            {
                if (xmlDoc == null)
                    throw new ArgumentException("xmlDoc");
                if (Key == null)
                    throw new ArgumentException("Key");

                SignedXml signedXml = new SignedXml(xmlDoc);

                signedXml.SigningKey = Key;

                Reference reference = new Reference();
                reference.Uri = "";

                XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
                reference.AddTransform(env);

                signedXml.AddReference(reference);

                signedXml.ComputeSignature();

                XmlElement xmlDigitalSignature = signedXml.GetXml();

                xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));
            }
        }
    }
}