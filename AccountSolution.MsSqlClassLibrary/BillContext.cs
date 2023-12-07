using AccountSolution.FromAccountClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSolution.MsSqlClassLibrary
{
    public class BillContext : DbContext
    {
        public BillContext() : base("DbConnection")
        { }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillLine> BillLine { get; set; }
    }
}
