using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PUFT_PRUEBA_001
{




    class CTRL_DIRECCIONES
    {


        public int CountDirreccionCorrec { get; set; }

      
    public CTRL_DIRECCIONES()
        {
          


        }
        public void AJUSTAR_DIRECCIONES_SAP_MYSQL()
        {
            using ( AGROVERSA_PRODUCTIVA  Dbo = new AGROVERSA_PRODUCTIVA())
            {




                foreach (VW_PUFT_VALI_INSER_DIREC row in Dbo.VW_PUFT_VALI_INSER_DIREC)
                {
                    if (row.APLI_INSERT == 1)
                    {
                        var objtMYsql = new cmdsForm();
                        if (!objtMYsql.insertDirrecciones(row))
                        {
                            break;
                        }
                    }


                }



            }

        }




        public bool  AJUSTAR_FACTURASCON_DIRECCIONES( DateTime  INICIO , DateTime  FIN   )
         {
            bool resultado = false; 
            using (AGROVERSA_PRODUCTIVA Dbo = new AGROVERSA_PRODUCTIVA())
            {


                var Rsultado = Dbo.SP_PUFT_ORDENVENTA_DIRECCIONES_BY_DATE(INICIO,
                      FIN);



            foreach (SP_PUFT_ORDENVENTA_DIRECCIONES_BY_DATE_Result row in Rsultado)
            {
                var ejem = row.cve_cte;
                    if (!this.UpdateDIreccionesPedidosFacturasEntregas(row))
                    {
                        break;
                    }
                    else {
                        resultado = true;
                    }
            }

                return resultado; 

        }


    }



        public bool UpdateDIreccionesPedidosFacturasEntregas(SP_PUFT_ORDENVENTA_DIRECCIONES_BY_DATE_Result Objt )
        {
            bool EXITO = false; 
            try
            {
                string connection =
                              System.Configuration.ConfigurationManager.
                              ConnectionStrings["Server80"].ConnectionString;

                using (MySqlConnection coneccmys = new MySqlConnection(connection))
                {
                    coneccmys.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_PUFT_CTRL_DIRECCIONES", coneccmys))
                    {  

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new MySqlParameter("VLN_FACTURA", MySqlDbType.Int64)).Value = 0;  // Objt.n_factura;
                        cmd.Parameters.Add(new MySqlParameter("VL_ORDEN_VENTA", MySqlDbType.Int32)).Value =Objt.ORDEN_VENTA;
                        cmd.Parameters.Add(new MySqlParameter("VL_NREMISION", MySqlDbType.Int64)).Value = Objt.n_remision;
                        cmd.Parameters.Add(new MySqlParameter("VL_AGENTE", MySqlDbType.Int32)).Value = Objt.n_agente;
                        cmd.Parameters.Add(new MySqlParameter("vlLineNum", MySqlDbType.Int32)).Value = Objt.LineNum;
                        cmd.Parameters.Add(new MySqlParameter("vlShipCode", MySqlDbType.VarChar)).Value = Objt.ShipToCode;
                        cmd.Parameters.Add(new MySqlParameter("vl_cve_cli", MySqlDbType.VarChar)).Value = Objt.cve_cte;
                        cmd.Parameters.Add(new MySqlParameter("Adress", MySqlDbType.VarChar)).Value = Objt.Address;
                        DataTable dt_table = new DataTable();
                        MySqlDataAdapter APSTER = new MySqlDataAdapter(cmd);

                        APSTER.Fill(dt_table);
                        if (dt_table.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt_table.Rows)
                            {
                                //	SELECT  encabeza_id AS ID_ENCABEZA_PEDIDO ,  ID_ENTREGA AS ID_ENTREGA , AUTO_GENERETE_TB_TEMPORALES AS  ESTATUS_TEMPORALES , EXISTEN_REMI_ORDEN AS EXITE_REMISION_ORDENVENTA ,Ctrl_Direcccion AS EXISTE_DIRECCION ; 


                                if (Convert.ToInt32(row["MainResult"]) == 20210908)
                                {
                                    string VARIABLES = "Remision:" + Objt.n_remision.ToString() + "Factura:NA NO APLICA   Orden de Venta:" + Objt.ORDEN_VENTA;
                                    PUFT_DIRECCIONES_ERRORS insertExisto = new PUFT_DIRECCIONES_ERRORS("Correcto .Net", "CORRECTO", VARIABLES);
                                    EXITO = true;
                                    CountDirreccionCorrec++; 
                                }
                                else if (Convert.ToInt32(row["MainResult"]) == 904) // El registro  ya se le modifico la  direccion asi que homite 
                                {
                                    EXITO = true;

                                }
                                else {
                                    EXITO = false ;
                                }


                            }
                        }


                     }
                }
            }
            catch (Exception e)
            {
                // Get the current date.
                DateTime thisDay = DateTime.Today;
                // Display the date in the default (general) format.

                
                PUFT_DIRECCIONES_ERRORS insertExisto = new PUFT_DIRECCIONES_ERRORS("ERROR NET", "UpdateDIreccionesPedidosFacturasEntregas", e.ToString());
                EXITO = false;
            }





            return EXITO;
        }

}
}
