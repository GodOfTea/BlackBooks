using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    [Serializable]
    public class DomainData
    {
        /// <summary>
        /// Порядковый номер
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public int Password { get; set; }

        public override string ToString()
        {
            return Login;
        }
    }
}
