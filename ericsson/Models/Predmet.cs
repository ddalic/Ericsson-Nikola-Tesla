using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ericsson.Models
{
    public class Predmet
    {
        [DisplayName("PredmetID")]
        public int PredmetID { get; set; }
        [DisplayName("Naziv predmeta")]
        public string ImePredmeta { get; set; }
        [DisplayName("Profesor")]
        public string ImeProfesora { get; set; }
        [DisplayName("Opis")]
        public string Opis { get; set; }

    }
}