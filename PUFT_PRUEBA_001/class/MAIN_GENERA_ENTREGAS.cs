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
    class respuesta_entrega 
    {
        private Int64 _entrega;
        private Boolean _existe_entrega = false;

        public respuesta_entrega(Int64 ENTREGA , Boolean EXSITE)
        {
            this._entrega = ENTREGA;
            this._existe_entrega = EXSITE;
        }


        public Int64 NUEVA_ENTREGA
        { get => _entrega; }
        public Boolean EXISTE_ENTREGA
        { get => _existe_entrega; }
    }






    class MAIN_GENERA_ENTREGAS
    {
      private  DataTable TB_FACTURAS_A_GENERAR_ENTREGAS;
        private DataTable sap_FACTURA_PENDIENTE;

        public MAIN_GENERA_ENTREGAS ()
        {
            try
            {
                TB_FACTURAS_A_GENERAR_ENTREGAS = new DataTable();
                string connection =
                                  System.Configuration.ConfigurationManager.
                                  ConnectionStrings["PUFT_PRUEBA_001.Properties.Settings.VRS_SALESFORCE"].ConnectionString;
                using (SqlConnection CONECT = new SqlConnection(connection))
                {
                    CONECT.Open();
                    using (SqlCommand COMANDO = new SqlCommand("SP_PUFT_FACTURAS_PARA_GENERAR_ENTREGA", CONECT))


                    {
                        COMANDO.CommandType = CommandType.StoredProcedure;

                        TB_FACTURAS_A_GENERAR_ENTREGAS.Load(COMANDO.ExecuteReader());


                    }
                }
            }
            catch (Exception e)
            {
                // Get the current date.
                DateTime thisDay = DateTime.Today;
                // Display the date in the default (general) format.

                PUFT_ERRORS error = new PUFT_ERRORS("CLASSE MAIN_GENERA_ENTREGAS ", "ERROR EN GENERAR FACTURAS   Y ENTREGAS", e.ToString(), thisDay);

            }



           

        }
        public void  GET_PRODUCTOS_FACTURA(Int64 _FACTURA_SAP)
        {
             sap_FACTURA_PENDIENTE = new DataTable();
            try
            {
              

                try
                {
                    string connection =
                                  System.Configuration.ConfigurationManager.
                                  ConnectionStrings["PUFT_PRUEBA_001.Properties.Settings.VRS_SALESFORCE"].ConnectionString;
                    using (SqlConnection CONECT = new SqlConnection(connection))
                    {
                        CONECT.Open();
                        using (SqlCommand COMANDO = new SqlCommand("SP_PUFT_FACTURAS_PENDIENTES", CONECT))
                            {
                            COMANDO.CommandType = CommandType.StoredProcedure;
                            COMANDO.Parameters.Add("@FACTURA_SAP", SqlDbType.BigInt).Value = _FACTURA_SAP;
                            sap_FACTURA_PENDIENTE.Load(COMANDO.ExecuteReader());


                        }
                    }

                }
                catch (Exception e)
                {
                    // Get the current date.
                    DateTime thisDay = DateTime.Today;
                    // Display the date in the default (general) format.

                    PUFT_ERRORS error = new PUFT_ERRORS("CLASSE MAIN_GENERA_ENTREGAS ", "ERROR  EN NEW MAIN_GENERA_ENTREGAS SP SP_PUFT_FACTURAS_PENDIENTES", e.ToString(), thisDay);



                    sap_FACTURA_PENDIENTE = null;
                }
            }
            catch (Exception e)
            {

                // Get the current date.
                DateTime thisDay = DateTime.Today;
                // Display the date in the default (general) format.

                PUFT_ERRORS error = new PUFT_ERRORS("CLASSE MAIN_GENERA_ENTREGAS ", "ERROR  EN ", e.ToString(), thisDay);

                sap_FACTURA_PENDIENTE = null;
            }




           
        }
        public void GENERAR_ENTREGAS_CON_FACTURA()
        {
            if (TB_FACTURAS_A_GENERAR_ENTREGAS.Rows.Count > 0)
            {
                foreach (DataRow row in TB_FACTURAS_A_GENERAR_ENTREGAS.Rows)
                {
                    DataRow accion_row = row;

                    if (row["ID_PEDIDOS"] != null    )
                    {
                        var prueba = row["ORDEN_VENTA"].ToString();
                        Int64 sap_n_remision = row["n_remision"] is null ? 0 : Convert.ToInt64(row["n_remision"]);

                        respuesta_entrega resultado_entrega = GET_NEW_ENTREGA(Convert.ToInt32(row["ID_PEDIDOS"]), 888);
                        if (EXISTE_FACTURA_CREADA(resultado_entrega, Convert.ToInt64(row["n_factura"])) == false )
                        {

                            if (RECORRER_FACTURAS_PENDIENTES(resultado_entrega, Convert.ToInt64(row["n_factura"])))
                            {
                                //`SP_PUFT_GUARDAR_FOLIO_ENTREGA`(NEW_ENTREGA BIGINT, SAP_USUARIO INT)
                                if (GUARDAR_ENTREGA_CTRL(resultado_entrega, Convert.ToInt32(row["ID_PEDIDOS"])))
                                {

                                    // Get the current date.
                                    DateTime thisDay = DateTime.Today;
                                    // Display the date in the default (general) format.

                                    PUFT_ERRORS error = new PUFT_ERRORS("CORRECTO SE GENERO  ENTREGA:" + resultado_entrega.NUEVA_ENTREGA.ToString(), "CON ORDEN DE VENTA" + row["ORDEN_VENTA"].ToString(), "CORRECTO", thisDay);

                                    CONVERTIR_ENTREGA_A_FACTURA(resultado_entrega, Convert.ToInt64(row["n_factura"]));
                                }
                                else {


                                    ELIMINAR_ENTREGA_FALLIDA(resultado_entrega, Convert.ToInt64(row["n_factura"]), sap_n_remision);


                                }

                            }
                        }
                    }

                }



            }


        }
        public Boolean GUARDAR_ENTREGA_CTRL(respuesta_entrega resultado_entrega ,int  USU_LOGISTICA   )
        {
            Boolean   resulta =  false;
            try
            {
                string connection =
                              System.Configuration.ConfigurationManager.
                              ConnectionStrings["Server80"].ConnectionString;

                using (MySqlConnection coneccmys = new MySqlConnection(connection))
                {
                    coneccmys.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_PUFT_GUARDAR_FOLIO_ENTREGA", coneccmys))
                    {
                        try
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new MySqlParameter("NEW_ENTREGA", MySqlDbType.Int32)).Value = resultado_entrega.NUEVA_ENTREGA;
                            cmd.Parameters.Add(new MySqlParameter("SAP_USUARIO", MySqlDbType.Int32)).Value = USU_LOGISTICA;
                            DataTable dt_table = new DataTable();
                            MySqlDataAdapter APSTER = new MySqlDataAdapter(cmd);

                            APSTER.Fill(dt_table);
                            if (dt_table.Rows.Count > 0)
                            {
                                foreach (DataRow row in dt_table.Rows)
                                {
                                    if (Convert.ToInt32(row["CTRL_INSERT"]) == 8888)
                                    {
                                        // Get the current date.
                                        DateTime thisDay = DateTime.Today;
                                        // Display the date in the default (general) format.

                                        PUFT_ERRORS error = new PUFT_ERRORS("CLASSE MAIN_GENERA_ENTREGAS ", "SE CARGO CORRECTAMENTE ", resultado_entrega.NUEVA_ENTREGA.ToString(), thisDay);

                                        resulta = true;
                                    }
                                    else
                                    {
                                        // Get the current date.
                                        DateTime thisDay = DateTime.Today;
                                        // Display the date in the default (general) format.

                                        PUFT_ERRORS error = new PUFT_ERRORS("CLASSE MAIN_GENERA_ENTREGAS", "ERROR GUARDAR_ENTREGA_CTRL  EXISTE UN PROBLEMA PARA CARGAR ENTREGA", "NO SE GUARDO LA ENTREGA EN EL CONTROL DE ENTREGAS ", thisDay);


                                    }


                                }

                            }
                        }
                        catch (Exception e)
                        {
                            // Get the current date.
                            DateTime thisDay = DateTime.Today;
                            // Display the date in the default (general) format.

                            PUFT_ERRORS error = new PUFT_ERRORS("CLASSE MAIN_GENERA_ENTREGAS ", "ERROR  MAIN_GENERA_ENTREGAS ", e.ToString(), thisDay);


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

                PUFT_ERRORS error = new PUFT_ERRORS("CLASSE MAIN_GENERA_ENTREGAS ", "ERROR  NO SE  AGREGO  ENTREGA A LA TABLA DE CONTROL", resultado_entrega.NUEVA_ENTREGA.ToString() , thisDay);



            }




            return resulta;
        }


        public Boolean  RECORRER_FACTURAS_PENDIENTES(respuesta_entrega resultado_entrega , Int64 _facturas)
        {
            Boolean resultadoinser_prod = true;
            GET_PRODUCTOS_FACTURA(_facturas);
                DataTable TB_FACTURAS_PENDIENTES = this.sap_FACTURA_PENDIENTE ;
                if (TB_FACTURAS_PENDIENTES.Rows.Count > 0 && TB_FACTURAS_PENDIENTES != null)
                {




                    foreach (DataRow row in TB_FACTURAS_PENDIENTES.Rows)
                    {
                        try
                        {
                            DataRow accion_row = row;
                            if (row["ID_PEDIDOS"] != null)
                            {
                                var prueba = row["ORDEN_VENTA"].ToString();
                            
                            Int64  sap_n_remision = 0;
                           
                                sap_n_remision =Convert.ToInt64(row["n_remision"]);


                                ///VALIDAMOS QUE EXISTA LA  NUEVA ENTREGA
                                if (resultado_entrega.EXISTE_ENTREGA)
                                {

                                    ACCION_ENTREGAS_PRODUCTOS acc_entregas = new ACCION_ENTREGAS_PRODUCTOS(resultado_entrega, ref accion_row);

                                    if (acc_entregas.INSERT_ENTREGA() == false)
                                    {
                                        ELIMINAR_ENTREGA_FALLIDA(resultado_entrega, _facturas, sap_n_remision);
                                        resultadoinser_prod = false;

                                    }
                                }
                            
                            }

                        }
                        catch (Exception e)
                        {
                            resultadoinser_prod = false;
                            // Get the current date.
                            DateTime thisDay = DateTime.Today;
                            // Display the date in the default (general) format.

                            PUFT_ERRORS error = new PUFT_ERRORS("CLASSE MAIN_GENERA_ENTREGAS ", "ERROR  EN NEW RECORRER_FACTURAS_PENDIENTES  DENTRO DEL  RECORRIDO  DE ORDNES DE FACTRUAS  PENDIENTES", e.ToString(), thisDay);

                            break;

                        }

                    }





                }
            
           return  resultadoinser_prod;

        }



        public respuesta_entrega GET_NEW_ENTREGA(int ID_USUARIO_PEDIDOS ,int exis_agen)
        {
            Int64 new_ENTREGA = 0;
            Boolean EXISTE_ENTREGA = false;

            respuesta_entrega RESPUESTA = null;

            try
            {
                string connection =
                                    System.Configuration.ConfigurationManager.
                                    ConnectionStrings["Server80"].ConnectionString;

                using (MySqlConnection coneccmys = new MySqlConnection(connection))
                {
                    coneccmys.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_PUFT_NUEVO_FOLIO_ENTREGA", coneccmys))
                    {
                        try
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new MySqlParameter("logis_usu", MySqlDbType.Int32)).Value = ID_USUARIO_PEDIDOS;
                            cmd.Parameters.Add(new MySqlParameter("EXIS_AGENTE", MySqlDbType.Int32)).Value = exis_agen;
                            DataTable dt_table = new DataTable();
                            MySqlDataAdapter APSTER = new MySqlDataAdapter(cmd);

                            APSTER.Fill(dt_table);
                            if (dt_table.Rows.Count > 0)
                            {
                                foreach (DataRow row in dt_table.Rows)
                                {
                                    if (Convert.ToInt32(row["ESNULL_ENTREGA"]) != 0)
                                    {
                                        ///
                                        Int64 main_ctrl = Convert.ToInt64(row["NEW_ENTREGA"]);
                                        int EXISTE_TB = Convert.ToInt32(row["EXISTE_TB"]);
                                        int EXISTE_FIN_ENTREGA = Convert.ToInt32(row["EXISTE_FIN_ENTREGA"]);
                                        if (EXISTE_TB == 0 && EXISTE_FIN_ENTREGA == 0)
                                        {

                                            new_ENTREGA = Convert.ToInt64(row["NEW_ENTREGA"]);
                                            EXISTE_ENTREGA = true;

                                            RESPUESTA = new respuesta_entrega(new_ENTREGA, EXISTE_ENTREGA);
                                           


                                        }
                                        else
                                        {
                                            // Get the current date.
                                            DateTime thisDay = DateTime.Today;
                                            // Display the date in the default (general) format.

                                            PUFT_ERRORS error = new PUFT_ERRORS("CLASSE MAIN_GENERA_ENTREGAS ", "ERROR  GET_NEW_REMISION  NO SE  GENERO ENTREGA SE ENCONTRO DUPLICADO IMPOSIBLE GENERAR ENTREGA", "ID USUARIO" + ID_USUARIO_PEDIDOS, thisDay);



                                        }

                                    }
                                    else
                                    {
                                        // Get the current date.
                                        DateTime thisDay = DateTime.Today;
                                        // Display the date in the default (general) format.

                                        PUFT_ERRORS error = new PUFT_ERRORS("CLASSE MAIN_GENERA_ENTREGAS ", "ERROR  GET_NEW_REMISION ", "NO SE  GENERO ENTREGA  POR QUE SE  GENERO UNA ENTREGA NULL ", thisDay);


                                    }


                                }

                            }
                        }
                        catch (Exception e)
                        {
                            // Get the current date.
                            DateTime thisDay = DateTime.Today;
                            // Display the date in the default (general) format.

                            PUFT_ERRORS error = new PUFT_ERRORS("CLASSE MAIN_GENERA_ENTREGAS ", "ERROR  MAIN_GENERA_ENTREGAS ", e.ToString() , thisDay);


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

                PUFT_ERRORS error = new PUFT_ERRORS("CLASSE MAIN_ORDEN_VENTAS ", "ERROR  GET_NEW_REMISION", e.ToString(), thisDay);




            }




            return RESPUESTA; 

        }


        public Boolean EXISTE_FACTURA_CREADA(respuesta_entrega resultado_entrega, Int64  FACTURA )
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
                    using (MySqlCommand cmd = new MySqlCommand("SP_PUFT_EXISTE_FACTURASINENTREGAS", coneccmys))
                    {
                        try
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new MySqlParameter("NEW_ENTREGA", MySqlDbType.Int32)).Value = resultado_entrega.NUEVA_ENTREGA;
                            cmd.Parameters.Add(new MySqlParameter("NEW_FACTURA", MySqlDbType.Int32)).Value = FACTURA;
                            DataTable dt_table = new DataTable();
                            MySqlDataAdapter APSTER = new MySqlDataAdapter(cmd);

                            APSTER.Fill(dt_table);
                            if (dt_table.Rows.Count > 0)
                            {
                                foreach (DataRow row in dt_table.Rows)
                                {
                                    if (Convert.ToInt32(row["EXISTE_FACTURA"]) == 0)

                                    {
                                        // Get the current date.
                                        DateTime thisDay = DateTime.Today;
                                        // Display the date in the default (general) format.

                                        PUFT_ERRORS error = new PUFT_ERRORS("CLASSE MAIN_GENERA_ENTREGAS", "CORRECTO NO EXISTE  LA  SIGIENTE  FACTURA =" + FACTURA.ToString()+"  EN TABLA DE  ENTREGAS SE AGREGARA", "SE CARGA LA  FACTURA=" + FACTURA.ToString() + " CON LA ENTREGA=" + resultado_entrega.NUEVA_ENTREGA.ToString(), thisDay);


                                    }
                                    else
                                    {
                                        resulta = true ;
                                    }


                                }

                            }
                        }
                        catch (Exception e)
                        {
                            // Get the current date.
                            DateTime thisDay = DateTime.Today;
                            // Display the date in the default (general) format.

                            PUFT_ERRORS error = new PUFT_ERRORS("CLASSE MAIN_GENERA_ENTREGAS ", "ERROR  EXISTE_FACTURA_CREADA ", e.ToString(), thisDay);


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

                PUFT_ERRORS error = new PUFT_ERRORS("CLASSE MAIN_GENERA_ENTREGAS ", "ERROR  NO SE  AGREGO  ENTREGA A LA TABLA DE CONTROL", resultado_entrega.NUEVA_ENTREGA.ToString(), thisDay);



            }




            return resulta;
        }

        public Boolean   ELIMINAR_ENTREGA_FALLIDA (respuesta_entrega resultado_entrega, Int64 FACTURA , Int64  N_REMISION)
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
                    using (MySqlCommand cmd = new MySqlCommand("SP_PUFT_ELIMINAR_ENTREGA_FALLIDA", coneccmys))
                    {
                        try
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new MySqlParameter("NEW_ENTREGA", MySqlDbType.Int64)).Value = resultado_entrega.NUEVA_ENTREGA;
                            cmd.Parameters.Add(new MySqlParameter("SAP_FACTURA", MySqlDbType.Int64)).Value = FACTURA;
                            cmd.Parameters.Add(new MySqlParameter("CTRL_DELETE", MySqlDbType.String)).Value = "V3rs@";
                            cmd.Parameters.Add(new MySqlParameter("PLAT_REMISION", MySqlDbType.Int64)).Value = N_REMISION;
                            DataTable dt_table = new DataTable();
                            MySqlDataAdapter APSTER = new MySqlDataAdapter(cmd);

                            APSTER.Fill(dt_table);
                            if (dt_table.Rows.Count > 0)
                            {
                                foreach (DataRow row in dt_table.Rows)
                                {
                                    if (Convert.ToInt32(row["CTRLRESUL"]) == 8888)

                                    {
                                        resulta = true;
                                    }
                                    


                                }

                            }
                        }
                        catch (Exception e)
                        {
                            // Get the current date.
                            DateTime thisDay = DateTime.Today;
                            // Display the date in the default (general) format.

                            PUFT_ERRORS error = new PUFT_ERRORS("CLASSE MAIN_GENERA_ENTREGAS ", "NO REGRESAMOS LA  ENTREGA ", e.ToString(), thisDay);


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

                PUFT_ERRORS error = new PUFT_ERRORS("CLASSE MAIN_GENERA_ENTREGAS ", "ERROR  REGRESO LA ENTREGA DE LA TABLA", resultado_entrega.NUEVA_ENTREGA.ToString(), thisDay);



            }




            return resulta;
        }


        public void  CONVERTIR_ENTREGA_A_FACTURA(respuesta_entrega resultado_entrega, Int64 FACTURA)
        {
          
            try
            {
                string connection =
                              System.Configuration.ConfigurationManager.
                              ConnectionStrings["Server80"].ConnectionString;

                using (MySqlConnection coneccmys = new MySqlConnection(connection))
                {
                    coneccmys.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_INSERT_FACTURAS_PUFT", coneccmys))
                    {
                        try
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new MySqlParameter("ENTREGA", MySqlDbType.Int64)).Value = resultado_entrega.NUEVA_ENTREGA;
                            cmd.Parameters.Add(new MySqlParameter("FACTURA", MySqlDbType.Int64)).Value = FACTURA;
                            DataTable dt_table = new DataTable();
                            MySqlDataAdapter APSTER = new MySqlDataAdapter(cmd);

                            APSTER.Fill(dt_table);
                           
                        }
                        catch (Exception e)
                        {
                            // Get the current date.
                            DateTime thisDay = DateTime.Today;
                            // Display the date in the default (general) format.

                            PUFT_ERRORS error = new PUFT_ERRORS("CLASSE MAIN_GENERA_ENTREGAS ", "ERROR  GURADAR FACTURAS ", e.ToString(), thisDay);


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

                PUFT_ERRORS error = new PUFT_ERRORS("CLASSE MAIN_GENERA_ENTREGAS ", "ERROR NO CARGO  FACTURA", resultado_entrega.NUEVA_ENTREGA.ToString(), thisDay);



            }




          
        }


    }
}
