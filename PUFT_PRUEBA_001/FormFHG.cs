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
            MAIN_ORDEN_VENTAS ORDENES_VENTAS = new MAIN_ORDEN_VENTAS();
            ORDENES_VENTAS.RECORRER_ORDEN_VENTAS();


            //CTRL_OBJET _ORDENVENTA001 = new CTRL_OBJET(13067, true, 147202001, true);
            //ACCION_PRODUCTOS_PEDIDOS INSERT_PROD = new ACCION_PRODUCTOS_PEDIDOS(_ORDENVENTA001);
            //INSERT_PROD.RECORRER_PRODUCTOS(); 

        }
    }
}
