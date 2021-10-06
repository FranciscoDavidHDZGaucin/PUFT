﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PUFT_PRUEBA_001
{

    /*
     CLASE PARA ALMACENAR LA  INFORMACION NECESARAIA PARA  ASIGNAR  DIRECCION A UN  PEDIDO   GENERADO
     EN PROCESO  AUTOMATICO
         */ 
    class DIRECCIO_ORDENVENTA
    {
        public int ORDEN_VENTA { get; set; }
        public Nullable<long> n_remision { get; set; }
        public string ShipToCode { get; set; }
        public string cve_cte { get; set; }
        public string Address { get; set; }
        public Nullable<int> LineNum { get; set; }


    }



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
      public SP_PUFT_ORDENVENTA_DIRECCIONES_BY_DocNumOrdenVenta_Result GET_ORDEN_VENTA_DIRECC (   int ord_num)
      {
            SP_PUFT_ORDENVENTA_DIRECCIONES_BY_DocNumOrdenVenta_Result reusltado = null;


            try
            {
                using (AGROVERSA_PRODUCTIVA dbo = new AGROVERSA_PRODUCTIVA () )
                {
                    foreach (SP_PUFT_ORDENVENTA_DIRECCIONES_BY_DocNumOrdenVenta_Result objreturn in  dbo.SP_PUFT_ORDENVENTA_DIRECCIONES_BY_DocNumOrdenVenta(ord_num))
                    {

                         reusltado = objreturn;
                        break;
                    }
                } 

            } catch (Exception e  )
            {

                // Get the current date.
                DateTime thisDay = DateTime.Today;
                PUFT_DIRECCIONES_ERRORS insertExisto = new PUFT_DIRECCIONES_ERRORS("ERR EN GET_ORDEN_VENTA_DIRECC", "ERROR EN OBTENER IFROMACION DE DIRECCION POR ORDEN DE VENTA", e.ToString());
               

            }


            return reusltado;

       }

      public bool UpdateDireccionPedioEntrante(SP_PUFT_ORDENVENTA_DIRECCIONES_BY_DocNumOrdenVenta_Result Objt )
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
                        cmd.Parameters.Add(new MySqlParameter("CTRL_ACCION", MySqlDbType.VarChar)).Value = "UPDEREMI";
                        cmd.Parameters.Add(new MySqlParameter("VLN_FACTURA", MySqlDbType.Int64)).Value = 0;  // Objt.n_factura;
                        cmd.Parameters.Add(new MySqlParameter("VL_ORDEN_VENTA", MySqlDbType.Int32)).Value = Objt.ORDEN_VENTA;
                        cmd.Parameters.Add(new MySqlParameter("VL_NREMISION", MySqlDbType.Int64)).Value = Objt.n_remision;
                        cmd.Parameters.Add(new MySqlParameter("VL_AGENTE", MySqlDbType.Int32)).Value = 0;/// Objt.n_agente;
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
                                else if (Convert.ToInt32(row["MainResult"]) >= 904 && Convert.ToInt32(row["MainResult"]) <= 913) // El registro  ya se le modifico la  direccion asi que homite 
                                {
                                    EXITO = true;

                                }
                                else
                                {
                                    EXITO = false;
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
                        cmd.Parameters.Add(new MySqlParameter("CTRL_ACCION", MySqlDbType.VarChar)).Value = "UPDEREMI"; 
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
                                else if (Convert.ToInt32(row["MainResult"]) >= 904 && Convert.ToInt32(row["MainResult"]) <=  913) // El registro  ya se le modifico la  direccion asi que homite 
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


        public void Accion_Add_DirreccionPedidoWhitOrenventa(int  OrdenVenta)
        {
            try
            {
                SP_PUFT_ORDENVENTA_DIRECCIONES_BY_DocNumOrdenVenta_Result reusltado = GET_ORDEN_VENTA_DIRECC(OrdenVenta);
                if (ValidarObjetoDireccion(reusltado))
                {
                    if (UpdateDireccionPedioEntrante(reusltado))
                    {
                        DateTime thisDay = DateTime.Today;
                        PUFT_ERRORS error = new PUFT_ERRORS("DIRRECCION AGREGADA", "CORRECTO ASIGNADA DIRECCION" + " ORDEN:" + reusltado.ORDEN_VENTA.ToString(), "CVE CLIENTE:" +reusltado.cve_cte + " REMISION :" +reusltado.n_remision.ToString(), thisDay);
                    }
                }
            }
            catch (Exception e)
            {
                PUFT_DIRECCIONES_ERRORS insertExisto = new PUFT_DIRECCIONES_ERRORS("ERROR NET", "Accion_Add_DirreccionPedidoWhitOrenventa", e.ToString());


            }



        }
        public bool ValidarObjetoDireccion(SP_PUFT_ORDENVENTA_DIRECCIONES_BY_DocNumOrdenVenta_Result Objt)
        {
            bool EXITO = true;

            if (String.IsNullOrEmpty(Objt.ShipToCode))
            {
                PUFT_DIRECCIONES_ERRORS insertExisto = new PUFT_DIRECCIONES_ERRORS("ERROR NET", "Validacion Objeto .NET", "ShipToCode");
                EXITO = false;

            }
            if ( Objt.LineNum == null )
            {
                PUFT_DIRECCIONES_ERRORS insertExisto = new PUFT_DIRECCIONES_ERRORS("ERROR NET", "Validacion Objeto .NET", "LineNum");
                EXITO = false;

            }
            if (Objt.n_remision == null)
            {
                PUFT_DIRECCIONES_ERRORS insertExisto = new PUFT_DIRECCIONES_ERRORS("ERROR NET", "Validacion Objeto .NET", "LineNum");
                EXITO = false;

            }
            if (String.IsNullOrEmpty(Objt.cve_cte))
            {
                PUFT_DIRECCIONES_ERRORS insertExisto = new PUFT_DIRECCIONES_ERRORS("ERROR NET", "Validacion Objeto .NET", "cve_cte");
                EXITO = false;

            }

            return EXITO;


        }
}
}
