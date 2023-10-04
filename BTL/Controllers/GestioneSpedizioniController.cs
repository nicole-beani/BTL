using BTL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BTL.Controllers
{
    public class GestioneSpedizioniController : Controller
    {
        // GET: GestioneSpedizioni


        public ActionResult Index()
         {
         return View( GestioneSpedizioni.ListaSpedizioni);
        }
        [HttpGet]
        public ActionResult AggiungiSpedizioni()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AggiungiSpedizioni(GestioneSpedizioni newSpezione)
        {
            string conn = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(conn);
            if (ModelState.IsValid) {
                GestioneSpedizioni.ListaSpedizioni.Add(newSpezione);
                try
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO GestioneSpedizioni VALUES (@Mittente,@NomeDestinatario,@IndirizzoDestinazione,@CittàDestinazione,@Costo,@Peso,@DataSpedizione,@DataStimataConsegna) ");
                    sqlCommand.Parameters.AddWithValue("Mittente", newSpezione.Mittente);
                    sqlCommand.Parameters.AddWithValue("NomeDestinatario", newSpezione.NomeDestinatario);
                    sqlCommand.Parameters.AddWithValue("IndirizzoDestinazione", newSpezione.IndirizzoDestinazione);
                    sqlCommand.Parameters.AddWithValue("CittàDestinazione", newSpezione.CittàDestinazione);
                    sqlCommand.Parameters.AddWithValue("Costo", newSpezione.Costo);
                    sqlCommand.Parameters.AddWithValue("Peso", newSpezione.Peso);
                    sqlCommand.Parameters.AddWithValue("DataSpedizione", newSpezione.DataSpedizione);
                    sqlCommand.Parameters.AddWithValue("Mittente", newSpezione.Mittente);
                    sqlCommand.Parameters.AddWithValue("DataStimataConsegna", newSpezione.DataStimataConsegna);

                   cmd.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    
                }
                finally
                { sqlConnection.Close(); }


                return RedirectToAction("Index", "GestioneSpedizioni");


            }
            else
            {
                return View();
            }

        } }

}