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
   public partial class Form2 : Form
    {
        private string[] enumIndex = { "ССС", "ДС", "ОДА", "зрение", "слабый иммунитет", "спина", "НС", "вестибулярный аппарат", "моторика" };
        public Form2()
        {
            InitializeComponent();

            List<string> sports;
            List<string> index;

            Database.isSport(out sports);
            Database.isIndexSport(out index);

            for (int i = 0; i < sports.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = sports[i];
                item.SubItems.Add(index[i]);

                Sports.Items.Add(item);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Database.removeSport(Sports.Items[0].Text);
            Database.removeIndexSport(Sports.Items[0].SubItems[0].Text);

            Sports.Items.Remove(Sports.SelectedItems[0]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                List<string> sports = new List<string>(textBox1.Text.Split(' '));
                List<string> health = new List<string>(textBox2.Text.Split(' '));

                while (sports.IndexOf("") != -1 && health.IndexOf("") != -1)
                {
                    sports.Remove("");
                    health.Remove("");
                }

                

                string[] massString = textBox2.Text.Split(',');

                bool a = true;

                for (int i = 0; i < massString.Length; i++)
                {
                    int count = 0;
                    for (int j = 0; j < enumIndex.Length; j++)
                    {
                        if (massString[i] == enumIndex[j]) count++;
                        if (j == enumIndex.Length - 1 && count == 0)
                        {
                            textBox1.Clear();
                            textBox2.Clear();
                            MessageBox.Show("Недопустимый ввод!");
                            a = false;
                        }
                    }
                }

                if (a == true)
                {
                    ListViewItem item = new ListViewItem();

                    item.Text = textBox1.Text;
                    item.SubItems.Add(textBox2.Text);

                    Sports.Items.Add(item);

                    Database.addSport(textBox1.Text);
                    Database.addIndexSport(textBox2.Text);

                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
        }
    }
}
