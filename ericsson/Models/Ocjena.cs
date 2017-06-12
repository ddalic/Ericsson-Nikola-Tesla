using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ericsson.Models
{
    public class Ocjena
    {
        [DisplayName("OcjenaID")]
        public int OcjenaID { get; set; }
        [ForeignKey("ucenik")]
        [DisplayName("Učenik")]
        public int UcenikID { get; set; }
        [ForeignKey("predmet")]
        [DisplayName("Predmet")]
        public int PredmetID { get; set; }
        [DisplayName("Ocjena")]
        public int Grade { get; set; }
        public virtual Ucenik ucenik { get; set; }
        public virtual Predmet predmet { get; set; }
        [DisplayName("Datum rođenja")]
        [DataType(DataType.Date)]
        public DateTime datum { get; set; }
        [DisplayName("Komentar")]
        public string komentar { get; set; }
    }
}