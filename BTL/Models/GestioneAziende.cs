using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL.Models
{
    public class GestioneAziende
    { public int IdGestioneAziende { get; set; }
        public int PartitaIVA { get; set; }
        public string IndirizzoSede { get; set; }
        public string CittàSede { get; set; }
        public static List<GestioneAziende> ListaGestioneAziende { get; set; } = new List<GestioneAziende>();
        GestioneAziende() { }
        public GestioneAziende (int idGestioneAziende, int paritaIVA, string indirizzoSede, string cittàSede)
        {
            IdGestioneAziende = idGestioneAziende;
            PartitaIVA = paritaIVA;
            IndirizzoSede = indirizzoSede;
            CittàSede = cittàSede;


        }
    }
}