using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CROUDClientesConsumidorServidorWeb
{
    public partial class FormularioAcceso : Form
    {
        public FormularioAcceso()
        {
            InitializeComponent();
        }

        private void FormularioAcceso_Load(object sender, EventArgs e)
        {
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = tbUsuario.Text;
            string contraseña = tbContraseña.Text;
            if(usuario == "urcotes" && contraseña == "urcotes")
            {
                Formulario formulario = new Formulario();
                this.Visible = false;
                formulario.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Usuario o contraseña no válidos");
            }
        }
    }
}
