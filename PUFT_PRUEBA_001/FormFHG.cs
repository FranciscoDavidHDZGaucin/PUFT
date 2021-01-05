using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PUFT_PRUEBA_001
{
    public partial class FormFHG : Form
    {
        public FormFHG()
        {
            InitializeComponent();
            show_errors();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //TIMER_CICLO_PUFT.Start();
            //MAIN_GENERA_ENTREGAS GENERAR_ENTREGAS = new MAIN_GENERA_ENTREGAS();
            //GENERAR_ENTREGAS.RECORRER_FACTURAS_PENDIENTES();


            MAIN_ORDEN_VENTAS ORDENES_VENTAS = new MAIN_ORDEN_VENTAS();
            ORDENES_VENTAS.RECORRER_ORDEN_VENTAS();



            //CTRL_OBJET _ORDENVENTA001 = new CTRL_OBJET(13067, true, 147202001, true);
            //ACCION_PRODUCTOS_PEDIDOS INSERT_PROD = new ACCION_PRODUCTOS_PEDIDOS(_ORDENVENTA001);
            //INSERT_PROD.RECORRER_PRODUCTOS(); 
            int time = Convert.ToInt32(tiempoExe.SelectedItem);
            if (time == 3)
            {
                TIMER_CICLO_PUFT.Interval = 180000;
                TIMER_CICLO_PUFT.Start();
            }
            if (time == 4)
            {
                TIMER_CICLO_PUFT.Interval = 240000;
                TIMER_CICLO_PUFT.Start();
            }
            if (time == 5)
            {
                TIMER_CICLO_PUFT.Interval = 300000;
                TIMER_CICLO_PUFT.Start();
            }
            if (time == 10)
            {
                TIMER_CICLO_PUFT.Interval = 600000;
                TIMER_CICLO_PUFT.Start();
            }
            if (time == 15)
            {
                TIMER_CICLO_PUFT.Interval = 900000;
                TIMER_CICLO_PUFT.Start();
            }

        }

        private void TIMER_CICLO_PUFT_Tick(object sender, EventArgs e)
        {
            MAIN_ORDEN_VENTAS ORDENES_VENTAS = new MAIN_ORDEN_VENTAS();
            ORDENES_VENTAS.RECORRER_ORDEN_VENTAS();
            show_errors();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void show_errors()
        {
            string connStr =
                                     System.Configuration.ConfigurationManager.
                                     ConnectionStrings["Server80"].ConnectionString;
            string query = "select msg_puft, class_puft, exception_puft, fecha_puft from TB_PUFT_ERROS;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    var bindingSource = new BindingSource();
                    bindingSource.DataSource = ds.Tables[0];
                    dataGridView1.DataSource = bindingSource;
                }
            }
        }



    }
}
