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
using System.Text.RegularExpressions;

namespace TicketTevervation
{
    public partial class FrmSingup : Form
    {
        public FrmSingup()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-OC5036T\MSSQLSERVER1;Initial Catalog=DbTicketTevervation;Integrated Security=True");

        static bool EmailControl(string mail)
        {
            string pattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
           + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
           + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
           + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
           + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
           + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";
            return (new Regex(pattern)).IsMatch(mail);
        }
        private void FrmSingup_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void TxtMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            connection.Open();
            if (TxtName.Text.Trim() != "" && TxtSurname.Text.Trim() != "" && MskPhone.Text.Trim() != "(___) ___-____" && MskTC.Text.Trim() != "___________" && TxtMail.Text.Trim() != "" && TxtPassword.Text.Trim() != "")
            {
                string mailc = TxtMail.Text;
                bool control = EmailControl(mailc);
                if (control==true)
                {

                    SqlCommand command = new SqlCommand("select * from TblCustomer where CustomerTC=@p1", connection);
                    command.Parameters.AddWithValue("@p1", MskTC.Text.Trim());
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.Read())
                    {
                        MessageBox.Show("TC Kimlik Numarası Daha Önce Kayıt Edilmiş");

                    }
                    else
                    {
                        dr.Close();
                        connection.Close();
                        connection.Open();
                        SqlCommand command1 = new SqlCommand("select * from TblCustomer where CustomerPhone=@p1", connection);
                        command1.Parameters.AddWithValue("@p1", MskPhone.Text.Trim());
                        SqlDataReader dr1 = command1.ExecuteReader();
                        if (dr1.Read())
                        {
                            MessageBox.Show("Telefon Numarası Daha Önce Kayıt Edilmiş");

                        }
                        else
                        {


                            string Aouthority = "1";
                            dr1.Close();
                            SqlCommand command2 = new SqlCommand("insert into TblCustomer (CustomerName,CustomerSurname,CustomerPhone,CustomerTC,CustomerGender,CustomerMail,CustomerPass,CostomerAouthority) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", connection);
                            command2.Parameters.AddWithValue("@p1", TxtName.Text);
                            command2.Parameters.AddWithValue("@p2", TxtSurname.Text);
                            command2.Parameters.AddWithValue("@p3", MskPhone.Text);
                            command2.Parameters.AddWithValue("@p4", MskTC.Text);
                            command2.Parameters.AddWithValue("@p5", CbmGender.Text);
                            command2.Parameters.AddWithValue("@p6", TxtMail.Text);
                            command2.Parameters.AddWithValue("@p7", TxtPassword.Text);
                            command2.Parameters.AddWithValue("@p8", Aouthority);
                            command2.ExecuteNonQuery();
                            MessageBox.Show("Yolcu Sisteme Kayıt Edilmiştir.");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Mail Adresi Hatalı Lütfen Kontrol Ediniz");
                }

            }
            else
            {
                MessageBox.Show("Lütfen Bütün Alanları Doldurunuz");
            }
            connection.Close();
        }
        
    }
}
