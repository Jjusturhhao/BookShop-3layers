using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;


namespace BusinessLayer
{
    public class CusOrderBL
    {
        private CusOrderDL CusOrderDL;

        public CusOrderBL()
        {
            CusOrderDL = new CusOrderDL();
        }
        public List<CusOrder> GetCusOrdersByUsername(string username)
        {
            return CusOrderDL.GetCusOrdersByUsername(username);
        }

    }
}
