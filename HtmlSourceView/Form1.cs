using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace HtmlSourceView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "HtmlSourceView";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Uri webUri = new Uri(textBox1.Text);

            WebClient client = new WebClient();
            try
            {
                Stream st = client.OpenRead(webUri);

                Encoding enc = Encoding.GetEncoding("UTF-8");
                StreamReader sr = new StreamReader(st, enc);
                string result = sr.ReadToEnd();

                textBox2.Text = result.Replace("\n", Environment.NewLine);
                sr.Close();
                st.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
