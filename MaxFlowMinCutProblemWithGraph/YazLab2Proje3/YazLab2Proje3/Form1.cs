using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace YazLab2Proje3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] musluk = { "A", "B", "C", "D", "E", "F", "G", "H", "J", "K"};
        List<int> list1 = new List<int>();
        string[] muslukliste = new string[10];
        int k = 0;
        string[] secilenlertxt = new string[50];
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            sinif.muslukSay = Convert.ToInt32(comboBox1.Text);
            for (int a = 0; a < sinif.muslukSay; a++)
            {
                listBox1.Items.Add(musluk[a]);
                muslukliste[a] += musluk[a];
                sinif.muslukliste[a] = muslukliste[a];
            }
            for (int i = 0; i < sinif.muslukSay * sinif.muslukSay; i++)
            {
                list1.Add(0);
            }
        }
        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            for (int i = 0; i < sinif.muslukSay; i++)
            {
                string kenar = listBox1.SelectedItem + musluk[i];
                if (musluk[i] != listBox1.SelectedItem.ToString())
                {
                    checkedListBox1.Items.Add(kenar);
                }
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            sinif.kenar = new int[sinif.muslukSay, sinif.muslukSay];
            int z = 0;
            for (int i = 0; i < sinif.muslukSay; i++)
            {
                for (int j = 0; j < sinif.muslukSay; j++)
                {
                    sinif.kenar[i, j] = list1[z];
                    z++;
                }
            }
            textBox2.Text = sinif.fordFulkerson(sinif.kenar, Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), sinif.muslukSay).ToString();
        }
        int t = 0;
        int secilenler = 0;
        private void button2_Click_1(object sender, EventArgs e)
        {
            foreach (object itemChecked in checkedListBox1.CheckedItems)
            {
                secilenlertxt[t] += itemChecked.ToString();
                sinif.secilenlertxt[t] += secilenlertxt[t];
                t++;
            }

            if (checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex))
            {
                if (listBox1.SelectedIndex > checkedListBox1.SelectedIndex)
                {
                    list1[listBox1.SelectedIndex * sinif.muslukSay + checkedListBox1.SelectedIndex] = Convert.ToInt32(textBox1.Text);
                    sinif.dizi[k] = list1[listBox1.SelectedIndex * sinif.muslukSay + checkedListBox1.SelectedIndex].ToString();
                    k++;
                    secilenler++;
                    sinif.secilenler = secilenler;
                    textBox1.Text = "";
                }
                else
                {
                    list1[listBox1.SelectedIndex * sinif.muslukSay + checkedListBox1.SelectedIndex + 1] = Convert.ToInt32(textBox1.Text);
                    sinif.dizi[k] = list1[listBox1.SelectedIndex * sinif.muslukSay + checkedListBox1.SelectedIndex + 1].ToString();
                    k++;
                    secilenler++;
                    sinif.secilenler = secilenler;
                    textBox1.Text = "";
                }
            }

            while (checkedListBox1.CheckedIndices.Count > 0)
            {
                checkedListBox1.SetItemChecked(checkedListBox1.CheckedIndices[0], false);
            }  
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Text = sinif.minCut(sinif.kenar, Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}