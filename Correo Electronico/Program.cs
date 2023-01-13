using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Correo_Electronico
{
    static class Program
    {
        
        [STAThread]
        static void Main()
        {
            ListaEmails emails = new ListaEmails();
            ListaUsuarios usuarios = new ListaUsuarios();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login(emails, usuarios));
        }
    }
}
