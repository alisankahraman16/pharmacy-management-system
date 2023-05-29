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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        static string constring = ("Data Source=DESKTOP-D3I3BR1\\SQLEXPRESS;Initial Catalog=eczane;Integrated Security=True");
        SqlConnection baglan = new SqlConnection(constring);
        private void Form6_Load(object sender, EventArgs e)
        {

        }
        public void personel_göster()
        {
            string getir_personel = "Select * from personel";

            SqlCommand komut_pers = new SqlCommand(getir_personel, baglan);
            SqlDataAdapter ad_pers = new SqlDataAdapter(komut_pers);

            DataTable dt_pers = new DataTable();
            ad_pers.Fill(dt_pers);
            dataGridView1.DataSource = dt_pers;
            baglan.Close();

        }

        public void personel_sil(int id)
        {
            string sil = "Delete From personel where personel_id = @persid";
            SqlCommand komut4 = new SqlCommand(sil, baglan);
            baglan.Open();
            komut4.Parameters.AddWithValue("@persid", id);

            komut4.ExecuteNonQuery();
            baglan.Close();
        }

        private void perskaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)
                {
                    baglan.Open();
                    string kayit = "insert into personel (personel_id,pers_ad,pers_soyad,pers_tel,pers_isealim,kullanici_adi,sifre)values(@personel_id," +
                        "@pers_ad, @persoyad, @perstel, @perstarih, @kullanici, @sifre)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);

                    komut.Parameters.AddWithValue("@personel_id", richTextBox1.Text);
                    komut.Parameters.AddWithValue("@pers_ad", richTextBox2.Text);
                    komut.Parameters.AddWithValue("@persoyad", richTextBox7.Text);
                    komut.Parameters.AddWithValue("@perstel", richTextBox3.Text);
                    komut.Parameters.AddWithValue("@perstarih", richTextBox4.Text);
                    komut.Parameters.AddWithValue("@kullanici", richTextBox5.Text);
                    komut.Parameters.AddWithValue("@sifre", richTextBox6.Text);



                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı");



                }
            }

            catch (Exception hata)
            {
                MessageBox.Show("Bir hata Var!" + hata.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            personel_göster();
        }

        private void perssil_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                personel_sil(id);
                personel_göster();


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            baglan.Open();
            string personel_guncel = ("Update personel Set pers_ad = @persad,pers_soyad = @persoyad," +
                "pers_tel = @perstel, pers_isealim = @tarih, kullanici_adi = @kullanici, sifre = @sifre where personel_id = @id");

            SqlCommand komut6 = new SqlCommand(personel_guncel, baglan);
            komut6.Parameters.AddWithValue("@personel_id", richTextBox1.Text);
            komut6.Parameters.AddWithValue("@persad", richTextBox2.Text);
            komut6.Parameters.AddWithValue("@persoyad", richTextBox7.Text);
            komut6.Parameters.AddWithValue("@perstel", richTextBox3.Text);
            komut6.Parameters.AddWithValue("@tarih", richTextBox4.Text);
            komut6.Parameters.AddWithValue("@kullanici", richTextBox5.Text);
            komut6.Parameters.AddWithValue("@sifre", richTextBox6.Text);

            komut6.ExecuteNonQuery();
            MessageBox.Show("Kayıtlar başarıyla güncellendi");
            baglan.Close();
            personel_göster();
        }
        int i = 0;

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            i = e.RowIndex;
            richTextBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            richTextBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            richTextBox7.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            richTextBox3.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            richTextBox4.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            richTextBox5.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            richTextBox6.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
        }
    }
}
