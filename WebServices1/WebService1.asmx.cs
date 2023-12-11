using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServices
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        private string connectionString = "server=(local); database=academico; user=Inf324; pwd=123456";


        [WebMethod]
        public DataSet tbalumno()
        {

            SqlConnection con = new SqlConnection();
            SqlDataAdapter ada = new SqlDataAdapter();
            DataSet ds = new DataSet();

            con.ConnectionString = "server=(local); database=academico; user=Inf324; pwd=123456";
            ada.SelectCommand = new SqlCommand("SELECT * FROM alumno", con);

            try
            {
                con.Open();
                ada.Fill(ds, "alumno");
                return ds;
            }
            catch (Exception ex)
            {
                // Manejar las excepciones de manera apropiada (registrar, lanzar, etc.)
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        [WebMethod]
        public void InsertAlumno(string ci, string nombre)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO alumno (CI, Nombre) VALUES (@CI, @Nombre)", con);
                cmd.Parameters.AddWithValue("@CI", ci);
                cmd.Parameters.AddWithValue("@Nombre", nombre);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        [WebMethod]
        public void UpdateAlumno(string ci, string nuevoNombre)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE alumno SET Nombre = @Nombre WHERE CI = @CI", con);
                cmd.Parameters.AddWithValue("@CI", ci);
                cmd.Parameters.AddWithValue("@Nombre", nuevoNombre);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        [WebMethod]
        public void DeleteAlumno(string ci)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM alumno WHERE CI = @CI", con);
                cmd.Parameters.AddWithValue("@CI", ci);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
