using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.Models;
using Presentation.Helps;

namespace Presentation.Forms
{

    public partial class frmCustomer : Form
    {
        private Helps.EntityState customerState;
        private int _id = -1;
        private int _indexe = -1;

        public frmCustomer()
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
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ToActiveButtons();
            customerState = EntityState.Add;
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            ToActiveButtons();
            if (_indexe < 0)
            {
                MessageBox.Show("Debe elegir un registro");
                return;
            }
            customerState = EntityState.Edit;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (DialogConfirm.GetDialogResult("Desea guardar los cambios", "Question").Equals(DialogResult.No))
            {
                return;
            }
            else
            {
                try
                {
                    var customerModel = new CustomerModel();
                    customerModel.IdCustomer = _id;
                    customerModel.Lastname = txtLastname.Text.Trim();
                    customerModel.Firstname = txtFirstname.Text;
                    customerModel.Birthday = dtpBirthday.Value;
                    customerModel.Gender = txtGender.Text;
                    customerModel.Document = mtbCID.Text;
                    customerModel.Phone = mtbPhome.Text;
                    customerModel.CustomerAddress = txtDireccion.Text;
                    customerModel.Note = txtNotas.Text;

                    SaveChanges(customerState, customerModel);
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2601 || ex.Number == 2627)
                    {
                        MessageBox.Show("ya tiene una Cedula registra con este mismo nuemero, la cedula de identidad no se puede duplicar");
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                finally
                {
                    ClearFields();
                    GetCustomer();
                }
            }
            ToBlockButtons();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (DialogConfirm.GetDialogResult("¿Está seguro qué desea cancelar la operación?", "Question").Equals(DialogResult.No))
            {
                return;
            }
            ClearFields();
            ToBlockButtons();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_indexe < 0)
            {
                MessageBox.Show("Debe seleccionar un registro");
                return;
            }
            customerState = EntityState.Delete;
            btnGuardar_Click(this, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Desea salir del formulario actual??", "Pregunta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResult.Equals("Ok"))
            {
                // frmDashBoard frmDashBoard = new frmDashBoard();
                Application.Exit();
            }
        }

        private void SaveChanges(EntityState entityState, CustomerModel customerModel)
        {
            switch (entityState)
            {
                case EntityState.Add:
                    customerModel.InsertCustomer();
                    break;
                case EntityState.Edit:
                    customerModel.EditCustomer();
                    break;
                case EntityState.Delete:
                    customerModel.DeleteCustomer();
                    break;
                default:
                    DialogConfirm.GetDialogResult("Debe Seleccionar la operación a realizar", "Exclamation");
                    break;
            }
        }

        // ------------------------ Method Ayuda
        private void ToActiveButtons()
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

        private void ToBlockButtons()
        {
            panelTextBox.Enabled = false;
            btnBuscar.Enabled = false;
            txtBuscar.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;

            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            txtFirstname.Focus();
        }

        private void ClearFields()
        {
            _id = -1;
            _indexe = -1;
            txtLastname.Clear();
            txtFirstname.Clear();
            dtpBirthday.Value = DateTime.Now;
            txtGender.Clear();
            mtbCID.Clear();
            mtbPhome.Clear();
            txtDireccion.Clear();
            txtNotas.Clear();
        }

        private void dgvCustomer_Click(object sender, EventArgs e)
        {
            SelectRow();
        }

        private void SelectRow()
        {
            _indexe = Convert.ToInt32(dgvCustomer.CurrentRow.Index.ToString());
            _id = Convert.ToInt32(dgvCustomer.CurrentRow.Cells["IdCustomer"].Value.ToString());
            txtFirstname.Text = dgvCustomer.CurrentRow.Cells["Firstname"].Value.ToString().TrimEnd();
            txtLastname.Text = dgvCustomer.CurrentRow.Cells["Lastname"].Value.ToString().TrimEnd();
            dtpBirthday.Value = Convert.ToDateTime(dgvCustomer.CurrentRow.Cells["Birthday"].Value.ToString());
            txtGender.Text = dgvCustomer.CurrentRow.Cells["Gender"].Value.ToString().TrimEnd();
            mtbCID.Text = dgvCustomer.CurrentRow.Cells["Document"].Value.ToString().TrimEnd();
            mtbPhome.Text = dgvCustomer.CurrentRow.Cells["Phone"].Value.ToString().TrimEnd();
            txtDireccion.Text = dgvCustomer.CurrentRow.Cells["CustomerAddress"].Value.ToString().TrimEnd();
            txtNotas.Text = dgvCustomer.CurrentRow.Cells["Note"].Value.ToString().TrimEnd();
        }
    }
}
