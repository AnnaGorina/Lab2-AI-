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

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<string> sports; //виды спорта
            List<string> indexSport; //показатели здоровья у видов спорта

            List<string> ifRules;
            List<string> elseRules;

            List<string> index; //показатели здоровья для улучшения

            Database.isSport(out sports);
            Database.isIndexSport(out indexSport);

            Database.ifListRules(out ifRules);
            Database.elseListRules(out elseRules);

            Database.isIndex(out index);

            List<string> isIndex = new List<string>();

            for (int i = 0; i < index.Count; i++)
            {
                for (int j = 0; j < ifRules.Count; j++)
                {
                    if (index[i].Contains(ifRules[j]))
                    {
                        isIndex.Add(elseRules[j]);
                    }
                }
            }

            for (int i = 0; i < indexSport.Count; i++)
            {
                for (int j = 0; j < isIndex.Count; j++)
                {
                    if (indexSport[i].Contains(isIndex[j])) continue;
                    else
                    {
                        sports.RemoveAt(i);
                        indexSport.RemoveAt(i);
                        i--;
                        break;
                    }
                }
            }

            if (sports.Count > 0)
            {
                Form4 form4 = new Form4(sports);
                form4.Show();
            } 
            else
            {
                MessageBox.Show("Нет подходящих видов спорта!");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                List<string> healthInput = new List<string>(textBox1.Text.Split(' '));

                while (healthInput.IndexOf("") != -1) healthInput.Remove("");

                indexHealth.Items.Add(textBox1.Text);

                Database.addIndex(textBox1.Text);

                textBox1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Database.removeIndex(indexHealth.SelectedItem.ToString());
            indexHealth.Items.Remove(indexHealth.SelectedItem.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();

            
        }
    }
}
