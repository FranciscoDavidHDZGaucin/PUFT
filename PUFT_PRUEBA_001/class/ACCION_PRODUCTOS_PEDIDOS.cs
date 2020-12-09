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
                        ///
                        var pr = new cmdsForm();
                        pr.insertarDatosDetalle(Convert.ToInt32(row["n_remision"].ToString()), Convert.ToInt32(row["n_agente"].ToString()), row["nom_age"].ToString(),
                            Convert.ToDateTime(row["fecha_alta"].ToString()), Convert.ToString(row["cve_cte"].ToString()), Convert.ToString(row["nom_cte"].ToString()),
                            Convert.ToString(row["cve_prod"].ToString()), Convert.ToString(row["nom_prod"].ToString()), Convert.ToInt32(row["cant_prod"].ToString()),
                            Convert.ToInt32(row["precio_prod"].ToString()), Convert.ToInt32(row["dcto_prod"].ToString()), Convert.ToInt32(row["ieps"].ToString()),
                            Convert.ToInt32(row["iva"].ToString()), Convert.ToInt32(row["total_prod"].ToString()), Convert.ToInt32(row["moneda_prod"].ToString()),
                            Convert.ToInt32(row["cant_falta"].ToString()), Convert.ToInt32(row["AUTORIZADP"].ToString()), Convert.ToInt32(row["total_prodmxp"].ToString()),
                            Convert.ToInt32(row["TIPO_CAMBIO"].ToString()), Convert.ToInt32(row["precio_condcto"].ToString()), Convert.ToInt32(row["precio_politica"].ToString()),
                            Convert.ToString(row["comentario"].ToString()), Convert.ToString(row["estatus"].ToString()), Convert.ToString(row["bonificacion"].ToString()),
                            Convert.ToDateTime(row["fecha_autoriza"].ToString()), Convert.ToString(row["estatus2"].ToString()), Convert.ToString(row["n_factura"].ToString()),
                            Convert.ToString(row["comentario2"].ToString()), Convert.ToInt32(row["TERMINADA"].ToString()), Convert.ToString(row["motivo"].ToString()),
                            Convert.ToDateTime(row["f_cancela"].ToString()), Convert.ToDateTime(row["fecha_promesa"].ToString()), Convert.ToInt32(row["n_promotor"].ToString()),
                            Convert.ToString(row["nom_promotor"].ToString()), Convert.ToInt32(row["corte"].ToString()), Convert.ToDateTime(row["fechap_programa"].ToString()),
                            Convert.ToDateTime(row["fechap_real"].ToString()), Convert.ToString(row["sinfecha"].ToString()), Convert.ToInt32(row["notifica_p"].ToString()),
                            Convert.ToDateTime(row["fecha_autorizadc"].ToString()), Convert.ToString(row["litkg_unidad"].ToString()), Convert.ToInt32(row["fact_ds"].ToString()),
                            Convert.ToInt32(row["precio_representante"].ToString()), Convert.ToInt32(row["au_gerente"].ToString()), Convert.ToInt32(row["au_dc"].ToString()),
                            Convert.ToInt32(row["precio_pagar"].ToString()), Convert.ToInt32(row["precio_factura"].ToString()), Convert.ToInt32(row["total_factura"].ToString()),
                            Convert.ToInt32(row["bandera_especial"].ToString()), Convert.ToInt32(row["plazo_especial"].ToString()), Convert.ToInt32(row["boni_precioporunidad"].ToString()), Convert.ToInt32(row["boni_cantidadporunidad"].ToString()),
                            Convert.ToString(row["boni_productoid"].ToString()), Convert.ToInt32(row["boni_precioventa"].ToString()), Convert.ToInt32(row["boni_cantidadcalculo"].ToString()),
                            Convert.ToInt32(row["boni_estado"].ToString()), Convert.ToInt32(row["boni_costomp"].ToString()), Convert.ToInt32(row["boni_bonificadomp"].ToString()),
                            Convert.ToString(row["entrega"].ToString()), Convert.ToDateTime(row["fecha_autorizajefecomer"].ToString()), Convert.ToDateTime(row["fecha_autorizanalisajr"].ToString()),
                            Convert.ToString(row["cancela_coment_soporte"].ToString()), Convert.ToString(row["abasto_inicial"].ToString()));

                        //pr.insertarDatosEncabeza(Convert.ToInt32(row["n_remision"].ToString()), Convert.ToInt32(row["n_agente"].ToString()), row["nom_age"].ToString(),
                        //    Convert.ToDateTime(row["fecha_alta"].ToString()), Convert.ToString(row["cve_cte"].ToString()), Convert.ToString(row["nom_cte"].ToString()),
                        //    Convert.ToString(row["cve_prod"].ToString()), Convert.ToString(row["nom_prod"].ToString()), Convert.ToInt32(row["cant_prod"].ToString()),
                        //    Convert.ToInt32(row["precio_prod"].ToString()), Convert.ToInt32(row["dcto_prod"].ToString()), Convert.ToInt32(row["ieps"].ToString()),
                        //    Convert.ToInt32(row["iva"].ToString()), Convert.ToInt32(row["total_prod"].ToString()), Convert.ToInt32(row["moneda_prod"].ToString()),
                        //    Convert.ToInt32(row["cant_falta"].ToString()), Convert.ToInt32(row["AUTORIZADP"].ToString()), Convert.ToInt32(row["total_prodmxp"].ToString()),
                        //    Convert.ToInt32(row["TIPO_CAMBIO"].ToString()), Convert.ToInt32(row["precio_condcto"].ToString()), Convert.ToInt32(row["precio_politica"].ToString()),
                        //    Convert.ToString(row["comentario"].ToString()), Convert.ToString(row["estatus"].ToString()), Convert.ToString(row["bonificacion"].ToString()),
                        //    Convert.ToDateTime(row["fecha_autoriza"].ToString()), Convert.ToString(row["estatus2"].ToString()), Convert.ToString(row["n_factura"].ToString()),
                        //    Convert.ToString(row["comentario2"].ToString()), Convert.ToInt32(row["TERMINADA"].ToString()), Convert.ToString(row["motivo"].ToString()),
                        //    Convert.ToDateTime(row["f_cancela"].ToString()), Convert.ToDateTime(row["fecha_promesa"].ToString()), Convert.ToInt32(row["n_promotor"].ToString()),
                        //    Convert.ToString(row["nom_promotor"].ToString()), Convert.ToInt32(row["corte"].ToString()), Convert.ToDateTime(row["fechap_programa"].ToString()),
                        //    Convert.ToDateTime(row["fechap_real"].ToString()), Convert.ToString(row["sinfecha"].ToString()), Convert.ToInt32(row["notifica_p"].ToString()),
                        //    Convert.ToDateTime(row["fecha_autorizadc"].ToString()), Convert.ToString(row["litkg_unidad"].ToString()), Convert.ToInt32(row["fact_ds"].ToString()),
                        //    Convert.ToInt32(row["precio_representante"].ToString()), Convert.ToInt32(row["au_gerente"].ToString()), Convert.ToInt32(row["au_dc"].ToString()),
                        //    Convert.ToInt32(row["precio_pagar"].ToString()), Convert.ToInt32(row["precio_factura"].ToString()), Convert.ToInt32(row["total_factura"].ToString()),
                        //    Convert.ToInt32(row["bandera_especial"].ToString()), Convert.ToInt32(row["plazo_especial"].ToString()), Convert.ToInt32(row["boni_precioporunidad"].ToString()), Convert.ToInt32(row["boni_cantidadporunidad"].ToString()),
                        //    Convert.ToString(row["boni_productoid"].ToString()), Convert.ToInt32(row["boni_precioventa"].ToString()), Convert.ToInt32(row["boni_cantidadcalculo"].ToString()),
                        //    Convert.ToInt32(row["boni_estado"].ToString()), Convert.ToInt32(row["boni_costomp"].ToString()), Convert.ToInt32(row["boni_bonificadomp"].ToString()),
                        //    Convert.ToString(row["entrega"].ToString()), Convert.ToDateTime(row["fecha_autorizajefecomer"].ToString()), Convert.ToDateTime(row["fecha_autorizanalisajr"].ToString()),
                        //    Convert.ToString(row["cancela_coment_soporte"].ToString()));

                    }




                }

            }

        }


    }



}
