using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace DrugiDeoDusanBogosavljev
{
    internal class clsDataAccess
    {
        public static DataSet selectAll()
        {
            DataSet Ds = new DataSet();

            try
            {
                var cs = ConfigurationManager.ConnectionStrings["KolokvijumskiProjekat"].ConnectionString;

                using (var conn = new SqlConnection(cs))
                {
                    SqlCommand Cm = new SqlCommand();
                    Cm.Connection = conn;
                    Cm.CommandType = CommandType.StoredProcedure;
                    Cm.CommandText = "dbo.PrikaziSve";

                    SqlDataAdapter Da = new SqlDataAdapter();
                    Da.SelectCommand = Cm;

                    Da.Fill(Ds);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return Ds;
        }

        public int KlijentInsert(string naziv, string kontakt, string grad, string zemlja)
        {
            var cs = ConfigurationManager.ConnectionStrings["KolokvijumskiProjekat"].ConnectionString;
            using (var conn = new SqlConnection(cs))
            {
                SqlCommand Cm = new SqlCommand();
                Cm.Connection = conn;
                Cm.CommandType = CommandType.StoredProcedure;
                Cm.CommandText = "dbo.InsertKlijent";

                Cm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
                Cm.Parameters.AddWithValue("@naziv", naziv);
                Cm.Parameters.AddWithValue("@kontakt", kontakt);
                Cm.Parameters.AddWithValue("@grad", grad);
                Cm.Parameters.AddWithValue("@zemlja", zemlja);

                try
                {
                    if (conn.State == ConnectionState.Closed) { conn.Open(); }
                    Cm.ExecuteNonQuery();
                    conn.Close();
                    return Convert.ToInt32(Cm.Parameters["@RETURN_VALUE"].Value);
                }
                catch (Exception ex)
                {
                    throw new Exception("Greska: " + ex.Message);
                }
            }
        }

        public int KlijentUpdate(int klijentid, string naziv, string kontakt, string grad, string zemlja)
        {
            var cs = ConfigurationManager.ConnectionStrings["KolokvijumskiProjekat"].ConnectionString;
            using (var conn = new SqlConnection(cs))
            {
                SqlCommand Cm = new SqlCommand();
                Cm.Connection = conn;
                Cm.CommandType = CommandType.StoredProcedure;
                Cm.CommandText = "dbo.UpdateKlijent";

                Cm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
                Cm.Parameters.AddWithValue("@klijentid", klijentid);
                Cm.Parameters.AddWithValue("@naziv", naziv);
                Cm.Parameters.AddWithValue("@kontakt", kontakt);
                Cm.Parameters.AddWithValue("@grad", grad);
                Cm.Parameters.AddWithValue("@zemlja", zemlja);

                try
                {
                    if (conn.State == ConnectionState.Closed) { conn.Open(); }
                    Cm.ExecuteNonQuery();
                    conn.Close();
                    return Convert.ToInt32(Cm.Parameters["@RETURN_VALUE"].Value);
                }
                catch (Exception ex)
                {
                    throw new Exception("Greska: " + ex.Message);
                }
            }
        }

        public int KlijentDelete(int klijentid)
        {
            var cs = ConfigurationManager.ConnectionStrings["KolokvijumskiProjekat"].ConnectionString;
            using (var conn = new SqlConnection(cs))
            {
                SqlCommand Cm = new SqlCommand();
                Cm.Connection = conn;
                Cm.CommandType = CommandType.StoredProcedure;
                Cm.CommandText = "dbo.DeleteKlijent";
                Cm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
                Cm.Parameters.AddWithValue("@klijentid", klijentid);

                try
                {
                    if (conn.State == ConnectionState.Closed) { conn.Open(); }
                    Cm.ExecuteNonQuery();
                    conn.Close();
                    return Convert.ToInt32(Cm.Parameters["@RETURN_VALUE"].Value);
                }
                catch (Exception ex)
                {
                    throw new Exception("Greska: " + ex.Message);
                }
            }
        }
    }
}
