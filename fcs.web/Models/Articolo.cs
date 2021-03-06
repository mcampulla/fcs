﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace fcs.web.Models
{
    [Table("Articoli")]
    public class Articolo
    {
        [Key]
        public int ArticoloID { get; set; }
        public int CategoriaID { get; set; }
        public int TipoID { get; set; }
        public string Titolo { get; set; }
        public string Abstract { get; set; }
        [DataType("Date")]
        public DateTime Data { get; set; }
        public int Stato { get; set; }
        public string Body { get; set; }
        [DataType("Foto")]
        public string ImmagineHome { get; set; }
        [DataType("Foto")]
        public string ImmagineLista { get; set; }
        [DataType("Foto")]
        public string Immagine1 { get; set; }
        [DataType("Foto")]
        public string Immagine2 { get; set; }
        [DataType("Foto")]
        public string Immagine3 { get; set; }
        [DataType("Foto")]
        public string Immagine4 { get; set; }
        [DataType("Foto")]
        public string Immagine5 { get; set; }
        public string Sezione1 { get; set; }
        public string Sezione2 { get; set; }
        public string Sezione3 { get; set; }
        public string Sezione4 { get; set; }
        public string Sezione5 { get; set; }
    }
}