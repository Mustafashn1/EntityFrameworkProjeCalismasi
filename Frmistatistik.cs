using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkProjeÇalışması
{
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }
        ldbEntitiyProjeEntities db = new ldbEntitiyProjeEntities();

        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            label2.Text = db.TBL_KATEGORİ.Count().ToString();
            label3.Text = db.TBL_URUN.Count().ToString();
            label5.Text = db.TBL_MUSTERI.Count(x => x.DURUN == true).ToString();
            label7.Text = db.TBL_MUSTERI.Count(x => x.DURUN == false).ToString();
            label13.Text = db.TBL_URUN.Sum(x => x.STOK).ToString();
            label21.Text = db.TBL_SATIS.Sum(x => x.FIYAT).ToString() + " TL";

            // bu metotda ise x isiminde bir değişken Tbl_urunlere gidip fiyata göre
            // bir  sıralama yapıyor en yüksekten den en düşüğüne düzenle
            // onlarında içinden en yüksek olanı label11 yazdır.
            label11.Text = (from x in db.TBL_URUN orderby x.FİYAT descending select x.URUNAD).FirstOrDefault();
            label9.Text = (from x in db.TBL_URUN orderby x.FİYAT ascending select x.URUNAD).FirstOrDefault();
            label15.Text = db.TBL_URUN.Count(x => x.KATEGORİ == 5).ToString();
            label17.Text = db.TBL_URUN.Count(x => x.URUNAD == "BUZDOLABI").ToString();

            // Şehiri seç, Seçtiğin bu şehri Tekrarsız olarak getir. getirdiğin şehirleri say ve yazdır.
            label23.Text = (from x in db.TBL_MUSTERI select x.SEHİR).Distinct().Count().ToString();

            label19.Text = db.MARKAGETİR().FirstOrDefault();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmAnaForm frm = new FrmAnaForm();
            frm.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
