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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        static string constring = ("Data Source=DESKTOP-D3I3BR1\\SQLEXPRESS;Initial Catalog=eczane;Integrated Security=True");
        SqlConnection baglan = new SqlConnection(constring);
        public void ilac_göster()
        {
            
            string getir = "Select * From ilac";

            SqlCommand komut = new SqlCommand(getir, baglan);
            SqlDataAdapter ad = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView2.DataSource = dt;
            baglan.Close();
        }

        public void firma_göster()
        {
            string getir_firma = "Select * from firma";

            SqlCommand komut_firma = new SqlCommand(getir_firma, baglan);
            SqlDataAdapter ad_firma = new SqlDataAdapter(komut_firma);

            DataTable dt_firma = new DataTable();
            ad_firma.Fill(dt_firma);
            dataGridView3.DataSource = dt_firma;
            baglan.Close();

        }

        public void firma_sil(int id)
        {
            string sil = "Delete From firma where firma_id = @firma_id";
            SqlCommand komut4 = new SqlCommand(sil, baglan);
            baglan.Open();
            komut4.Parameters.AddWithValue("@firma_id", id);

            komut4.ExecuteNonQuery();
            baglan.Close();
        }

        private void ilac_sil(int id2)
        {
            string sil2 = "Delete From ilac where ilac_id = @ilac_id";
            SqlCommand komut5 = new SqlCommand(sil2, baglan);
            baglan.Open();
            komut5.Parameters.AddWithValue("@ilac_id", id2);

            komut5.ExecuteNonQuery();
            baglan.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ilac_göster();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State==ConnectionState.Closed)
                {
                    baglan.Open();
                    string kayit = "insert into ilac (ilac_id,ilac_ad,kullanim_gün,ilac_fiyat,firma_id)values(@ilac_id,"+
                        "@ilac_ad,@kullanim_gün,@ilac_fiyat,@firma_id)";


                    SqlCommand komut = new SqlCommand(kayit, baglan);

                    komut.Parameters.AddWithValue("@ilac_id", textBox1.Text);
                    komut.Parameters.AddWithValue("@ilac_ad", textBox2.Text);
                    komut.Parameters.AddWithValue("@kullanim_gün", textBox3.Text);
                    komut.Parameters.AddWithValue("@ilac_fiyat", textBox4.Text);
                    komut.Parameters.AddWithValue("@firma_id", textBox5.Text);
                    
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı");
                    


                }
            }

            catch(Exception hata)
            {
                MessageBox.Show("Bir hata Var!" + hata.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)
                {
                    baglan.Open();
                    string kayit_firma = "insert into firma (firma_id,firma_ad,firma_adres)values(@firma_id," +
                        "@firma_ad,@firma_adres)";


                    SqlCommand komut_firma = new SqlCommand(kayit_firma, baglan);

                    komut_firma.Parameters.AddWithValue("@firma_id", textBox6.Text);
                    komut_firma.Parameters.AddWithValue("@firma_ad", textBox7.Text);
                    komut_firma.Parameters.AddWithValue("@firma_adres", textBox8.Text);
                   

                    komut_firma.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı");


                }
            }

            catch (Exception hata)
            {
                MessageBox.Show("Bir hata Var!" + hata.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            firma_göster();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string kayit1 = "Select * from firma where firma_ad = @firmad";
            SqlCommand komut2 = new SqlCommand(kayit1, baglan);

            komut2.Parameters.AddWithValue("@firmad",textBox9.Text);
            SqlDataAdapter da3 = new SqlDataAdapter(komut2);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            dataGridView3.DataSource = dt3;
            baglan.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView3.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                firma_sil(id);
                firma_göster();
                

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView2.SelectedRows)
            {
                int id2 = Convert.ToInt32(drow.Cells[0].Value);
                ilac_sil(id2);
                ilac_göster();


            }
        }
        int i = 0;
        private void button9_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string ilac_guncel = ("Update ilac Set ilac_ad = @ilacad,kullanim_gün = @gun,"+
                "ilac_fiyat = @fiyat where ilac_id = @id");
            
            SqlCommand komut6 = new SqlCommand(ilac_guncel, baglan);
            komut6.Parameters.AddWithValue("@id", textBox1.Text);
            komut6.Parameters.AddWithValue("@ilacad", textBox2.Text);
            komut6.Parameters.AddWithValue("@gun", textBox3.Text);
            komut6.Parameters.AddWithValue("@fiyat", textBox4.Text);
            



            komut6.ExecuteNonQuery();
            MessageBox.Show("Kayıtlar başarıyla güncellendi");
            baglan.Close();
            ilac_göster();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            string kayit1 = "Select * from ilac where ilac_ad = @ilacad";
            SqlCommand komut2 = new SqlCommand(kayit1, baglan);

            komut2.Parameters.AddWithValue("@ilacad", textBox10.Text);
            SqlDataAdapter da4 = new SqlDataAdapter(komut2);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            dataGridView2.DataSource = dt4;
            baglan.Close();
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            i = e.RowIndex;
            textBox1.Text = dataGridView2.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dataGridView2.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = dataGridView2.Rows[i].Cells[2].Value.ToString();
            textBox4.Text = dataGridView2.Rows[i].Cells[3].Value.ToString();
            

        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            i = e.RowIndex;
            textBox6.Text = dataGridView3.Rows[i].Cells[0].Value.ToString();
            textBox7.Text = dataGridView3.Rows[i].Cells[1].Value.ToString();
            textBox8.Text = dataGridView3.Rows[i].Cells[2].Value.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string firma_guncel = ("Update firma Set firma_ad = @firmaad," +
                "firma_adres = @adres where firma_id = @id");

            SqlCommand komut6 = new SqlCommand(firma_guncel, baglan);
            komut6.Parameters.AddWithValue("@id", textBox6.Text);
            komut6.Parameters.AddWithValue("@firmaad", textBox7.Text);
            komut6.Parameters.AddWithValue("@adres", textBox8.Text);
            




            komut6.ExecuteNonQuery();
            MessageBox.Show("Kayıtlar başarıyla güncellendi");
            baglan.Close();
            firma_göster();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
