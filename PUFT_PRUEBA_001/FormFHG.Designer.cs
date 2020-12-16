namespace PUFT_PRUEBA_001
{
    partial class FormFHG
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.TIMER_CICLO_PUFT = new System.Windows.Forms.Timer(this.components);
            this.tiempoExe = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 57);
            this.button1.TabIndex = 0;
            this.button1.Text = "Iniciar  Cada 2 Minutos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TIMER_CICLO_PUFT
            // 
            this.TIMER_CICLO_PUFT.Interval = 180000;
            this.TIMER_CICLO_PUFT.Tick += new System.EventHandler(this.TIMER_CICLO_PUFT_Tick);
            // 
            // tiempoExe
            // 
            this.tiempoExe.FormattingEnabled = true;
            this.tiempoExe.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "10",
            "15"});
            this.tiempoExe.Location = new System.Drawing.Point(37, 157);
            this.tiempoExe.Name = "tiempoExe";
            this.tiempoExe.Size = new System.Drawing.Size(171, 21);
            this.tiempoExe.TabIndex = 1;
            this.tiempoExe.Text = "Selecciona intervalo de tiempo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tiempo";
            // 
            // FormFHG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tiempoExe);
            this.Controls.Add(this.button1);
            this.Name = "FormFHG";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer TIMER_CICLO_PUFT;
        private System.Windows.Forms.ComboBox tiempoExe;
        private System.Windows.Forms.Label label1;
    }
}