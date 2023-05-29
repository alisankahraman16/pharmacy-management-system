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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        static string constring = ("Data Source=DESKTOP-D3I3BR1\\SQLEXPRESS;Initial Catalog=eczane;Integrated Security=True");
        SqlConnection baglan = new SqlConnection(constring);

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void alan_göster()
        {
            string getir_alan = "Select * from alan";

            SqlCommand komut_alan = new SqlCommand(getir_alan, baglan);
            SqlDataAdapter ad_alan = new SqlDataAdapter(komut_alan);

            DataTable dt_alan = new DataTable();
            ad_alan.Fill(dt_alan);
            dataGridView1.DataSource = dt_alan;
            baglan.Close();

        }
        public void alan_sil(int id)
        {
            string sil = "Delete From alan where alan_id = @alan_id";
            SqlCommand komut4 = new SqlCommand(sil, baglan);
            baglan.Open();
            komut4.Parameters.AddWithValue("@alan_id", id);

            komut4.ExecuteNonQuery();
            baglan.Close();
        }

        public void hastane_göster()
        {
            string getir_hastane = "Select * from hastane";

            SqlCommand komut_hastane = new SqlCommand(getir_hastane, baglan);
            SqlDataAdapter ad_hastane = new SqlDataAdapter(komut_hastane);

            DataTable dt_hastane = new DataTable();
            ad_hastane.Fill(dt_hastane);
            dataGridView2.DataSource = dt_hastane;
            baglan.Close();

        }

        public void hastane_sil(int id)
        {
            string sil = "Delete From hastane where hastane_id = @hastane_id";
            SqlCommand komut4 = new SqlCommand(sil, baglan);
            baglan.Open();
            komut4.Parameters.AddWithValue("@hastane_id", id);

            komut4.ExecuteNonQuery();
            baglan.Close();
        }

        public void doktor_göster()
        {
            string getir_doktor = "Select * from doktor";

            SqlCommand komut_doktor = new SqlCommand(getir_doktor, baglan);
            SqlDataAdapter ad_doktor = new SqlDataAdapter(komut_doktor);

            DataTable dt_doktor = new DataTable();
            ad_doktor.Fill(dt_doktor);
            dataGridView3.DataSource = dt_doktor;
            baglan.Close();

        }

        public void doktor_sil(int id)
        {
            string sil = "Delete From doktor where dr_id = @dr_id";
            SqlCommand komut4 = new SqlCommand(sil, baglan);
            baglan.Open();
            komut4.Parameters.AddWithValue("@dr_id", id);

            komut4.ExecuteNonQuery();
            baglan.Close();
        }

        private void doktor_kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)
                {
                    baglan.Open();
                    string kayit = "insert into alan (alan_id,alan_ad)values(@alan_id," +
                        "@alan_ad)";


                    SqlCommand komut = new SqlCommand(kayit, baglan);

                    komut.Parameters.AddWithValue("@alan_id", textBox1.Text);
                    komut.Parameters.AddWithValue("@alan_ad", textBox2.Text);
                    

                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı");



                }
            }

            catch (Exception hata)
            {
                MessageBox.Show("Bir hata Var!" + hata.Message);
            }
        }
        int i = 0;

        private void alan_goster_Click(object sender, EventArgs e)
        {
            alan_göster();
        }

        private void alansil_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                alan_sil(id);
                alan_göster();


            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            i = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
        }

        private void Alanguncel_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string alan_guncel = ("Update alan Set alan_ad = @alanad where alan_id = @id");

            SqlCommand komut6 = new SqlCommand(alan_guncel, baglan);
            komut6.Parameters.AddWithValue("@id", textBox1.Text);
            komut6.Parameters.AddWithValue("@alanad", textBox2.Text);
            
            komut6.ExecuteNonQuery();
            MessageBox.Show("Kayıtlar başarıyla güncellendi");
            baglan.Close();
            alan_göster();
        }

        private void alan_arama_Click(object sender, EventArgs e)
        {
            string kayit1 = "Select * from alan where alan_ad = @alanad";
            SqlCommand komut2 = new SqlCommand(kayit1, baglan);

            komut2.Parameters.AddWithValue("@alanad", textBox10.Text);
            SqlDataAdapter da4 = new SqlDataAdapter(komut2);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            dataGridView1.DataSource = dt4;
            baglan.Close();
        }
        

        private void hastanekayit_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)
                {
                    baglan.Open();
                    string kayit = "insert into hastane (hastane_id,hastane_ad)values(@hastane_id," +
                        "@hastane_ad)";


                    SqlCommand komut = new SqlCommand(kayit, baglan);

                    komut.Parameters.AddWithValue("@hastane_id", textBox3.Text);
                    komut.Parameters.AddWithValue("@hastane_ad", textBox4.Text);


                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı");



                }
            }

            catch (Exception hata)
            {
                MessageBox.Show("Bir hata Var!" + hata.Message);
            }
        }

        private void hastanegorunt_Click(object sender, EventArgs e)
        {
            hastane_göster();
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
           
            
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            i = e.RowIndex;
            textBox3.Text = dataGridView2.Rows[i].Cells[0].Value.ToString();
            textBox4.Text = dataGridView2.Rows[i].Cells[1].Value.ToString();
        }

        private void hastanearama_Click(object sender, EventArgs e)
        {
            string kayit1 = "Select * from hastane where hastane_ad = @hastanead";
            SqlCommand komut2 = new SqlCommand(kayit1, baglan);

            komut2.Parameters.AddWithValue("@hastanead", textBox11.Text);
            SqlDataAdapter da4 = new SqlDataAdapter(komut2);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            dataGridView2.DataSource = dt4;
            baglan.Close();
        }

        private void hastanesil_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView2.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                hastane_sil(id);
                hastane_göster();


            }
        }

        private void hastaneguncel_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string hastane_guncel = ("Update hastane Set hastane_ad = @hastanead where hastane_id = @id");

            SqlCommand komut6 = new SqlCommand(hastane_guncel, baglan);
            komut6.Parameters.AddWithValue("@id", textBox3.Text);
            komut6.Parameters.AddWithValue("@hastanead", textBox4.Text);

            komut6.ExecuteNonQuery();
            MessageBox.Show("Kayıtlar başarıyla güncellendi");
            baglan.Close();
            hastane_göster();
        }

        private void doktorkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)
                {
                    baglan.Open();
                    string kayit = "insert into doktor (dr_id,dr_ad,dr_soyad,hastane_id,alan_id)values(@dr_id," +
                        "@dr_ad, @dr_soyad, @hastane_id, @alan_id)";


                    SqlCommand komut = new SqlCommand(kayit, baglan);

                    komut.Parameters.AddWithValue("@dr_id", textBox6.Text);
                    komut.Parameters.AddWithValue("@dr_ad", textBox5.Text);
                    komut.Parameters.AddWithValue("@dr_soyad", textBox7.Text);
                    komut.Parameters.AddWithValue("@hastane_id", textBox8.Text);
                    komut.Parameters.AddWithValue("@alan_id", textBox9.Text);



                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı");



                }
            }

            catch (Exception hata)
            {
                MessageBox.Show("Bir hata Var!" + hata.Message);
            }
        }

        private void doktorgoruntu_Click(object sender, EventArgs e)
        {
            doktor_göster();
        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            i = e.RowIndex;
            textBox6.Text = dataGridView3.Rows[i].Cells[0].Value.ToString();
            textBox5.Text = dataGridView3.Rows[i].Cells[1].Value.ToString();
            textBox7.Text = dataGridView3.Rows[i].Cells[2].Value.ToString();
            textBox8.Text = dataGridView3.Rows[i].Cells[3].Value.ToString();
            textBox9.Text = dataGridView3.Rows[i].Cells[4].Value.ToString();

        }

        private void doktorarama_Click(object sender, EventArgs e)
        {
            string kayit1 = "Select * from doktor where dr_ad = @drad";
            SqlCommand komut2 = new SqlCommand(kayit1, baglan);

            komut2.Parameters.AddWithValue("@drad", textBox12.Text);
            SqlDataAdapter da4 = new SqlDataAdapter(komut2);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            dataGridView3.DataSource = dt4;
            baglan.Close();
        }

        private void doktorsil_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView3.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                doktor_sil(id);
                doktor_göster();


            }
        }

        private void doktorguncel_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string doktor_guncel = ("Update doktor Set dr_ad = @drad ,dr_soyad = @drsoyad, hastane_id = @hid, alan_id=@alanid where dr_id = @id");

            SqlCommand komut6 = new SqlCommand(doktor_guncel, baglan);
            komut6.Parameters.AddWithValue("@id", textBox6.Text);
            komut6.Parameters.AddWithValue("@drad", textBox5.Text);
            komut6.Parameters.AddWithValue("@drsoyad", textBox7.Text);
            komut6.Parameters.AddWithValue("@hid", textBox8.Text);
            komut6.Parameters.AddWithValue("@alanid", textBox9.Text);

            komut6.ExecuteNonQuery();
            MessageBox.Show("Kayıtlar başarıyla güncellendi");
            baglan.Close();
            doktor_göster();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
