using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;


namespace Presentation.Forms
{
    public partial class frmEmployee : Form
    {
        private DEmployee objDEmployee = new DEmployee();

        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            GetProduct();
        }

        private void GetProduct()
        {
            dgvEmployee.DataSource = objDEmployee.GetProducto();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                objDEmployee.InsertData();
                MessageBox.Show("Datos insertados");
            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }
            finally
            {
                GetProduct();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                objDEmployee.EdiRecord();
                MessageBox.Show("Datos insertados");
            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }
            finally
            {
                GetProduct();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                objDEmployee.DeleteRecord();
                MessageBox.Show("Datos insertados");
            }
            catch (Exception)
            {
                MessageBox.Show("error");
            }
            finally
            {
                GetProduct();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int poscEnteroA = 0, poscEnteroB = 1, sumaPoscAB = 1;
            string result = string.Empty;
            for (int i = 0; i < 20; i++)
            {
                listBox1.Items.Add(sumaPoscAB);
                sumaPoscAB = poscEnteroA + poscEnteroB;
                poscEnteroA = poscEnteroB;
                poscEnteroB = sumaPoscAB;
            }
            //long a = 0, b = 1, aux;
            //long[] result = new long[100];
            //string _result = string.Empty;
            //for (int i = 0; i < 100; i++)
            //{
            //    aux = a;
            //    a = b;
            //    b = aux + a;
            //    result[i] = a;
            //} 


        }
    }
}
