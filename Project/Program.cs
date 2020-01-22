using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project.PresentationLayer;

namespace Project
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.C:\Users\USER\Desktop\DEMO 1 Fianl\Project\Project\PresentationLayer\Chu.cs
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new  Login());



         
        }
    }
}
