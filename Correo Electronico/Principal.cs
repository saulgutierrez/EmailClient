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
    public partial class Principal : Form
    {
        ListaEmails emails;
        ListaUsuarios usuarios;
        Usuario usuario;
        public Principal(ListaEmails emails, ListaUsuarios usuarios, Usuario usuario)
        {
            InitializeComponent();
            this.emails = emails;
            this.usuarios = usuarios;
            this.usuario = usuario;
        }

        private void cbRedactar_CheckedChanged(object sender, EventArgs e)
        {
            txtAsunto.Clear();
            txtUsuario.Clear();
            rtxtMensaje.Clear();

            bool estado = cbRedactar.Checked;
            lbCorreos.Enabled = !estado;
            btnEnviar.Enabled = estado;
            lblFecha.Visible = !estado;
            comboBox1.Enabled = !estado;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (usuarios.lst.Find(x => x.nombre == txtUsuario.Text) != null)
            {
                Email nuevo = new Email();
                nuevo.destinatario = usuarios.lst.Find(x => x.nombre == txtUsuario.Text);
                nuevo.asunto = txtAsunto.Text;
                nuevo.mensaje = rtxtMensaje.Text;
                nuevo.fecha = DateTime.Now;
                nuevo.remitente = usuario;

                emails.lst.Add(nuevo);
                usuario.enviados.lst.Add(nuevo);
                nuevo.destinatario.recibidos.lst.Add(nuevo);

                txtAsunto.Clear();
                txtUsuario.Clear();
                rtxtMensaje.Clear();
            }
            else
                MessageBox.Show("EL USUARIO NO EXISTE");

        }

        private void Principal_Load(object sender, EventArgs e)
        {
            lblNombre.Text = usuario.nombre;
            LlenarListaCorreos(true);
        }





        private void LlenarListaCorreos(bool tipo)
        {
            lbCorreos.Items.Clear();
            if (tipo == true)
            {
                foreach (Email e in usuario.recibidos.lst)
                    lbCorreos.Items.Add(e.asunto);
            }
            else
            {
                foreach (Email e in usuario.enviados.lst)
                    lbCorreos.Items.Add(e.asunto);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
                LlenarListaCorreos(false);
            else
                LlenarListaCorreos(true);
        }

        private void lbCorreos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Email email = null;

            if (comboBox1.SelectedIndex == 0) // Enviados
                email = usuario.enviados.lst[lbCorreos.SelectedIndex];
            else    // Recibidos
                email = usuario.recibidos.lst[lbCorreos.SelectedIndex];
            

            if(email != null)
            {
                txtUsuario.Text = email.remitente.nombre;
                txtAsunto.Text = email.asunto;
                rtxtMensaje.Text = email.mensaje;
                lblFecha.Text = email.fecha.ToString();
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                LlenarListaCorreos(false);
            else
                LlenarListaCorreos(true);
        }
    }
}
