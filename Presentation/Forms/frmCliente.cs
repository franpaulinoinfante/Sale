using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.Models;

namespace Presentation.Forms
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            GetCustomer();
        }

        private void GetCustomer()
        {
            CustomerModel oCuscomerM = new CustomerModel();
            try
            {
                dgvCustomer.DataSource = oCuscomerM.GetCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            panelTextBox.Enabled = true;
            btnBuscar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnNuevo.Enabled = false;

            txtBuscar.Enabled = false;

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            txtFirstname.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            panelTextBox.Enabled = true;
            btnBuscar.Enabled = false;
            btnEliminar.Enabled = false;
            txtBuscar.Enabled = false;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            txtFirstname.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            panelTextBox.Enabled = false;
            btnCancelar.Enabled = false;
            btnGuardar.Enabled = false;

            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true ;
            btnBuscar.Enabled = true;

            txtBuscar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelTextBox.Enabled = false;

            btnBuscar.Enabled = true;
            btnEditar.Enabled = true;
            btnNuevo.Enabled = true;
            btnEliminar.Enabled = true;

            txtBuscar.Enabled = true;

            btnCancelar.Enabled = false;
            btnGuardar.Enabled = false;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            panelTextBox.Enabled = false;

            btnBuscar.Enabled = true;
            btnEditar.Enabled = true;
            btnNuevo.Enabled = true;
            btnEliminar.Enabled = true;
            btnEliminar.Enabled = true;
            txtBuscar.Enabled = true;

            btnCancelar.Enabled = false;
            btnGuardar.Enabled = false;
        }

        
    }
}
