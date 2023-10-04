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
    public class TrackingController : Controller
    {
        // GET: Tracking
        public ActionResult Tracking()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Tracking(Tracking t)
        {
            string conn = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(conn);
            try
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("Select * FROM Tracking WHERE Mittente=@Mittente And NumSpedizione=@NumSpedizione", sqlConnection);
                sqlCommand.Parameters.AddWithValue("Mittente", t.Mittente);
                sqlCommand.Parameters.AddWithValue("NumSpedizione", t.NumSpedizione);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    FormsAuthentication.SetAuthCookie(t.Mittente, false);
                    return RedirectToAction("Index", "Tracking");
                }
                else
                {
                    ViewBag.AuthError = "Autenticazione non riuscita";
                    return View();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlConnection.Close();
            }

            return RedirectToAction("Index", "Tracking");
        }
    }
}