using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackBooks
{
    /// <summary>
    /// Информация о заказе
    /// </summary>
    public class BookRequestDto
    {
        /// <summary>
        /// Дата заполнения
        /// </summary>
        public DateTime Filled { get; set; }
        /// <summary>
        /// Дата доставки
        /// </summary>
        public DateTime Delivery { get; set; }
        /// <summary>
        /// ФИО заказчика
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Названия книг
        /// </summary>
        public List<BookDetail> BookDetails { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public string Addres { get; set; }
        /// <summary>
        /// Стоимость
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Валюта
        /// </summary>
        public Currency Currency { get; set; }
    }
    /// <summary>
    /// Информация о книге
    /// </summary>
    public class BookDetail
    {
        /// <summary>
        /// Название книги
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Жанр
        /// </summary>
        public Genre Genre {get;set;}
        /// <summary>
        /// Автор книги
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public double Price { get; set; }

        public override string ToString()
        {
            return string.Format("{0} | {1} | {2} | {3}", Title, Author, Genre.ToString(), Price);
        }

        public BookDetail Clone()
        {
            return new BookDetail { Title = Title, Author = Author, Genre = Genre, Price = Price };
        }
    }
    

    public enum Genre
    {
        Detective,
        Fantasy,
        Fiction,
        Adventures,
        Horror,
        RomanceNovel,
        Tale,
        Comics,
        Biography
    }

    public enum Currency
    {
        Rubles,
        Dollars,
        Euro,
        Bitcoins,
        BonusPoints
    }
}
