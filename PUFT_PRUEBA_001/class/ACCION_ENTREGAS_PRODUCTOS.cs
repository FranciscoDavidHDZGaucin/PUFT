using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUFT_PRUEBA_001
{
    class ACCION_ENTREGAS_PRODUCTOS
    {
        respuesta_entrega NUEVA_ENTREGA;
        DataRow PARTIDA_PRODUCTO_SAP;
        DataRow PARTIDA_CRONOS; 





        public ACCION_ENTREGAS_PRODUCTOS(respuesta_entrega _NUEVA_ENTREGA  ,ref  DataRow _PARTIDA_PRODUCTO)
        {
            this.NUEVA_ENTREGA = _NUEVA_ENTREGA;
            this.PARTIDA_PRODUCTO_SAP = _PARTIDA_PRODUCTO;
            GET_PARTIDA_CRONOS();


        }
        public void GET_PARTIDA_CRONOS()
        {
            try
            {
                string connection =
                                   System.Configuration.ConfigurationManager.
                                   ConnectionStrings["Server80"].ConnectionString;

                using (MySqlConnection coneccmys = new MySqlConnection(connection))
                {
                    coneccmys.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_PUFT_GET_PRODUCTOS_PEDIDOS", coneccmys))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new MySqlParameter("SAP_REMISION", MySqlDbType.Int64)).Value = Convert.ToInt64( this.PARTIDA_PRODUCTO_SAP["n_remision"]);
                        cmd.Parameters.Add(new MySqlParameter("ENTREGA_NUEVO", MySqlDbType.Int64)).Value = NUEVA_ENTREGA.NUEVA_ENTREGA;
                        cmd.Parameters.Add(new MySqlParameter("SAP_ORDEN_VENTA", MySqlDbType.Int32)).Value = Convert.ToInt64(this.PARTIDA_PRODUCTO_SAP["ORDEN_VENTA"]);
                        cmd.Parameters.Add(new MySqlParameter("LINE_NUM", MySqlDbType.Int32)).Value = Convert.ToInt32(this.PARTIDA_PRODUCTO_SAP["LineNum"]);
                        cmd.Parameters.Add(new MySqlParameter("SAP_CVE_PRODUCTO", MySqlDbType.VarChar)).Value = this.PARTIDA_PRODUCTO_SAP["cve_prod"].ToString();
                        DataTable PARTIDA_PRODUCTO_CRONOS = new DataTable(); 
                         MySqlDataAdapter APSTER = new MySqlDataAdapter(cmd);

                        APSTER.Fill(PARTIDA_PRODUCTO_CRONOS);

                        PARTIDA_CRONOS = PARTIDA_PRODUCTO_CRONOS.Rows[0];

                    }
                    coneccmys.Close();
                }


             }
            catch (Exception e)
            {
                // Get the current date.
                DateTime thisDay = DateTime.Today;
                // Display the date in the default (general) format.

                PUFT_ERRORS error = new PUFT_ERRORS("CLASSE ACCION_ENTREGAS_PRODUCTOS ", "ERROR NOSE  PUDO OBTENER  LA PARTIDA DEL  PRODUCTO", e.ToString(), thisDay);


            }


        }

        public void INSERT_ENTREGA()
        {
            try
            {
                         

                double sap_cant_prod = 0;
                double sap_cant_original = 0;

                var id_detalle = Convert.ToInt64(PARTIDA_CRONOS["id_detalle"]);
                   Convert.ToInt64(PARTIDA_PRODUCTO_SAP["n_remision"]);
                   Convert.ToInt32(PARTIDA_PRODUCTO_SAP["n_agente"]);
                   PARTIDA_PRODUCTO_SAP["nom_age"].ToString();
                   Convert.ToDateTime(PARTIDA_PRODUCTO_SAP["fecha_alta"]);
                   PARTIDA_PRODUCTO_SAP["cve_cte"].ToString();
                   PARTIDA_PRODUCTO_SAP["CardName"].ToString();
                   PARTIDA_PRODUCTO_SAP["cve_prod"].ToString();
                   PARTIDA_PRODUCTO_SAP["nom_prod"].ToString();
                  
                   Convert.ToDouble(PARTIDA_PRODUCTO_SAP["precio_prod"]);
                   Convert.ToDouble(PARTIDA_PRODUCTO_SAP["dcto_prod"]);
                   Convert.ToDouble(PARTIDA_PRODUCTO_SAP["ieps"]);
                   Convert.ToDouble(PARTIDA_PRODUCTO_SAP["iva"]);
                   Convert.ToDouble(PARTIDA_PRODUCTO_SAP["total_prod"]);
                   Convert.ToInt32(PARTIDA_PRODUCTO_SAP["moneda"]);
                   Convert.ToDouble(PARTIDA_PRODUCTO_SAP["cant_falta"]);
                   Convert.ToDouble(PARTIDA_PRODUCTO_SAP["tipo_cambio"]);
                   Convert.ToDouble(PARTIDA_PRODUCTO_SAP["precio_condcto"]);
                   Convert.ToDouble(PARTIDA_PRODUCTO_SAP["precio_politica"]);
                    PARTIDA_PRODUCTO_SAP["bonificacion"].ToString();
                   Convert.ToDateTime(PARTIDA_PRODUCTO_SAP["fecha_factura"]);

                    Convert.ToInt64(PARTIDA_PRODUCTO_SAP["n_factura"]);
                    PARTIDA_PRODUCTO_SAP["condiciones"].ToString();
                   PARTIDA_PRODUCTO_SAP["comentariof"].ToString();
                   PARTIDA_PRODUCTO_SAP["comentariol"].ToString();

                   PARTIDA_PRODUCTO_SAP["WhsCode"].ToString();
                   PARTIDA_PRODUCTO_SAP["WhsName"].ToString();
                   PARTIDA_PRODUCTO_SAP["block"].ToString();
                   PARTIDA_PRODUCTO_SAP["City"].ToString();
                   PARTIDA_PRODUCTO_SAP["State"].ToString();
                 var ebte =   NUEVA_ENTREGA.NUEVA_ENTREGA;
                    Convert.ToInt32(PARTIDA_PRODUCTO_SAP["indica_entrega"]);
                var ebte00 = 0; //Convert.ToInt64(PARTIDA_CRONOS["id_pedido"]);
                Convert.ToInt32(PARTIDA_PRODUCTO_SAP["LineNum"]);



                PROD_QUATITY  CANTIDA_CALCULADA =    CALCULO_CANTIDADES_DE_ENTREGA( ref  PARTIDA_CRONOS, ref PARTIDA_PRODUCTO_SAP);
                sap_cant_prod = CANTIDA_CALCULADA.CANTIDAD_SOLICITADA_FACTURA_SAP;
                sap_cant_original = Convert.ToInt64(PARTIDA_CRONOS["cant_prod"]);




                var pr = new cmdsForm();
                pr.insertarDatosEntrega(
                   Convert.ToInt64(PARTIDA_CRONOS["id_detalle"]),
                   Convert.ToInt64(PARTIDA_PRODUCTO_SAP["n_remision"]),
                   Convert.ToInt32(PARTIDA_PRODUCTO_SAP["n_agente"]),
                   PARTIDA_PRODUCTO_SAP["nom_age"].ToString(),
                   Convert.ToDateTime(PARTIDA_PRODUCTO_SAP["fecha_alta"]),
                   PARTIDA_PRODUCTO_SAP["cve_cte"].ToString(),
                   PARTIDA_PRODUCTO_SAP["CardName"].ToString(),
                   PARTIDA_PRODUCTO_SAP["cve_prod"].ToString(),
                   PARTIDA_PRODUCTO_SAP["nom_prod"].ToString(),
                   sap_cant_prod,
                   sap_cant_original,
                   Convert.ToDouble(PARTIDA_PRODUCTO_SAP["precio_prod"]),
                   Convert.ToDouble(PARTIDA_PRODUCTO_SAP["dcto_prod"]),
                   Convert.ToDouble(PARTIDA_PRODUCTO_SAP["ieps"]),
                   Convert.ToDouble(PARTIDA_PRODUCTO_SAP["iva"]),
                   Convert.ToDouble(PARTIDA_PRODUCTO_SAP["total_prod"]),
                   Convert.ToInt32(PARTIDA_PRODUCTO_SAP["moneda"]),
                   CANTIDA_CALCULADA.CANTIDAD_FALTANTE_MAIN, // PARTIDA_PRODUCTO_SAP["cant_falta"]
                   Convert.ToDouble(PARTIDA_PRODUCTO_SAP["tipo_cambio"]),
                   Convert.ToDouble(PARTIDA_PRODUCTO_SAP["precio_condcto"]),
                   Convert.ToDouble(PARTIDA_PRODUCTO_SAP["precio_politica"]),
                    PARTIDA_PRODUCTO_SAP["bonificacion"].ToString(),
                   Convert.ToDateTime(PARTIDA_PRODUCTO_SAP["fecha_factura"]),

                    Convert.ToInt64(PARTIDA_PRODUCTO_SAP["n_factura"]),
                    PARTIDA_PRODUCTO_SAP["condiciones"].ToString(),
                   PARTIDA_PRODUCTO_SAP["comentariof"].ToString(),
                   PARTIDA_PRODUCTO_SAP["comentariol"].ToString(),

                   PARTIDA_PRODUCTO_SAP["WhsCode"].ToString(),
                   PARTIDA_PRODUCTO_SAP["WhsName"].ToString(),
                   PARTIDA_PRODUCTO_SAP["block"].ToString(),
                   PARTIDA_PRODUCTO_SAP["City"].ToString(),
                   PARTIDA_PRODUCTO_SAP["State"].ToString(),
                    NUEVA_ENTREGA.NUEVA_ENTREGA,
                    Convert.ToInt32(PARTIDA_PRODUCTO_SAP["indica_entrega"]),
                   0, //Convert.ToInt64(PARTIDA_CRONOS["id_pedido"]),
                    PARTIDA_PRODUCTO_SAP["ID_SALESFORECE"].ToString(),
                    Convert.ToInt32(PARTIDA_PRODUCTO_SAP["LineNum"])
                    );


                CANTIDA_CALCULADA.MODIFICAR_CANTIDADES_DETALLE_PEDIDO(Convert.ToInt64(PARTIDA_CRONOS["id_detalle"]), NUEVA_ENTREGA.NUEVA_ENTREGA);



            }
            catch (Exception e)
            {
                // Get the current date.
                DateTime thisDay = DateTime.Today;
                // Display the date in the default (general) format.

                PUFT_ERRORS error = new PUFT_ERRORS("CLASSE ACCION_ENTREGAS_PRODUCTOS ", "ERROR  EN INSERT_ENTREGA", e.ToString(), thisDay);



            }




        }

        public PROD_QUATITY  CALCULO_CANTIDADES_DE_ENTREGA( ref DataRow detalle_pedido , ref DataRow sap_factura)
        {

            PROD_QUATITY resultado; 
            Int64 CAN_SOLIC_FACTURA = Convert.ToInt64(sap_factura["cant_prod"]);
            Int64 CANTIDAD_FALTANTE = 0;
            Double TOTAL_PROD = 0; 
            if (Convert.ToInt64(detalle_pedido["cant_prod"]) == Convert.ToInt64(detalle_pedido["cant_falta"]))
            {
                CANTIDAD_FALTANTE = Convert.ToInt64(detalle_pedido["cant_prod"]) - CAN_SOLIC_FACTURA;


            }
            else
            {
                CANTIDAD_FALTANTE = Convert.ToInt64(detalle_pedido["cant_falta"]) - CAN_SOLIC_FACTURA;


            }

            return resultado = new PROD_QUATITY(CAN_SOLIC_FACTURA, CANTIDAD_FALTANTE);




        }


    }

    class PROD_QUATITY
    {
        private    Int64 CAN_SOLIC_FACTURA ;
        private Int64 CANTIDAD_FALTANTE = 0;
       

        public PROD_QUATITY( Int64 sap_CAN_SOLIC_FACTURA,  Int64 main_CANTIDAD_FALTANTE  )
        {
            this.CAN_SOLIC_FACTURA = sap_CAN_SOLIC_FACTURA;
            this.CANTIDAD_FALTANTE = main_CANTIDAD_FALTANTE; 
         }


        public Boolean MODIFICAR_CANTIDADES_DETALLE_PEDIDO(Int64 CTRL_ID_DETALLE , Int64 NEW_EMNTREGA )
        {

            Boolean resulta = false;

            try
            {
                string connection =
                                   System.Configuration.ConfigurationManager.
                                   ConnectionStrings["Server80"].ConnectionString;

                using (MySqlConnection coneccmys = new MySqlConnection(connection))
                {
                    coneccmys.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_PUFT_UPDATE_DETALLE_PEDIDO_CANFALTANTE_ESTATUS", coneccmys))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new MySqlParameter("CTRL_ID_DETALLE", MySqlDbType.Int64)).Value = CTRL_ID_DETALLE ;
                        cmd.Parameters.Add(new MySqlParameter("NEW_EMNTREGA", MySqlDbType.Int64)).Value = NEW_EMNTREGA ;
                        cmd.Parameters.Add(new MySqlParameter("MAIN_CANTIDAD_FALTANTE", MySqlDbType.Int32)).Value = this.CANTIDAD_FALTANTE;
                      
                        DataTable PARTIDA_PRODUCTO_CRONOS = new DataTable();
                        MySqlDataAdapter APSTER = new MySqlDataAdapter(cmd);

                        APSTER.Fill(PARTIDA_PRODUCTO_CRONOS);
                        if (PARTIDA_PRODUCTO_CRONOS.Rows.Count > 0)
                        {
                            foreach (DataRow row in PARTIDA_PRODUCTO_CRONOS.Rows)
                            {
                                if (Convert.ToInt32(row["CORRECT_CTRL"]) == 8888)
                                {
                                    resulta = true;

                                }
                                

                            }

                        }


                    }
                    coneccmys.Close();
                }


            }
            catch (Exception e)
            {
                // Get the current date.
                DateTime thisDay = DateTime.Today;
                // Display the date in the default (general) format.

                PUFT_ERRORS error = new PUFT_ERRORS("CLASSE PROD_QUATITY ", "ERROR MODIFICAR_CANTIDADES_DETALLE_PEDIDO", e.ToString(), thisDay);


            }

            return resulta;
        }



        public Int64 CANTIDAD_SOLICITADA_FACTURA_SAP { get => CAN_SOLIC_FACTURA; }
        public Int64 CANTIDAD_FALTANTE_MAIN { get => CANTIDAD_FALTANTE; }

    }




}
