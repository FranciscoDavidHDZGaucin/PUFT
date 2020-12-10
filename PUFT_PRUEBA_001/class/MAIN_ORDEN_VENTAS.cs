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
                    ///
                    var pr = new cmdsForm();
                    pr.insertarDatosEncabeza(Convert.ToInt32(row["n_remision"].ToString()), Convert.ToDateTime(row["fecha_alta"].ToString()), row["cve_cte"].ToString(),
                        Convert.ToString(row["CardName"].ToString()), "", "", "", "", Convert.ToString(row["estatus"].ToString()), Convert.ToInt32(row["n_agente"].ToString()),
                        Convert.ToString(row["nom_age"].ToString()), Convert.ToString(row["comentario"].ToString()), Convert.ToInt32(row["moneda"].ToString()),
                        Convert.ToInt32(row["plazo"].ToString()), Convert.ToInt32(row["tipo_venta"].ToString()), Convert.ToInt32(row["toal"].ToString()),
                        Convert.ToString(row["medio_pago"].ToString()), Convert.ToInt32(row["cuenta"].ToString()), Convert.ToString(row["destino"].ToString()),
                        Convert.ToInt32(row["tipo_agente"].ToString()), Convert.ToInt32(row["total_p"].ToString()), "", "", 0, "", Convert.ToInt32(row["vbo_gestor"].ToString()),
                        Convert.ToString(row["comentario_gestor"].ToString()), Convert.ToInt32(row["vbo_jefecyc"].ToString()), Convert.ToString(row["comentario_jefecyc"].ToString()),
                        0, "", 0, "", Convert.ToDateTime(row["timeres_gestor"].ToString()), Convert.ToDateTime(row["timeres_jefecyc"].ToString()), DateTime.Now, DateTime.Now, 0, Convert.ToInt32(row["vbo_gerente"].ToString()),
                        Convert.ToString(row["comentario_gerente"].ToString()), Convert.ToDateTime(row["timeres_gerente"].ToString()), DateTime.Now, 0, DateTime.Now, 0, Convert.ToDateTime(row["altahora_pedido"].ToString()),
                        0, 0, Convert.ToInt32(row["encbandera_especial"].ToString()), Convert.ToInt32(row["encbandera_especial"].ToString()), 0, 0, "", DateTime.Now, Convert.ToString(row["opCFDI"].ToString()),
                        "", Convert.ToString(row["MTDPG"].ToString()), 0, 0, "", 0, "");

                }




            }

            

        }


    }
}
