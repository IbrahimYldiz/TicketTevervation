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
    public partial class FrmExpeditionInfo : Form
    {
        public FrmExpeditionInfo()
        {
            InitializeComponent();
        }
        string date;
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-OC5036T\MSSQLSERVER1;Initial Catalog=DbTicketTevervation;Integrated Security=True");
        private void FrmExpeditionInfo_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select ExpeditionNo as 'Sefer Numarası',CityName as 'Kalkış' ,CityName1 as 'Varış',ExpeditionDate as 'Tarih',ExpeditionHour as 'Saat',(ChaufferName+' '+ChaufferSurname) as 'Şöför Ad Soyad',ExpeditionPrice as 'Ücret' from TblExpeditionInfo INNER JOIN TblCity on TblCity.CityID=TblExpeditionInfo.ExpeditionDeparture INNER JOIN TblCity1 on TblCity1.CtiyID1=TblExpeditionInfo.ExpeditionArrival INNER JOIN TblChauffer on TblChauffer.ChaufferID=TblExpeditionInfo.ExpeditionChauffer ", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            date = dateTimePicker1.Value.ToString("dd.MM.yyyy");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            date = dateTimePicker1.Value.ToString("dd.MM.yyyy");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da1 = new SqlDataAdapter("select ExpeditionNo as 'Sefer Numarası',CityName as 'Kalkış' ,CityName1 as 'Varış',ExpeditionDate as 'Tarih',ExpeditionHour as 'Saat',(ChaufferName+' '+ChaufferSurname) as 'Şöför Ad Soyad',ExpeditionPrice as 'Ücret' from TblExpeditionInfo INNER JOIN TblCity on TblCity.CityID=TblExpeditionInfo.ExpeditionDeparture INNER JOIN TblCity1 on TblCity1.CtiyID1=TblExpeditionInfo.ExpeditionArrival INNER JOIN TblChauffer on TblChauffer.ChaufferID=TblExpeditionInfo.ExpeditionChauffer where ExpeditionDate=@p1", connection);
            da1.SelectCommand.Parameters.AddWithValue("@p1", date);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            
                dataGridView1.DataSource = dt1;
            
               
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da1 = new SqlDataAdapter("select ExpeditionNo as 'Sefer Numarası',CityName as 'Kalkış' ,CityName1 as 'Varış',ExpeditionDate as 'Tarih',ExpeditionHour as 'Saat',(ChaufferName+' '+ChaufferSurname) as 'Şöför Ad Soyad',ExpeditionPrice as 'Ücret' from TblExpeditionInfo INNER JOIN TblCity on TblCity.CityID=TblExpeditionInfo.ExpeditionDeparture INNER JOIN TblCity1 on TblCity1.CtiyID1=TblExpeditionInfo.ExpeditionArrival INNER JOIN TblChauffer on TblChauffer.ChaufferID=TblExpeditionInfo.ExpeditionChauffer where ExpeditionNo=@p1", connection);
            da1.SelectCommand.Parameters.AddWithValue("@p1", textBox1.Text);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);

            dataGridView1.DataSource = dt1;
        }
    }
}
