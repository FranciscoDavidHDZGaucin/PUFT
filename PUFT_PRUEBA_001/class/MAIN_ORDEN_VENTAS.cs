using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUFT_PRUEBA_001
{
    class respuesta_remi
    {
        private Int64 _remision;
        private Boolean _existe_remi = false;

        public respuesta_remi(Int64 REMISION, Boolean EXSITE)
        {
            this._remision = REMISION;
            this._existe_remi = EXSITE;
        }


        public Int64 RESP_REMISION
        { get => _remision; }
        public Boolean REPS_ECISTE
        { get => _existe_remi; }
    }

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
                    string connection =
                                  System.Configuration.ConfigurationManager.
                                  ConnectionStrings["PUFT_PRUEBA_001.Properties.Settings.VRS_SALESFORCE"].ConnectionString;
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
                    // Get the current date.
                    DateTime thisDay = DateTime.Today;
                    // Display the date in the default (general) format.

                    PUFT_ERRORS error = new PUFT_ERRORS("CLASSE MAIN_ORDEN_VENTAS ", "ERROR  EN NEW MAIN_ORDEN_VENTAS SP SP_PUFT_ORDENDEVENTA_PENDIENTE", e.ToString(), thisDay);



                    TB_ORDVTS = new DataTable();
                }




            }
            catch (Exception e)
            {

                // Get the current date.
                DateTime thisDay = DateTime.Today;
                // Display the date in the default (general) format.

                PUFT_ERRORS error = new PUFT_ERRORS("CLASSE MAIN_ORDEN_VENTAS ", "ERROR  EN NEW MAIN_ORDEN_VENTAS SP SP_PUFT_ORDENDEVENTA_PENDIENTE", e.ToString(), thisDay);



            }







        }

        public void RECORRER_ORDEN_VENTAS()
        {


            if (TB_ORDVTS.Rows.Count > 0)
            {
                foreach (DataRow row in TB_ORDVTS.Rows)
                {
                    try
                    {
                        var prueba = row["ORDENDE_VENTA"].ToString();

                        GET_NEW_REMISION(Convert.ToInt32(row["n_agente"]), 888);

                        int ORDEN_VENTA = Convert.ToInt32(row["ORDENDE_VENTA"]);
                        int N_AGENTE = Convert.ToInt32(row["n_agente"]);
                        Boolean existe_ORDENVNETA = false;
                        Boolean exis_agnete = false;
                        int control_agente_new_remi = 0;
                        CTRL_OBJET NUEVA_REMISION = null;


                        if (ORDEN_VENTA == 13062 || ORDEN_VENTA == 13063)
                        {
                            if (ORDEN_VENTA > 0) { existe_ORDENVNETA = true; }
                            if (N_AGENTE > 0) { exis_agnete = true; control_agente_new_remi = 888; }

                            if (existe_ORDENVNETA == true && exis_agnete)
                            {
                                NUEVA_REMISION = GENERAR_CONTROL_OBJECTO(ORDEN_VENTA, N_AGENTE, exis_agnete, existe_ORDENVNETA, control_agente_new_remi);
                            }
                            ///*********** Esta permitido  Insertar 
                            if (ctrl_ESTA_PERMITIDO_INSERTAR(existe_ORDENVNETA, exis_agnete, NUEVA_REMISION))
                            {
                                try
                                {
                                    var pr = new cmdsForm();
                                    pr.insertarDatosEncabeza(NUEVA_REMISION.REMISION, Convert.ToDateTime(row["fecha_alta"]), row["cve_cte"].ToString(),
                                        Convert.ToString(row["CardName"]), Convert.ToString(row["estatus"]), Convert.ToInt32(row["n_agente"]),
                                        Convert.ToString(row["nom_age"]), Convert.ToString(row["comentario"]), Convert.ToInt32(row["moneda"]),
                                        Convert.ToInt32(row["plazo"]), Convert.ToInt32(row["tipo_venta"]), Convert.ToDouble(row["toal"]),
                                        Convert.ToString(row["medio_pago"]), Convert.ToString(row["destino"]),
                                        Convert.ToInt32(row["tipo_agente"]), Convert.ToDouble(row["total_p"]), Convert.ToInt32(row["vbo_gestor"]),
                                        Convert.ToString(row["comentario_gestor"]), Convert.ToInt32(row["vbo_jefecyc"].ToString()), Convert.ToString(row["comentario_jefecyc"]),
                                        Convert.ToDateTime(row["timeres_gestor"]), Convert.ToDateTime(row["timeres_jefecyc"]),
                                        Convert.ToString(row["comentario_gerente"]), Convert.ToDateTime(row["timeres_gerente"]),
                                        Convert.ToInt32(row["encbandera_especial"]), Convert.ToInt32(row["encbandera_especial"]), Convert.ToString(row["opCFDI"]),
                                        Convert.ToString(row["MTDPG"]), Convert.ToString(row["ID_SALESFORECE"]));

                                }
                                catch (Exception e)
                                {
                                    DateTime thisDay = DateTime.Today;
                                    // Display the date in the default (general) format.
                                    PUFT_ERRORS error = new PUFT_ERRORS("CLASSE RECORRER_ORDEN_VENTAS ", "ERROR  EN RECORRER_ORDEN_VENTAS Al validar datos para insertar Encabezado", e.ToString(), thisDay);
                                }



                                //ACCION_PRODUCTOS_PEDIDOS INSERT_PROD = new ACCION_PRODUCTOS_PEDIDOS(NUEVA_REMISION);
                                //            INSERT_PROD.RECORRER_PRODUCTOS();

                                ///***** REVISAR QUE SE CARGO EL PEDIDO
                                if (vALIDAR_NEW_PEDIDO(NUEVA_REMISION, N_AGENTE, Convert.ToString(row["ID_SALESFORECE"])))
                                { }

                            }
                        }



                    }
                    catch (Exception e)
                    {

                    }
                }




            }



        }
        public respuesta_remi GET_NEW_REMISION(int cve_agente, int exis_agen)
        {
            Int64 new_REMISION = 0;
            Boolean EXISTE_REMI = false;

            respuesta_remi RESPUESTA = null;

            try
            {
                string connection =
                                    System.Configuration.ConfigurationManager.
                                    ConnectionStrings["Server80"].ConnectionString;

                using (MySqlConnection coneccmys = new MySqlConnection(connection))
                {
                    coneccmys.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_FOLIO_PEDIDOS", coneccmys))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new MySqlParameter("agent_ventas", MySqlDbType.Int32)).Value = cve_agente;
                        cmd.Parameters.Add(new MySqlParameter("EXIS_AGENTE", MySqlDbType.Int32)).Value = exis_agen;
                        DataTable dt_table = new DataTable();
                        MySqlDataAdapter APSTER = new MySqlDataAdapter(cmd);

                        APSTER.Fill(dt_table);
                        if (dt_table.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt_table.Rows)
                            {

                                ///MAIN_PEDIDO EXIS_DETALLE  EXIS_ENCABEZA
                                int main_ctrl = Convert.ToInt32(row["MAIN_PEDIDO"]);
                                int encabeza_ctrl = Convert.ToInt32(row["EXIS_DETALLE"]);
                                int detalle_ctrl = Convert.ToInt32(row["EXIS_ENCABEZA"]);
                                if (main_ctrl == 0 && encabeza_ctrl == 0 && detalle_ctrl == 0)
                                {

                                    new_REMISION = Convert.ToInt32(row["REMISION"]);
                                    EXISTE_REMI = true;

                                    RESPUESTA = new respuesta_remi(new_REMISION, EXISTE_REMI);

                                }




                            }

                        }
                    }
                    coneccmys.Close();
                }



                return RESPUESTA;



            }
            catch (Exception e)
            {

                // Get the current date.
                DateTime thisDay = DateTime.Today;
                // Display the date in the default (general) format.

                PUFT_ERRORS error = new PUFT_ERRORS("CLASSE MAIN_ORDEN_VENTAS ", "ERROR  EN GET_NEW_REMISION ", e.ToString(), thisDay);


            }




            return RESPUESTA;

        }

        public CTRL_OBJET GENERAR_CONTROL_OBJECTO(int _ordenventa, int cve_agente, Boolean exis_agnete, Boolean existe_ORDENVNETA, int enter_cve_agente)
        {
            CTRL_OBJET ctrl = null;
            respuesta_remi rem_respuesta = null;

            try
            {
                if (exis_agnete == true && existe_ORDENVNETA == true)
                {


                    rem_respuesta = GET_NEW_REMISION(Convert.ToInt32(cve_agente), enter_cve_agente);
                    if (rem_respuesta.REPS_ECISTE)
                    {
                        ctrl = new CTRL_OBJET(_ordenventa, existe_ORDENVNETA, rem_respuesta.RESP_REMISION, rem_respuesta.REPS_ECISTE);

                        if (ctrl.CONTROL_MAIN)
                        {
                            return ctrl;

                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Get the current date.
                DateTime thisDay = DateTime.Today;
                // Display the date in the default (general) format.

                PUFT_ERRORS error = new PUFT_ERRORS("CLASSE MAIN_ORDEN_VENTAS ", "ERROR  EN GENERAR_CONTROL_OBJECTO ", e.ToString(), thisDay);


            }
            return ctrl;

        }


        public Boolean vALIDAR_NEW_PEDIDO(CTRL_OBJET CTRL, Int32 cve_agente, String id_salesforce)
        {
            Boolean RESP_VALIDA = false;

            try
            {

                string connection =
                                   System.Configuration.ConfigurationManager.
                                   ConnectionStrings["Server80"].ConnectionString;

                using (MySqlConnection coneccmys = new MySqlConnection(connection))
                {
                    coneccmys.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_PUFT_SE_CARGO_REMISION_NUEVA", coneccmys))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new MySqlParameter("_REMISION_MAIN", MySqlDbType.Int32)).Value = CTRL.REMISION;
                        cmd.Parameters.Add(new MySqlParameter("ordenventa", MySqlDbType.Int32)).Value = CTRL.ORD_VENTA;
                        cmd.Parameters.Add(new MySqlParameter("cve_agente", MySqlDbType.Int32)).Value = cve_agente;
                        cmd.Parameters.Add(new MySqlParameter("cve_agente", MySqlDbType.Text)).Value = id_salesforce;



                        DataTable dt_table = new DataTable();
                        MySqlDataAdapter APSTER = new MySqlDataAdapter(cmd);

                        APSTER.Fill(dt_table);
                        if (dt_table.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt_table.Rows)
                            {

                                ///MAIN_PEDIDO EXIS_DETALLE  EXIS_ENCABEZA
                                int main_ctrl = Convert.ToInt32(row["MAIN_PEDIDO"]);
                                int encabeza_ctrl = Convert.ToInt32(row["EXIS_DETALLE"]);
                                int detalle_ctrl = Convert.ToInt32(row["EXIS_ENCABEZA"]);
                                if (main_ctrl == 1 && encabeza_ctrl == 1 && detalle_ctrl == 1)
                                {

                                    RESP_VALIDA = true;


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

                PUFT_ERRORS error = new PUFT_ERRORS("CLASSE MAIN_ORDEN_VENTAS ", "ERROR  EN vALIDAR_NEW_PEDIDO ", e.ToString(), thisDay);


            }

            return RESP_VALIDA;
        }



        public Boolean ctrl_ESTA_PERMITIDO_INSERTAR(Boolean existe_ORDENVNETA, Boolean exis_agnete, CTRL_OBJET CTRL)
        {
            Boolean perInsert = false;

            if (existe_ORDENVNETA == true && exis_agnete == true && CTRL != null)
            {
                perInsert = true;
            }
            return perInsert;
        }
    }
}
