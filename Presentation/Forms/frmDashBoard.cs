using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Forms
{
    public partial class frmDashBoard : Form
    {
        public frmDashBoard()
        {
            InitializeComponent();
        }

        private void customerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCustomer frmCliente = new frmCustomer();
            this.Hide();
            frmCliente.Show();
        }

        private void userToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmUser frmUser = new frmUser();
            this.Hide();
            frmUser.Show();

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
