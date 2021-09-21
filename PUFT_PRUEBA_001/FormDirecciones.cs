using MySql.Data.MySqlClient;
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
    public partial class FormDirecciones : Form
    {
        public FormDirecciones()
        {
            InitializeComponent();
            Dictionary< int, string > test = new Dictionary<int, string>();
            test.Add(959, "CORRECTO" );
            test.Add(958, "ERROR");
            comboBox1.DataSource = new BindingSource(test, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
            show_errors(957);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ///CTRL_DIRECCIONES CTRLDIRE = new CTRL_DIRECCIONES();
            using (AGROVERSA_PRODUCTIVA Dbo = new AGROVERSA_PRODUCTIVA())
            {

                gridDirecciones.DataSource = Dbo.VW_PUFT_VALI_INSER_DIREC.ToList(); 


                //foreach (VW_PUFT_VALI_INSER_DIREC row in Dbo.VW_PUFT_VALI_INSER_DIREC)
                //{
                //    if (row.APLI_INSERT == 1)
                //    {
                //        var objtMYsql = new cmdsForm();
                //        if (!objtMYsql.insertDirrecciones(row))
                //        {
                //            break;
                //        }
                //    }


                //}



            }
        }

        private void BTN_OBTENER_FACTURAS_Click(object sender, EventArgs e)
        {
           var  INICIO =   inicidate.Value;
            var FIN = endDATE.Value;

            using (AGROVERSA_PRODUCTIVA Dbo = new AGROVERSA_PRODUCTIVA())
            {


                var Rsultado = Dbo.SP_PUFT_ORDENVENTA_DIRECCIONES_BY_DATE(INICIO,
                      FIN);

                GRIDMAIN.DataSource = Rsultado.ToList();
                lbNUMfACTRUAAJUSTAR.Text = GRIDMAIN.Rows.Count.ToString();
                
            }



         }

        private void show_errors(int  typeShow)
        {
            string connStr =
                                     System.Configuration.ConfigurationManager.
                                     ConnectionStrings["Server80"].ConnectionString;
            string query = ""; 

            if (typeShow ==  957)
            {
                query =  "select  ID, FECHA,FASE_ERROR,ERROR_direcc,DatosEntrada,IsCorrect from VW_PUFT_LOG_DIRECCIONES  ";
            }
            if (typeShow == 958)
            {
                query = "select  ID, FECHA,FASE_ERROR,ERROR_direcc,DatosEntrada,IsCorrect from VW_PUFT_LOG_DIRECCIONES  where  IsCorrect = 0 ";
            }
            if (typeShow == 959)
            {
                query = "select  ID, FECHA,FASE_ERROR,ERROR_direcc,DatosEntrada,IsCorrect from VW_PUFT_LOG_DIRECCIONES  where  IsCorrect = 1 ";
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    var bindingSource = new BindingSource();
                    bindingSource.DataSource = ds.Tables[0];
                    dataGridView1.DataSource = bindingSource;


                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
        }

        private void btnajustar_Click(object sender, EventArgs e)
        {
            CTRL_DIRECCIONES CTRLDIRE = new CTRL_DIRECCIONES();
            CTRLDIRE.AJUSTAR_DIRECCIONES_SAP_MYSQL();

        }

        private void btnAsignarMysFac_Click(object sender, EventArgs e)
        {
            var INICIO = inicidate.Value;
            var FIN = endDATE.Value;
            CTRL_DIRECCIONES CTRLDIRE = new CTRL_DIRECCIONES();
            if (CTRLDIRE.AJUSTAR_FACTURASCON_DIRECCIONES(INICIO, FIN))
            {
                lBAGREGADAS.Text = CTRLDIRE.CountDirreccionCorrec.ToString();
                string message = "Se  realiso  el ajuste necesario";
                string caption = "correcto";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    // Closes the parent form.
                    this.Close();
                }

            }
            else {

                string message = "Error Ocurrio algo  con una factura ";
                string caption = "Revisar la tabla de errores ";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    // Closes the parent form.
                    this.Close();
                }


            }

        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            show_errors(957);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

           
            if (comboBox1.SelectedValue  !=  null )
            {
                show_errors(Convert.ToInt32( comboBox1.SelectedValue));
            }
            
        }
    }
}
