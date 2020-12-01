using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace PUFT_PRUEBA_001
{
    class cmdsForm { 

    private string connection = string.Empty;
    MySqlConnection conexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["Server80"].ConnectionString);
        private MySqlCommand cmd;
        private MySqlCommandBuilder cmbuilder;
        private MySqlDataAdapter da;
        private DataSet ds;
        private DataTable dt;

        public bool Conectar()
        {
            bool conectado = false;
            try
            {
                conexion.Open();
                conectado = true;
            }
            catch(MySqlException e)
            {
                conectado = false;
            }
            finally
            {
                conexion.Close();
            }
            return conectado;
        }
}
}
