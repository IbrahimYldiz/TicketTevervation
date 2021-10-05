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
    public partial class FrmPersonTicketInfo : Form
    {
        public FrmPersonTicketInfo()
        {
            InitializeComponent();
        }
        string date;
        public string TCno1;
        string CustomerID;
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-OC5036T\MSSQLSERVER1;Initial Catalog=DbTicketTevervation;Integrated Security=True");
        private void FrmPersonTicketInfo_Load(object sender, EventArgs e)
        {
            date = dateTimePicker1.Value.ToString("dd.MM.yyyy");
            connection.Open();
            SqlCommand command1 = new SqlCommand("select CustomerID from TblCustomer where CustomerTC=@p1", connection);
            command1.Parameters.AddWithValue("@p1", TCno1);
            SqlDataReader dr = command1.ExecuteReader();
            while (dr.Read())
            {
                CustomerID = dr[0].ToString();
            }
            dr.Close();
            connection.Close();
            SqlDataAdapter da = new SqlDataAdapter("select ExpeditionNo as 'Sefer Numarası',CityName as 'Kalkış',CityName1 as 'Varış', (CustomerName+' '+CustomerSurname) as 'Ad Soyad',ExpeditionDate as 'Tarih',ExpeditionHour as 'Saat', TravellerSeatNo as 'Koltuk Numarası' from TblTravellerDetail INNER JOIN TblExpeditionInfo on TblExpeditionInfo.ExpeditionID=TblTravellerDetail.TravellerExpeditionID INNER JOIN TblCity ON TblCity.CityID=TblExpeditionInfo.ExpeditionDeparture INNER JOIN TblCity1 on TblCity1.CtiyID1=TblExpeditionInfo.ExpeditionArrival Inner JOIN TblCustomer on TblCustomer.CustomerID=TblTravellerDetail.TravellerCustomerID where TravellerCustomerID=@p1", connection);
            da.SelectCommand.Parameters.AddWithValue("@p1", CustomerID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da1 = new SqlDataAdapter("select ExpeditionNo as 'Sefer Numarası',CityName as 'Kalkış',CityName1 as 'Varış', (CustomerName+' '+CustomerSurname) as 'Ad Soyad',ExpeditionDate as 'Tarih',ExpeditionHour as 'Saat', TravellerSeatNo as 'Koltuk Numarası' from TblTravellerDetail INNER JOIN TblExpeditionInfo on TblExpeditionInfo.ExpeditionID=TblTravellerDetail.TravellerExpeditionID INNER JOIN TblCity ON TblCity.CityID=TblExpeditionInfo.ExpeditionDeparture INNER JOIN TblCity1 on TblCity1.CtiyID1=TblExpeditionInfo.ExpeditionArrival Inner JOIN TblCustomer on TblCustomer.CustomerID=TblTravellerDetail.TravellerCustomerID where TravellerCustomerID=@p1 and ExpeditionDate=@p2 ", connection);
            da1.SelectCommand.Parameters.AddWithValue("@p1", CustomerID);
            da1.SelectCommand.Parameters.AddWithValue("@p2", date);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            date = dateTimePicker1.Value.ToString("dd.MM.yyyy");
        }
    }
}
