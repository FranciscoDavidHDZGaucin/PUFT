using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ServicioReportePedidos
{
    partial class Service_ReloadReportePediodos : ServiceBase
    {
        System.Timers.Timer Tipocoder  = new  System.Timers.Timer() ;

        System.Timers.Timer  FailEstandarReload  = new System.Timers.Timer();
        bool ctrl_timer = false;
        int compensacion_ctrl = 0; 
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
            
        }

        protected override void OnStart(string[] args)
        {
            
            Event_reload.WriteEntry("Iniciado servicio de respuesta de mensajes " +
                "Servicio de Prueba REPORTE PEDIDOS   (Service_ReloadReportePediodos).");

            try
            {
                Class_Reload ObjeIntervalos = new Class_Reload(Event_reload);
                Tipocoder.Interval = ObjeIntervalos.intervaloReload;
                Tipocoder.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimeCoder);
                Tipocoder.Start();
                ///Iniciamos  un timer de   5  minutos para compensar el  fallo 
                FailEstandarReload.Interval = 300000;
                FailEstandarReload.Elapsed += new System.Timers.ElapsedEventHandler(this.OnFailEstandarReload);
                ///***Inicio  apagado del   timer  de conpensacion 
                FailEstandarReload.Stop();
                ///EjecutarCorte();


            }
            catch (Exception e)
            {
                // Get the current date.
                DateTime thisDay = DateTime.Today;
                // Display the date in the default (general) format.

                Class_ErroReload EROR = new Class_ErroReload("Error Estado inicila servicio", "Service_ReloadReportePediodos", e.ToString());
                Event_reload.WriteEntry("Error Estado inicila servicio");

            }
            // TODO: agregar código aquí para iniciar el servicio.
        }

        protected override void OnStop()
        {
            Tipocoder.Stop();
            Event_reload.WriteEntry("Recarga Reporte Pedidos Detenido");
            Class_ErroReload EROR = new Class_ErroReload("Servicio Recarga de Reporte Pedidos", "Detenido", "Detenido");
            // TODO: agregar código aquí para realizar cualquier anulación necesaria para detener el servicio.
        }

        private void OnTimeCoder(object sender, ElapsedEventArgs e)
        {
          
            try
            {

                EjecutarCorte();
                
            }
            catch (Exception I)
            {
                Event_reload.WriteEntry("Error N#xx Incio de Timer" + I);

            }


           
        }

        private void OnFailEstandarReload(object sender, ElapsedEventArgs e)
        {
            try
            {
                Event_reload.WriteEntry("INICIO RECARGA COMPENSACION   ");
                Class_ReportePedidos ReporteReload = new Class_ReportePedidos();
                if (ReporteReload.EjecutarPaso(Event_reload))
                {
                    Class_ErroReload EROR = new Class_ErroReload("CORRECTO RECARGA COMPENSACION TERMINADA", "REPORTE CARGADO", "RPTCORRECT");
                    Event_reload.WriteEntry("CORRECTO RECARGA COMPENSACION TERMINADA");
                    compensacion_ctrl = 1; 
                    FailEstandarReload.Stop();
                }
                else
                {
                    if (compensacion_ctrl > 5)
                    {
                        FailEstandarReload.Stop();

                    }
                  
                    Class_ErroReload EROR = new Class_ErroReload("ERROR  RECARGA COMPENSACION N# INTENTOS:"+compensacion_ctrl.ToString(), "SIN REPORTE", "RPTFAILCOMPENSASION");
                }

                compensacion_ctrl += 1;
            }
            catch (Exception J)
            {

                Event_reload.WriteEntry("Error  en recarga de Compensacion" + J);
                Class_ErroReload EROR = new Class_ErroReload("ERROR  RECARGA COMPENSACION ", J.ToString(), "RPTCORRECT");
            }

        }
        public void EjecutarCorte()
        {
            try
            {
                FailEstandarReload.Stop();
                Event_reload.WriteEntry("INICIAMOS LA  RECARGA ");
                Class_ReportePedidos ReporteReload = new Class_ReportePedidos();
                if (ReporteReload.EjecutarPaso(Event_reload))
                {
                    Class_ErroReload EROR = new Class_ErroReload("CORRECTO RECARGA TERMINADA", "REPORTE CARGADO", "RPTCORRECT");
                    Event_reload.WriteEntry("CORRECTO RECARGA TERMINADA");
                }
                else
                {
                    ////***Iniciamos  Recarga de compensacion
                    FailEstandarReload.Start();



                }


            }
            catch (Exception J)
            {

                Event_reload.WriteEntry("Error N#00 Incio de Timer" + J);

            }

        }



    }
}
