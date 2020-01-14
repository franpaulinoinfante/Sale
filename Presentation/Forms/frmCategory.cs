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
    public partial class frmCategory : Form
    {
        private Helps.EntityState entityState;
        private int _indixe = -1;
        private int _id = -1;

        public frmCategory()
        {
            InitializeComponent();
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            GetCategory();
        }

        private void GetCategory()
        {
            try
            {
                CategoryModel categoryModel = new CategoryModel();
                dgvCategory.DataSource = categoryModel.GetCategories();
            }
            catch (SqlException ex)
            {
                DialogConfirm.GetDialogResult(ex.Message, "Warning");
                return;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ToActiveButtons();
            entityState = EntityState.Add;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (_indixe < 0)
            {
                DialogResult dialogResult = DialogConfirm.GetDialogResult("Debe elegir un registro", "Exclamation");
                return;
            }
            ToActiveButtons();
            entityState = EntityState.Edit;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (DialogConfirm.GetDialogResult("Desea guardar los cambios?", "Question").Equals(DialogResult.No))
            {
                return;
            }

            try
            {
                var categoryModel = new CategoryModel();
                categoryModel.IdCategory = _id;
                categoryModel.Category = txtCategory.Text.Trim();

                SaveChanges(entityState, categoryModel);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2601 || ex.Number == 2627)
                {
                    DialogConfirm.GetDialogResult("No se puede ingresar registros duplicados", "Error");
                }
                else
                {
                    DialogConfirm.GetDialogResult(ex.Message, "Error");
                }
            }
            finally
            {
                GetCategory();
                ToBlockButtons();
            }
        }

        private void SaveChanges(Helps.EntityState entityState, CategoryModel categoryModel)
        {
            switch (entityState)
            {
                case EntityState.Add:
                    categoryModel.InsertCategory();
                    break;
                case EntityState.Edit:
                    categoryModel.EditCategory();
                    break;
                case EntityState.Delete:
                    categoryModel.RemoveCategory();
                    break;
                default:
                    DialogConfirm.GetDialogResult("Debe Seleccionar la operación a realizar", "Exclamation");
                    break;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_indixe<0)
            {
                DialogConfirm.GetDialogResult("Debe seleccionar un registro", "Exclamation");
                return;
            }
            entityState = EntityState.Delete;
            btnGuardar_Click(this, e);
            //ToBlockButtons();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (DialogConfirm.GetDialogResult("¿Está seguro qué desea cancelar la operación?", "Question").Equals(DialogResult.No))
            {
                return;
            }
            ToBlockButtons();
        }
        
        private void ToActiveButtons()
        {
            txtCategory.Enabled = true;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;

            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnNuevo.Enabled = false;

            txtCategory.Focus();
        }

        private void ToBlockButtons()
        {
            txtCategory.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            txtCategory.Enabled = false;

            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnNuevo.Enabled = true;

            txtCategory.Clear();
            _id = -1;
            _indixe = -1;   
        }

        private void dgvCategory_Click(object sender, EventArgs e)
        {
            _indixe = Convert.ToInt32(dgvCategory.CurrentRow.Index.ToString());
            _id = Convert.ToInt32(dgvCategory.CurrentRow.Cells["IdCategory"].Value.ToString());
            txtCategory.Text = dgvCategory.CurrentRow.Cells["Category"].Value.ToString().TrimEnd();
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
    }
}
