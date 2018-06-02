using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlackBooks;

namespace BlackBooks.Web.Controllers
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
                var dto = BooksDtoHelper.LoadFromFile(file.InputStream);
                return View(dto);
            }

            return RedirectToAction("Index");
        }
    }
}