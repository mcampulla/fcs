using fcs.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fcs.web.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class HomeController : Controller
    {
        FcsDbContext db = new FcsDbContext();

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Cats = db.Categorie.Where(c => c.IsMain != 1).ToList();
            var model = db.Categorie.Where(c => c.IsMain == 1).ToList();
            return View(model);
        }

        public ActionResult CategoryList()
        {
            var model = db.Categorie.ToList();
            return View(model);
        }

        public ActionResult ArticleList(int categoryId)
        {
            var model = db.Articoli.Where(a => a.CategoriaID == categoryId).ToList();
            return View(model);
        }

        public ActionResult ArticleDetail(int articleId)
        {
            var model = db.Articoli.Find(articleId);
            if (model == null)
                return RedirectToAction("Index");

            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }

            base.Dispose(disposing);
        }
    }
}