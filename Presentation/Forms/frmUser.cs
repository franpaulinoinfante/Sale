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
    public partial class frmUser : Form
    {
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
            dgvUser.DataSource = userModel.GetUsers();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            panelTextBox.Enabled = true;
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            panelTextBox.Enabled = true;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            panelTextBox.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelTextBox.Enabled = false;
        }
    }
}
