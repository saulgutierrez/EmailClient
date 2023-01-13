using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correo_Electronico
{
    public class Email
    {
        public Usuario remitente { get; set; }
        public Usuario destinatario { get; set; }
        public string asunto { get; set; }
        public string mensaje { get; set; }
        public DateTime fecha { get; set; }
    }
    public class ListaEmails
    {
        public List<Email> lst { get; set; }

        public ListaEmails()
        {
            lst = new List<Email>();
        }
    }
}
