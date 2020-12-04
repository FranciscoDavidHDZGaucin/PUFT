using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUFT_PRUEBA_001{
    class ACCION_PRODUCTOS_PEDIDOS


    {
        public CTRL_OBJET _CONTROL_ORDEVENTA;
        private DataTable tb_productos;

        public ACCION_PRODUCTOS_PEDIDOS(CTRL_OBJET   _CTRLORDVENTA     )
        {

            try
             {
                this._CONTROL_ORDEVENTA = _CTRLORDVENTA;
                //VALIDAMOS QUE ESTE AUTORIZADO  LA  ORDEN DE VENTA 
                if (this._CONTROL_ORDEVENTA.CONTROL_MAIN)
                {

                  
                    tb_productos = new DataTable();
                    try
                    {
                        var connection =
                                      System.Configuration.ConfigurationManager.
                                      ConnectionStrings["SALESFOREC"].ConnectionString;
                        using (SqlConnection CONECT = new SqlConnection(connection))
                        {
                            CONECT.Open();
                            using (SqlCommand COMANDO = new SqlCommand("SP_PUFT_PRODUCTOS_PEDIDOS", CONECT))


                            {
                                COMANDO.CommandType = CommandType.StoredProcedure;
                                COMANDO.Parameters.Add("@ORDEN_VENTA", SqlDbType.BigInt).Value = _CONTROL_ORDEVENTA.ORD_VENTA;
                                tb_productos.Load(COMANDO.ExecuteReader());

                                _CONTROL_ORDEVENTA.TB_PRODUCTOS = tb_productos; 


                            }
                        }

                    }
                    catch (Exception e)
                    {
                        tb_productos = new DataTable();
                    }


                }


            }
            catch (Exception e)
            { }




        }

        public  void  RECORRER_PRODUCTOS()
       {

            if (_CONTROL_ORDEVENTA.CONTROL_MAIN)
            {
                if (tb_productos.Rows.Count > 0)
                {
                    foreach (DataRow row in tb_productos.Rows)
                    {
                        var  prueba =   row["ORDENDE_VENTA"].ToString();
                        //// METER KLA CLASE DE INSERTSIO DE   PRODUCTOS  
                     
                    }




                }

            }

        }


    }



}
