using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace fcs.web.Models
{
    [Table("Categorie")]
    public class Categoria
    {
        [Key]
        public int CategoriaID { get; set; }
        public int IsMain { get; set; }
        public string Titolo { get; set; }
        public string Descrizione { get; set; }
        public string Immagine { get; set; }
    }
}