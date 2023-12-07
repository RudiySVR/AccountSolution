using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountSolution.ExIm77;

namespace AccountSolution.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string switch_on="";
            //Console.WriteLine(Directory.GetCurrentDirectory());
            if (args == null)
            {
                Console.WriteLine("args is null");
            }
            else
            {
                Console.Write("args length is ");
                Console.WriteLine(args.Length);
                for (int i = 0; i < args.Length; i++)
                {
                    string argument = args[i];
                    Console.Write("args index ");
                    Console.Write(i); // Write index
                    Console.Write(" is [");
                    Console.Write(argument); // Write string
                    Console.WriteLine("]");
                }
                try
                {
                    switch_on = args[0];
                }
                catch (Exception ex)
                {
                    Console.WriteLine("===============" + ex.Message);
                    //throw;
                }
            }
            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }
            //string switch_on=Console.ReadKey().KeyChar.ToString();
            //Console.WriteLine("");
            //Console.WriteLine(switch_on);
            switch (switch_on)
            {
                case "1":
                    Count();
                    break;
                default:
                    Console.WriteLine("By default");
                    break;
            }
            //Console.ReadKey();
        }

        public static void Count()
        {
            try
            {
                Price exIm77 = new Price();
                //Console.ReadKey();
                if (exIm77.blGood)
                {
                    //exIm77.BillMove();
                    exIm77.ShortPriceMove();
                    exIm77.MoveDetPrice();
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
