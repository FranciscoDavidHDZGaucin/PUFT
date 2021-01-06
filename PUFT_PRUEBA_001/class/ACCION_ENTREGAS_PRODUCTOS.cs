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
                var pr = new cmdsForm();

                var cro_id_detalle  = PARTIDA_CRONOS["id_detalle"];
                var sap_n_remision = PARTIDA_PRODUCTO_SAP["n_remision"]; 
                var sap_n_agente = PARTIDA_PRODUCTO_SAP["n_agente"];
                var sap_nom_age = PARTIDA_PRODUCTO_SAP["nom_age"];
                var sap_fecha_alta = PARTIDA_PRODUCTO_SAP["fecha_alta"];

                var sap_cve_cte = PARTIDA_PRODUCTO_SAP["cve_cte"];
                var sap_CardName = PARTIDA_PRODUCTO_SAP["CardName"];
                var sap_cve_prod = PARTIDA_PRODUCTO_SAP["cve_prod"];
                var sap_nom_prod = PARTIDA_PRODUCTO_SAP["nom_prod"];


                var sap_cant_prod = 0;
                var sap_cant_original = 0;

                var sap_precio_prod = PARTIDA_PRODUCTO_SAP["precio_prod"];
                var sap_dcto_prod = PARTIDA_PRODUCTO_SAP["dcto_prod"];

                var sap_ieps = PARTIDA_PRODUCTO_SAP["ieps"];
                var sap_iva = PARTIDA_PRODUCTO_SAP["iva"];


                var sap_total_prod = PARTIDA_PRODUCTO_SAP["total_prod"];
                var sap_moneda = PARTIDA_PRODUCTO_SAP["moneda"];
                var sap_cant_falta= PARTIDA_PRODUCTO_SAP["cant_falta"];
                var sap_tipo_cambio = PARTIDA_PRODUCTO_SAP["tipo_cambio"];
                var sap_precio_condcto = PARTIDA_PRODUCTO_SAP["precio_condcto"];
                var sap_precio_politica = PARTIDA_PRODUCTO_SAP["precio_politica"];


                var sap_bonificacion = PARTIDA_PRODUCTO_SAP["bonificacion"];
                var sap_fecha_factura = PARTIDA_PRODUCTO_SAP["fecha_factura"];


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
