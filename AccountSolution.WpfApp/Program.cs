﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AccountSolution.WpfApp
{
    class Program
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.StartupUri = new Uri("MainPage.xaml", UriKind.Relative);
            app.Run();
        }
    }
}
