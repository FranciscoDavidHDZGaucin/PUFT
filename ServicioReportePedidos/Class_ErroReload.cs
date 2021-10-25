using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioReportePedidos
{
    class Class_ErroReload
    {
        public    Class_ErroReload( string MESSAGE_CTRL, string MESSAGE_CATACTER , string EXCEPTION)
        {

          
            try
            {
                var connection = "server=192.168.101.154;database=JUPITER;uid=sa;password=DB@gr0V3rs@;";


                using (SqlConnection sqljupiter = new SqlConnection(connection))
                {
                    sqljupiter.Open();
                    using (SqlCommand SP_EROR  = new SqlCommand("SP_RELOAD_ERROR_LOG_REPORTE_PEDIDOS", sqljupiter))
                    {
                        SP_EROR.CommandType = CommandType.StoredProcedure;
                        SP_EROR.Parameters.Add("@MESSAGE_CTRL",  SqlDbType.NChar).Value  = MESSAGE_CTRL;
                        SP_EROR.Parameters.Add("@MESSAGE_CATACTER", SqlDbType.NChar).Value = MESSAGE_CATACTER;
                        SP_EROR.Parameters.Add("@EXCEPTION", SqlDbType.NChar).Value = EXCEPTION;


                        SP_EROR.ExecuteReader(); 

                    }



                }




            }
            catch (Exception J)
            {

          ///     Event001.WriteEntry("Error N#0001  Incio de consulta" + J);

            }





        }

    }
}
