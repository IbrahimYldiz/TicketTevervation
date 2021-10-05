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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-OC5036T\MSSQLSERVER1;Initial Catalog=DbTicketTevervation;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("select CostomerAouthority from TblCustomer where CustomerTC=@p1 and CustomerPass=@p2", connection);
            command.Parameters.AddWithValue("@p1", MskTc.Text);
            command.Parameters.AddWithValue("@p2", TxtPassword.Text);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                if (dr[0].ToString() == "1")
                {
                    //yolcu
                    FrmCustomer fr = new FrmCustomer();
                    fr.TC = MskTc.Text;
                    fr.Show();
                    this.Hide();
                }
                else if (dr[0].ToString() == "2")
                {
                    // personel
                    FrmBranch fr1 = new FrmBranch();
                    fr1.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("T.C. Kimlik Numarası ya da Şifre Hatalı");
            }
            connection.Close();
        }

        private void LlblSingup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSingup fr = new FrmSingup();
            fr.Show();
            
        }
    }
}
