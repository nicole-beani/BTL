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
    public class AmministratoriController : Controller
    {
        // GET: Amministratori
        public ActionResult Amministratori()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Amministratori( Amministratori a)
        {
            string conn = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(conn);
            try
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("Select * FROM LoginAm WHERE Username=@Username And Password=@Password", sqlConnection);
                sqlCommand.Parameters.AddWithValue("Username", a.Username);
                sqlCommand.Parameters.AddWithValue("Password", a.Password);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    FormsAuthentication.SetAuthCookie(a.Username, false);
                    return RedirectToAction("Index", "Home");
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

            return RedirectToAction("Index", "Home");
        }
    }
}