namespace PUFT_PRUEBA_001
{
    partial class FormDirecciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.inicidate = new System.Windows.Forms.DateTimePicker();
            this.endDATE = new System.Windows.Forms.DateTimePicker();
            this.BTN_OBTENER_FACTURAS = new System.Windows.Forms.Button();
            this.GRIDMAIN = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lBAGREGADAS = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbNUMfACTRUAAJUSTAR = new System.Windows.Forms.Label();
            this.btnAsignarMysFac = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnajustar = new System.Windows.Forms.Button();
            this.gridDirecciones = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnactualizar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.GRIDMAIN)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDirecciones)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = " Direcciones  SAP Y MYSQL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // inicidate
            // 
            this.inicidate.Location = new System.Drawing.Point(42, 53);
            this.inicidate.Name = "inicidate";
            this.inicidate.Size = new System.Drawing.Size(200, 20);
            this.inicidate.TabIndex = 2;
            // 
            // endDATE
            // 
            this.endDATE.Location = new System.Drawing.Point(266, 53);
            this.endDATE.Name = "endDATE";
            this.endDATE.Size = new System.Drawing.Size(200, 20);
            this.endDATE.TabIndex = 3;
            // 
            // BTN_OBTENER_FACTURAS
            // 
            this.BTN_OBTENER_FACTURAS.Location = new System.Drawing.Point(483, 36);
            this.BTN_OBTENER_FACTURAS.Name = "BTN_OBTENER_FACTURAS";
            this.BTN_OBTENER_FACTURAS.Size = new System.Drawing.Size(157, 59);
            this.BTN_OBTENER_FACTURAS.TabIndex = 4;
            this.BTN_OBTENER_FACTURAS.Text = "OBTENER  FACTURAS CON DIRECCION";
            this.BTN_OBTENER_FACTURAS.UseVisualStyleBackColor = true;
            this.BTN_OBTENER_FACTURAS.Click += new System.EventHandler(this.BTN_OBTENER_FACTURAS_Click);
            // 
            // GRIDMAIN
            // 
            this.GRIDMAIN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GRIDMAIN.Location = new System.Drawing.Point(27, 105);
            this.GRIDMAIN.Name = "GRIDMAIN";
            this.GRIDMAIN.Size = new System.Drawing.Size(970, 398);
            this.GRIDMAIN.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1021, 588);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lBAGREGADAS);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.lbNUMfACTRUAAJUSTAR);
            this.tabPage1.Controls.Add(this.btnAsignarMysFac);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.GRIDMAIN);
            this.tabPage1.Controls.Add(this.BTN_OBTENER_FACTURAS);
            this.tabPage1.Controls.Add(this.inicidate);
            this.tabPage1.Controls.Add(this.endDATE);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1013, 562);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ajustar Facturas direccion Mysql";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lBAGREGADAS
            // 
            this.lBAGREGADAS.AutoSize = true;
            this.lBAGREGADAS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBAGREGADAS.Location = new System.Drawing.Point(777, 521);
            this.lBAGREGADAS.Name = "lBAGREGADAS";
            this.lBAGREGADAS.Size = new System.Drawing.Size(34, 24);
            this.lBAGREGADAS.TabIndex = 12;
            this.lBAGREGADAS.Text = "N#";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(532, 521);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(226, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "FACTURAS AJUSTADAS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(114, 521);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(267, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "NUM FACTURAS A AJUSTAR";
            // 
            // lbNUMfACTRUAAJUSTAR
            // 
            this.lbNUMfACTRUAAJUSTAR.AutoSize = true;
            this.lbNUMfACTRUAAJUSTAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNUMfACTRUAAJUSTAR.Location = new System.Drawing.Point(400, 521);
            this.lbNUMfACTRUAAJUSTAR.Name = "lbNUMfACTRUAAJUSTAR";
            this.lbNUMfACTRUAAJUSTAR.Size = new System.Drawing.Size(34, 24);
            this.lbNUMfACTRUAAJUSTAR.TabIndex = 9;
            this.lbNUMfACTRUAAJUSTAR.Text = "N#";
            // 
            // btnAsignarMysFac
            // 
            this.btnAsignarMysFac.Location = new System.Drawing.Point(781, 36);
            this.btnAsignarMysFac.Name = "btnAsignarMysFac";
            this.btnAsignarMysFac.Size = new System.Drawing.Size(88, 43);
            this.btnAsignarMysFac.TabIndex = 8;
            this.btnAsignarMysFac.Text = "Asignar facturas en Mysql";
            this.btnAsignarMysFac.UseVisualStyleBackColor = true;
            this.btnAsignarMysFac.Click += new System.EventHandler(this.btnAsignarMysFac_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fecha  Fin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Fecha  Incio";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnajustar);
            this.tabPage2.Controls.Add(this.gridDirecciones);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1013, 562);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Ajustar Direcciones";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnajustar
            // 
            this.btnajustar.Location = new System.Drawing.Point(612, 37);
            this.btnajustar.Name = "btnajustar";
            this.btnajustar.Size = new System.Drawing.Size(130, 42);
            this.btnajustar.TabIndex = 7;
            this.btnajustar.Text = "Ajustar";
            this.btnajustar.UseVisualStyleBackColor = true;
            this.btnajustar.Click += new System.EventHandler(this.btnajustar_Click);
            // 
            // gridDirecciones
            // 
            this.gridDirecciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDirecciones.Location = new System.Drawing.Point(26, 101);
            this.gridDirecciones.Name = "gridDirecciones";
            this.gridDirecciones.Size = new System.Drawing.Size(970, 398);
            this.gridDirecciones.TabIndex = 6;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.comboBox1);
            this.tabPage3.Controls.Add(this.btnactualizar);
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1013, 562);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Log Erorres";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnactualizar
            // 
            this.btnactualizar.Location = new System.Drawing.Point(21, 19);
            this.btnactualizar.Name = "btnactualizar";
            this.btnactualizar.Size = new System.Drawing.Size(129, 23);
            this.btnactualizar.TabIndex = 8;
            this.btnactualizar.Text = "Actualizar";
            this.btnactualizar.UseVisualStyleBackColor = true;
            this.btnactualizar.Click += new System.EventHandler(this.btnactualizar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(970, 476);
            this.dataGridView1.TabIndex = 7;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ERRORES",
            "CORRECTOS"});
            this.comboBox1.Location = new System.Drawing.Point(570, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(192, 21);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // FormDirecciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 612);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormDirecciones";
            this.Text = "FormDirecciones";
            ((System.ComponentModel.ISupportInitialize)(this.GRIDMAIN)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDirecciones)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker inicidate;
        private System.Windows.Forms.DateTimePicker endDATE;
        private System.Windows.Forms.Button BTN_OBTENER_FACTURAS;
        private System.Windows.Forms.DataGridView GRIDMAIN;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView gridDirecciones;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnajustar;
        private System.Windows.Forms.Button btnAsignarMysFac;
        private System.Windows.Forms.Button btnactualizar;
        private System.Windows.Forms.Label lbNUMfACTRUAAJUSTAR;
        private System.Windows.Forms.Label lBAGREGADAS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}