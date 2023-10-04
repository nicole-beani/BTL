using BTL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL.Controllers
{
    public class GestioneAziendeController : Controller
    {
        // GET: GestioneAziende
        public ActionResult Index()
        {
            return View(GestioneAziende.ListaGestioneAziende);
        }
        [HttpGet]
        public ActionResult AggiungiGestioneAziende()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AggiungiGestioneAziende(GestioneAziende newSpezione)
        {
            string conn = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(conn);
            if (ModelState.IsValid)
            {
                GestioneAziende.ListaGestioneAziende.Add(newSpezione);
                try
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO GestioneAziende VALUES (@PartitaIVA,@IndirizzoSede,@CittàSede) ");
                    sqlCommand.Parameters.AddWithValue("PartitaIVA", newSpezione.PartitaIVA);
                    sqlCommand.Parameters.AddWithValue("IndirizzoSede", newSpezione.IndirizzoSede);
                    sqlCommand.Parameters.AddWithValue("CF", newSpezione.CittàSede);
                  
                    int insertedSuccessfully = cmd.ExecuteNonQuery();

                    if (insertedSuccessfully > 0)
                    {
                        Response.Write("Inserted into database!");

                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Error" + ex.Message);
                }
                finally
                { sqlConnection.Close(); }


                return RedirectToAction("Index", "AggiungiGestioneAziende");


            }
            else
            {
                return View();
            }
        }
    }
}