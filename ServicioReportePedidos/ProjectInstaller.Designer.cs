namespace ServicioReportePedidos
{
    partial class ProjectInstaller
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
            this.ReportePedisoServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstallerReporte = new System.ServiceProcess.ServiceInstaller();
            this.serviceControllerReportePedidos = new System.ServiceProcess.ServiceController();
            // 
            // ReportePedisoServiceProcessInstaller
            // 
            this.ReportePedisoServiceProcessInstaller.Password = null;
            this.ReportePedisoServiceProcessInstaller.Username = null;
            // 
            // serviceInstallerReporte
            // 
            this.serviceInstallerReporte.Description = "Instalador  de  Servicio de recarga de Pedidos";
            this.serviceInstallerReporte.DisplayName = "Recarga de Reporte  de Pedidos";
            this.serviceInstallerReporte.ServiceName = "Service_ReloadReportePediodos";
            // 
            // serviceControllerReportePedidos
            // 
            this.serviceControllerReportePedidos.ServiceName = "Servico  Recarga de Pedidos";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceInstallerReporte,
            this.ReportePedisoServiceProcessInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller ReportePedisoServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller serviceInstallerReporte;
        private System.ServiceProcess.ServiceController serviceControllerReportePedidos;
    }
}