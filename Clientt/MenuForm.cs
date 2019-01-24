using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clientt
{
    public partial class MenuForm : Form
    {

        public MenuForm()
        {
            InitializeComponent();
        }

        private void singlePlayButton_Click(object sender, EventArgs e)
        {
            Hide();
            SinglePlayForm singlePlayForm = new SinglePlayForm();
            singlePlayForm.FormClosed += new FormClosedEventHandler(ChildForm_Closed);
            singlePlayForm.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        void ChildForm_Closed(object sender, FormClosedEventArgs e)
        {
            Show();
        }

        private void multiPlayButton_Click(object sender, EventArgs e)
        {
            Hide();
            MultPlayForm multiPlayForm = new MultPlayForm();
            multiPlayForm.FormClosed += new FormClosedEventHandler(ChildForm_Closed);
            multiPlayForm.Show();
        }
    }
}
