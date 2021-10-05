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
using System.Collections;

namespace TicketTevervation
{
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-OC5036T\MSSQLSERVER1;Initial Catalog=DbTicketTevervation;Integrated Security=True");
        public string TC;
        string deger;
        string gender1;
        string PersonID;

        string k2, k3, k5, k6, k8, k9, k11, k12, k15, k16, k18, k19, k21, k22;
        void PersonInfo()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("select * from TblCustomer where CustomerTC=@p1", connection);
            command.Parameters.AddWithValue("@p1", TC);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                LblTC.Text = TC;
                LblNameSurname.Text = dr[1].ToString() + " " + dr[2].ToString();
                gender1 = dr[5].ToString();
                PersonID = dr[0].ToString();
                this.Text = dr[5].ToString();

            }
            connection.Close();
        }



        private void Btn2_Click(object sender, EventArgs e)
        {
            if (k3 == "Kadın" && gender1 == "Kadın")
            {
                LblSeatNo.Text = "2";
                LblSeatNo.Visible = true;
            }

            else if (k3 == "Erkek" && gender1 == "Erkek")
            {
                LblSeatNo.Text = "2";
                LblSeatNo.Visible = true;

            }
            else if (Btn3.BackColor == this.BackColor)
            {
                LblSeatNo.Text = "2";
                LblSeatNo.Visible = true;

            }
            else
            {
                MessageBox.Show("Lütfen Koltukta Yanınızda Oturacak Kişinin Cinsiyetine Dikkat Ediniz. ikili Koltuklarda, Kadın-Kadın ya da Erkek-Erkek Şeklinde Oturulmasına İzin Verilmektedir. Anlayışınız İçin Teşşekür Ederiz.");
            }


        }

        private void Btn1_Click(object sender, EventArgs e)
        {//cinsiyet kontrolü ve koltuk seçimi


            LblSeatNo.Text = "1";
            LblSeatNo.Visible = true;
            Btn1.Enabled = false;

        }

        void EnabledFalse()
        {
            Btn1.Enabled = false;
            Btn2.Enabled = false;
            Btn3.Enabled = false;
            Btn4.Enabled = false;
            Btn5.Enabled = false;
            Btn6.Enabled = false;
            Btn7.Enabled = false;
            Btn8.Enabled = false;
            Btn9.Enabled = false;
            Btn10.Enabled = false;
            Btn11.Enabled = false;
            Btn12.Enabled = false;
            Btn13.Enabled = false;
            Btn14.Enabled = false;
            Btn15.Enabled = false;
            Btn16.Enabled = false;
            Btn17.Enabled = false;
            Btn18.Enabled = false;
            Btn19.Enabled = false;
            Btn20.Enabled = false;
            Btn21.Enabled = false;
            Btn22.Enabled = false;

        }
        void CityInfo()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TblCity", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbCity1.DisplayMember = "CityName";
            CmbCity1.ValueMember = "CityID";
            CmbCity1.DataSource = dt;

        }
        void CityInfo1()
        {
            SqlDataAdapter da2 = new SqlDataAdapter("select * from TblCity", connection);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            CmbCity2.DisplayMember = "CityName";
            CmbCity2.ValueMember = "CityID";
            CmbCity2.DataSource = dt2;
        }
        void list()
        {

            SqlDataAdapter da1 = new SqlDataAdapter("select ExpeditionID as'ID', ExpeditionNo as 'Sefer Numarası', CityName as 'Kalkış',CityName1 as 'Varış',ExpeditionDate as 'Tarih',ExpeditionHour as 'Saat',ExpeditionPrice as 'Ücret' from TblExpeditionInfo INNER JOIN TblCity ON TblExpeditionInfo.ExpeditionDeparture=TblCity.CityID INNER JOIN TblCity1 ON TblExpeditionInfo.ExpeditionArrival=TblCity1.CtiyID1 where ExpeditionDeparture=@p1 and ExpeditionArrival=@p2 and ExpeditionDate=@p3", connection);
            da1.SelectCommand.Parameters.AddWithValue("@p1", CmbCity1.SelectedValue.ToString());
            da1.SelectCommand.Parameters.AddWithValue("@p2", CmbCity2.SelectedValue.ToString());
            da1.SelectCommand.Parameters.AddWithValue("@p3", dateTimePicker1.Value.ToString("dd.MM.yyyy"));
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }
        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            PersonInfo();
            CityInfo();
            CityInfo1();
            EnabledFalse();
            LblSeatNo.Visible = false;
            LblDate.Text = dateTimePicker1.Value.ToString("dd.MM.yyyy");


        }



        private void Btn3_Click(object sender, EventArgs e)
        {
            if (k2 == "Kadın" && gender1 == "Kadın")
            {
                LblSeatNo.Text = "3";
                LblSeatNo.Visible = true;
            }

            else if (k2 == "Erkek" && gender1 == "Erkek")
            {
                LblSeatNo.Text = "3";
                LblSeatNo.Visible = true;

            }
            else if (Btn2.BackColor == this.BackColor)
            {
                LblSeatNo.Text = "3";
                LblSeatNo.Visible = true;

            }
            else
            {
                MessageBox.Show("Lütfen Koltukta Yanınızda Oturacak Kişinin Cinsiyetine Dikkat Ediniz. ikili Koltuklarda, Kadın-Kadın ya da Erkek-Erkek Şeklinde Oturulmasına İzin Verilmektedir. Anlayışınız İçin Teşşekür Ederiz.");
            }


        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            LblSeatNo.Text = "4";
            LblSeatNo.Visible = true;
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            if (k6 == "Kadın" && gender1 == "Kadın")
            {
                LblSeatNo.Text = "5";
                LblSeatNo.Visible = true;
            }

            else if (k6 == "Erkek" && gender1 == "Erkek")
            {
                LblSeatNo.Text = "5";
                LblSeatNo.Visible = true;

            }
            else if (Btn6.BackColor == this.BackColor)
            {
                LblSeatNo.Text = "5";
                LblSeatNo.Visible = true;

            }
            else
            {
                MessageBox.Show("Lütfen Koltukta Yanınızda Oturacak Kişinin Cinsiyetine Dikkat Ediniz. ikili Koltuklarda, Kadın-Kadın ya da Erkek-Erkek Şeklinde Oturulmasına İzin Verilmektedir. Anlayışınız İçin Teşşekür Ederiz.");
            }

        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            if (k8 == "Kadın" && gender1 == "Kadın")
            {
                LblSeatNo.Text = "9";
                LblSeatNo.Visible = true;
            }

            else if (k8 == "Erkek" && gender1 == "Erkek")
            {
                LblSeatNo.Text = "9";
                LblSeatNo.Visible = true;

            }
            else if (Btn8.BackColor == this.BackColor)
            {
                LblSeatNo.Text = "9";
                LblSeatNo.Visible = true;

            }
            else
            {
                MessageBox.Show("Lütfen Koltukta Yanınızda Oturacak Kişinin Cinsiyetine Dikkat Ediniz. ikili Koltuklarda, Kadın-Kadın ya da Erkek-Erkek Şeklinde Oturulmasına İzin Verilmektedir. Anlayışınız İçin Teşşekür Ederiz.");
            }

        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            if (k5 == "Kadın" && gender1 == "Kadın")
            {
                LblSeatNo.Text = "6";
                LblSeatNo.Visible = true;
            }

            else if (k5 == "Erkek" && gender1 == "Erkek")
            {
                LblSeatNo.Text = "6";
                LblSeatNo.Visible = true;

            }
            else if (Btn5.BackColor == this.BackColor)
            {
                LblSeatNo.Text = "6";
                LblSeatNo.Visible = true;

            }
            else
            {
                MessageBox.Show("Lütfen Koltukta Yanınızda Oturacak Kişinin Cinsiyetine Dikkat Ediniz. ikili Koltuklarda, Kadın-Kadın ya da Erkek-Erkek Şeklinde Oturulmasına İzin Verilmektedir. Anlayışınız İçin Teşşekür Ederiz.");
            }

        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            LblSeatNo.Text = "7";
            LblSeatNo.Visible = true;
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            if (k9 == "Kadın" && gender1 == "Kadın")
            {
                LblSeatNo.Text = "8";
                LblSeatNo.Visible = true;
            }

            else if (k9 == "Erkek" && gender1 == "Erkek")
            {
                LblSeatNo.Text = "8";
                LblSeatNo.Visible = true;

            }
            else if (Btn9.BackColor == this.BackColor)
            {
                LblSeatNo.Text = "8";
                LblSeatNo.Visible = true;

            }
            else
            {
                MessageBox.Show("Lütfen Koltukta Yanınızda Oturacak Kişinin Cinsiyetine Dikkat Ediniz. ikili Koltuklarda, Kadın-Kadın ya da Erkek-Erkek Şeklinde Oturulmasına İzin Verilmektedir. Anlayışınız İçin Teşşekür Ederiz.");
            }

        }

        private void Btn12_Click(object sender, EventArgs e)
        {
            if (k11 == "Kadın" && gender1 == "Kadın")
            {
                LblSeatNo.Text = "12";
                LblSeatNo.Visible = true;
            }

            else if (k11 == "Erkek" && gender1 == "Erkek")
            {
                LblSeatNo.Text = "12";
                LblSeatNo.Visible = true;

            }
            else if (Btn11.BackColor == this.BackColor)
            {
                LblSeatNo.Text = "12";
                LblSeatNo.Visible = true;

            }
            else
            {
                MessageBox.Show("Lütfen Koltukta Yanınızda Oturacak Kişinin Cinsiyetine Dikkat Ediniz. ikili Koltuklarda, Kadın-Kadın ya da Erkek-Erkek Şeklinde Oturulmasına İzin Verilmektedir. Anlayışınız İçin Teşşekür Ederiz.");
            }

        }

        private void Btn10_Click(object sender, EventArgs e)
        {
            LblSeatNo.Text = "10";
            LblSeatNo.Visible = true;
        }

        private void Btn11_Click(object sender, EventArgs e)
        {
            if (k12 == "Kadın" && gender1 == "Kadın")
            {
                LblSeatNo.Text = "11";
                LblSeatNo.Visible = true;
            }

            else if (k12 == "Erkek" && gender1 == "Erkek")
            {
                LblSeatNo.Text = "11";
                LblSeatNo.Visible = true;

            }
            else if (Btn12.BackColor == this.BackColor)
            {
                LblSeatNo.Text = "11";
                LblSeatNo.Visible = true;

            }
            else
            {
                MessageBox.Show("Lütfen Koltukta Yanınızda Oturacak Kişinin Cinsiyetine Dikkat Ediniz. ikili Koltuklarda, Kadın-Kadın ya da Erkek-Erkek Şeklinde Oturulmasına İzin Verilmektedir. Anlayışınız İçin Teşşekür Ederiz.");
            }

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Btn13_Click(object sender, EventArgs e)
        {
            LblSeatNo.Text = "13";
            LblSeatNo.Visible = true;
        }

        private void Btn14_Click(object sender, EventArgs e)
        {
            LblSeatNo.Text = "14";
            LblSeatNo.Visible = true;
        }

        private void Btn15_Click(object sender, EventArgs e)
        {
            if (k16 == "Kadın" && gender1 == "Kadın")
            {
                LblSeatNo.Text = "15";
                LblSeatNo.Visible = true;
            }

            else if (k16 == "Erkek" && gender1 == "Erkek")
            {
                LblSeatNo.Text = "15";
                LblSeatNo.Visible = true;

            }
            else if (Btn16.BackColor == this.BackColor)
            {
                LblSeatNo.Text = "15";
                LblSeatNo.Visible = true;

            }
            else
            {
                MessageBox.Show("Lütfen Koltukta Yanınızda Oturacak Kişinin Cinsiyetine Dikkat Ediniz. ikili Koltuklarda, Kadın-Kadın ya da Erkek-Erkek Şeklinde Oturulmasına İzin Verilmektedir. Anlayışınız İçin Teşşekür Ederiz.");
            }

        }

        private void Btn16_Click(object sender, EventArgs e)
        {
            if (k15 == "Kadın" && gender1 == "Kadın")
            {
                LblSeatNo.Text = "16";
                LblSeatNo.Visible = true;
            }

            else if (k15 == "Erkek" && gender1 == "Erkek")
            {
                LblSeatNo.Text = "16";
                LblSeatNo.Visible = true;

            }
            else if (Btn15.BackColor == this.BackColor)
            {
                LblSeatNo.Text = "16";
                LblSeatNo.Visible = true;

            }
            else
            {
                MessageBox.Show("Lütfen Koltukta Yanınızda Oturacak Kişinin Cinsiyetine Dikkat Ediniz. ikili Koltuklarda, Kadın-Kadın ya da Erkek-Erkek Şeklinde Oturulmasına İzin Verilmektedir. Anlayışınız İçin Teşşekür Ederiz.");
            }

        }

        private void Btn17_Click(object sender, EventArgs e)
        {
            LblSeatNo.Text = "17";
            LblSeatNo.Visible = true;
        }

        private void Btn18_Click(object sender, EventArgs e)
        {
            if (k19 == "Kadın" && gender1 == "Kadın")
            {
                LblSeatNo.Text = "18";
                LblSeatNo.Visible = true;
            }

            else if (k19 == "Erkek" && gender1 == "Erkek")
            {
                LblSeatNo.Text = "18";
                LblSeatNo.Visible = true;

            }
            else if (Btn19.BackColor == this.BackColor)
            {
                LblSeatNo.Text = "18";
                LblSeatNo.Visible = true;

            }
            else
            {
                MessageBox.Show("Lütfen Koltukta Yanınızda Oturacak Kişinin Cinsiyetine Dikkat Ediniz. ikili Koltuklarda, Kadın-Kadın ya da Erkek-Erkek Şeklinde Oturulmasına İzin Verilmektedir. Anlayışınız İçin Teşşekür Ederiz.");
            }

        }

        private void Btn19_Click(object sender, EventArgs e)
        {
            if (k18 == "Kadın" && gender1 == "Kadın")
            {
                LblSeatNo.Text = "19";
                LblSeatNo.Visible = true;
            }

            else if (k18 == "Erkek" && gender1 == "Erkek")
            {
                LblSeatNo.Text = "19";
                LblSeatNo.Visible = true;

            }
            else if (Btn18.BackColor == this.BackColor)
            {
                LblSeatNo.Text = "19";
                LblSeatNo.Visible = true;

            }
            else
            {
                MessageBox.Show("Lütfen Koltukta Yanınızda Oturacak Kişinin Cinsiyetine Dikkat Ediniz. ikili Koltuklarda, Kadın-Kadın ya da Erkek-Erkek Şeklinde Oturulmasına İzin Verilmektedir. Anlayışınız İçin Teşşekür Ederiz.");
            }

        }

        private void Btn20_Click(object sender, EventArgs e)
        {
            LblSeatNo.Text = "20";
            LblSeatNo.Visible = true;
        }

        private void Btn21_Click(object sender, EventArgs e)
        {
            if (k22 == "Kadın" && gender1 == "Kadın")
            {
                LblSeatNo.Text = "21";
                LblSeatNo.Visible = true;
            }

            else if (k22 == "Erkek" && gender1 == "Erkek")
            {
                LblSeatNo.Text = "21";
                LblSeatNo.Visible = true;

            }
            else if (Btn22.BackColor == this.BackColor)
            {
                LblSeatNo.Text = "21";
                LblSeatNo.Visible = true;

            }
            else
            {
                MessageBox.Show("Lütfen Koltukta Yanınızda Oturacak Kişinin Cinsiyetine Dikkat Ediniz. ikili Koltuklarda, Kadın-Kadın ya da Erkek-Erkek Şeklinde Oturulmasına İzin Verilmektedir. Anlayışınız İçin Teşşekür Ederiz.");
            }

        }

        private void Btn22_Click(object sender, EventArgs e)
        {
            if (k21 == "Kadın" && gender1 == "Kadın")
            {
                LblSeatNo.Text = "22";
                LblSeatNo.Visible = true;
            }

            else if (k21 == "Erkek" && gender1 == "Erkek")
            {
                LblSeatNo.Text = "22";
                LblSeatNo.Visible = true;

            }
            else if (Btn21.BackColor == this.BackColor)
            {
                LblSeatNo.Text = "22";
                LblSeatNo.Visible = true;

            }
            else
            {
                MessageBox.Show("Lütfen Koltukta Yanınızda Oturacak Kişinin Cinsiyetine Dikkat Ediniz. ikili Koltuklarda, Kadın-Kadın ya da Erkek-Erkek Şeklinde Oturulmasına İzin Verilmektedir. Anlayışınız İçin Teşşekür Ederiz.");
            }


        }

        private void BtnSearch_Click_1(object sender, EventArgs e)
        {

            list();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LblDate.Text = dateTimePicker1.Value.ToString("dd.MM.yyyy");
            LblDate.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            LblDate.Text = dateTimePicker1.Value.ToString("dd.mm.yyyy ");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (LblId.Text != "0" && PersonID != "" && LblSeatNo.Text != "0")
            {
                connection.Open();
                SqlCommand command = new SqlCommand("insert into TblTravellerDetail (TravellerExpeditionID,TravellerCustomerID,TravellerSeatNo) values (@p1,@p2,@p3)", connection);
                command.Parameters.AddWithValue("@p1", LblId.Text);
                command.Parameters.AddWithValue("@p2", PersonID);
                command.Parameters.AddWithValue("@p3", LblSeatNo.Text);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Bilet Alınmıştır");
                list1();
            }
            else
            {
                MessageBox.Show("Lütfen Seferi Seçiniz ya da Koltuk Seçimini Yapınız");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmPersonTicketInfo fr = new FrmPersonTicketInfo();
            fr.TCno1 = LblTC.Text;
            fr.Show();
        }
        void list1()
        {
            deger = LblId.Text;
            connection.Open();
            SqlCommand command2 = new SqlCommand("select * from TblTravellerDetail INNER JOIN TblExpeditionInfo ON TblExpeditionInfo.ExpeditionID=TblTravellerDetail.TravellerExpeditionID where TravellerExpeditionID=@p1 and ExpeditionDate=@p2 and ExpeditionHour=@p3 ", connection);
            command2.Parameters.AddWithValue("@p1", deger);
            command2.Parameters.AddWithValue("@p2", LblDate.Text);
            command2.Parameters.AddWithValue("@p3", label7.Text);
            SqlDataReader dr1 = command2.ExecuteReader();
            ArrayList koltukno = new ArrayList();
            while (dr1.Read())
            {
                koltukno.Add(dr1["TravellerSeatNo"]);

            }


            dr1.Close();

            if (koltukno.Contains("1"))
            {
                Btn1.Enabled = false;
            }
            else
            {
                Btn1.Enabled = true;
            }
            if (koltukno.Contains("2"))
            {
                Btn2.Enabled = false;
            }
            else
            {
                Btn2.Enabled = true;
            }
            if (koltukno.Contains("3"))
            {
                Btn3.Enabled = false;
            }
            else
            {
                Btn3.Enabled = true;
            }
            if (koltukno.Contains("4"))
            {
                Btn4.Enabled = false;
            }
            else
            {
                Btn4.Enabled = true;
            }
            if (koltukno.Contains("5"))
            {
                Btn5.Enabled = false;
            }
            else
            {
                Btn5.Enabled = true;
            }
            if (koltukno.Contains("6"))
            {
                Btn6.Enabled = false;
            }
            else
            {
                Btn6.Enabled = true;
            }
            if (koltukno.Contains("7"))
            {
                Btn7.Enabled = false;
            }
            else
            {
                Btn7.Enabled = true;
            }
            if (koltukno.Contains("8"))
            {
                Btn8.Enabled = false;
            }
            else
            {
                Btn8.Enabled = true;
            }
            if (koltukno.Contains("9"))
            {
                Btn9.Enabled = false;
            }
            else
            {
                Btn9.Enabled = true;
            }
            if (koltukno.Contains("10"))
            {
                Btn10.Enabled = false;
            }
            else
            {
                Btn10.Enabled = true;
            }
            if (koltukno.Contains("11"))
            {
                Btn11.Enabled = false;
            }
            else
            {
                Btn11.Enabled = true;
            }
            if (koltukno.Contains("12"))
            {
                Btn12.Enabled = false;
            }
            else
            {
                Btn12.Enabled = true;
            }
            if (koltukno.Contains("13"))
            {
                Btn13.Enabled = false;
            }
            else
            {
                Btn13.Enabled = true;
            }
            if (koltukno.Contains("14"))
            {
                Btn14.Enabled = false;
            }
            else
            {
                Btn14.Enabled = true;
            }
            if (koltukno.Contains("15"))
            {
                Btn15.Enabled = false;
            }
            else
            {
                Btn15.Enabled = true;
            }
            if (koltukno.Contains("16"))
            {
                Btn16.Enabled = false;
            }
            else
            {
                Btn16.Enabled = true;
            }

            if (koltukno.Contains("17"))
            {
                Btn17.Enabled = false;
            }
            else
            {
                Btn17.Enabled = true;
            }

            if (koltukno.Contains("18"))
            {
                Btn18.Enabled = false;
            }
            else
            {
                Btn18.Enabled = true;
            }
            if (koltukno.Contains("19"))
            {
                Btn19.Enabled = false;
            }
            else
            {
                Btn19.Enabled = true;
            }
            if (koltukno.Contains("20"))
            {
                Btn20.Enabled = false;
            }
            else
            {
                Btn20.Enabled = true;
            }
            if (koltukno.Contains("21"))
            {
                Btn21.Enabled = false;
            }
            else
            {
                Btn21.Enabled = true;
            }
            if (koltukno.Contains("22"))
            {
                Btn22.Enabled = false;
            }
            else
            {
                Btn22.Enabled = true;
            }





            if (koltukno.Contains("1"))
            {

                SqlCommand command3 = new SqlCommand("select TravellerCustomerID from TblTravellerDetail where TravellerExpeditionID=@p1 and TravellerSeatNo=1", connection);
                command3.Parameters.AddWithValue("@p1", deger);
                SqlDataReader dr2 = command3.ExecuteReader();

                if (dr2.Read())
                {

                    string b1;

                    b1 = dr2["TravellerCustomerID"].ToString();

                    dr2.Close();
                    SqlCommand command4 = new SqlCommand("select CustomerGender from TblCustomer where CustomerID=@p1", connection);
                    command4.Parameters.AddWithValue("@p1", b1);
                    SqlDataReader dr3 = command4.ExecuteReader();

                    while (dr3.Read())
                    {
                        if (dr3["CustomerGender"].ToString() == "Kadın")
                        {
                            Btn1.BackColor = Color.Pink;

                        }
                        else
                        {
                            Btn1.BackColor = Color.LightBlue;

                        }
                    }
                    dr3.Close();
                }
                dr2.Close();

            }
            //koltukların hangi cinsiyetlere ait olduğunu görme
            if (koltukno.Contains("2"))
            {

                SqlCommand command5 = new SqlCommand("select TravellerCustomerID from TblTravellerDetail where TravellerExpeditionID=@p1 and TravellerSeatNo=2", connection);
                command5.Parameters.AddWithValue("@p1", deger);
                SqlDataReader dr4 = command5.ExecuteReader();
                if (dr4.Read())
                {
                    string b1 = dr4[0].ToString();
                    dr4.Close();
                    SqlCommand command6 = new SqlCommand("select CustomerGender from TblCustomer where CustomerID=" + b1, connection);
                    SqlDataReader dr5 = command6.ExecuteReader();
                    while (dr5.Read())
                    {
                        if (dr5[0].ToString() == "Kadın")
                        {
                            Btn2.BackColor = Color.Pink;
                            k2 = "Kadın";
                        }
                        else
                        {
                            Btn2.BackColor = Color.LightBlue;
                            k2 = "Erkek";
                        }
                    }
                    dr5.Close();
                }
                dr4.Close();
            }
            if (koltukno.Contains("3"))
            {

                SqlCommand command7 = new SqlCommand("select TravellerCustomerID from TblTravellerDetail where TravellerExpeditionID=@p1 and TravellerSeatNo=3", connection);
                command7.Parameters.AddWithValue("@p1", deger);
                SqlDataReader dr6 = command7.ExecuteReader();
                if (dr6.Read())
                {
                    string b1 = dr6[0].ToString();
                    dr6.Close();
                    SqlCommand command8 = new SqlCommand("select CustomerGender from TblCustomer where CustomerID=" + b1, connection);
                    SqlDataReader dr7 = command8.ExecuteReader();

                    while (dr7.Read())
                    {
                        if (dr7[0].ToString() == "Kadın")
                        {
                            Btn3.BackColor = Color.Pink;
                            k3 = "Kadın";
                        }
                        else
                        {
                            Btn3.BackColor = Color.LightBlue;
                            k3 = "Erkek";
                        }

                    }
                    dr7.Close();
                }
                dr6.Close();
            }
            if (koltukno.Contains("4"))
            {

                SqlCommand command9 = new SqlCommand("select TravellerCustomerID from TblTravellerDetail where TravellerExpeditionID=@p1 and TravellerSeatNo=4", connection);
                command9.Parameters.AddWithValue("@p1", deger);
                SqlDataReader dr8 = command9.ExecuteReader();
                if (dr8.Read())
                {
                    string b1 = dr8[0].ToString();
                    dr8.Close();
                    SqlCommand command10 = new SqlCommand("select CustomerGender from TblCustomer where CustomerID=" + b1, connection);
                    SqlDataReader dr9 = command10.ExecuteReader();
                    while (dr9.Read())
                    {
                        if (dr9[0].ToString() == "Kadın")
                        {
                            Btn4.BackColor = Color.Pink;

                        }
                        else
                        {
                            Btn4.BackColor = Color.LightBlue;

                        }
                    }
                    dr9.Close();
                }
                dr8.Close();
            }
            if (koltukno.Contains("5"))
            {

                SqlCommand command11 = new SqlCommand("select TravellerCustomerID from TblTravellerDetail where TravellerExpeditionID=@p1 and TravellerSeatNo=5", connection);
                command11.Parameters.AddWithValue("@p1", deger);
                SqlDataReader dr10 = command11.ExecuteReader();
                if (dr10.Read())
                {
                    string b1 = dr10[0].ToString();
                    dr10.Close();
                    SqlCommand command12 = new SqlCommand("select CustomerGender from TblCustomer where CustomerID=" + b1, connection);
                    SqlDataReader dr11 = command12.ExecuteReader();
                    while (dr11.Read())
                    {
                        if (dr11[0].ToString() == "Kadın")
                        {
                            Btn5.BackColor = Color.Pink;
                            k5 = "Kadın";
                        }
                        else
                        {
                            Btn5.BackColor = Color.LightBlue;
                            k5 = "Erkek";
                        }
                    }
                    dr11.Close();
                }
                dr10.Close();
            }
            if (koltukno.Contains("6"))
            {

                SqlCommand command14 = new SqlCommand("select TravellerCustomerID from TblTravellerDetail where TravellerExpeditionID=@p1 and TravellerSeatNo=6", connection);
                command14.Parameters.AddWithValue("@p1", deger);
                SqlDataReader dr12 = command14.ExecuteReader();
                if (dr12.Read())
                {
                    string b1 = dr12[0].ToString();
                    dr12.Close();
                    SqlCommand command13 = new SqlCommand("select CustomerGender from TblCustomer where CustomerID=" + b1, connection);
                    SqlDataReader dr13 = command13.ExecuteReader();
                    while (dr13.Read())
                    {
                        if (dr13[0].ToString() == "Kadın")
                        {
                            Btn6.BackColor = Color.Pink;
                            k6 = "Kadın";
                        }
                        else
                        {
                            Btn6.BackColor = Color.LightBlue;
                            k6 = "Erkek";
                        }
                    }
                    dr13.Close();
                }
                dr12.Close();
            }
            if (koltukno.Contains("7"))
            {

                SqlCommand command15 = new SqlCommand("select TravellerCustomerID from TblTravellerDetail where TravellerExpeditionID=@p1 and TravellerSeatNo=7", connection);
                command15.Parameters.AddWithValue("@p1", deger);
                SqlDataReader dr14 = command15.ExecuteReader();
                if (dr14.Read())
                {
                    string b1 = dr14[0].ToString();
                    dr14.Close();
                    SqlCommand command16 = new SqlCommand("select CustomerGender from TblCustomer where CustomerID=" + b1, connection);
                    SqlDataReader dr15 = command16.ExecuteReader();
                    while (dr15.Read())
                    {
                        if (dr15[0].ToString() == "Kadın")
                        {
                            Btn7.BackColor = Color.Pink;

                        }
                        else
                        {
                            Btn7.BackColor = Color.LightBlue;

                        }
                    }
                    dr15.Close();
                }
                dr14.Close();
            }
            if (koltukno.Contains("8"))
            {

                SqlCommand command17 = new SqlCommand("select TravellerCustomerID from TblTravellerDetail where TravellerExpeditionID=@p1 and TravellerSeatNo=8", connection);
                command17.Parameters.AddWithValue("@p1", deger);
                SqlDataReader dr16 = command17.ExecuteReader();
                if (dr16.Read())
                {
                    string b1 = dr16[0].ToString();
                    dr16.Close();
                    SqlCommand command18 = new SqlCommand("select CustomerGender from TblCustomer where CustomerID=" + b1, connection);
                    SqlDataReader dr17 = command18.ExecuteReader();
                    while (dr17.Read())
                    {
                        if (dr17[0].ToString() == "Kadın")
                        {
                            Btn8.BackColor = Color.Pink;
                            k8 = "Kadın";
                        }
                        else
                        {
                            Btn8.BackColor = Color.LightBlue;
                            k8 = "Erkek";
                        }
                    }
                    dr17.Close();
                }
                dr16.Close();
            }
            if (koltukno.Contains("9"))
            {
                SqlCommand command17 = new SqlCommand("select TravellerCustomerID from TblTravellerDetail where TravellerExpeditionID=@p1 and TravellerSeatNo=9", connection);
                command17.Parameters.AddWithValue("@p1", deger);
                SqlDataReader dr16 = command17.ExecuteReader();
                if (dr16.Read())
                {

                    string b1 = dr16[0].ToString();
                    dr16.Close();
                    SqlCommand command18 = new SqlCommand("select CustomerGender from TblCustomer where CustomerID=" + b1, connection);
                    SqlDataReader dr17 = command18.ExecuteReader();
                    while (dr17.Read())
                    {

                        if (dr17[0].ToString() == "Kadın")
                        {

                            Btn9.BackColor = Color.Pink;
                            k9 = "Kadın";
                        }
                        else
                        {
                            Btn9.BackColor = Color.LightBlue;
                            k9 = "Erkek";
                        }
                    }
                    dr17.Close();
                }
                dr16.Close();
            }
            if (koltukno.Contains("10"))
            {

                SqlCommand command17 = new SqlCommand("select TravellerCustomerID from TblTravellerDetail where TravellerExpeditionID=@p1 and TravellerSeatNo=10", connection);
                command17.Parameters.AddWithValue("@p1", deger);
                SqlDataReader dr16 = command17.ExecuteReader();
                if (dr16.Read())
                {

                    string b1 = dr16[0].ToString();
                    dr16.Close();
                    SqlCommand command18 = new SqlCommand("select CustomerGender from TblCustomer where CustomerID=" + b1, connection);
                    SqlDataReader dr17 = command18.ExecuteReader();
                    while (dr17.Read())
                    {

                        if (dr17[0].ToString() == "Kadın")
                        {

                            Btn10.BackColor = Color.Pink;

                        }
                        else
                        {
                            Btn10.BackColor = Color.LightBlue;

                        }
                    }
                    dr17.Close();
                }
                dr16.Close();
            }
            if (koltukno.Contains("11"))
            {

                SqlCommand command17 = new SqlCommand("select TravellerCustomerID from TblTravellerDetail where TravellerExpeditionID=@p1 and TravellerSeatNo=11", connection);
                command17.Parameters.AddWithValue("@p1", deger);
                SqlDataReader dr16 = command17.ExecuteReader();
                if (dr16.Read())
                {

                    string b1 = dr16[0].ToString();
                    dr16.Close();
                    SqlCommand command18 = new SqlCommand("select CustomerGender from TblCustomer where CustomerID=" + b1, connection);
                    SqlDataReader dr17 = command18.ExecuteReader();
                    while (dr17.Read())
                    {

                        if (dr17[0].ToString() == "Kadın")
                        {

                            Btn11.BackColor = Color.Pink;
                            k11 = "Kadın";
                        }
                        else
                        {
                            Btn11.BackColor = Color.LightBlue;
                            k11 = "Erkek";
                        }
                    }
                    dr17.Close();
                }
                dr16.Close();
            }
            if (koltukno.Contains("12"))
            {

                SqlCommand command17 = new SqlCommand("select TravellerCustomerID from TblTravellerDetail where TravellerExpeditionID=@p1 and TravellerSeatNo=12", connection);
                command17.Parameters.AddWithValue("@p1", deger);
                SqlDataReader dr16 = command17.ExecuteReader();
                if (dr16.Read())
                {

                    string b1 = dr16[0].ToString();
                    dr16.Close();
                    SqlCommand command18 = new SqlCommand("select CustomerGender from TblCustomer where CustomerID=" + b1, connection);
                    SqlDataReader dr17 = command18.ExecuteReader();
                    while (dr17.Read())
                    {

                        if (dr17[0].ToString() == "Kadın")
                        {

                            Btn12.BackColor = Color.Pink;
                            k12 = "Kadın";
                        }
                        else
                        {
                            Btn12.BackColor = Color.LightBlue;
                            k12 = "Erkek";
                        }
                    }
                    dr17.Close();
                }
                dr16.Close();
            }
            if (koltukno.Contains("13"))
            {

                SqlCommand command11 = new SqlCommand("select TravellerCustomerID from TblTravellerDetail where TravellerExpeditionID=@p1 and TravellerSeatNo=13", connection);
                command11.Parameters.AddWithValue("@p1", deger);
                SqlDataReader dr10 = command11.ExecuteReader();
                if (dr10.Read())
                {
                    string b1 = dr10[0].ToString();
                    dr10.Close();
                    SqlCommand command12 = new SqlCommand("select CustomerGender from TblCustomer where CustomerID=" + b1, connection);
                    SqlDataReader dr11 = command12.ExecuteReader();
                    while (dr11.Read())
                    {
                        if (dr11[0].ToString() == "Kadın")
                        {
                            Btn13.BackColor = Color.Pink;

                        }
                        else
                        {
                            Btn13.BackColor = Color.LightBlue;

                        }
                    }
                    dr11.Close();
                }
                dr10.Close();


            }
            if (koltukno.Contains("14"))
            {

                SqlCommand command11 = new SqlCommand("select TravellerCustomerID from TblTravellerDetail where TravellerExpeditionID=@p1 and TravellerSeatNo=14", connection);
                command11.Parameters.AddWithValue("@p1", deger);
                SqlDataReader dr10 = command11.ExecuteReader();
                if (dr10.Read())
                {
                    string b1 = dr10[0].ToString();
                    dr10.Close();
                    SqlCommand command12 = new SqlCommand("select CustomerGender from TblCustomer where CustomerID=" + b1, connection);
                    SqlDataReader dr11 = command12.ExecuteReader();
                    while (dr11.Read())
                    {
                        if (dr11[0].ToString() == "Kadın")
                        {
                            Btn14.BackColor = Color.Pink;

                        }
                        else
                        {
                            Btn14.BackColor = Color.LightBlue;

                        }
                    }
                    dr11.Close();
                }
                dr10.Close();

            }
            if (koltukno.Contains("15"))
            {

                SqlCommand command11 = new SqlCommand("select TravellerCustomerID from TblTravellerDetail where TravellerExpeditionID=@p1 and TravellerSeatNo=15", connection);
                command11.Parameters.AddWithValue("@p1", deger);
                SqlDataReader dr10 = command11.ExecuteReader();
                if (dr10.Read())
                {
                    string b1 = dr10[0].ToString();
                    dr10.Close();
                    SqlCommand command12 = new SqlCommand("select CustomerGender from TblCustomer where CustomerID=" + b1, connection);
                    SqlDataReader dr11 = command12.ExecuteReader();
                    while (dr11.Read())
                    {
                        if (dr11[0].ToString() == "Kadın")
                        {
                            Btn15.BackColor = Color.Pink;
                            k15 = "Kadın";
                        }
                        else
                        {
                            Btn15.BackColor = Color.LightBlue;
                            k15 = "Erkek";
                        }
                    }
                    dr11.Close();
                }
                dr10.Close();

            }
            if (koltukno.Contains("16"))
            {

                SqlCommand command11 = new SqlCommand("select TravellerCustomerID from TblTravellerDetail where TravellerExpeditionID=@p1 and TravellerSeatNo=16", connection);
                command11.Parameters.AddWithValue("@p1", deger);
                SqlDataReader dr10 = command11.ExecuteReader();
                if (dr10.Read())
                {
                    string b1 = dr10[0].ToString();
                    dr10.Close();
                    SqlCommand command12 = new SqlCommand("select CustomerGender from TblCustomer where CustomerID=" + b1, connection);
                    SqlDataReader dr11 = command12.ExecuteReader();
                    while (dr11.Read())
                    {
                        if (dr11[0].ToString() == "Kadın")
                        {
                            Btn16.BackColor = Color.Pink;
                            k16 = "Kadın";
                        }
                        else
                        {
                            Btn16.BackColor = Color.LightBlue;
                            k16 = "Erkek";
                        }
                    }
                    dr11.Close();
                }
                dr10.Close();

            }
            if (koltukno.Contains("17"))
            {

                SqlCommand command11 = new SqlCommand("select TravellerCustomerID from TblTravellerDetail where TravellerExpeditionID=@p1 and TravellerSeatNo=17", connection);
                command11.Parameters.AddWithValue("@p1", deger);
                SqlDataReader dr10 = command11.ExecuteReader();
                if (dr10.Read())
                {
                    string b1 = dr10[0].ToString();
                    dr10.Close();
                    SqlCommand command12 = new SqlCommand("select CustomerGender from TblCustomer where CustomerID=" + b1, connection);
                    SqlDataReader dr11 = command12.ExecuteReader();
                    while (dr11.Read())
                    {
                        if (dr11[0].ToString() == "Kadın")
                        {
                            Btn17.BackColor = Color.Pink;

                        }
                        else
                        {
                            Btn17.BackColor = Color.LightBlue;

                        }
                    }
                    dr11.Close();
                }
                dr10.Close();

            }
            if (koltukno.Contains("18"))
            {

                SqlCommand command11 = new SqlCommand("select TravellerCustomerID from TblTravellerDetail where TravellerExpeditionID=@p1 and TravellerSeatNo=18", connection);
                command11.Parameters.AddWithValue("@p1", deger);
                SqlDataReader dr10 = command11.ExecuteReader();
                if (dr10.Read())
                {
                    string b1 = dr10[0].ToString();
                    dr10.Close();
                    SqlCommand command12 = new SqlCommand("select CustomerGender from TblCustomer where CustomerID=" + b1, connection);
                    SqlDataReader dr11 = command12.ExecuteReader();
                    while (dr11.Read())
                    {
                        if (dr11[0].ToString() == "Kadın")
                        {
                            Btn18.BackColor = Color.Pink;
                            k18 = "Kadın";
                        }
                        else
                        {
                            Btn18.BackColor = Color.LightBlue;
                            k18 = "Erkek";
                        }
                    }
                    dr11.Close();
                }
                dr10.Close();

            }
            if (koltukno.Contains("19"))
            {

                SqlCommand command11 = new SqlCommand("select TravellerCustomerID from TblTravellerDetail where TravellerExpeditionID=@p1 and TravellerSeatNo=19", connection);
                command11.Parameters.AddWithValue("@p1", deger);
                SqlDataReader dr10 = command11.ExecuteReader();
                if (dr10.Read())
                {
                    string b1 = dr10[0].ToString();
                    dr10.Close();
                    SqlCommand command12 = new SqlCommand("select CustomerGender from TblCustomer where CustomerID=" + b1, connection);
                    SqlDataReader dr11 = command12.ExecuteReader();
                    while (dr11.Read())
                    {
                        if (dr11[0].ToString() == "Kadın")
                        {
                            Btn19.BackColor = Color.Pink;
                            k19 = "Kadın";
                        }
                        else
                        {
                            Btn19.BackColor = Color.LightBlue;
                            k19 = "Erkek";
                        }
                    }
                    dr11.Close();
                }
                dr10.Close();

            }
            if (koltukno.Contains("20"))
            {

                SqlCommand command11 = new SqlCommand("select TravellerCustomerID from TblTravellerDetail where TravellerExpeditionID=@p1 and TravellerSeatNo=20", connection);
                command11.Parameters.AddWithValue("@p1", deger);
                SqlDataReader dr10 = command11.ExecuteReader();
                if (dr10.Read())
                {
                    string b1 = dr10[0].ToString();
                    dr10.Close();
                    SqlCommand command12 = new SqlCommand("select CustomerGender from TblCustomer where CustomerID=" + b1, connection);
                    SqlDataReader dr11 = command12.ExecuteReader();
                    while (dr11.Read())
                    {
                        if (dr11[0].ToString() == "Kadın")
                        {
                            Btn20.BackColor = Color.Pink;

                        }
                        else
                        {
                            Btn20.BackColor = Color.LightBlue;

                        }
                    }
                    dr11.Close();
                }
                dr10.Close();

            }
            if (koltukno.Contains("21"))
            {

                SqlCommand command11 = new SqlCommand("select TravellerCustomerID from TblTravellerDetail where TravellerExpeditionID=@p1 and TravellerSeatNo=21", connection);
                command11.Parameters.AddWithValue("@p1", deger);
                SqlDataReader dr10 = command11.ExecuteReader();
                if (dr10.Read())
                {
                    string b1 = dr10[0].ToString();
                    dr10.Close();
                    SqlCommand command12 = new SqlCommand("select CustomerGender from TblCustomer where CustomerID=" + b1, connection);
                    SqlDataReader dr11 = command12.ExecuteReader();
                    while (dr11.Read())
                    {
                        if (dr11[0].ToString() == "Kadın")
                        {
                            Btn21.BackColor = Color.Pink;
                            k21 = "Kadın";
                        }
                        else
                        {
                            Btn21.BackColor = Color.LightBlue;
                            k21 = "Erkek";
                        }
                    }
                    dr11.Close();
                }
                dr10.Close();

            }
            if (koltukno.Contains("22"))
            {

                SqlCommand command11 = new SqlCommand("select TravellerCustomerID from TblTravellerDetail where TravellerExpeditionID=@p1 and TravellerSeatNo=22", connection);
                command11.Parameters.AddWithValue("@p1", deger);
                SqlDataReader dr10 = command11.ExecuteReader();
                if (dr10.Read())
                {
                    string b1 = dr10[0].ToString();
                    dr10.Close();
                    SqlCommand command12 = new SqlCommand("select CustomerGender from TblCustomer where CustomerID=" + b1, connection);
                    SqlDataReader dr11 = command12.ExecuteReader();
                    while (dr11.Read())
                    {
                        if (dr11[0].ToString() == "Kadın")
                        {
                            Btn22.BackColor = Color.Pink;
                            k22 = "Kadın";
                        }
                        else
                        {
                            Btn22.BackColor = Color.LightBlue;
                            k22 = "Erkek";
                        }
                    }
                    dr11.Close();
                }
                dr10.Close();

            }
            connection.Close();
            koltukno.Clear();
        }

        void color()
        {
            Btn1.BackColor = this.BackColor;
            Btn2.BackColor = this.BackColor;
            Btn3.BackColor = this.BackColor;
            Btn4.BackColor = this.BackColor;
            Btn5.BackColor = this.BackColor;
            Btn6.BackColor = this.BackColor;
            Btn7.BackColor = this.BackColor;
            Btn8.BackColor = this.BackColor;
            Btn9.BackColor = this.BackColor;
            Btn10.BackColor = this.BackColor;
            Btn11.BackColor = this.BackColor;
            Btn12.BackColor = this.BackColor;
            Btn13.BackColor = this.BackColor;
            Btn14.BackColor = this.BackColor;
            Btn15.BackColor = this.BackColor;
            Btn16.BackColor = this.BackColor;
            Btn17.BackColor = this.BackColor;
            Btn18.BackColor = this.BackColor;
            Btn19.BackColor = this.BackColor;
            Btn20.BackColor = this.BackColor;
            Btn21.BackColor = this.BackColor;
            Btn22.BackColor = this.BackColor;

        }
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            LblId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            label7.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            color();

            timer1.Start();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            list1();
            timer1.Stop();
        }
    }
}
