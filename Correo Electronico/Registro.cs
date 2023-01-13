using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Correo_Electronico
{
    public partial class Registro : Form
    {
        ListaEmails emails;
        ListaUsuarios usuarios;
        public Registro(ListaEmails emails, ListaUsuarios usuarios)
        {
            InitializeComponent();
            this.emails = emails;
            this.usuarios = usuarios;
        }

        private void btnRegristrar_Click(object sender, EventArgs e)
        {
            if (usuarios.lst.Find(x => x.nombre == txtUsuario.Text) == null)
            {
                if (txtContraseña1.Text == txtContraseña2.Text)
                {
                    Usuario nuevo = new Usuario();
                    nuevo.nombre = txtUsuario.Text;
                    nuevo.contraseña = txtContraseña1.Text;

                    usuarios.lst.Add(nuevo);

                    MessageBox.Show("USUARIO REGISTRADO CON ÉXITO");
                    this.Close();
                }
                else
                    MessageBox.Show("LAS CONTRASEÑAS NO SON IGUALES");
            }
            else
                MessageBox.Show("NOMBRE DE USUARIO YA REGISTRADO");
        }
    }
}
