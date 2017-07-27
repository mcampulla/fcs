using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace fcs.web.Models
{
    [Table("TipiArticolo")]
    public class TipoArticolo
    {
        [Key]
        public int TipoArticoloID { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public string Immagine { get; set; }
    }
}