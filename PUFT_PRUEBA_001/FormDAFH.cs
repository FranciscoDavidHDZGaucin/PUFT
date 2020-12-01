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
    public partial class FormDAFH : Form
    {
        public FormDAFH()
        {
            InitializeComponent();
        }

        cmdsForm cmds = new cmdsForm();

        private void FormDAFH_Load(object sender, EventArgs e)
        {
            bool conectado = cmds.Conectar();

            if (conectado)
            {
                MessageBox.Show("Conectado");
            }
            else
            {
                MessageBox.Show("Hubo un error de conexion");
            }
        }
    }
}
