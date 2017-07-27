using fcs.web.Models;
using System;
using System.Collections.Generic;
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
            return View();
        }

        public ActionResult ArticoloDelete(int id)
        {
            Articolo model = agent.GetArticolo(id);
            agent.DeleteArticolo(model);
            return RedirectToAction("Articoli");
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