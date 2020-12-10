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


        public bool PUFT_InsertDatosDetalle(DataRow RENGLON,CTRL_OBJET CTRLVENTA)
        {
           var REMISION  =  Convert.ToInt32(CTRLVENTA.REMISION);
           var AGENTE  = Convert.ToInt32(RENGLON["n_agente"]);



            return true;
        }




        public bool insertarDatosDetalle(Int64 n_remision, int n_agente,string nom_age,DateTime fecha_alta, string cve_cte, string nom_cte, string cve_prod, string nom_prod,double cant_prod, double precio_prod, double dcto_prod, double ieps, double iva, double total_prod, int moneda_prod, double cant_falta
, int autorizado, double total_prodmxp, double tipo_cambio, double precio_condcto, double precio_politica, string comentario, string estatus, string bonificacion, DateTime fecha_autoriza, string estatus2, string n_factura, string comentario2, int terminada, string motivo, DateTime f_cancela
, DateTime fecha_promesa, int n_promotor, string nom_promotor, int corte, DateTime fechap_programa, DateTime fechap_real, string sinfecha, int notifica_p, DateTime fecha_autorizadc, string litkg_unidad, double fact_ds, double precio_representante, int au_gerente, int au_dc, double precio_pagar, double precio_factura
, double total_factura, int bandera_especial, int plazo_especial, double boni_precioporunidad, double boni_cantidadporunidad,string boni_productoid, double boni_precioventa, double boni_cantidadcalculo, double boni_estado, double boni_costomp, double boni_bonificadomp
, string entrega, DateTime fecha_autorizajefecomer, DateTime fecha_autorizanalisajr, string cancela_coment_soporte, string abasto_inicial) {
           

            bool exito = false;
            try
            {
                conexion.Open();
                MySqlCommand command = new MySqlCommand("SP_INSERT_DT_PEDIDOS", conexion);
                command.Connection = conexion;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("n_remision", n_remision);
                command.Parameters.AddWithValue("n_agente", n_agente);
                command.Parameters.AddWithValue("nom_age", nom_age);
                command.Parameters.AddWithValue("fecha_alta", fecha_alta);
                command.Parameters.AddWithValue("cve_cte", cve_cte);
                command.Parameters.AddWithValue("nom_cte", nom_cte);
                command.Parameters.AddWithValue("cve_prod", cve_prod);
                command.Parameters.AddWithValue("nom_prod", nom_prod);
                command.Parameters.AddWithValue("cant_prod", cant_prod);
                command.Parameters.AddWithValue("precio_prod", precio_prod);
                command.Parameters.AddWithValue("dcto_prod", dcto_prod);
                command.Parameters.AddWithValue("ieps", ieps);
                command.Parameters.AddWithValue("iva", iva);
                command.Parameters.AddWithValue("total_prod", total_prod);
                command.Parameters.AddWithValue("moneda_prod", moneda_prod);
                command.Parameters.AddWithValue("cant_falta", cant_falta);
                command.Parameters.AddWithValue("autorizado", autorizado);
                command.Parameters.AddWithValue("total_prodmxp", total_prodmxp);
                command.Parameters.AddWithValue("tipo_cambio", tipo_cambio);
                command.Parameters.AddWithValue("precio_condcto", precio_condcto);
                command.Parameters.AddWithValue("precio_politica", precio_politica);
                command.Parameters.AddWithValue("comentario", comentario);
                command.Parameters.AddWithValue("estatus", estatus);
                command.Parameters.AddWithValue("bonificacion", bonificacion);
                command.Parameters.AddWithValue("fecha_autoriza", fecha_autoriza);
                command.Parameters.AddWithValue("estatus2", estatus2);
                command.Parameters.AddWithValue("n_factura", n_factura);
                command.Parameters.AddWithValue("comentario2", comentario2);
                command.Parameters.AddWithValue("terminada", terminada);
                command.Parameters.AddWithValue("motivo", motivo);
                command.Parameters.AddWithValue("f_cancela", f_cancela);
                command.Parameters.AddWithValue("fecha_promesa", fecha_promesa);
                command.Parameters.AddWithValue("n_promotor", n_promotor);
                command.Parameters.AddWithValue("nom_promotor", nom_promotor);
                command.Parameters.AddWithValue("corte", corte);
                command.Parameters.AddWithValue("fechap_programa", fechap_programa);
                command.Parameters.AddWithValue("fechap_real", fechap_real);
                command.Parameters.AddWithValue("sinfecha", sinfecha);
                command.Parameters.AddWithValue("notifica_p", notifica_p);
                command.Parameters.AddWithValue("fecha_autorizadc", fecha_autorizadc);
                command.Parameters.AddWithValue("litkg_unidad", litkg_unidad);
                command.Parameters.AddWithValue("fact_ds", fact_ds);
                command.Parameters.AddWithValue("precio_representante", precio_representante);
                command.Parameters.AddWithValue("au_gerente", au_gerente);
                command.Parameters.AddWithValue("au_dc", au_dc);
                command.Parameters.AddWithValue("precio_pagar", precio_pagar);
                command.Parameters.AddWithValue("precio_factura", precio_factura);
                command.Parameters.AddWithValue("total_factura", total_factura);
                command.Parameters.AddWithValue("bandera_especial", bandera_especial);
                command.Parameters.AddWithValue("plazo_especial", plazo_especial);
                command.Parameters.AddWithValue("boni_precioporunidad", boni_precioporunidad);
                command.Parameters.AddWithValue("boni_cantidadporunidad", boni_cantidadporunidad);
                command.Parameters.AddWithValue("boni_productoid", boni_productoid);
                command.Parameters.AddWithValue("boni_precioventa", boni_precioventa);
                command.Parameters.AddWithValue("boni_cantidadcalculo", boni_cantidadcalculo);
                command.Parameters.AddWithValue("boni_estado", boni_estado);
                command.Parameters.AddWithValue("boni_costomp", boni_costomp);
                command.Parameters.AddWithValue("boni_bonificadomp", boni_bonificadomp);
                command.Parameters.AddWithValue("entrega", entrega);
                command.Parameters.AddWithValue("fecha_autorizajefecomer", fecha_autorizajefecomer);
                command.Parameters.AddWithValue("fecha_autorizanalisajr", fecha_autorizanalisajr);
                command.Parameters.AddWithValue("cancela_coment_soporte", cancela_coment_soporte);
                command.Parameters.AddWithValue("abasto_inicial", abasto_inicial);

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

        public bool insertarDatosEncabeza(int n_remision , DateTime fecha_alta , string cve_cte ,string nom_cte,string RFC  ,string Ciudad , string Domicilio,
 string CP  , string estatus  , int n_agente ,string nom_age , string observacion, int moneda, int plazo, int tipo_venta, float total,string medio_pago ,int cuenta,
 string destino ,int tipo_agente, float total_p , string documento,string cultivo ,int vip_estnotifi,string vip_cliente ,int vbo_gestor,string comentario_gestor ,int vbo_jefecyc,
 string comentario_jefecyc,int vbo_dircom,string comentario_dircom,int vbo_dirgral,string comentario_dirgral , DateTime timeres_gestor, DateTime timeres_jefecyc, DateTime timeres_dircom , DateTime timeres_dirgral,
   float tipo_cambio , int vbo_gerente ,string comentario_gerente , DateTime timeres_gerente , DateTime fechacomp_gerente, float montocomp_gerente , DateTime fechacomp_real, float montocomp_real,
 DateTime altahora_pedido , int localidad,float fact_ds ,int encbandera_especial,int encplazo_especial,int id_entregas,int indica_entrega ,string bodega_entrega , DateTime fech_3Areturn,
      string opCFDI ,string ORD ,string MTDPG  , int idEntregaSap,int dcto_pp,string CREDITO ,int mes_factura,string clas_credito_mes )
        {
            conexion.Open();

            bool exito = false;
            try
            {
                MySqlCommand command = new MySqlCommand("SP_INSERT_ENCABEZA_PD", conexion);
                command.Connection = conexion;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("n_remision", n_remision);
                command.Parameters.AddWithValue("fecha_alta", fecha_alta);
                command.Parameters.AddWithValue("cve_cte", cve_cte);
                command.Parameters.AddWithValue("nom_cte", nom_cte);
                command.Parameters.AddWithValue("RFC", RFC);
                command.Parameters.AddWithValue("Ciudad", Ciudad);
                command.Parameters.AddWithValue("Domicilio", Domicilio);
                command.Parameters.AddWithValue("CP", CP);
                command.Parameters.AddWithValue("estatus", estatus);
                command.Parameters.AddWithValue("n_agente", n_agente);
                command.Parameters.AddWithValue("nom_age", nom_age);
                command.Parameters.AddWithValue("observacion", observacion);
                command.Parameters.AddWithValue("moneda", moneda);
                command.Parameters.AddWithValue("plazo", plazo);
                command.Parameters.AddWithValue("tipo_venta", tipo_venta);
                command.Parameters.AddWithValue("total", total);
                command.Parameters.AddWithValue("medio_pago", medio_pago);
                command.Parameters.AddWithValue("cuenta", cuenta);
                command.Parameters.AddWithValue("destino", destino);
                command.Parameters.AddWithValue("tipo_agente", tipo_agente);
                command.Parameters.AddWithValue("total_p", total_p);
                command.Parameters.AddWithValue("documento", documento);
                command.Parameters.AddWithValue("cultivo", cultivo);
                command.Parameters.AddWithValue("vip_estnotifi", vip_estnotifi);
                command.Parameters.AddWithValue("vip_cliente", vip_cliente);
                command.Parameters.AddWithValue("vbo_gestor", vbo_gestor);
                command.Parameters.AddWithValue("comentario_gestor", comentario_gestor);
                command.Parameters.AddWithValue("vbo_jefecyc", vbo_jefecyc);
                command.Parameters.AddWithValue("comentario_jefecyc", comentario_jefecyc);
                command.Parameters.AddWithValue("vbo_dircom", vbo_dircom);
                command.Parameters.AddWithValue("comentario_dircom", comentario_dircom);
                command.Parameters.AddWithValue("vbo_dirgral", vbo_dirgral);
                command.Parameters.AddWithValue("comentario_dirgral", comentario_dirgral);
                command.Parameters.AddWithValue("timeres_gestor", timeres_gestor);
                command.Parameters.AddWithValue("timeres_jefecyc", timeres_jefecyc);
                command.Parameters.AddWithValue("timeres_dircom", timeres_dircom);
                command.Parameters.AddWithValue("timeres_dirgral", timeres_dirgral);
                command.Parameters.AddWithValue("tipo_cambio", tipo_cambio);
                command.Parameters.AddWithValue("vbo_gerente", vbo_gerente);
                command.Parameters.AddWithValue("comentario_gerente", comentario_gerente);
                command.Parameters.AddWithValue("timeres_gerente", timeres_gerente);
                command.Parameters.AddWithValue("fechacomp_gerente", fechacomp_gerente);
                command.Parameters.AddWithValue("montocomp_gerente", montocomp_gerente);
                command.Parameters.AddWithValue("fechacomp_real", fechacomp_real);
                command.Parameters.AddWithValue("montocomp_real", montocomp_real);
                command.Parameters.AddWithValue("altahora_pedido", altahora_pedido);
                command.Parameters.AddWithValue("localidad", localidad);
                command.Parameters.AddWithValue("fact_ds", fact_ds);
                command.Parameters.AddWithValue("encbandera_especial", encbandera_especial);
                command.Parameters.AddWithValue("encplazo_especial", encplazo_especial);
                command.Parameters.AddWithValue("id_entregas", id_entregas);
                command.Parameters.AddWithValue("indica_entrega", indica_entrega);
                command.Parameters.AddWithValue("bodega_entrega", bodega_entrega);
                command.Parameters.AddWithValue("fech_3Areturn", fech_3Areturn);
                command.Parameters.AddWithValue("opCFDI", opCFDI);
                command.Parameters.AddWithValue("ORD", ORD);
                command.Parameters.AddWithValue("MTDPG", MTDPG);
                command.Parameters.AddWithValue("idEntregaSap", idEntregaSap);
                command.Parameters.AddWithValue("dcto_pp", dcto_pp);
                command.Parameters.AddWithValue("CREDITO", CREDITO);
                command.Parameters.AddWithValue("mes_factura", mes_factura);
                command.Parameters.AddWithValue("clas_credito_mes", clas_credito_mes);
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
