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
    public partial class Form3 : Form
    {
        private string[] enumElse = { "ДС", "ССС", "зрение", "НС", "ОДА", "слабый иммунитет", "спина", "моторика", "вестибулярный аппарат" };
        public Form3()
        {
            InitializeComponent();

            List<string> isRules;
            List<string> elseRules;

            Database.ifListRules(out isRules);
            Database.elseListRules(out elseRules);

            for (int i = 0; i < isRules.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = isRules[i];
                item.SubItems.Add(elseRules[i]);

                Rules.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                List<string> IF = new List<string>(textBox1.Text.Split(' '));
                List<string> ELSE = new List<string>(textBox2.Text.Split(' '));

                while (IF.IndexOf("") != -1 && ELSE.IndexOf("") != -1)
                {
                    IF.Remove("");
                    ELSE.Remove("");
                }

                string[] massString = textBox2.Text.Split(',');

                bool a = true;

                for (int i = 0; i < massString.Length; i++)
                {
                    int count = 0;
                    for (int j = 0; j < enumElse.Length; j++)
                    {
                        if (massString[i] == enumElse[j]) count++;
                        if (j == enumElse.Length - 1 && count == 0)
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

                    Rules.Items.Add(item);

                    Database.addIfRules(textBox1.Text);
                    Database.addElseRules(textBox2.Text);

                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Database.removeIfRules(Rules.SelectedItems[0].Text);
            Database.removeElseRules(Rules.SelectedItems[0].SubItems[0].Text);

            Rules.Items.Remove(Rules.SelectedItems[0]);
        }

        private void Rules_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
