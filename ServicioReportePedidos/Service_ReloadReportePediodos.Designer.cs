﻿namespace ServicioReportePedidos
{
    partial class Service_ReloadReportePediodos
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Event_reload = new System.Diagnostics.EventLog();
            this.timerReload = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Event_reload)).BeginInit();
            // 
            // Event_reload
            // 
            this.Event_reload.Log = "Application";
            this.Event_reload.Source = "RECARGA_PEDIDOS";
            // 
            // Service_ReloadReportePediodos
            // 
            this.ServiceName = "Service_ReloadReportePediodos";
            ((System.ComponentModel.ISupportInitialize)(this.Event_reload)).EndInit();

        }

        #endregion

        private System.Diagnostics.EventLog Event_reload;
        private System.Windows.Forms.Timer timerReload;
    }
}