using AccountSolution.FromAccountClassLibrary.Entities;
using AccountSolution.SqliteClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountSolution.ExIm77;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Trade();
            //Bill bill = new Bill();
            //BillLine billLine = new BillLine();
            SQLiteBillProvider sQLiteBillProvider = new SQLiteBillProvider();
            foreach (var item in sQLiteBillProvider.GetBill())
            {
                Console.WriteLine("{0} - {1} | {2}", item.OrderGuid, item.DateDoc.ToString("dd-MM-yyyy"), item.DeliveryName);
                //foreach (var itemDet in sQLiteBillProvider.ge)
                //{

                //}
            }
        }

        public static void Trade()
        {
            try
            {
                Trade trade = new Trade();
                //Console.ReadKey();
                if (trade.blGood)
                {
                    //exIm77.BillMove();
                    trade.BillMove("16.09.2019", "21.09.2019");
                }
                else
                {
                    Console.WriteLine("Not open!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
