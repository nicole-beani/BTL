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
    public class GestionePrivatiController : Controller
    {
        // GET: GestionePrivati
        public ActionResult Index()
        {
            return View(GestionePrivati.ListaGestionePrivati);
        }
        [HttpGet]
        public ActionResult AggiungiGestionePrivati()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AggiungiGestionePrivati(GestionePrivati newSpezione)
        {
            string conn = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(conn);
            if (ModelState.IsValid)
            {
                GestionePrivati.ListaGestionePrivati.Add(newSpezione);
                try
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO GestionePrivati VALUES (@Nome,@Cognome,@CF,@LuogoNascita,@Residenza,@DataNascita) ");
                    sqlCommand.Parameters.AddWithValue("Nome", newSpezione.Nome);
                    sqlCommand.Parameters.AddWithValue("Cognome", newSpezione.Cognome);
                    sqlCommand.Parameters.AddWithValue("CF", newSpezione.CF);
                    sqlCommand.Parameters.AddWithValue("LuogoNascita", newSpezione.LuogoNascita);
                    sqlCommand.Parameters.AddWithValue("Residenza", newSpezione.Residenza);
                    sqlCommand.Parameters.AddWithValue("DataNascita", newSpezione.DataNascita);
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


                return RedirectToAction("Index", "AggiungiGestionePrivati");


            }
            else
            {
                return View();
            }

        }
    }
}
