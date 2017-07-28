using fcs.web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace fcs.web.Controllers
{
    public class AdminController : Controller
    {
        FcsDbAgent agent = new FcsDbAgent();

        public ActionResult Index()
        {
            return View();
        }

        #region Categorie

        public ActionResult Categorie()
        {
            IEnumerable<Categoria> model = agent.GetCategorie();
            return View(model);
        }      

        public ActionResult CategoriaEdit(int? id)
        {
            Categoria model = new Categoria();
            if (id.HasValue)
                model = agent.GetCategoria(id.Value);

            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CategoriaEdit(Categoria model)
        {
            if (ModelState.IsValid)
            {
                int id = agent.SaveCategoria(model);
                return RedirectToAction("CategoriaEdit", new { id = id });
            }
            return View();
        }

        public ActionResult CategoriaDelete(int id)
        {
            Categoria model = agent.GetCategoria(id);
            agent.DeleteCategoria(model);
            return RedirectToAction("Categorie");
        }

        #endregion

        #region Articoli

        public ActionResult Articoli()
        {
            IEnumerable<Articolo> model = agent.GetArticoli();
            return View(model);
        }

        public ActionResult ArticoloEdit(int? id)
        {
            Articolo model = new Articolo();
            if (id.HasValue)
                model = agent.GetArticolo(id.Value);

            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ArticoloEdit(Articolo model)
        {
            if (ModelState.IsValid)
            {
                int id = agent.SaveArticolo(model);
                return RedirectToAction("ArticoloEdit", new { id = id });
            }
            return View(model);
        }

        public ActionResult ArticoloDelete(int id)
        {
            Articolo model = agent.GetArticolo(id);
            agent.DeleteArticolo(model);
            return RedirectToAction("Articoli");
        }

        #endregion

        #region utility

        public ActionResult CloseFancybox()
        {
            return View();
        }        

        [HttpPost]
        public ActionResult UploadFile()
        {
            string uploadpath = ConfigurationManager.AppSettings["UploadPath"];
            HttpPostedFile file1 = System.Web.HttpContext.Current.Request.Files[0];
            string url = string.Empty;
            string foldername = string.Empty;

            if (file1 != null)
            {
                string filename = string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMdd-HHmmss"), System.IO.Path.GetFileName(file1.FileName));
                url = string.Format(uploadpath + "/{1}", DateTime.Now.Year, filename);
                foldername = Server.MapPath(string.Format(uploadpath, DateTime.Now.Year));

                if (!System.IO.Directory.Exists(foldername))
                    System.IO.Directory.CreateDirectory(foldername);

                string path = System.IO.Path.Combine(foldername, filename);
                // file is uploaded
                file1.SaveAs(path);

                // save the image path path to the database or you can send image directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file1.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
            }

            return Json(new
            {
                files = new[] {
                    new {name = file1.FileName, size = file1.ContentLength, url = url}
                }
                //new {name = "picture2.jpg", size = 902604, url = @"http://example.org/files/picture2.jpg", 
                //thumbnailUrl = @"http://example.org/files/thumbnail/picture2.jpg", deleteUrl = @"http://example.org/files/picture2.jpg", deleteType = "DELETE"}

            });
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (agent != null)
                {
                    agent.Dispose();
                    agent = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}