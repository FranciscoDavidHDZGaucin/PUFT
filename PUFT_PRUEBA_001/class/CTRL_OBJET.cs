using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUFT_PRUEBA_001
{
    class CTRL_OBJET
    {
        private Boolean _CONTROL_MAIN = false ; 
        private  Int64 _REMISION;
        private Boolean _Esnew;
        private Boolean _ExisteORDVENTA;
        private int _ORD_VENTA;
        private DataTable tb_productos;

        public CTRL_OBJET(int ORD_VENTA, Boolean ExisteORDVENTA, Int64 REMISION, Boolean Esnew)
        {
            try
            {
                this._REMISION = REMISION;
                this._Esnew = Esnew;
                this._ExisteORDVENTA = ExisteORDVENTA;
                this._ORD_VENTA = ORD_VENTA;
                if (this._ExisteORDVENTA && this._Esnew)
                {
                    this._CONTROL_MAIN = true;

                }
            }
            catch (Exception e)
            {


            }


        }

        public  Int64 REMISION { get  => _REMISION ;  }
        public Boolean EsNew { get => _Esnew;  }
        public Boolean ExisteORDVENTA { get => _ExisteORDVENTA;  }
        public int ORD_VENTA { get => _ORD_VENTA; }
        public DataTable TB_PRODUCTOS { get => tb_productos; set => tb_productos = value; }

        public Boolean CONTROL_MAIN { get => _CONTROL_MAIN;  } 
    }
}
