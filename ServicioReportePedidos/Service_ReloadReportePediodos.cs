using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ServicioReportePedidos
{
    partial class Service_ReloadReportePediodos : ServiceBase
    {
        public Service_ReloadReportePediodos()
        {
            InitializeComponent();
            Event_reload = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("Service_ReloadReportePediodos"))
            {
                System.Diagnostics.EventLog.CreateEventSource(

                   "Service_ReloadReportePediodos", "Application");
            }
            Event_reload.Source = "Service_ReloadReportePediodos";
            Event_reload.Log = "Application";
            Class_Reload ObjeIntervalos = new Class_Reload(Event_reload);
        }

        protected override void OnStart(string[] args)
        {
            // TODO: agregar código aquí para iniciar el servicio.
        }

        protected override void OnStop()
        {
            // TODO: agregar código aquí para realizar cualquier anulación necesaria para detener el servicio.
        }
    }
}
