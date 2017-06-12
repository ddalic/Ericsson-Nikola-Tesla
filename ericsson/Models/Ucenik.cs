using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ericsson.Models
{
    public class Ucenik
    {
        [DisplayName("UcenikID")]
        public int UcenikID { get; set; }
        [DisplayName("Ime učenika")]
        public string Ime { get; set; }
        [DisplayName("Prezime učenika")]
        public string Prezime { get; set; }
        [DisplayName("Datum rođenja")]
        [DataType(DataType.Date)]
        public DateTime DatumRodenja { get; set; }
        [DisplayName("Adresa")]
        public string Adresa { get; set; }
        [DisplayName("Ime roditelja")]
        public string ImeRoditelja { get; set; }
        [DisplayName("Učenik")]
        public virtual string ImeIPrezime { get
            {
                return Ime + " " + Prezime;
            } }
    }
}