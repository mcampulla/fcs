using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace fcs.web.Models
{
    public class FcsDbAgent : IDisposable
    {
        FcsDbContext db = new FcsDbContext();

        public FcsDbAgent()
        {
        }

        #region Categorie

        public IEnumerable<Categoria> GetCategorie()
        {
            return db.Categorie;
        }

        public Categoria GetCategoria(int id)
        {
            return db.Categorie.Find(id);
        }

        public int SaveCategoria(Categoria obj)
        {
            if (obj.CategoriaID != 0)
            {
                db.Categorie.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                db.Categorie.Add(obj);
                db.SaveChanges();
            }
            return obj.CategoriaID;
        }

        public bool DeleteCategoria(Categoria obj)
        {
            db.Categorie.Attach(obj);
            db.Categorie.Remove(obj);
            db.SaveChanges();
            return true;
        }

        #endregion

        #region Articoli

        public IEnumerable<Articolo> GetArticoli()
        {
            return db.Articoli;
        }

        public Articolo GetArticolo(int id)
        {
            return db.Articoli.Find(id);
        }

        public int SaveArticolo(Articolo obj)
        {
            if (obj.ArticoloID != 0)
            {
                db.Articoli.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                db.Articoli.Add(obj);
                db.SaveChanges();
            }
            return obj.ArticoloID;
        }

        public bool DeleteArticolo(Articolo obj)
        {
            db.Articoli.Attach(obj);
            db.Articoli.Remove(obj);
            db.SaveChanges();
            return true;
        }
        #endregion

        public void Dispose()
        {
            if (db != null)
            {
                db.Dispose();
                db = null;
            }
        }
    }
}