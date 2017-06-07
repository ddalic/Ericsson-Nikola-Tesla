using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ericsson.Models
{
    public class Imenik
    {
        public int ImenikID { get; set; }
        public virtual ICollection<Ucenik> ucenici { get; set; }
        public virtual ICollection<Ocjena> ocjene { get; set; }
    }
}