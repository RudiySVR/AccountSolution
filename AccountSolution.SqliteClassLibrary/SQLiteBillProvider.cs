using AccountSolution.FromAccountClassLibrary.DAL;
using AccountSolution.FromAccountClassLibrary.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSolution.SqliteClassLibrary
{
    public class SQLiteBillProvider : DataAccess
    {
        public SQLiteBillProvider()
        {
            this.ConnectionString = Directory.GetCurrentDirectory() + "\\App_Data\\Trade.db";
            using (var db = new SQLiteConnection(this.ConnectionString, true))
            {
                try
                {
                    db.CreateTable<Bill>();
                    db.CreateTable<BillLine>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Table exist!");
                }
            }
        }

        public  bool DeleteBillAll()
        {
            using (var db = new SQLiteConnection(this.ConnectionString, true))
            {
                Console.WriteLine( db.DeleteAll<Bill>());
                return true;
            }
        }

        public  List<Bill> GetBill()
        {
            using (var db = new SQLiteConnection(this.ConnectionString, true))
            {
                return db.Table<Bill>().ToList();
            }
        }

        //this.ConnectionString = "Provider =";
        //this.ConnectionString += ConfigurationManager.ConnectionStrings["FromAccountSqlite"].ProviderName + ";";
        //this.ConnectionString += ConfigurationManager.ConnectionStrings["FromAccountSqlite"].ConnectionString;

        public int InsertBill(Bill Bill)
        {
            using (var db = new SQLiteConnection(this.ConnectionString, true))
            {
                return db.Insert(Bill);
            }
        }

        public int InsertBillLine(BillLine BillLine)
        {
            using (var db = new SQLiteConnection(this.ConnectionString, true))
            {
                return db.Insert(BillLine);
            }
        }

        public bool DeleteBillLineAll()
        {
            using (var db = new SQLiteConnection(this.ConnectionString, true))
            {
                Console.WriteLine(db.DeleteAll<BillLine>());
                return true;
            }
        }
    }

}
