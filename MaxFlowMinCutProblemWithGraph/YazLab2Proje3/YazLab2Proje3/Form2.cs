using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace YazLab2Proje3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        int m = 0;
        private void Form2_Load(object sender, EventArgs e)
        {
            Microsoft.Msagl.GraphViewerGdi.GViewer grafekrani = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            Microsoft.Msagl.Drawing.Graph graf = new Microsoft.Msagl.Drawing.Graph("graph");

            string[] nodedizi = new string[50];
            string[] uzunlukdizi = new string[50];

            for (int i = 0; i < sinif.muslukSay; i++)
            {
                nodedizi[i] += sinif.MuslukListe[i];
                Debug.WriteLine(nodedizi[i]);
            }

            for (int i = 0; i < sinif.Secilenler; i++)
            {
                uzunlukdizi[i] = sinif.dizi[i];
                Debug.WriteLine(uzunlukdizi[i]);
            }

            for (int i = 0; i < sinif.muslukSay; i++)
            {
                graf.AddNode(nodedizi[i]);
                graf.FindNode(nodedizi[i]).Attr.FillColor = Microsoft.Msagl.Drawing.Color.SkyBlue;
                
            }

            for (int k = 0; k < sinif.Secilenler; k++)
            {
                Debug.WriteLine(sinif.SecilenlerTxt[k]);
                string kelime = sinif.SecilenlerTxt[k];
                char[] ayir = kelime.ToCharArray();
                //Debug.WriteLine(ayir[0]);
                //Debug.WriteLine(ayir[1]);
             if (uzunlukdizi[m] != null)
             {
               graf.AddEdge(ayir[0].ToString(), uzunlukdizi[m], ayir[1].ToString()).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
               m++;
               if (m == uzunlukdizi.Length)
               break;
             }
            }
            grafekrani.Graph = graf;
            this.Controls.Add(grafekrani);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}