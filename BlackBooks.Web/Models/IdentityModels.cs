using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.ObjectModel;

namespace BlackBooks.Web.Models
{
    // Чтобы добавить данные профиля для пользователя, можно добавить дополнительные свойства в класс ApplicationUser. Дополнительные сведения см. по адресу: http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<DbBookRequest> BookRequests { get; set; }
        public DbSet<DbBookDetail> DbBookPoints { get; set; }
    }



    /// <summary>
    /// Информация о заказе
    /// </summary>
    public class DbBookRequest
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
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
        public virtual Collection<DbBookDetail> BookDetails { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public string Addres { get; set; }
        /// <summary>
        /// Стоимость
        /// </summary>
        public decimal Price { get; set; }
    }

    public class DbBookDetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        /// <summary>
        /// Название книги
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Жанр
        /// </summary>
        public Genre Genre { get; set; }
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
}