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
        private DataTable TB_FACTURAS_PENDIENTES;

        public MAIN_GENERA_ENTREGAS ()
        {
            try
            {
                TB_FACTURAS_PENDIENTES = new DataTable();

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

                            TB_FACTURAS_PENDIENTES.Load(COMANDO.ExecuteReader());


                        }
                    }

                }
                catch (Exception e)
                {
                    // Get the current date.
                    DateTime thisDay = DateTime.Today;
                    // Display the date in the default (general) format.

                    PUFT_ERRORS error = new PUFT_ERRORS("CLASSE MAIN_GENERA_ENTREGAS ", "ERROR  EN NEW MAIN_GENERA_ENTREGAS SP SP_PUFT_FACTURAS_PENDIENTES", e.ToString(), thisDay);



                    TB_FACTURAS_PENDIENTES = new DataTable();
                }
            }
            catch (Exception e)
            {

                // Get the current date.
                DateTime thisDay = DateTime.Today;
                // Display the date in the default (general) format.

                PUFT_ERRORS error = new PUFT_ERRORS("CLASSE MAIN_GENERA_ENTREGAS ", "ERROR  EN ", e.ToString(), thisDay);


            }



        }


        public void RECORRER_FACTURAS_PENDIENTES()
        {
            if (TB_FACTURAS_PENDIENTES.Rows.Count > 0)
            {

                foreach (DataRow row in TB_FACTURAS_PENDIENTES.Rows)
                {
                    try {
                        if (row["ID_PEDIDOS"] != null  )
                         {
                            var prueba = row["ORDEN_VENTA"].ToString();

                            respuesta_entrega resultado_entrega = GET_NEW_ENTREGA(Convert.ToInt32(row["ID_PEDIDOS"]), 888);
                            ///VALIDAMOS QUE EXISTA LA  NUEVA ENTREGA
                            if (resultado_entrega.EXISTE_ENTREGA)
                            {

                                ACCION_ENTREGAS_PRODUCTOS acc_entregas = new ACCION_ENTREGAS_PRODUCTOS(resultado_entrega, row);

                                acc_entregas.INSERT_ENTREGA();
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        // Get the current date.
                        DateTime thisDay = DateTime.Today;
                        // Display the date in the default (general) format.

                        PUFT_ERRORS error = new PUFT_ERRORS("CLASSE MAIN_GENERA_ENTREGAS ", "ERROR  EN NEW RECORRER_FACTURAS_PENDIENTES  DENTRO DEL  RECORRIDO  DE ORDNES DE FACTRUAS  PENDIENTES", e.ToString(), thisDay);



                    }

                }





            }
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




    }
}
