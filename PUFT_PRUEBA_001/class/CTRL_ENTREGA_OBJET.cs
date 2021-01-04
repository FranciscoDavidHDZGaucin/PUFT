using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUFT_PRUEBA_001
{
    class CTRL_ENTREGA_OBJET
        {
        private Boolean _CONTROL_MAIN = false;
        private Int64 _REMISION;
        private Boolean _Esnew;
        private Boolean _ExistEntrega;
        private Int64 _ENTREGA; 

        public CTRL_ENTREGA_OBJET(Int64 ENTREGA , Int64 REMISION, Boolean ExistEntrega,  Boolean Esnew )
        {
            try
            {
                this._REMISION = REMISION;
                this._Esnew = Esnew;
                this._ExistEntrega = ExistEntrega;
                this._ENTREGA = ENTREGA;
                if (this._ExistEntrega && this._Esnew)
                {
                    this._CONTROL_MAIN = true;

                }
            }
            catch (Exception e)
            {
                // Get the current date.
                DateTime thisDay = DateTime.Today;
                // Display the date in the default (general) format.

                PUFT_ERRORS error = new PUFT_ERRORS("CLASSE CTRL_ENTREGA_OBJET ", "ERROR  EN CTRL_ENTREGA_OBJET ", e.ToString(), thisDay);

            }


        }


        public Int64 REMISION { get => _REMISION; }
        public Boolean EsNew { get => _Esnew; }
        public Boolean ExistEntrega { get => _ExistEntrega; }
        public Int64 ENTREGA { get => _ENTREGA; }
        
        public Boolean CONTROL_MAIN { get => _CONTROL_MAIN; }
    }
}
