using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PUFT_PRUEBA_001
{
    public partial class FormFHG : Form
    {
        public FormFHG()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //TIMER_CICLO_PUFT.Start();
            MAIN_ORDEN_VENTAS ORDENES_VENTAS = new MAIN_ORDEN_VENTAS();
            ORDENES_VENTAS.RECORRER_ORDEN_VENTAS();
            //CTRL_OBJET _ORDENVENTA001 = new CTRL_OBJET(13067, true, 147202001, true);
            //ACCION_PRODUCTOS_PEDIDOS INSERT_PROD = new ACCION_PRODUCTOS_PEDIDOS(_ORDENVENTA001);
            //INSERT_PROD.RECORRER_PRODUCTOS(); 
            int time = Convert.ToInt32(tiempoExe.SelectedItem);
            if (time == 3)
            {
                TIMER_CICLO_PUFT.Interval = 3000;
                TIMER_CICLO_PUFT.Start();
            }
            if (time == 4)
            {
                TIMER_CICLO_PUFT.Interval = 4000;
                TIMER_CICLO_PUFT.Start();
            }
            if (time == 5)
            {
                TIMER_CICLO_PUFT.Interval = 5000;
                TIMER_CICLO_PUFT.Start();
            }
            if (time == 10)
            {
                TIMER_CICLO_PUFT.Interval = 10000;
                TIMER_CICLO_PUFT.Start();
            }
            if (time == 15)
            {
                TIMER_CICLO_PUFT.Interval = 15000;
                TIMER_CICLO_PUFT.Start();
            }

        }

        private void TIMER_CICLO_PUFT_Tick(object sender, EventArgs e)
        {
            MAIN_ORDEN_VENTAS ORDENES_VENTAS = new MAIN_ORDEN_VENTAS();
            ORDENES_VENTAS.RECORRER_ORDEN_VENTAS();
            
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
