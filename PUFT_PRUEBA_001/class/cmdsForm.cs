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

        public bool insertarDatos() {
            conexion.Open();

            bool exito = false;
            try
            {
                MySqlCommand command = new MySqlCommand("SP_INSERT_DT_PEDIDOS", conexion);
                command.Connection = conexion;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("n_remision", 123123);
                command.Parameters.AddWithValue("n_agente", 0);
                command.Parameters.AddWithValue("nom_age", "fdsgsgsd");
                command.Parameters.AddWithValue("fecha_alta", "fdsgsgsd");
                command.Parameters.AddWithValue("cve_cte", "fdsgsgsd");
                command.Parameters.AddWithValue("nom_cte", "fdsgsgsd");
                command.Parameters.AddWithValue("cve_prod", "fdsgsgsd");
                command.Parameters.AddWithValue("nom_prod", "fdsgsgsd");
                command.Parameters.AddWithValue("cant_prod", 123);
                command.Parameters.AddWithValue("precio_prod", 123);
                command.Parameters.AddWithValue("dcto_prod", 123);
                command.Parameters.AddWithValue("ieps", 12);
                command.Parameters.AddWithValue("iva", 16);
                command.Parameters.AddWithValue("total_prod", 123);
                command.Parameters.AddWithValue("moneda_prod", 1);
                command.Parameters.AddWithValue("cant_falta", 12);
                command.Parameters.AddWithValue("autorizado", 1);
                command.Parameters.AddWithValue("total_prodmxp", 123);
                command.Parameters.AddWithValue("tipo_cambio", 123);
                command.Parameters.AddWithValue("precio_condcto", 123);
                command.Parameters.AddWithValue("precio_politica", 123);
                command.Parameters.AddWithValue("comentario", "fdsgsgsd");
                command.Parameters.AddWithValue("estatus", "s");
                command.Parameters.AddWithValue("bonificacion", "s");
                command.Parameters.AddWithValue("fecha_autoriza", "2020-12-02");
                command.Parameters.AddWithValue("estatus2", "s");
                command.Parameters.AddWithValue("n_factura", "1234");
                command.Parameters.AddWithValue("comentario2", "fdsgsgsd");
                command.Parameters.AddWithValue("terminada", 123);
                command.Parameters.AddWithValue("motivo", "fdsgsgsd");
                command.Parameters.AddWithValue("f_cancela", "2020-12-02");
                command.Parameters.AddWithValue("fecha_promesa", "2020-12-02");
                command.Parameters.AddWithValue("n_promotor", 123);
                command.Parameters.AddWithValue("nom_promotor", "fdsgsgsd");
                command.Parameters.AddWithValue("corte", 123);
                command.Parameters.AddWithValue("fechap_programa", "2020-12-02");
                command.Parameters.AddWithValue("fechap_real", "2020-12-02");
                command.Parameters.AddWithValue("sinfecha", "no");
                command.Parameters.AddWithValue("notifica_p", 123);
                command.Parameters.AddWithValue("fecha_autorizadc", "2020-12-02");
                command.Parameters.AddWithValue("litkg_unidad", "fdsgsgsd");
                command.Parameters.AddWithValue("fact_ds", 123);
                command.Parameters.AddWithValue("precio_representante", 123);
                command.Parameters.AddWithValue("au_gerente", 1);
                command.Parameters.AddWithValue("au_dc", 1);
                command.Parameters.AddWithValue("precio_pagar", 123);
                command.Parameters.AddWithValue("precio_factura", 123);
                command.Parameters.AddWithValue("total_factura", 123);
                command.Parameters.AddWithValue("bandera_especial", 1);
                command.Parameters.AddWithValue("plazo_especial", 2);
                command.Parameters.AddWithValue("boni_precioporunidad", 123);
                command.Parameters.AddWithValue("boni_cantidadporunidad", 123);
                command.Parameters.AddWithValue("boni_productoid", "123");
                command.Parameters.AddWithValue("boni_precioventa", 123);
                command.Parameters.AddWithValue("boni_cantidadcalculo", 4789654134);
                command.Parameters.AddWithValue("boni_estado", 123);
                command.Parameters.AddWithValue("boni_costomp", 123);
                command.Parameters.AddWithValue("boni_bonificadomp", "fdsgsgsd");
                command.Parameters.AddWithValue("entrega", "fdsgsgsd");
                command.Parameters.AddWithValue("fecha_autorizajefecomer", "2020-12-02");
                command.Parameters.AddWithValue("fecha_autorizanalisajr", "2020-12-02");
                command.Parameters.AddWithValue("cancela_coment_soporte", "fdsgsgsd");
                command.Parameters.AddWithValue("abasto_inicial", "fdsgsgsd");
                
                if (command.ExecuteNonQuery() == 1)
                {
                    exito = true;
                }
            }
            catch (MySqlException e)
            {
                exito = false;
            }
            finally
            {
                conexion.Close();
            }
           
            
            return exito;
        }

}
}
