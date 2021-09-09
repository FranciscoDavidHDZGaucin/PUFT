using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUFT_PRUEBA_001
{
    class PUFT_ERRORS
{
        String msg_puft_error = null;
        String class_puft_error = null;
        String exception_puft_error = null;
        DateTime fecha_puft_error;
        Boolean existe_eror = false;
        



        public PUFT_ERRORS( string msg_puft, string class_puft , string exception_puft , DateTime fecha_puft)
        {

            this.msg_puft_error = msg_puft;
            this.class_puft_error = class_puft;
            this.exception_puft_error = exception_puft;
            this.fecha_puft_error = fecha_puft;
            insert_ERROR_PUFT();
        }
        public void insert_ERROR_PUFT()
        {
            try
            {
                string connection =
                                    System.Configuration.ConfigurationManager.
                                    ConnectionStrings["Server80"].ConnectionString;

                using (MySqlConnection coneccmys = new MySqlConnection(connection))
                {
                    coneccmys.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_PUFT_INS_ERROR", coneccmys))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new MySqlParameter("PUFT_msg_puft", MySqlDbType.String )).Value = this.msg_puft_error ;
                        cmd.Parameters.Add(new MySqlParameter("PUFT_class_puft", MySqlDbType.String)).Value = this.class_puft_error;
                        cmd.Parameters.Add(new MySqlParameter("PUFT_exception_puft", MySqlDbType.String)).Value = this.exception_puft_error;
                        cmd.Parameters.Add(new MySqlParameter("PUFT_fecha_puft", MySqlDbType.DateTime)).Value = this.fecha_puft_error;

                        DataTable dt_table = new DataTable();
                        MySqlDataAdapter APSTER = new MySqlDataAdapter(cmd);

                        APSTER.Fill(dt_table);
                        if (dt_table.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt_table.Rows)
                            {
                            }

                        }
                    }
                    coneccmys.Close();
                }



                

            }
            catch (Exception e)
            {



            }




        }

    }

    class PUFT_DIRECCIONES_ERRORS
    {
        String msg_puft_error = null;
        String class_puft_error = null;
        String exception_puft_error = null;
        DateTime fecha_puft_error;
        Boolean existe_eror = false;




        public PUFT_DIRECCIONES_ERRORS(string msg_puft, string class_puft, string exception_puft)
        {

            this.msg_puft_error = msg_puft;
            this.class_puft_error = class_puft;
            this.exception_puft_error = exception_puft;
            insert_ERROR_PUFT();
        }
        public void insert_ERROR_PUFT()
        {
            try
            {
                string connection =
                                    System.Configuration.ConfigurationManager.
                                    ConnectionStrings["Server80"].ConnectionString;

                using (MySqlConnection coneccmys = new MySqlConnection(connection))
                {
                    coneccmys.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_PUFT_INS_ERROR", coneccmys))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new MySqlParameter("INTFASE_ERROR", MySqlDbType.String)).Value = this.msg_puft_error;
                        cmd.Parameters.Add(new MySqlParameter("INSERROR_direcc", MySqlDbType.String)).Value = this.class_puft_error;
                        cmd.Parameters.Add(new MySqlParameter("VAR_SEND", MySqlDbType.String)).Value = this.exception_puft_error;
                        

                        DataTable dt_table = new DataTable();
                        MySqlDataAdapter APSTER = new MySqlDataAdapter(cmd);

                        APSTER.Fill(dt_table);
                        if (dt_table.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt_table.Rows)
                            {
                            }

                        }
                    }
                    coneccmys.Close();
                }





            }
            catch (Exception e)
            {



            }




        }

    }








}
