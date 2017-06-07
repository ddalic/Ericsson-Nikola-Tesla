using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ericsson.Models
{
    public class Ocjena
    {
        public int OcjenaID { get; set; }
        public int Grade { get; set; }
        public Ucenik ucenik { get; set; }
        public Predmet predmet { get; set; }
        public DateTime datum { get; set; }
        public string komentar { get; set; }


    }
}