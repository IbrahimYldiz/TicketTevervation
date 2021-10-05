using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TicketTevervation
{
    public partial class FrmExpedition : Form
    {
        public FrmExpedition()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-OC5036T\MSSQLSERVER1;Initial Catalog=DbTicketTevervation;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            if (MskHour.Text.Trim() != "__:__" && TxtPrice.Text.Trim() != "")
            {
                Random random = new Random();
                int ran = random.Next(9999, 99999);
                SqlCommand command1 = new SqlCommand("select * from TblExpeditionInfo where ExpeditionNo=@p1");
                command1.Parameters.AddWithValue("@p1", ran);
                SqlDataReader dr = command1.ExecuteReader();
                while (dr.Read())
                {
                    ran = random.Next(9999, 999999999);
                }
                dr.Close();

                SqlCommand command2 = new SqlCommand("select * from TblExpeditionInfo where ExpeditionChauffer=@p1 and ExpeditionDate=@p2 and ExpeditionHour=@p3", connection);
                command2.Parameters.AddWithValue("@p1", CmbChauffer.SelectedValue.ToString());
                command2.Parameters.AddWithValue("@p2", Lbldate.Text);
                command2.Parameters.AddWithValue("@p3", MskHour.Text);
                SqlDataReader dr1 = command2.ExecuteReader();
                if (dr1.Read())
                {
                    MessageBox.Show("Şöför Aynı Tarih ve Saatte Seferde Gözüküyor Lütfen Kontrol Ediniz");
                }
                else
                {
                    dr1.Close();
                    SqlCommand command = new SqlCommand("insert into TblExpeditionInfo (ExpeditionNo,ExpeditionDeparture,ExpeditionArrival,ExpeditionDate,ExpeditionHour,ExpeditionChauffer,ExpeditionPrice) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)");
                    command.Parameters.AddWithValue("@p1", ran);
                    command.Parameters.AddWithValue("@p2", CmbDeparture.SelectedValue.ToString());
                    command.Parameters.AddWithValue("@p3", CmbArrival.SelectedValue.ToString());
                    command.Parameters.AddWithValue("@p4", Lbldate.Text);
                    command.Parameters.AddWithValue("@p5", MskHour.Text);
                    command.Parameters.AddWithValue("@p6", CmbChauffer.SelectedValue.ToString());
                    command.Parameters.AddWithValue("@p7", TxtPrice.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Sefer Girişi Başarılı");
                }
                dr1.Close();


            }
            else
            {
                MessageBox.Show("Lütfen Bütün Bilgileri Giriniz");
            }
            connection.Close();
        }
        void city()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TblCity", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbDeparture.ValueMember = "CityID";
            CmbDeparture.DisplayMember = "CityName";
            CmbDeparture.DataSource = dt;
        }
        void city1()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TblCity1", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbArrival.ValueMember = "CtiyID1";
            CmbArrival.DisplayMember = "CityName1";
            CmbArrival.DataSource = dt;
        }
        void Chauffer()
        {
            SqlDataAdapter da = new SqlDataAdapter("select (ChaufferName+' '+ChaufferSurname) as Name,ChaufferID from TblChauffer ", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbChauffer.ValueMember = "ChaufferID";
            CmbChauffer.DisplayMember = "Name";
            CmbChauffer.DataSource = dt;
        }
        private void FrmExpedition_Load(object sender, EventArgs e)
        {
            city(); city1(); Chauffer(); Lbldate.Text = dateTimePicker1.Value.ToString("dd.MM.yyyy");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Lbldate.Text=dateTimePicker1.Value.ToString("dd.MM.yyyy");
        }

        private void TxtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
