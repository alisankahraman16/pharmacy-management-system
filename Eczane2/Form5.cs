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

namespace Eczane2
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        static string constring = ("Data Source=DESKTOP-D3I3BR1\\SQLEXPRESS;Initial Catalog=eczane;Integrated Security=True");
        SqlConnection baglan = new SqlConnection(constring);


        public void cins_göster()
        {
            string getir_cins = "Select * from cinsiyet";

            SqlCommand komut_cinsiyet = new SqlCommand(getir_cins, baglan);
            SqlDataAdapter ad_cinsiyet = new SqlDataAdapter(komut_cinsiyet);

            DataTable dt_cinsiyet = new DataTable();
            ad_cinsiyet.Fill(dt_cinsiyet);
            dataGridView1.DataSource = dt_cinsiyet;
            baglan.Close();

        }

        public void recete_göster()
        {
            string getir_recete = "Select * from recete";

            SqlCommand komut_recete = new SqlCommand(getir_recete, baglan);
            SqlDataAdapter ad_recete = new SqlDataAdapter(komut_recete);

            DataTable dt_recete = new DataTable();
            ad_recete.Fill(dt_recete);
            dataGridView2.DataSource = dt_recete;
            baglan.Close();

        }

        public void hasta_göster()
        {
            string getir_hasta = "SELECT  h.h_ad, h.h_soyad, c.cinsiyet_ad FROM hasta h INNER JOIN cinsiyet c ON h.cinsiyet_id = c.cinsiyet_id";

            SqlCommand komut_hasta = new SqlCommand(getir_hasta, baglan);
            SqlDataAdapter ad_hasta = new SqlDataAdapter(komut_hasta);

            DataTable dt_hasta = new DataTable();
            ad_hasta.Fill(dt_hasta);
            dataGridView3.DataSource = dt_hasta;
            baglan.Close();

        }

        public void hasta_sil(int id)
        {
            string sil = "Delete From hasta where hasta_id = @hid";
            SqlCommand komut4 = new SqlCommand(sil, baglan);
            baglan.Open();
            komut4.Parameters.AddWithValue("@hid", id);

            komut4.ExecuteNonQuery();
            baglan.Close();
        }

        private void cinskayıt_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)
                {
                    baglan.Open();
                    string kayit = "insert into cinsiyet (cinsiyet_id,cinsiyet_ad)values(@cinsid," +
                        "@cinsad)";


                    SqlCommand komut = new SqlCommand(kayit, baglan);

                    komut.Parameters.AddWithValue("@cinsid", textBox1.Text);
                    komut.Parameters.AddWithValue("@cinsad", textBox2.Text);


                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı");



                }
            }

            catch (Exception hata)
            {
                MessageBox.Show("Bir hata Var!" + hata.Message);
            }
        }

        private void Cinsgoruntu_Click(object sender, EventArgs e)
        {
            cins_göster();
        }

        private void recetegoryntu_Click(object sender, EventArgs e)
        {
            recete_göster();
        }

        private void recetekayt_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)
                {
                    baglan.Open();
                    string kayit = "insert into recete (rct_id,yazan_doktor_id,hastaid,tarih,satan_pers_id,ilac_id)values(@recid," +
                        "@doktorid, @hastaid, @tarih, @persid, @ilacid)";


                    SqlCommand komut = new SqlCommand(kayit, baglan);

                    komut.Parameters.AddWithValue("@recid", textBox3.Text);
                    komut.Parameters.AddWithValue("@doktorid", textBox4.Text);
                    komut.Parameters.AddWithValue("@hastaid", textBox5.Text);
                    komut.Parameters.AddWithValue("@tarih", textBox6.Text);
                    komut.Parameters.AddWithValue("@persid", textBox7.Text);
                    komut.Parameters.AddWithValue("@ilacid", textBox8.Text);


                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı");



                }
            }

            catch (Exception hata)
            {
                MessageBox.Show("Bir hata Var!" + hata.Message);
            }
        }

        private void hastagoruntu_Click(object sender, EventArgs e)
        {
            hasta_göster();
        }

        int i = 0;
        private void hastakayıt_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)
                {
                    baglan.Open();
                    string kayit = "insert into hasta (hasta_id,h_ad,h_soyad,cinsiyet_id,telefon,email,adres,TC_no)values(@hastaid," +
                        "@had, @hsoyad, @cinid, @telefon, @email, @adres, @tc)";


                    SqlCommand komut = new SqlCommand(kayit, baglan);

                    komut.Parameters.AddWithValue("@hastaid", textBox9.Text);
                    komut.Parameters.AddWithValue("@had", textBox10.Text);
                    komut.Parameters.AddWithValue("@hsoyad", textBox11.Text);
                    komut.Parameters.AddWithValue("@cinid", textBox12.Text);
                    komut.Parameters.AddWithValue("@telefon", textBox13.Text);
                    komut.Parameters.AddWithValue("@email", textBox14.Text);
                    komut.Parameters.AddWithValue("@adres", textBox15.Text);
                    komut.Parameters.AddWithValue("@tc", textBox16.Text);



                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı");



                }
            }

            catch (Exception hata)
            {
                MessageBox.Show("Bir hata Var!" + hata.Message);
            }
        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            i = e.RowIndex;
            textBox9.Text = dataGridView3.Rows[i].Cells[0].Value.ToString();
            textBox10.Text = dataGridView3.Rows[i].Cells[1].Value.ToString();
            textBox11.Text = dataGridView3.Rows[i].Cells[2].Value.ToString();
            textBox12.Text = dataGridView3.Rows[i].Cells[3].Value.ToString();
            textBox13.Text = dataGridView3.Rows[i].Cells[4].Value.ToString();
            textBox14.Text = dataGridView3.Rows[i].Cells[5].Value.ToString();
            textBox15.Text = dataGridView3.Rows[i].Cells[6].Value.ToString();
            textBox16.Text = dataGridView3.Rows[i].Cells[7].Value.ToString();

        }

        private void hastasil_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView3.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                hasta_sil(id);
                hasta_göster();


            }
        }

        private void menudon_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
