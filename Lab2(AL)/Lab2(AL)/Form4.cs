using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_AL_
{
    public partial class Form4 : Form
    {
        private List<string> sports;

        public Form4(List<string> sports)
        {
            this.sports = sports;
            InitializeComponent();
            for (int i = 0; i < sports.Count; i++)
            {
                this.listBox1.Items.Add(sports[i]);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
