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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            FrmAnaForm frm = new FrmAnaForm();
            frm.Show();
            this.Hide();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
        ldbEntitiyProjeEntities db = new ldbEntitiyProjeEntities();

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.TBL_URUN select new
            {
                x.URUNID,
                x.URUNAD,
                x.MARKA,
                x.STOK,
                x.FİYAT,
                x.TBL_KATEGORİ.AD,
                x.DURUM

            }).ToList();

        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TBL_URUN t = new TBL_URUN();
            t.URUNAD = TxtUrunADI.Text;
            t.MARKA = TxtMarka.Text;
            t.STOK = short.Parse(TxtStok.Text);
            t.KATEGORİ = int.Parse(CmbKategori.SelectedValue.ToString());
            t.FİYAT = decimal.Parse(TxtFiyat.Text);
            t.DURUM = true;

            db.TBL_URUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Sisteme Kaydedildi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtUrunID.Text);
            var urun  = db.TBL_URUN.Find(x);
            db.TBL_URUN.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Ürün Sistemden Silindi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);


      
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtUrunID.Text);
            var urun = db.TBL_URUN.Find(x);
            urun.URUNAD =TxtUrunADI.Text;
            urun.STOK =short.Parse(TxtStok.Text);
            urun.MARKA =TxtMarka.Text;
            urun.FİYAT= decimal.Parse(TxtFiyat.Text);
            urun.DURUM = true;
            db.SaveChanges();
            MessageBox.Show("Ürün Güncelendi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);    

        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.TBL_KATEGORİ 
                               select new 
                               {
                                   x.ID,
                                   x.AD
                               }
                               ).ToList();

            CmbKategori.ValueMember = "ID";
            CmbKategori.DisplayMember = "AD";
            CmbKategori.DataSource = kategoriler;
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtUrunID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtUrunADI.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtMarka.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtStok.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            CmbKategori.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }
    }
}
