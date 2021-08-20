using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUFT_PRUEBA_001
{
    
    class CTRL_DIRECCIONES
{

        public CTRL_DIRECCIONES()
        {
            using (AGROVERSA_PRODUCTIVAEntities Dbo = new AGROVERSA_PRODUCTIVAEntities())
            {
               
                foreach(VW_PUFT_VALI_INSER_DIREC row in Dbo.VW_PUFT_VALI_INSER_DIREC)
                {
                    if (row.APLI_INSERT == 1)
                    {


                    }


                }



            }

        }
          


}
}
