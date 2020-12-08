using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUFT_PRUEBA_001
{
    class MAIN_ORDEN_VENTAS
{
        private DataTable TB_ORDVTS;

        public MAIN_ORDEN_VENTAS()

        {
            try
            {
                
               

                    TB_ORDVTS = new DataTable();
                    try
                    {
                        var connection =
                                      System.Configuration.ConfigurationManager.
                                      ConnectionStrings["SALESFOREC"].ConnectionString;
                        using (SqlConnection CONECT = new SqlConnection(connection))
                        {
                            CONECT.Open();
                            using (SqlCommand COMANDO = new SqlCommand("SP_PUFT_ORDENDEVENTA_PENDIENTE", CONECT))


                            {
                                COMANDO.CommandType = CommandType.StoredProcedure;
                               
                                TB_ORDVTS.Load(COMANDO.ExecuteReader());

                                
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        TB_ORDVTS = new DataTable();
                    }




            }
            catch (Exception e)
            { }







        }

        public void RECORRER_ORDEN_VENTAS()
        {

           
                if (TB_ORDVTS.Rows.Count > 0)
                {
                    foreach (DataRow row in TB_ORDVTS.Rows)
                    {
                        var prueba = row["ORDENDE_VENTA"].ToString();
                        //// METER KLA CLASE DE INSERTSIO DE   PRODUCTOS  

                    }




                }

            

        }


    }
}
