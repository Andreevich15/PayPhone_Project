using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Course_Work
{
    public partial class ReceiverCardForm : Form
    {
        private CardLimit delegate_for_translation;
        public ReceiverCardForm(CardLimit sender)
        {
            InitializeComponent();
            delegate_for_translation = sender;
        }

        private void Card40_Click(object sender, EventArgs e)
        {
            delegate_for_translation(40);
            this.Close();
        }

        private void Card60_Click(object sender, EventArgs e)
        {
            delegate_for_translation(60);
            this.Close();
        }

        private void Card90_Click(object sender, EventArgs e)
        {
            delegate_for_translation(90);
            this.Close();
        }

        private void Card180_Click(object sender, EventArgs e)
        {
            delegate_for_translation(180);
            this.Close();
        }
    }
}
