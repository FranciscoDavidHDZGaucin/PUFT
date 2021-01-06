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
                                      ConnectionStrings["PUFT_PRUEBA_001.Properties.Settings.VRS_SALESFORCE"].ConnectionString;
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
                        // Get the current date.
                        DateTime thisDay = DateTime.Today;
                        // Display the date in the default (general) format.
                    
                        PUFT_ERRORS error = new PUFT_ERRORS("CLASSE ACCION_PRODUCTOS_PEDIDOS ", "ERROR  EN NEW ACCION_PRODUCTOS_PEDIDOS CONSULATA", e.ToString(), thisDay); 
                    }


                }


            }
            catch (Exception e)
            {
                // Get the current date.
                DateTime thisDay = DateTime.Today;
                // Display the date in the default (general) format.
                PUFT_ERRORS error = new PUFT_ERRORS("CLASSE ACCION_PRODUCTOS_PEDIDOS ", "ERROR  EN NEW ACCION_PRODUCTOS_PEDIDOS TRY  PRINCIPAL ", e.ToString(), thisDay);

            }



            
        }

        public  Boolean   RECORRER_PRODUCTOS()
       {
            Boolean CTRL_PROD = true ; 

            if (_CONTROL_ORDEVENTA.CONTROL_MAIN)
            {
                if (tb_productos.Rows.Count > 0)
                {
                    foreach (DataRow row in tb_productos.Rows)
                    {
                        try
                        {
                            string  prueba = row["ORDENDE_VENTA"].ToString();
                            int  notifica_p = Convert.ToInt32(row["notifica_p"]);
                            string SALES = row["ID_SALESFORECE"].ToString();
                            int  LINENUM = Convert.ToInt32(row["LineNum"]);
                            //// METER KLA CLASE DE INSERTSIO DE   PRODUCTOS  
                            ///
                            var pr = new cmdsForm();
                            pr.insertarDatosDetalle(_CONTROL_ORDEVENTA.REMISION,
                                Convert.ToInt32(row["n_agente"]),
                                row["nom_age"].ToString(),
                                Convert.ToDateTime(row["fecha_alta"]),
                                row["cve_cte"].ToString(), 
                                row["nom_cte"].ToString(),
                                row["cve_prod"].ToString(),
                                row["nom_prod"].ToString(), 
                                Convert.ToInt32(row["cant_prod"]),
                                Convert.ToDouble(row["precio_prod"]),
                                Convert.ToDouble(row["dcto_prod"]),
                                Convert.ToDouble(row["ieps"]),
                                Convert.ToDouble(row["iva"]),
                                Convert.ToDouble(row["total_prod"]), 
                                Convert.ToInt32(row["moneda_prod"]),

                                Convert.ToDouble(row["cant_falta"]),
                                Convert.ToInt32(row["AUTORIZADP"]),
                                Convert.ToDouble(row["total_prodmxp"]),
                                Convert.ToDouble(row["TIPO_CAMBIO"]),
                                Convert.ToDouble(row["precio_condcto"]),
                                Convert.ToDouble(row["precio_politica"]),
                                row["comentario"].ToString(),
                                row["estatus"].ToString(),
                                row["bonificacion"].ToString(),
                                Convert.ToDateTime(row["fecha_autoriza"]),
                                row["estatus2"].ToString(),
                                row["n_factura"].ToString(),
                                row["comentario2"].ToString(),
                                Convert.ToInt32(row["TERMINADA"]),
                                 /// row["motivo"].ToString(),
                                 //Convert.ToDateTime(row["f_cancela"]),
                                // Convert.ToDateTime(row["fecha_promesa"]),
                                //Convert.ToInt32(row["n_promotor"]),
                                //row["nom_promotor"].ToString(),
                                Convert.ToInt32(row["corte"]),
                                //Convert.ToDateTime(row["fechap_programa"]),
                                //Convert.ToDateTime(row["fechap_real"]),
                                //row["sinfecha"].ToString(),
                                Convert.ToInt32(row["notifica_p"]),
                                //Convert.ToDateTime(row["fecha_autorizadc"]),
                                row["litkg_unidad"].ToString(),
                                Convert.ToDouble(row["fact_ds"]),
                                Convert.ToDouble(row["precio_representante"]),
                                Convert.ToInt32(row["au_gerente"]),
                                Convert.ToInt32(row["au_dc"]),
                                Convert.ToDouble(row["precio_pagar"]),
                                Convert.ToDouble(row["precio_factura"]),
                                Convert.ToDouble(row["total_factura"]),
                                Convert.ToInt32(row["bandera_especial"]),
                                //Convert.ToInt32(row["plazo_especial"]),
                                //Convert.ToDouble(row["boni_precioporunidad"]),
                                //Convert.ToDouble(row["boni_cantidadporunidad"]),
                                //row["boni_productoid"].ToString(),
                                //Convert.ToDouble(row["boni_precioventa"]),
                                //Convert.ToDouble(row["boni_cantidadcalculo"]),
                                //Convert.ToDouble(row["boni_estado"]),
                                //Convert.ToDouble(row["boni_costomp"]),
                                //Convert.ToDouble(row["boni_bonificadomp"]),
                                //row["entrega"].ToString(),
                                Convert.ToDateTime(row["fecha_autorizajefecomer"]),
                                Convert.ToDateTime(row["fecha_autorizanalisajr"]),
                                //row["cancela_coment_soporte"].ToString(),
                                //row["abasto_inicial"].ToString()  0Q0S0000000OJksKAG
                                row["ID_SALESFORECE"].ToString(),
                                 Convert.ToInt32(row["LineNum"])
                                );
                        }
                          catch (Exception e)
                        {
                            CTRL_PROD = false; 

                            var resultado = e.ToString();
                            // Get the current date.
                            DateTime thisDay = DateTime.Today;
                            // Display the date in the default (general) format.

                            PUFT_ERRORS error = new PUFT_ERRORS("CLASSE ACCION_PRODUCTOS_PEDIDOS ", "ERROR  EN RECORRER_PRODUCTOS DENTRO DEL FORE ", e.ToString(), thisDay);
                            break;
                        }
                        //pr.insertarDatosEncabeza(Convert.ToInt32(row["n_remision"].ToString()), Convert.ToInt32(row["fecha_alta"].ToString()), row["cve_cte"].ToString(),
                        //    Convert.ToDateTime(row["CardName"].ToString()), Convert.ToString(row["estatus"].ToString()), Convert.ToString(row["n_agente"].ToString()),
                        //    Convert.ToString(row["nom_age"].ToString()), Convert.ToString(row["comentario"].ToString()), Convert.ToInt32(row["moneda"].ToString()),
                        //    Convert.ToInt32(row["plazo"].ToString()), Convert.ToInt32(row["tipo_venta"].ToString()), Convert.ToInt32(row["toal"].ToString()),
                        //    Convert.ToInt32(row["medio_pago"].ToString()), Convert.ToInt32(row["cuenta"].ToString()), Convert.ToInt32(row["destino"].ToString()),
                        //    Convert.ToInt32(row["tipo_agente"].ToString()), Convert.ToInt32(row["total_p"].ToString()), Convert.ToInt32(row["vbo_gestor"].ToString()),
                        //    Convert.ToInt32(row["comentario_gestor"].ToString()), Convert.ToInt32(row["vbo_jefecyc"].ToString()), Convert.ToInt32(row["comentario_jefecyc"].ToString()),
                        //    Convert.ToString(row["timeres_gestor"].ToString()), Convert.ToString(row["timeres_jefecyc"].ToString()), Convert.ToString(row["vbo_gerente"].ToString()),
                        //    Convert.ToDateTime(row["comentario_gerente"].ToString()), Convert.ToString(row["timeres_gerente"].ToString()), Convert.ToString(row["altahora_pedido"].ToString()),
                        //    Convert.ToString(row["encbandera_especial"].ToString()), Convert.ToInt32(row["encbandera_especial"].ToString()), Convert.ToString(row["opCFDI"].ToString()),
                        //    Convert.ToDateTime(row["MTDPG"].ToString()), Convert.ToDateTime(row["TOTALENCABEZ"].ToString()), Convert.ToInt32(row["total"].ToString()),
                        //    Convert.ToString(row["VatSum"].ToString()), Convert.ToInt32(row["VatSumFC"].ToString()), Convert.ToDateTime(row["DocTotal"].ToString()),
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
            return CTRL_PROD;
        }


    }



}
