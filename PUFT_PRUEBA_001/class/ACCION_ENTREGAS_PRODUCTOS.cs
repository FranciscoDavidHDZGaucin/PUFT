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
                   Convert.ToDouble(PARTIDA_PRODUCTO_SAP["cant_falta"]),
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

            }
            catch (Exception e)
            {
                // Get the current date.
                DateTime thisDay = DateTime.Today;
                // Display the date in the default (general) format.

                PUFT_ERRORS error = new PUFT_ERRORS("CLASSE ACCION_ENTREGAS_PRODUCTOS ", "ERROR  EN INSERT_ENTREGA", e.ToString(), thisDay);



            }




        }



    }
}
