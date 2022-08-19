using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apresentacao
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length != 0)
            {
                Application.Run(new FrmLogin());
            }

            else
            {
               Application.Run(new FrmSplash());
                //Application.Run(new FrmPagamento());
            }
            //Application.Run(new FrmClienteCadastro());
            //Application.Run(new FrmSelecaoCliente());
        }
    }
}
