using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CROUDClientesConsumidorServidorWeb
{
    public partial class Formulario : Form
    {
        DataTable tableClients = new DataTable();
        public Formulario()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            localhost.CROUDClientesService objeto = new localhost.CROUDClientesService();

            tableClients = objeto.MostrarClientes();

            DateTime fechaActual = DateTime.Now;
            DateTime fechaDesde;

            dateFechaAfiliacion.Value = fechaActual;
            fechaDesde = fechaActual;

            fechaDesde = fechaDesde.AddDays(-fechaActual.Day + 1);
            fechaDesde = fechaDesde.AddMonths(-fechaActual.Month + 1);

            dateInicioBuscar.Value = fechaDesde;
            dateFinalBuscar.Value = fechaActual;

            dataGridView.Columns.Clear();
            dataGridView.DataSource = tableClients;

        }

        private void btnInsertarCliente_Click(object sender, EventArgs e)
        {
            int rowsAffected;
            localhost.CROUDClientesService objeto = new localhost.CROUDClientesService();

            rowsAffected=objeto.InsertarCliente(txtNombreCliente.Text,txtPrimerApellidoCliente.Text,txtSegundoApellidoCliente.Text);
            MessageBox.Show("Se ha añadido " + rowsAffected + " cliente.");
            tableClients = objeto.MostrarClientes();
            dataGridView.Columns.Clear();
            dataGridView.DataSource = tableClients;
        }

        private void btnDeleteClientById_Click(object sender, EventArgs e)
        {
            localhost.CROUDClientesService objeto = new localhost.CROUDClientesService();
            string resp;

            if (txtIdClienteBorrar.Text == null)
            {
                MessageBox.Show("Debes ingresar un id");
            }
            else
            {
                resp = objeto.EliminarCliente(Int32.Parse(txtIdClienteBorrar.Text));
                tableClients = objeto.MostrarClientes();
                dataGridView.Columns.Clear();
                dataGridView.DataSource = tableClients;
                MessageBox.Show(resp);
                
            }

        }

        private void btnSearchClients_Click(object sender, EventArgs e)
        {
            localhost.CROUDClientesService objeto = new localhost.CROUDClientesService();

            try
            {
                if (txtNombreClienteBuscar.Text == "")
                {
                    tableClients = objeto.MostrarClientes();
                }
                else
                {
                    tableClients = objeto.FiltrarClientes(txtNombreClienteBuscar.Text, dateInicioBuscar.Value, dateFinalBuscar.Value);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error al buscar el cliente. " + ex.ToString());
            }

            if (tableClients.Rows.Count > 0)
            {

                dataGridView.DataSource = tableClients;
            }
            else
            {
                MessageBox.Show("No se ha encontrado cliente.");
            }
        }

        private void txtIdClienteBorrar_TextChanged(object sender, EventArgs e)
        {
            var result = Regex.Replace(txtIdClienteBorrar.Text, @"[^""0-9""]", "");
            txtIdClienteBorrar.Text = result;
            txtIdClienteBorrar.Select(txtIdClienteBorrar.Text.Length, 0);
        }

        private void txtNombreCliente_TextChanged(object sender, EventArgs e)
        {
            var result = Regex.Replace(txtNombreCliente.Text, @"[^a-zA-ZñÑ\s]", "");
            txtNombreCliente.Text = result;
            txtNombreCliente.Select(txtNombreCliente.Text.Length, 0);
        }

        private void txtPrimerApellidoCliente_TextChanged(object sender, EventArgs e)
        {
            var result = Regex.Replace(txtPrimerApellidoCliente.Text, @"[^a-zA-ZñÑ\s]", "");
            txtPrimerApellidoCliente.Text = result;
            txtPrimerApellidoCliente.Select(txtPrimerApellidoCliente.Text.Length, 0);
        }

        private void txtSegundoApellidoCliente_TextChanged(object sender, EventArgs e)
        {
            var result = Regex.Replace(txtSegundoApellidoCliente.Text, @"[^a-zA-ZñÑ\s]", "");
            txtSegundoApellidoCliente.Text = result;
            txtSegundoApellidoCliente.Select(txtSegundoApellidoCliente.Text.Length, 0);

        }

        private void txtNombreClienteBuscar_TextChanged(object sender, EventArgs e)
        {
            var result = Regex.Replace(txtNombreClienteBuscar.Text, @"[^a-zA-ZñÑ\s]", "");
            txtNombreClienteBuscar.Text = result;
            txtNombreClienteBuscar.Select(txtNombreClienteBuscar.Text.Length, 0);
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateInicioBuscar_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
