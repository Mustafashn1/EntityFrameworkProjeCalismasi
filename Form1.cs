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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ldbEntitiyProjeEntities db = new ldbEntitiyProjeEntities();
        private void BtnListele_Click(object sender, EventArgs e)
        {
            // listele çalışması
            // To.List Metodu ile Listeleme İşlemi Yapılıyor

            var kategoriler = db.TBL_KATEGORİ.ToList();
            dataGridView1.DataSource = kategoriler;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            // Ekleme Çalışması 
            // Add Metodu ile Ekleme İşlami Yapılıyor
            // Entity Framework de SaveChanges işlemi Sqlde  ExecuteNonQuery() İşlemi ile aynı işlemi yapıyor.

            TBL_KATEGORİ t = new TBL_KATEGORİ();
            t.AD = TxtKategoriAd.Text;
            db.TBL_KATEGORİ.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori Ekleme İşlemi Gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            
                int x = Convert.ToInt32(TxtKategoriID.Text);
                var ktgr = db.TBL_KATEGORİ.Find(x);
                db.TBL_KATEGORİ.Remove(ktgr);
                db.SaveChanges();
                MessageBox.Show("Kategori Silme İşlemi Gerçekleşti!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtKategoriID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtKategoriAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TxtKategoriAd.Clear();
            TxtKategoriID.Clear();

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtKategoriID.Text);
            var ktgr = db.TBL_KATEGORİ.Find(x);
            ktgr.AD = TxtKategoriAd.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme İşlemi Gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            FrmAnaForm frm = new FrmAnaForm();
            frm.Show();
            this.Hide();
        }
    }
}
