using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correo_Electronico
{
    public class Usuario
    {
        public string nombre { get; set; }
        public string contraseña { get; set; }
        public ListaEmails enviados { get; set; }
        public ListaEmails recibidos { get; set; }
        public ListaUsuarios agenda { get; set; }
        public Usuario()
        {
            enviados = new ListaEmails();
            recibidos = new ListaEmails();
            agenda = new ListaUsuarios();
        }
    }
    public class ListaUsuarios
    {
        public List<Usuario> lst { get; set; }
        public ListaUsuarios()
        {
            lst = new List<Usuario>();
        }
    }
}
