using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL.Models
{
    public class GestionePrivati
    { 
        public int IdGestionePrivati { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CF { get; set; }
        public string LuogoNascita { get; set; }
        public string Residenza { get; set; }
        public DateTime DataNascita { get; set; }

        public static List<GestionePrivati> ListaGestionePrivati { get; set; } = new List<GestionePrivati>();

        GestionePrivati() { }
        public GestionePrivati(int idGestionePrivati, string nome, string cognome, string cF, string luogoNascita, string residenza, DateTime dataNascita)
        {
            IdGestionePrivati = idGestionePrivati;
            Nome = nome;
            Cognome = cognome;
            CF = cF;
            LuogoNascita = luogoNascita;
            Residenza = residenza;
            DataNascita = dataNascita;
        }
    }
}