using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioReportePedidos
{
    class Class_ReportePedidos
    {


        public Boolean EjecutarPaso(EventLog eventLog)
        {
            bool EXITO = true ;
            ///--### PASO  0 #####
            try
            {
                string connection = "Data Source=192.168.101.05; Initial Catalog=pedidos;User Id=root; Password=avsa0543;SslMode=none;";

                using (MySqlConnection coneccmys = new MySqlConnection(connection))
                {
                    coneccmys.Open();
                    using (MySqlCommand cmd = new MySqlCommand("spREPRT_LOGIST_PEDIDOS_PASO0", coneccmys))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
       
                        DataTable dt_table = new DataTable();
                        MySqlDataAdapter APSTER = new MySqlDataAdapter(cmd);

                        APSTER.Fill(dt_table);
                        Class_ErroReload EROR = new Class_ErroReload("CORRECTO  spREPRT_LOGIST_PEDIDOS_PASO0 ", "EJECUCION PASO 00", "CORRECTO");
                        eventLog.WriteEntry("CORRECTO  spREPRT_LOGIST_PEDIDOS_PASO0 ");


                    }
                }
            }
            catch (Exception e)
            {
                // Get the current date.
                DateTime thisDay = DateTime.Today;
                // Display the date in the default (general) format.

                Class_ErroReload EROR = new Class_ErroReload("Error spREPRT_LOGIST_PEDIDOS_PASO0 ", "Class EjecutarPaso", e.ToString());
                eventLog.WriteEntry("Error spREPRT_LOGIST_PEDIDOS_PASO0 N#0001");
                EXITO = false;
            }
            ///--### PASO  1 #####
            if(EXITO)
            {
                try
                {
                    string connection = "Data Source=192.168.101.05; Initial Catalog=pedidos;User Id=root; Password=avsa0543;SslMode=none;";

                    using (MySqlConnection coneccmys = new MySqlConnection(connection))
                    {
                        coneccmys.Open();
                        using (MySqlCommand cmd = new MySqlCommand("spREPRT_LOGIST_PEDIDOS_PASO1", coneccmys))
                        {

                            cmd.CommandType = CommandType.StoredProcedure;


                            cmd.ExecuteReader(); 


                        }
                    }
                }
                catch (Exception e)
                {
                    // Get the current date.
                    DateTime thisDay = DateTime.Today;
                    // Display the date in the default (general) format.

                    Class_ErroReload EROR = new Class_ErroReload("Error spREPRT_LOGIST_PEDIDOS_PASO1 ", "Class EjecutarPaso", e.ToString());
                    eventLog.WriteEntry("Error spREPRT_LOGIST_PEDIDOS_PASO1 N#0001");
                    EXITO = false;
                }
            }
            ///--### PASO  2 #####
            if (EXITO)
            {
                try
                {
                    string connection = "Data Source=192.168.101.05; Initial Catalog=pedidos;User Id=root; Password=avsa0543;SslMode=none;";

                    using (MySqlConnection coneccmys = new MySqlConnection(connection))
                    {
                        coneccmys.Open();
                        using (MySqlCommand cmd = new MySqlCommand("spREPRT_LOGIST_PEDIDOS_PASO2", coneccmys))
                        {

                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.ExecuteReader();



                        }
                    }
                }
                catch (Exception e)
                {
                    // Get the current date.
                    DateTime thisDay = DateTime.Today;
                    // Display the date in the default (general) format.

                    Class_ErroReload EROR = new Class_ErroReload("Error spREPRT_LOGIST_PEDIDOS_PASO2 ", "Class EjecutarPaso", e.ToString());
                    eventLog.WriteEntry("Error spREPRT_LOGIST_PEDIDOS_PASO2 N#0002");
                    EXITO = false;
                }
            }
            ///--### PASO  3 #####
            if (EXITO)
            {
                try
                {
                    string connection = "Data Source=192.168.101.05; Initial Catalog=pedidos;User Id=root; Password=avsa0543;SslMode=none;";

                    using (MySqlConnection coneccmys = new MySqlConnection(connection))
                    {
                        coneccmys.Open();
                        using (MySqlCommand cmd = new MySqlCommand("spREPRT_LOGIST_PEDIDOS_PASO3", coneccmys))
                        {

                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.ExecuteReader();



                        }
                    }
                }
                catch (Exception e)
                {
                    // Get the current date.
                    DateTime thisDay = DateTime.Today;
                    // Display the date in the default (general) format.

                    Class_ErroReload EROR = new Class_ErroReload("Error spREPRT_LOGIST_PEDIDOS_PASO3 ", "Class EjecutarPaso", e.ToString());
                    eventLog.WriteEntry("Error spREPRT_LOGIST_PEDIDOS_PASO3 N#0003");
                    EXITO = false;
                }
            }
            ///--### PASO  4 #####
            if (EXITO)
            {
                try
                {
                    string connection = "Data Source=192.168.101.05; Initial Catalog=pedidos;User Id=root; Password=avsa0543;SslMode=none;";

                    using (MySqlConnection coneccmys = new MySqlConnection(connection))
                    {
                        coneccmys.Open();
                        using (MySqlCommand cmd = new MySqlCommand("spREPRT_LOGIST_PEDIDOS_PASO4", coneccmys))
                        {

                            cmd.CommandType = CommandType.StoredProcedure;


                            cmd.ExecuteReader();



                        }
                    }
                }
                catch (Exception e)
                {
                    // Get the current date.
                    DateTime thisDay = DateTime.Today;
                    // Display the date in the default (general) format.

                    Class_ErroReload EROR = new Class_ErroReload("Error spREPRT_LOGIST_PEDIDOS_PASO4 ", "Class EjecutarPaso", e.ToString());
                    eventLog.WriteEntry("Error spREPRT_LOGIST_PEDIDOS_PASO4 N#0004");
                    EXITO = false;
                }
            }

            return EXITO;
        }


    }
}
