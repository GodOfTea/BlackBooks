using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace BookClass
{
    public class License
    {
        public DateTime ValidUntil { get; set; }

        public static string PublicKey = @"<RSAKeyValue>
<Modulus>6Gc3RpvzB7YFSvWsy/zg2sIgpHgkfba7c+jU95L7UNUaipX6WY5Trby28usPnODsU5XRdnAlnKwVINPQkDdipRwTlH08uIHc0CrtVi+W/2zrxL4Fi8bAfme+FirVdEchMda1SNa7TqGWhRgoKN7QLjrlWCob6yUXspbnMMd9Zb8=</Modulus>
<Exponent>AQAB</Exponent>
</RSAKeyValue>";
    }

    public class LicenseValidator
    {
        public LicenseValidator(string path)
        {
            foreach (var file in Directory.EnumerateFiles(path, "*.blk_licence"))
            {
                if (TryLoadLicense(file))
                {
                    if (IsValid)
                    {
                        string s = file.ToString();
                        var t = s.LastIndexOf('\\');
                        var tempPath = Application.StartupPath + s.Substring(t, s.Length - t);
                        FileInfo f = new FileInfo(tempPath);
                        if (!f.Exists)
                        {
                            File.Copy(file, tempPath, true);
                        }
                        return;
                    }
                }
            }
        }

        public bool IsValid
        {
            get { return ValidUntil > DateTime.Now; }
        }

        private bool TryLoadLicense(string fileName)

        {
            RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider();

            rsaKey.FromXmlString(License.PublicKey);
        
            // Create a new XML document.
            XmlDocument xmlDoc = new XmlDocument();

            // Load an XML file into the XmlDocument object.
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.Load(fileName);

            // Verify the signature of the signed XML.
            bool result = VerifyXml(xmlDoc, rsaKey);
            if (!result)
                return false;

            HasLicense = true;

            License dto;

            using (var fileStream = File.OpenRead(fileName))
            {
                dto = (License)new XmlSerializer(typeof(License)).Deserialize(fileStream);
            }

            ValidUntil = dto.ValidUntil;
            return true;
        }

        public DateTime ValidUntil { get; set; }
        public bool HasLicense { get; set; }


        // Verify the signature of an XML file against an asymmetric
        // algorithm and return the result.

        public static Boolean VerifyXml(XmlDocument Doc, RSA Key)

        {

            // Check arguments.

            if (Doc == null)
                throw new ArgumentException("Doc");
            if (Key == null)
                throw new ArgumentException("Key");



            // Create a new SignedXml object and pass it
            // the XML document class.
            SignedXml signedXml = new SignedXml(Doc);

            // Find the "Signature" node and create a new
            // XmlNodeList object.
            XmlNodeList nodeList = Doc.GetElementsByTagName("Signature");

            // Throw an exception if no signature was found.
            if (nodeList.Count <= 0)
            {
                throw new CryptographicException("Verification failed: No Signature was found in the document.");
            }



            // This example only supports one signature for
            // the entire XML document. Throw an exception
            // if more than one signature was found.
            if (nodeList.Count >= 2)
            {
                throw new CryptographicException("Verification failed: More that one signature was found for the document.");
            }

            // Load the first node.
            signedXml.LoadXml((XmlElement)nodeList[0]);

            // Check the signature and return the result.
            return signedXml.CheckSignature(Key);

        }
    }
}
