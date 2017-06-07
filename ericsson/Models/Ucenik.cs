using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ericsson.Models
{
    public class Ucenik
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodenja { get; set; }
        public string Adresa { get; set; }
        public string ImeRoditelja { get; set; }
    }
}