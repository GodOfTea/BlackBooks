using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackBooks.Web.Models;
using BlackBooks;

namespace GoHome.Web.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Print(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var dto = BooksDtoHelper.LoadFromStream(file.InputStream);

                using (var db = new ApplicationDbContext())
                {
                    var row = new DbBookRequest
                    {
                        Addres = dto.Addres,
                        FullName = dto.FullName,
                        Delivery = dto.Delivery,
                        Price = dto.Price,
                        Filled = dto.Filled,
                    };

                    row.BookDetails = new Collection<DbBookDetail>();

                    foreach (var dbDto in dto.BookDetails)
                    {
                        row.BookDetails.Add(new DbBookDetail
                        {
                            Title = dbDto.Title,
                            Author = dbDto.Author,
                            Genre = (BlackBooks.Web.Models.Genre)(int)dbDto.Genre
                        });
                    }

                    //db.BookRequests.Add(row);
                    db.SaveChanges();
                }

                return View(dto);
            }

            return RedirectToAction("Index");
        }
    }
}