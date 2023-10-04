using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL.Models
{
    public class GestioneSpedizioni
    {
        public string Mittente { get; set; }
        public string NomeDestinatario { get; set;}
        public string IndirizzoDestinazione { get; set; }
        public string CittàDestinazione { get; set; }
        public double Costo { get; set; }
        public double Peso  { get; set; }
        public DateTime DataSpedizione { get; set; }
        public DateTime DataStimataConsegna { get; set; }

       public static List <GestioneSpedizioni> ListaSpedizioni { get; set; }= new List<GestioneSpedizioni> ();

        GestioneSpedizioni() { }
        public GestioneSpedizioni(string mittente, string nomeDestinatario, string indirizzoDestinazione, string cittàDestinazione, double costo, double peso, DateTime dataSpedizione, DateTime dataStimataConsegna)
        {
            Mittente = mittente;
            NomeDestinatario = nomeDestinatario;
            IndirizzoDestinazione = indirizzoDestinazione;
            CittàDestinazione = cittàDestinazione;
            Costo = costo;
            Peso = peso;
            DataSpedizione = dataSpedizione;
            DataStimataConsegna = dataStimataConsegna;
        }
    }
}