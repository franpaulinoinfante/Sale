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
    public partial class frmUser : Form
    {
        private EntityState userState;
        private int _id;
        private int _indixe = -1;

        public frmUser()
        {
            InitializeComponent();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            GetUsers();
        }

        private void GetUsers()
        {
            UserModel userModel = new UserModel();
            try
            {
                dgvUser.DataSource = userModel.GetUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            panelTextBox.Enabled = true;
            userState = EntityState.Add;
            txtFirstname.Focus();
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (_indixe < 0)
            {
                MessageBox.Show("Debe elegir un registro");
                return;
            }

            panelTextBox.Enabled = true;
            userState = EntityState.Edit;
            SelectUser();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (DialogConfirm.GetDialogResult("¿Desea guardar los Cambios", "Question").Equals(DialogResult.No))
            {
                return;
            }
            else
            {
                try
                {
                    UserModel userModel = new UserModel();
                    userModel.IdUser = _id;
                    userModel.Lastname = txtLastname.Text;
                    userModel.Firstname = txtFirstname.Text;
                    userModel.Birthday = dtpBirthday.Value;
                    userModel.Gender = txtGender.Text;
                    userModel.Document = mtbCID.Text;
                    userModel.Phone = mtbPhome.Text;
                    userModel.UserAddress = txtAddress.Text;
                    userModel.Note = txtNotes.Text;

                    SaveChanges(userState, userModel);
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2601 || ex.Number == 2627)
                    {
                        MessageBox.Show("ya tiene una Cedula registra con este mismo nuemero, la cedula de identidad no se puede duplicar");
                        return;
                    }
                }
                finally
                {
                    GetUsers();
                }
            }
        }
        
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUser.SelectedRows.Count.Equals(0) /*||
                GetDialogResult("¿Está seguro qué desea eliminar el registro", "Question").Equals(DialogResult.No)*/)
            {
                return;
            }
            userState = EntityState.Delete;
            btnGuardar_Click_1(this, e);
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (DialogConfirm.GetDialogResult("¿Está seguro qué desea cancelar la operación?", "Question").Equals(DialogResult.No))
            {
                return;
            }
            panelTextBox.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = DialogConfirm.GetDialogResult("¿Está seguro qué desea salir?", "Question");
            if (dialogResult == DialogResult.Yes)
            {
                frmDashBoard frmDashBoard = new frmDashBoard();
                this.Close();
                frmDashBoard.Show();
            }
        }

        private void SaveChanges(EntityState operacion, UserModel userModel)
        {
            switch (operacion)
            {
                case EntityState.Add:
                    userModel.InsertUser();
                    break;
                case EntityState.Edit:
                    userModel.EditUser();
                    break;
                case EntityState.Delete:
                    userModel.DeleteUser();
                    break;
            }
        }
        
        private void dgvUser_DoubleClick(object sender, EventArgs e)
        {
            SelectUser();
        }


        private void SelectUser()
        {
            _indixe = Convert.ToInt32(dgvUser.CurrentRow.Index.ToString());
            _id = Convert.ToInt32(dgvUser.CurrentRow.Cells["IdUser"].Value.ToString());
            txtLastname.Text = dgvUser.CurrentRow.Cells["Lastname"].Value.ToString();
            txtFirstname.Text = dgvUser.CurrentRow.Cells["Firstname"].Value.ToString();
            dtpBirthday.Value = Convert.ToDateTime(dgvUser.CurrentRow.Cells["Birthday"].Value.ToString());
            txtGender.Text = dgvUser.CurrentRow.Cells["Gender"].Value.ToString();
            mtbCID.Text = dgvUser.CurrentRow.Cells["Document"].Value.ToString();
            mtbPhome.Text = dgvUser.CurrentRow.Cells["Phone"].Value.ToString();
            txtAddress.Text = dgvUser.CurrentRow.Cells["UserAddress"].Value.ToString();
            txtNotes.Text = dgvUser.CurrentRow.Cells["Note"].Value.ToString();
        }
    }
}
