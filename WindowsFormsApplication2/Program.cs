using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Controle
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            System.Diagnostics.Process.Start("D:\\Sistema de Controle de Ambulancias\\pastaDTI.bat");
            Update updatando = new Update();
            updatando.up();
            if (updatando.Yn == true)
            {
                Environment.Exit(1);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CONTROLE());
        }
    }
}
