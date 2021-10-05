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
    public partial class FrmChauffer : Form
    {
        public FrmChauffer()
        {
            InitializeComponent();
        }

        
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-OC5036T\MSSQLSERVER1;Initial Catalog=DbTicketTevervation;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            if (TxtChaufferName.Text.Trim() != "" && TxtChaufferSurname.Text.Trim() != "" && TxtChaufferCar.Text.Trim() != "" && MskChaufferTC.Text.Trim() != "" && MskPhone.Text.Trim() != "(   )    -")
            {
                if (MskChaufferTC.Text.Trim().Length == 11)
                {
                    if (TxtChaufferCar.Text.Trim().Length > 8)
                    {
                        if (MskPhone.Text.Trim().Length > 12)
                        {
                            
                            SqlCommand command1 = new SqlCommand("select * from TblChauffer where ChaufferTC=@p1 ", connection);
                            command1.Parameters.AddWithValue("@p1", MskChaufferTC.Text);
                            SqlDataReader dr = command1.ExecuteReader();
                            if (dr.Read())
                            {
                                MessageBox.Show("Bu Şöför Kayıtlı");
                                dr.Close();
                            }
                            else
                            {
                                dr.Close();
                                SqlCommand command2 = new SqlCommand("select * from TblChauffer where ChaufferPhone=@p1 ", connection);
                                command2.Parameters.AddWithValue("@p1", MskPhone.Text);
                                SqlDataReader dr1 = command2.ExecuteReader();
                                if (dr1.Read())
                                {
                                    MessageBox.Show("Bu Telefon Numarası Sisteme Kayıtlı. Lütfen Telefon Numarasını Kontrol Ediniz");
                                    dr1.Close();
                                }
                                else
                                {
                                    dr1.Close();
                                    SqlCommand command = new SqlCommand("insert into TblChauffer (ChaufferName,ChaufferSurname,ChaufferTC,ChaufferCarPlate,ChaufferPhone) values (@p1,@p2,@p3,@p4,@p5)", connection);
                                    command.Parameters.AddWithValue("@p1", TxtChaufferName.Text);
                                    command.Parameters.AddWithValue("@p2", TxtChaufferSurname.Text);
                                    command.Parameters.AddWithValue("@p3", MskChaufferTC.Text);
                                    command.Parameters.AddWithValue("@p4", TxtChaufferCar.Text.ToUpper());
                                    command.Parameters.AddWithValue("@p5", MskPhone.Text);
                                    command.ExecuteNonQuery();
                                    MessageBox.Show("Kayıt Başarılı");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Telefon Numarası Hatalı. Lütfen Kontrol Ediniz");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Araç Plakası Hatalı Lütfen Kontrol Ediniz");
                    }

                }
                else
                {
                    MessageBox.Show("Şöförün T.C. Kimlik Numarası Hatalı Lütfen Kontrol Ediniz");
                }
            }
            else
            {
                MessageBox.Show("Lütfen Bütün Bilgileri Eksiksiz Giriniz");
            }
            connection.Close();
        }

        private void FrmChauffer_Load(object sender, EventArgs e)
        {

        }
    }
}
