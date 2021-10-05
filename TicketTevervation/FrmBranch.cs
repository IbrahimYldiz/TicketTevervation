using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketTevervation
{
    public partial class FrmBranch : Form
    {
        public FrmBranch()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmChauffer fr = new FrmChauffer();
            fr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmChaufferInfo fr = new FrmChaufferInfo();
            fr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmExpeditionInfo fr = new FrmExpeditionInfo();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmExpedition fr = new FrmExpedition();
            fr.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmSingup fr = new FrmSingup();
            fr.Show();
        }

        private void FrmBranch_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Şube Yetkili Kaydı Sadece Sistem Yönetici Tarafından Yapılmaktadır. Yeni Bir Kayıt Yaptırmak İçin Sistem Yöneticisi İle İletişime Geçiniz");
        }
    }
}
