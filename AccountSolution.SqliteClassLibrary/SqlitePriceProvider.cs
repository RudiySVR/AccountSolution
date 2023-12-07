using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountSolution.FromAccountClassLibrary.DAL;
using AccountSolution.FromAccountClassLibrary.Entities;
using SQLite;

namespace AccountSolution.SqliteClassLibrary
{
    public class SqlitePriceProvider : DataAccess
    {
        //string ConnectionString;
        public SqlitePriceProvider()
        {
            this.ConnectionString = Directory.GetCurrentDirectory() + "\\App_Data\\FromAccount.db";
            using (var db = new SQLiteConnection(this.ConnectionString, true))
            {
                try
                {
                    db.CreateTable<PriceGroup>();
                    db.CreateTable<Price>();
                    db.CreateTable<ShortPrice>();
                }
                catch (Exception)
                {
                    Console.WriteLine("Table exist!");
                }
            }
            //this.ConnectionString = "Provider =";
            //this.ConnectionString += ConfigurationManager.ConnectionStrings["FromAccountSqlite"].ProviderName + ";";
            //this.ConnectionString += ConfigurationManager.ConnectionStrings["FromAccountSqlite"].ConnectionString;
        }

        public SqlitePriceProvider(string web) { }

        public  bool DeletePriceAll()
        {
            //db.DeleteAll<Person>();
            using (var db = new SQLiteConnection(this.ConnectionString, true))
            {
                Console.WriteLine(db.DeleteAll<Price>());
                return true;
            }
        }

        public  bool DeletePriceGroupAll()
        {
            using (var db = new SQLiteConnection(this.ConnectionString, true))
            {
                Console.WriteLine(db.DeleteAll<PriceGroup>());
                return true;
            }
        }

        public  bool DeleteShortPriceAll()
        {
            using (var db = new SQLiteConnection(this.ConnectionString, true))
            {
                Console.WriteLine(db.DeleteAll<ShortPrice>());
                return true;
            }
        }

        public  List<Price> GetPrice()
        {
            using (var db = new SQLiteConnection(this.ConnectionString, true))
            {
                return db.Table<Price>().ToList();
            }
        }

        public  List<PriceGroup> GetPriceGroup()
        {
            using (var db = new SQLiteConnection(this.ConnectionString, true))
            {
                return db.Table<PriceGroup>().Where(x => x.Internet == true).ToList();
            }
        }

        public  List<PriceGroup> GetPriceGroupAll()
        {
            using (var db = new SQLiteConnection(this.ConnectionString, true))
            {
                return db.Table<PriceGroup>().ToList();
            }
        }

        public  List<ShortPrice> GetShortPrice()
        {
            using (var db = new SQLiteConnection(this.ConnectionString, true))
            {
                return db.Table<ShortPrice>().ToList();
            }
        }

        public  ShortPrice GetShortPriceById(int id)
        {
            using (var db = new SQLiteConnection(this.ConnectionString, true))
            {
                return db.Table<ShortPrice>().Where(x=>x.StockPriceGroupeID==id).FirstOrDefault();
            }
        }

        public  int InsertPrice(Price Price)
        {
            using (var db = new SQLiteConnection(this.ConnectionString, true))
            {
                return db.Insert(Price);
            }
        }

        public  int InsertPriceGroup(PriceGroup category)
        {
            using (var db = new SQLiteConnection(this.ConnectionString, true))
            {
                return db.Insert(category);
            }
        }

        public  int InsertShortPrice(ShortPrice ShortPrice)
        {
            using (var db = new SQLiteConnection(this.ConnectionString, true))
            {
                return db.Insert(ShortPrice);
            }
        }
    }
}
