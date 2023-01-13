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
    public partial class Login : Form
    {
        ListaEmails emails;
        ListaUsuarios usuarios;
        public Login(ListaEmails emails, ListaUsuarios usuarios)
        {
            InitializeComponent();
            this.emails = emails;
            this.usuarios = usuarios;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = usuarios.lst.Find(x => x.nombre == txtUsuario.Text && x.contraseña == txtContraseña.Text);
            if (usuario != null)
            {
                Principal frm = new Principal(emails, usuarios, usuario);
                frm.Show();
                txtContraseña.Clear();
                txtUsuario.Clear();
            }
            else
                MessageBox.Show("USUARIO O CONTRASEÑA INCORRECTOS");
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Registro frm = new Registro(emails, usuarios);
            frm.ShowDialog();
        }
    }
}
