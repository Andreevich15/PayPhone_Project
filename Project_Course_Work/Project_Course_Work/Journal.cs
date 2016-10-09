using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project_Course_Work
{
    public partial class Journal : Form
    {
        public Journal()
        {
            InitializeComponent();
        }
        private void Read_File()
        {
            using (StreamReader read = File.OpenText("Call_journal.txt"))
            {
                string line;
                while ((line = read.ReadLine()) != null)
                {
                    Journalinfo.AppendText(line + '\n');
                }
            }
        }

        private void Journal_Load(object sender, EventArgs e)
        {
            Read_File();
        }
    }
}
