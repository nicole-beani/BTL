using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL.Models
{
    public class Tracking
    {
        public string Mittente { get; set; }
        public double NumSpedizione { get; set; }
        Tracking() { }
        public Tracking(string mittente, double numSpedizione)
        {
            Mittente = mittente;
            NumSpedizione = numSpedizione;
        }
    }
}