using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Helps
{
    public class DialogConfirm
    {
        public static DialogResult GetDialogResult(string message, string caption)
        {
            return MessageBox.Show($"{message}", $"{caption}", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }
    }
}
