using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Eczane2
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        static string constring = ("Data Source=DESKTOP-D3I3BR1\\SQLEXPRESS;Initial Catalog=eczane;Integrated Security=True");
        SqlConnection baglan = new SqlConnection(constring);

        private void Form7_Load(object sender, EventArgs e)
        {

        }
        public void sorgu1_göster()
        {
            string getir_sorgu1 = "SELECT d.dr_ad, a.alan_ad, h.hastane_ad FROM doktor d INNER JOIN alan a ON d.alan_id = a.alan_id INNER JOIN hastane h ON d.hastane_id = h.hastane_id;";

            SqlCommand komut_sorgu1 = new SqlCommand(getir_sorgu1, baglan);
            SqlDataAdapter ad_sorgu1 = new SqlDataAdapter(komut_sorgu1);

            DataTable dt_sorgu1 = new DataTable();
            ad_sorgu1.Fill(dt_sorgu1);
            dataGridView1.DataSource = dt_sorgu1;
            baglan.Close();

        }

        private void sorgu1_Click(object sender, EventArgs e)
        {
            sorgu1_göster();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kayit1 = "SELECT f.firma_ad, i.ilac_ad FROM ilac i INNER JOIN firma f ON i.firma_id = f.firma_id;";
            SqlCommand komut2 = new SqlCommand(kayit1, baglan);

            komut2.Parameters.AddWithValue("@alanad", textBox1.Text);
            SqlDataAdapter da4 = new SqlDataAdapter(komut2);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            dataGridView2.DataSource = dt4;
            baglan.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
        }
    }
}
