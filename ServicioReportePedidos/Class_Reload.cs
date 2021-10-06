using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Diagnostics;

namespace ServicioReportePedidos
{
    class Class_Reload
    {
        public int intervaloReload  { get; set; }
        public  Class_Reload(EventLog eventLog  )
        {
            try
            {
                var connection = "server=192.168.101.154;database=JUPITER;uid=sa;password=DB@gr0V3rs@;";


                using (SqlConnection sqljupiter = new SqlConnection(connection))
                {
                    sqljupiter.Open();
                    using (SqlCommand SP_GEP = new SqlCommand("SELECT dbo.FN_RELOAD_GET_INTERVAL() as INTERVALO", sqljupiter))
                    {
                        DataTable dt_table = new DataTable();
                        SqlDataAdapter ADPA = new SqlDataAdapter(SP_GEP);

                        ADPA.Fill(dt_table);
                        if (dt_table.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt_table.Rows)
                            {
                                this.intervaloReload =Convert.ToInt32( row["INTERVALO"]); 

                            }
                        }
                    }



                }




            }
            catch (Exception J)
            {
                Class_ErroReload EROR = new Class_ErroReload("Erro En Get intervalo N#0001 ", "Class Class_Reload", J.ToString());
                eventLog.WriteEntry("Erro En Get intervalo N#0001" + J);

            }





        }


    }
}
