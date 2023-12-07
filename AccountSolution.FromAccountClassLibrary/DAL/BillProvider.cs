using AccountSolution.FromAccountClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSolution.FromAccountClassLibrary.DAL
{
    public abstract class BillProvider : DataAccess
    {
        public abstract List<Bill> GetBill();
        public abstract int InsertBill(Bill category);
        public abstract bool DeleteBillAll();
    }
}
