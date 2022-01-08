using MetroSet_UI.Forms;
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
using System.Data.SQLite;


namespace Marangoz_İşletme
{
    public partial class Form1 : MetroSetForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        //DATA BAGLANTISI
        SQLiteConnection baglantı = new SQLiteConnection("Data source=veriler.db");


        //Kaydetme  Ve  Ekleme Button


        private void FaturalandırmaKaydet_Click(object sender, EventArgs e)
        {


            baglantı.Open();
            SQLiteCommand komut = new SQLiteCommand("insert into Faturalandırma(FaturaNo,MüsteriID,SiparisID,ÜrünAdı,ÜrünID,ÜrünFiyat)values (@FaturaNo,@MüşteriID,@SiparişID,@ÜrünAdı1,@ÜrünID,@ÜrünFiyat)", baglantı);
            komut.Parameters.AddWithValue("@FaturaNo", FaturaNo2.Text);
            komut.Parameters.AddWithValue("@MüşteriID", MüşteriTelefon2.Text);
            komut.Parameters.AddWithValue("@SiparişID", SiparişID2.Text);
            komut.Parameters.AddWithValue("@ÜrünAdı1", ÜrünAdı1.Text);
            komut.Parameters.AddWithValue("@ÜrünID", ÜrünID3.Text);
            komut.Parameters.AddWithValue("@ÜrünFiyat", ÜrünFiyat1.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            TabloGuncelle();
            //sipariş edilen ürünlerin , fiyatını toplayıp hem faturalandırmadaki labela hem ödeme bilgilerindeki texte eklemek.
            int ToplamFiyat = Convert.ToInt32(ÜrünFiyat1.Text);
            int ToplamFiyat3 = Convert.ToInt32(ToplamFiyat2.Text.Trim());
            int toplam = ToplamFiyat3 + ToplamFiyat;
            ToplamFiyat2.Text = Convert.ToString(toplam.ToString());
            ToplamFiyat1.Text = Convert.ToString(toplam);

            //Text Temizleme

            FaturaNo2.Text = String.Empty;
            MüşteriTelefon2.Text = String.Empty;
            SiparişID2.Text = String.Empty;
            ÜrünAdı1.Text = String.Empty;
            ÜrünID3.Text = String.Empty;
            ÜrünFiyat1.Text = String.Empty;
            FaturaNo2.Focus();

        }
        private void ÖdemeBilgileriKaydet_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SQLiteCommand komut = new SQLiteCommand("insert into ÖdemeBilgileri(FaturaNo,MüsteriID,ToplamFiyat,ÖdenenFiyat,KalanFiyat)values(@FaturaNo1,@MüşteriID,@ToplamFiyat,@ÖdenenFiyat,@KalanFiyat)", baglantı);
            komut.Parameters.AddWithValue("@FaturaNo1", FaturaNo1.Text);
            komut.Parameters.AddWithValue("@MüşteriID", txt_must3.Text);
            komut.Parameters.AddWithValue("@ToplamFiyat", ToplamFiyat1.Text);
            komut.Parameters.AddWithValue("@ÖdenenFiyat", ÖdenenFiyat1.Text);
            komut.Parameters.AddWithValue("@KalanFiyat", KalanFiyat1.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            TabloGuncelle();


            //Text Temizleme*
            FaturaNo1.Text = String.Empty;
            txt_must3.Text = String.Empty;
            txt_must_adi.Text = String.Empty;
            ToplamFiyat1.Text = String.Empty;
            ÖdenenFiyat1.Text = String.Empty;
            KalanFiyat1.Text = String.Empty;
            FaturaNo1.Focus();
        }

        private void TedarikciKaydet_Click(object sender, EventArgs e)
        {
            
            baglantı.Open();
                SQLiteCommand komut = new SQLiteCommand("insert into Tedarikci(TC,Ad,Soyad,Telefon,Mail,Adres)values(@TC,@Ad,@Soyad,@Telefon,@Mail,@Adres)", baglantı);
            komut.Parameters.AddWithValue("@TC", TC2.Text);
            komut.Parameters.AddWithValue("@Ad", Ad3.Text);
            komut.Parameters.AddWithValue("@Soyad", Soyad2.Text);
            komut.Parameters.AddWithValue("@Telefon", Telefon2.Text);
            komut.Parameters.AddWithValue("@Mail", Mail2.Text);
            komut.Parameters.AddWithValue("@Adres", Adres2.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            TabloGuncelle();

            //Text Temizleme
            TC2.Text = String.Empty;
            Ad3.Text = String.Empty;
            Soyad2.Text = String.Empty;
            Telefon2.Text = String.Empty;
            Mail2.Text = String.Empty;
            Adres2.Text = String.Empty;
            TC2.Focus();
           
        }

        private void MüsteriKaydet_Click(object sender, EventArgs e)
        {
           
           
                baglantı.Open();
                SQLiteCommand komut = new SQLiteCommand("insert into Müsteri(TC,Ad,Soyad,Telefon,DogumTarihi,Cinsiyet,Mail,Adres)values(@TC1,@Ad1,@Soyad1,@Telefon1,@DoğumTarihi,@Cinsiyet,@Mail1,@Adres1)", baglantı);
            komut.Parameters.AddWithValue("@TC1", TC1.Text);
            komut.Parameters.AddWithValue("@Ad1", Ad1.Text);
            komut.Parameters.AddWithValue("@Soyad1", Soyad1.Text);
            komut.Parameters.AddWithValue("@Telefon1", Telefon1.Text);
            komut.Parameters.AddWithValue("@DoğumTarihi", DoğumTarihi1.Text);
            komut.Parameters.AddWithValue("@Cinsiyet", Cinsiyet1.Text);
            komut.Parameters.AddWithValue("@Mail1", Mail1.Text);
            komut.Parameters.AddWithValue("@Adres1", Adres1.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            TabloGuncelle();


            //Text Temizleme
            TC1.Text = String.Empty;
            Ad1.Text = String.Empty;
            Soyad1.Text = String.Empty;
            DoğumTarihi1.Text = String.Empty;
            Cinsiyet1.Text = null;
            Telefon1.Text = String.Empty;
            Mail1.Text = String.Empty;
            Adres1.Text = String.Empty;
            TC1.Focus();
       }
        private void MalzemeKaydet_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SQLiteCommand komut = new SQLiteCommand("insert into Malzeme(Ad,Birim,Adet,MiktarBoyut,Fiyat,AlındıgıTarih)values(@Ad2,@Birim,@Adet,@MiktarBoyut,@Fiyat,@AlındığıTarih)", baglantı);
         
            komut.Parameters.AddWithValue("@Ad2", Ad2.Text);
            komut.Parameters.AddWithValue("@Birim", Birim1.Text);
            komut.Parameters.AddWithValue("@Adet", Adet1.Text);
            komut.Parameters.AddWithValue("@MiktarBoyut", MiktarBoyut1.Text);
            komut.Parameters.AddWithValue("@Fiyat", Fiyat1.Text);
            komut.Parameters.AddWithValue("@AlındığıTarih", AlındığıTarih1.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            TabloGuncelle();


            //Text Temizleme
            MalzemeID2.Text = String.Empty;
            Ad2.Text = String.Empty;
            Birim1.Text = String.Empty;
            Adet1.Text = String.Empty;
            MiktarBoyut1.Text = String.Empty;
            Fiyat1.Text = String.Empty;

            AlındığıTarih1.Text = String.Empty;
            MalzemeID2.Focus();
        }
        
        private void SiparisKaydet_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            //Siparişlere satır eklerken aynı ürünID'sinde veritabanında başka bir ürün var mı diye kontrol ettiğimiz blok.
            //Veritabanından gelen değer
            SQLiteCommand sql_sorgu = new SQLiteCommand($"SELECT ÜrünID FROM Siparis where ÜrünID='{txt_urun_id.Text}'",baglantı);
            string veri = Convert.ToString(sql_sorgu.ExecuteScalar());

            if (Convert.ToString(veri).Trim() == txt_urun_id.Text)
            {
                MessageBox.Show("Eklemeye çalıştığınız ürün ID'sine ait bir başka ID zaten kayıtlıdır.", "Hata Oluştu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                SQLiteCommand komut = new SQLiteCommand("insert into Siparis(MüsteriID,ÜrünID,ÜrünAdı,SiparisAdedi,ÜrünFiyatı)values(@MüsteriID,@ÜrünID,@ÜrünAdı,@SiparisAdedi,@ÜrünFiyatı)", baglantı);
                komut.Parameters.AddWithValue("@MüsteriID", MüsteriTelefon1.Text);
                komut.Parameters.AddWithValue("@ÜrünID", txt_urun_id.Text);
                komut.Parameters.AddWithValue("@ÜrünAdı", ÜrünAdı2.Text);
                komut.Parameters.AddWithValue("@SiparisAdedi", SiparisAdedi1.Text);
                komut.Parameters.AddWithValue("@ÜrünFiyatı", ÜrünFiyatı1.Text);
                komut.ExecuteNonQuery();


                //Text Temizleme
                MüsteriTelefon1.Text = String.Empty;
                ÜrünAdı2.Text = String.Empty;
                SiparisAdedi1.Text = String.Empty;
                txt_siparis_id.Text = String.Empty;
                ÜrünFiyatı1.Text = String.Empty;
                txt_urun_id.Text = String.Empty;
                MüsteriTelefon1.Focus();
            }
            baglantı.Close();
            TabloGuncelle();






        }

        
        private void ÜrünOlusturmaKaydet_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            //Ürün kaydederken veritabanında yeterli malzemenin var olup olmadığı if else blokları ile kontrol ediliyor.
            SQLiteCommand cmd = new SQLiteCommand($"SELECT Adet from Malzeme where MalzemeID='{MalzemeId3.Text}'",baglantı);

            int toplam_stok = Convert.ToInt32(cmd.ExecuteScalar());
            int cikarilacak_deger = Convert.ToInt32(MalzemeAdedi2.Text);
            //Malzeme sayısını 0 giremez.
            if (cikarilacak_deger == 0) {
                MessageBox.Show("Malzeme Sayısı Sıfır Olamaz.", "Hata uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            //Eğer stoktaki malzeme sayısından fazla kullanım olursa bu bloğa giriyor.
            else if (cikarilacak_deger > toplam_stok)
            {
                MessageBox.Show("Yeterli Malzeme kalmamıştır", "Hata uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            //Eğer hata çıkmaz ise kod  çalışıyor. 
            else {
                int sonuc = toplam_stok - cikarilacak_deger;
                SQLiteCommand sql_guncelle = new SQLiteCommand($"UPDATE Malzeme set Adet='{sonuc}' where MalzemeID='{MalzemeId3.Text}'",baglantı);
                sql_guncelle.ExecuteNonQuery();

                //insert deyimi ile veritabanına Ürünolusturma tablosuna veri kaydediliyor.
                SQLiteCommand komut = new SQLiteCommand("insert into ÜrünOlusturma(ÜrünID,ÜretimTarihi,MalzemeID,MalzemeAdedi)values(@ÜrünID1,@ÜretimTarihi,@MalzemeId,@MalzemeAdedi)", baglantı);
            komut.Parameters.AddWithValue("@ÜrünID1", ÜrünID1.Text);
            komut.Parameters.AddWithValue("@ÜretimTarihi", ÜretimTarihi1.Text);
            komut.Parameters.AddWithValue("@MalzemeId", MalzemeId3.Text);
            komut.Parameters.AddWithValue("@MalzemeAdedi", MalzemeAdedi2.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            TabloGuncelle();
                //Text Temizleme
                txt_ID.Text = String.Empty;
                ÜrünID1.Text = String.Empty;
                ÜretimTarihi1.Text = String.Empty;
                MalzemeId3.Text = String.Empty;
                MalzemeAdedi2.Text = String.Empty;
                ÜrünID1.Focus();
            }
            baglantı.Close();
        }


        //DataGridView Çift Tık İle Veri Getirme
        private void SatımİşleriData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçilenalan = SatımİşleriData.SelectedCells[0].RowIndex;
            string FaturaNo = SatımİşleriData.Rows[seçilenalan].Cells[0].Value.ToString();
            string MüsteriTelefon = SatımİşleriData.Rows[seçilenalan].Cells[1].Value.ToString();
            string SiparisID = SatımİşleriData.Rows[seçilenalan].Cells[2].Value.ToString();
            string ÜrünAdı = SatımİşleriData.Rows[seçilenalan].Cells[3].Value.ToString();
            string ÜrünID = SatımİşleriData.Rows[seçilenalan].Cells[4].Value.ToString();
            string ÜrünFiyat = SatımİşleriData.Rows[seçilenalan].Cells[5].Value.ToString();

            FaturaNo2.Text = FaturaNo.Trim();
            MüşteriTelefon2.Text = MüsteriTelefon.Trim();
            SiparişID2.Text = SiparisID.Trim();
            ÜrünAdı1.Text = ÜrünAdı.Trim();
            ÜrünID3.Text = ÜrünID.Trim();
            ÜrünFiyat1.Text = ÜrünFiyat.Trim();

        }
        //DataGridView Çift Tık İle Veri Getirme
        private void ÖdemeBilgileriData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçilenalan = ÖdemeBilgileriData.SelectedCells[0].RowIndex;
            string FaturaNo = ÖdemeBilgileriData.Rows[seçilenalan].Cells[0].Value.ToString();
            string MüsteriID = ÖdemeBilgileriData.Rows[seçilenalan].Cells[1].Value.ToString();
            string ToplamFiyat = ÖdemeBilgileriData.Rows[seçilenalan].Cells[2].Value.ToString();
            string ÖdenenFiyat = ÖdemeBilgileriData.Rows[seçilenalan].Cells[3].Value.ToString();
            string KalanFiyat = ÖdemeBilgileriData.Rows[seçilenalan].Cells[4].Value.ToString();

            FaturaNo1.Text = FaturaNo.Trim();
            txt_must3.Text = MüsteriID.Trim();
            ToplamFiyat1.Text = ToplamFiyat.Trim();
            ÖdenenFiyat1.Text = ÖdenenFiyat.Trim();
            KalanFiyat1.Text = KalanFiyat.Trim();
            baglantı.Open();
            //Ödeme Bilgileri tablosundan Müşteri ID'sine göre,müşteri tablosundan ;müşterinin adı ve soyadı ilgili labelların Text özelliklerine aktarılıyor.
            string sql = $"SELECT Ad FROM ÖdemeBilgileri INNER JOIN Müsteri ON ÖdemeBilgileri.MüsteriID=Müsteri.MusteriID where MüsteriID='{txt_must3.Text}'";
            string sql2 = $"SELECT Soyad FROM ÖdemeBilgileri INNER JOIN Müsteri ON ÖdemeBilgileri.MüsteriID=Müsteri.MusteriID where MüsteriID='{txt_must3.Text}'";
            SQLiteCommand cmd = new SQLiteCommand(sql,baglantı);
            SQLiteCommand cmd2 = new SQLiteCommand(sql2,baglantı);

            string isim = Convert.ToString(cmd.ExecuteScalar());
            string soyisim = Convert.ToString(cmd2.ExecuteScalar());

            baglantı.Close();
            txt_must_adi.Text = isim.Trim() +" " +soyisim.Trim();

        }
        //DataGridView Çift Tık İle Veri Getirme
        private void TedarikçiData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçilenalan = TedarikçiData.SelectedCells[0].RowIndex;
            string TC = TedarikçiData.Rows[seçilenalan].Cells[0].Value.ToString();
            string Ad = TedarikçiData.Rows[seçilenalan].Cells[1].Value.ToString();
            string Soyad = TedarikçiData.Rows[seçilenalan].Cells[2].Value.ToString();
            string Telefon = TedarikçiData.Rows[seçilenalan].Cells[3].Value.ToString();
            string Mail = TedarikçiData.Rows[seçilenalan].Cells[4].Value.ToString();
            string Adres = TedarikçiData.Rows[seçilenalan].Cells[5].Value.ToString();

            TC2.Text = TC.Trim();
            Ad3.Text = Ad.Trim();
            Soyad2.Text = Soyad.Trim();
            Telefon2.Text = Telefon.Trim();
            Mail2.Text = Mail.Trim();
            Adres2.Text = Adres.Trim();

        }
        //DataGridView Çift Tık İle Veri Getirme
        private void MüşteriData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçilenalan = MüşteriData.SelectedCells[0].RowIndex;
            string TC = MüşteriData.Rows[seçilenalan].Cells[0].Value.ToString();
            string Ad = MüşteriData.Rows[seçilenalan].Cells[1].Value.ToString();
            string Soyad = MüşteriData.Rows[seçilenalan].Cells[2].Value.ToString();
            string DogumTarihi = MüşteriData.Rows[seçilenalan].Cells[3].Value.ToString();
            string Cinsiyet = MüşteriData.Rows[seçilenalan].Cells[4].Value.ToString();
            string Telefon = MüşteriData.Rows[seçilenalan].Cells[5].Value.ToString();
            string Mail = MüşteriData.Rows[seçilenalan].Cells[6].Value.ToString();
            string Adres = MüşteriData.Rows[seçilenalan].Cells[7].Value.ToString();

            TC1.Text = TC.Trim();
            Ad1.Text = Ad.Trim();
            Soyad1.Text = Soyad.Trim();
            DoğumTarihi1.Text = DogumTarihi.Trim();
            Cinsiyet1.Text = Cinsiyet.Trim();
            Telefon1.Text = Telefon.Trim();
            Mail1.Text = Mail.Trim();
            Adres1.Text = Adres.Trim();

        }
        //DataGridView Çift Tık İle Veri Getirme
        private void MalzemeData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçilenalan = MalzemeData.SelectedCells[0].RowIndex;
            string MalzemeID = MalzemeData.Rows[seçilenalan].Cells[0].Value.ToString();
            string Ad = MalzemeData.Rows[seçilenalan].Cells[1].Value.ToString();
            string Birim = MalzemeData.Rows[seçilenalan].Cells[2].Value.ToString();
            string Adet = MalzemeData.Rows[seçilenalan].Cells[3].Value.ToString();
            string MiktarBoyut = MalzemeData.Rows[seçilenalan].Cells[4].Value.ToString();
            string Fiyat = MalzemeData.Rows[seçilenalan].Cells[5].Value.ToString();
            string AlındıgıTarih = MalzemeData.Rows[seçilenalan].Cells[6].Value.ToString();

            MalzemeID2.Text = MalzemeID.Trim();
            Ad2.Text = Ad.Trim();
            Birim1.Text = Birim.Trim();
            Adet1.Text = Adet.Trim();
            MiktarBoyut1.Text = MiktarBoyut.Trim();
            Fiyat1.Text = Fiyat.Trim();
           // Zayiat1.Text = Zayiat.Trim();
            AlındığıTarih1.Text = AlındıgıTarih.Trim();

        }
        //DataGridView Çift Tık İle Veri Getirme
        private void ÜrünOluşturmaData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçilenalan = ÜrünOluşturmaData.SelectedCells[0].RowIndex;
            string ID = ÜrünOluşturmaData.Rows[seçilenalan].Cells[0].Value.ToString();
            string ÜrünID = ÜrünOluşturmaData.Rows[seçilenalan].Cells[1].Value.ToString();
            string ÜretimTarihi = ÜrünOluşturmaData.Rows[seçilenalan].Cells[2].Value.ToString();
            string MalzemeID = ÜrünOluşturmaData.Rows[seçilenalan].Cells[3].Value.ToString();
            string MalzemeAdedi = ÜrünOluşturmaData.Rows[seçilenalan].Cells[4].Value.ToString();


            txt_ID.Text = ID.Trim();
            ÜrünID1.Text = ÜrünID.Trim();
            ÜretimTarihi1.Text = ÜretimTarihi.Trim();
            MalzemeId3.Text = MalzemeID.Trim();
            MalzemeAdedi2.Text = MalzemeAdedi.Trim();


        }
        //DataGridView Çift Tık İle Veri Getirme
        private void SiparisData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçilenalan = SiparisData.SelectedCells[0].RowIndex;
            string SiparisID = SiparisData.Rows[seçilenalan].Cells[0].Value.ToString();
            string ÜrünID = SiparisData.Rows[seçilenalan].Cells[1].Value.ToString();
            string ÜrünAdı = SiparisData.Rows[seçilenalan].Cells[3].Value.ToString();
            string SiparisAdedi = SiparisData.Rows[seçilenalan].Cells[4].Value.ToString();
            string ÜrünFiyatı = SiparisData.Rows[seçilenalan].Cells[5].Value.ToString();
            string mustID = SiparisData.Rows[seçilenalan].Cells[2].Value.ToString();


            txt_siparis_id.Text = SiparisID.Trim();
            MüsteriTelefon1.Text = mustID.Trim();
            txt_urun_id.Text = ÜrünID.Trim();
            ÜrünAdı2.Text = ÜrünAdı.Trim();
            SiparisAdedi1.Text = SiparisAdedi.Trim();
            ÜrünFiyatı1.Text = ÜrünFiyatı.Trim();

        }
        //GÜNCELLEME

        private void FaturalandırmaGüncelle_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SQLiteCommand komut2 = new SQLiteCommand($"UPDATE Faturalandırma set MüsteriID='{MüşteriTelefon2.Text}',SiparisID='{SiparişID2.Text}',ÜrünAdı='{ÜrünAdı1.Text}',ÜrünID='{ÜrünID3.Text}',ÜrünFiyat='{ÜrünFiyat1.Text}' where ÜrünID='{ÜrünID3.Text}'", baglantı);
            komut2.ExecuteNonQuery();
            baglantı.Close();
            TabloGuncelle();


            //Text Temizleme
            FaturaNo2.Text = String.Empty;
            MüşteriTelefon2.Text = String.Empty;
            SiparişID2.Text = String.Empty;
            ÜrünAdı1.Text = String.Empty;
            ÜrünID3.Text = String.Empty;
            ÜrünFiyat1.Text = String.Empty;
            FaturaNo2.Focus();
        }

        private void ÖdemeBilgileriGüncelle_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SQLiteCommand komut = new SQLiteCommand("update ÖdemeBilgileri Set ToplamFiyat='" + ToplamFiyat1.Text + "',ÖdenenFiyat='" + ÖdenenFiyat1.Text + "',KalanFiyat='" + KalanFiyat1.Text + "' where FaturaNo = '" + FaturaNo1.Text + "'", baglantı);
            komut.ExecuteNonQuery();
            baglantı.Close();
            TabloGuncelle();

            //Text Temizleme
            FaturaNo1.Text = String.Empty;
            txt_must3.Text = String.Empty;
            txt_must_adi.Text = String.Empty;
            ToplamFiyat1.Text = String.Empty;
            ÖdenenFiyat1.Text = String.Empty;
            KalanFiyat1.Text = String.Empty;
            FaturaNo1.Focus();
        }
        private void TedarikciGüncelle_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SQLiteCommand komut = new SQLiteCommand("update Tedarikci Set TC='" + TC2.Text + "',Ad='" + Ad3.Text + "',Soyad='" + Soyad2.Text + "',Telefon='" + Telefon2.Text + "',Mail='" + Mail2.Text + "',Adres='" + Adres2.Text + "' where TC = '" + TC2.Text + "'", baglantı);
            komut.ExecuteNonQuery();

            baglantı.Close();
            TabloGuncelle();

            //Text Temizleme
            TC2.Text = String.Empty;
            Ad3.Text = String.Empty;
            Soyad2.Text = String.Empty;
            Telefon2.Text = String.Empty;
            Mail2.Text = String.Empty;
            Adres2.Text = String.Empty;
            TC2.Focus();

        }

        private void MüsteriGüncelle_Click(object sender, EventArgs e)
        {

            baglantı.Open();
            SQLiteCommand komut = new SQLiteCommand("update Müsteri Set TC='" + TC1.Text + "',Ad='" + Ad1.Text + "',Soyad='" + Soyad1.Text + "',DogumTarihi='" + DoğumTarihi1.Text + "',Cinsiyet='" + Cinsiyet1.Text + "',Telefon='" + Telefon1.Text + "',Mail='" + Mail1.Text + "',Adres='" + Adres1.Text + "' where TC = '" + TC1.Text + "'", baglantı);
            komut.ExecuteNonQuery();
            baglantı.Close();
            TabloGuncelle();

            //Text Temizleme
            TC1.Text = String.Empty;
            Ad1.Text = String.Empty;
            Soyad1.Text = String.Empty;
            DoğumTarihi1.Text = String.Empty;
            Cinsiyet1.Text = null;
            Telefon1.Text = String.Empty;
            Mail1.Text = String.Empty;
            Adres1.Text = String.Empty;
            TC1.Focus();
        }

        private void MalzemeGüncelle_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SQLiteCommand komut = new SQLiteCommand("update Malzeme Set Ad='" + Ad2.Text + "',Birim='" + Birim1.Text + "',Adet='" + Adet1.Text + "',MiktarBoyut='" + MiktarBoyut1.Text + "',Fiyat='" + Fiyat1.Text +"',AlındıgıTarih='" + AlındığıTarih1.Text + "' where MalzemeID = '" + MalzemeID2.Text + "'", baglantı);
            komut.ExecuteNonQuery();

            baglantı.Close();
            TabloGuncelle();

            //Text Temizleme
            MalzemeID2.Text = String.Empty;
            Ad2.Text = String.Empty;
            Birim1.Text = String.Empty;
            Adet1.Text = String.Empty;
            MiktarBoyut1.Text = String.Empty;
            Fiyat1.Text = String.Empty;
            AlındığıTarih1.Text = String.Empty;
            MalzemeID2.Focus();
        }

        private void ÜrünOlusturmaGüncelle_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SQLiteCommand komut = new SQLiteCommand("update ÜrünOlusturma Set ÜrünID='" + ÜrünID1.Text  + "',ÜretimTarihi='" + ÜretimTarihi1.Text + "',MalzemeID='" + MalzemeId3.Text +"' where ID = '" + txt_ID.Text + "'", baglantı);
            komut.ExecuteNonQuery();

            baglantı.Close();
            TabloGuncelle();

            //Text Temizleme
            txt_ID.Text = String.Empty;
            ÜrünID1.Text = String.Empty;
            ÜretimTarihi1.Text = String.Empty;
            MalzemeId3.Text = String.Empty;
            MalzemeAdedi2.Text = String.Empty;
            ÜrünID1.Focus();
        }

        private void SiparisGüncelle_Click(object sender, EventArgs e)
        {
           
            baglantı.Open();
            SQLiteCommand komut = new SQLiteCommand("update Siparis Set ÜrünAdı ='" + ÜrünAdı2.Text + "',SiparisAdedi='" + SiparisAdedi1.Text + "',ÜrünFiyatı='" + ÜrünFiyatı1.Text + "' where SiparisID='" + txt_siparis_id.Text + "'", baglantı);
            komut.ExecuteNonQuery();

            baglantı.Close();
            TabloGuncelle();
            //Text Temizleme
            MüsteriTelefon1.Text = String.Empty;
            ÜrünAdı2.Text = String.Empty;
            txt_siparis_id.Text = String.Empty;
            SiparisAdedi1.Text = String.Empty;
            ÜrünFiyatı1.Text = String.Empty;
            txt_urun_id.Text = String.Empty;
        }

        private void FaturalandırmaTemizle_Click(object sender, EventArgs e)
        {
            if (ÜrünID3.Text == "")
            {
                MessageBox.Show("Fatura işlemini yapmak için tablodan bir satır seçininiz.");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Fatura silmek istediğinizden emin misiniz? Silmek veri kaybına yol açacaktır Silmeniz Önerilmez.", "Emin Misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    baglantı.Open();
                    SQLiteCommand komut = new SQLiteCommand($"DELETE FROM Faturalandırma where ÜrünID='{ÜrünID3.Text}'", baglantı);
                    komut.ExecuteNonQuery();
                    baglantı.Close();
                    MessageBox.Show("Fatura başarıyla veritabanından silinmiştir.");
                    TabloGuncelle();

                    //Text Temizleme
                    FaturaNo2.Text = String.Empty;
                    MüşteriTelefon2.Text = String.Empty;
                    SiparişID2.Text = String.Empty;
                    ÜrünAdı1.Text = String.Empty;
                    ÜrünID3.Text = String.Empty;
                    ÜrünFiyat1.Text = String.Empty;
                    FaturaNo2.Focus();
                }
            }
        }

        private void ÖdemeBilgileriTemizle_Click(object sender, EventArgs e)
        {
            if (FaturaNo1.Text == "")
            {
                MessageBox.Show("Ödeme Bilgilerini Temizleme işlemini yapmak için tablodan bir satır seçininiz.");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Ödeme Bilgilerini silmek istediğinizden emin misiniz? Silmek veri kaybına yol açacaktır Silmeniz Önerilmez.", "Emin Misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    baglantı.Open();
                    SQLiteCommand komut = new SQLiteCommand($"DELETE FROM ÖdemeBilgileri where FaturaNo='{FaturaNo1.Text}'", baglantı);
                    komut.ExecuteNonQuery();
                    baglantı.Close();
                    MessageBox.Show("Ödeme Bilgileri başarıyla veritabanından silinmiştir.");
                    TabloGuncelle();

                    //Text Temizleme*
                    FaturaNo1.Text = String.Empty;
                    txt_must3.Text = String.Empty;
                    txt_must_adi.Text = String.Empty;
                    ToplamFiyat1.Text = String.Empty;
                    ÖdenenFiyat1.Text = String.Empty;
                    KalanFiyat1.Text = String.Empty;
                    FaturaNo1.Focus();
                }
            }
        }

        private void TedarikciTemizle_Click(object sender, EventArgs e)
        {
            if (TC2.Text == "")
            {
                MessageBox.Show("Temizleme işlemini yapmak için tablodan bir satır seçininiz.");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Tedarikçiyi silmek istediğinizden emin misiniz? Silmek veri kaybına yol açacaktır Silmeniz Önerilmez.", "Emin Misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    baglantı.Open();
                    SQLiteCommand komut = new SQLiteCommand($"DELETE FROM Tedarikci where  TC='{TC2.Text}'", baglantı);
                    komut.ExecuteNonQuery();
                    baglantı.Close();
                    MessageBox.Show("Tedarikçiyi başarıyla veritabanından silinmiştir.");
                    TabloGuncelle();


                    //Text Temizleme
                    TC2.Text = String.Empty;
                    Ad3.Text = String.Empty;
                    Soyad2.Text = String.Empty;
                    Telefon2.Text = String.Empty;
                    Mail2.Text = String.Empty;
                    Adres2.Text = String.Empty;
                    TC2.Focus();

                }
            }
        }

        private void MüsteriTemizle_Click(object sender, EventArgs e)
        {
            if (TC1.Text == "")
            {
                MessageBox.Show("Temizleme işlemini yapmak için tablodan bir satır seçininiz.");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Müşteri silmek istediğinizden emin misiniz? Silmek veri kaybına yol açacaktır Silmeniz Önerilmez.", "Emin Misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    baglantı.Open();
                    SQLiteCommand komut = new SQLiteCommand($"DELETE FROM Müsteri where  TC='{TC1.Text}'", baglantı);
                    komut.ExecuteNonQuery();
                    baglantı.Close();
                    MessageBox.Show("Müşteri başarıyla veritabanından silinmiştir.");
                    TabloGuncelle();

                    //Text Temizleme
                    TC1.Text = String.Empty;
                    Ad1.Text = String.Empty;
                    Soyad1.Text = String.Empty;
                    DoğumTarihi1.Text = String.Empty;
                    Cinsiyet1.Text = null;
                    Telefon1.Text = String.Empty;
                    Mail1.Text = String.Empty;
                    Adres1.Text = String.Empty;
                    TC1.Focus();
                }
            }

        }

        private void MalzemeTemizle_Click(object sender, EventArgs e)
        {
            if (MalzemeID2.Text == "")
            {
                MessageBox.Show("Temizleme işlemini yapmak için tablodan bir satır seçininiz.");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Malzemeyi silmek istediğinizden emin misiniz? Silmek veri kaybına yol açacaktır Silmeniz Önerilmez.", "Emin Misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    baglantı.Open();
                    SQLiteCommand komut = new SQLiteCommand($"DELETE FROM Malzeme where MalzemeID='{MalzemeID2.Text}'", baglantı);
                    komut.ExecuteNonQuery();
                    baglantı.Close();
                    MessageBox.Show("Malzeme başarıyla veritabanından silinmiştir.");
                    TabloGuncelle();

                    //Text Temizleme
                    MalzemeID2.Text = String.Empty;
                    Ad2.Text = String.Empty;
                    Birim1.Text = String.Empty;
                    Adet1.Text = String.Empty;
                    MiktarBoyut1.Text = String.Empty;
                    Fiyat1.Text = String.Empty;
                    AlındığıTarih1.Text = String.Empty;
                    MalzemeID2.Focus();
                }
            }
    }

        private void ÜrünOlusturmaTemizle_Click(object sender, EventArgs e)
        {
            if (txt_ID.Text == "")
            {
                MessageBox.Show("Temizleme işlemini yapmak için tablodan bir satır seçininiz.");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Malzemeyi silmek istediğinizden emin misiniz? Silmek veri kaybına yol açacaktır Silmeniz Önerilmez.", "Emin Misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    baglantı.Open();
                    SQLiteCommand komut = new SQLiteCommand($"DELETE FROM ÜrünOlusturma where ID='{txt_ID.Text}'", baglantı);
                    komut.ExecuteNonQuery();
                    baglantı.Close();
                    MessageBox.Show("Malzeme başarıyla veritabanından silinmiştir.");
                    TabloGuncelle();

                    //Text Temizleme
                    txt_ID.Text = String.Empty;
                    ÜrünID1.Text = String.Empty;
                    ÜretimTarihi1.Text = String.Empty;
                    MalzemeId3.Text = String.Empty;
                    MalzemeAdedi2.Text = String.Empty;
                    ÜrünID1.Focus();
                }
            }
        }

        private void SiparisTemizle_Click(object sender, EventArgs e)
        {
            if (txt_siparis_id.Text == "")
            {
                MessageBox.Show("Temizleme işlemini yapmak için tablodan bir sipariş seçininiz.");
            }
            else {
                DialogResult dialogResult = MessageBox.Show("Siparişi silmek istediğinizden emin misiniz? Silmek veri kaybına yol açacaktır Silmeniz Önerilmez.","Emin Misiniz?",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes) { 
                baglantı.Open();
                    SQLiteCommand komut = new SQLiteCommand($"DELETE FROM Siparis where SiparisID='{txt_siparis_id.Text}'", baglantı);
                    komut.ExecuteNonQuery();
                baglantı.Close();
                    MessageBox.Show("Sipariş başarıyla veritabanından silinmiştir.");
                    TabloGuncelle();


                    //Text Temizleme
                    MüsteriTelefon1.Text = String.Empty;
                    ÜrünAdı2.Text = String.Empty;
                    SiparisAdedi1.Text = String.Empty;
                    txt_siparis_id.Text = String.Empty;

                    ÜrünFiyatı1.Text = String.Empty;
                    txt_urun_id.Text = String.Empty;
                    MüsteriTelefon1.Focus();


                }

            }
        }
        //textboxa girilen harfe göre tabloda filtreleme(Malzeme Adına Göre)
        private void txt_malzeme_arama_TextChanged(object sender, EventArgs e)
        {
            (MalzemeData.DataSource as DataTable).DefaultView.RowFilter = string.Format("Ad LIKE '{0}%'", txt_malzeme_arama.Text);
        }

        //radio butonlarına göre tabloda filtreleme işlemleri yapılıyor.
        private void txt_ted_ara_TextChanged(object sender, EventArgs e)
        {
            if (radio_btn_isim.Checked == true)
            {
                (TedarikçiData.DataSource as DataTable).DefaultView.RowFilter = string.Format("Ad LIKE '{0}%'", txt_ted_ara.Text);
            }
            else if (radio_btn_tc.Checked == true)
            {
                (TedarikçiData.DataSource as DataTable).DefaultView.RowFilter = string.Format("TC LIKE '{0}%'", txt_ted_ara.Text);
            }
            else {
                radio_btn_isim.Checked = true;
                (TedarikçiData.DataSource as DataTable).DefaultView.RowFilter = string.Format("Ad LIKE '{0}%'", txt_ted_ara.Text);

            }
        }
        //radio butonlarına göre tabloda filtreleme işlemleri yapılıyor.

        private void txt_must_ara_TextChanged(object sender, EventArgs e)
        {
            if (radio_btn_must_isim.Checked == true)
            {
                (MüşteriData.DataSource as DataTable).DefaultView.RowFilter = string.Format("Ad LIKE '{0}%'", txt_must_ara.Text);
            }
            else if (radio_btn_tc.Checked == true)
            {
                (MüşteriData.DataSource as DataTable).DefaultView.RowFilter = string.Format("TC LIKE '{0}%'", txt_must_ara.Text);
            }
            else
            {
                radio_btn_must_isim.Checked = true;
                (MüşteriData.DataSource as DataTable).DefaultView.RowFilter = string.Format("Ad LIKE '{0}%'", txt_must_ara.Text);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TabloGuncelle();
            cbox_tablolar.Text = "Faturalandırma";
            cbox_urun_olusturma.Text = "Ürünler";

        }

        //Veritabanından tüm tabloları güncelleme işlemini yaparken kullandığımız fonksiyon.
        //Programdaki  Tüm Datagridview Güncelleme
        public void TabloGuncelle() {
            baglantı.Open();
            string sql_faturalandirma = "SELECT * FROM Faturalandırma";
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql_faturalandirma, baglantı);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SatımİşleriData.DataSource = dt;
            FaturalandırmaData2.DataSource = dt;

            string sql_tedarikciler = "SELECT * FROM Tedarikci";
            SQLiteDataAdapter da2 = new SQLiteDataAdapter(sql_tedarikciler, baglantı);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            TedarikçiData.DataSource = dt2;
            tedarikci_data.DataSource = dt2;

            string sql_musteriler = "SELECT * FROM Müsteri";
            SQLiteDataAdapter da3 = new SQLiteDataAdapter(sql_musteriler, baglantı);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            MüşteriData.DataSource = dt3;
            Must_Data.DataSource = dt3;
            Must_Data2.DataSource = dt3;
            Must_Data.AllowUserToAddRows = false;

            string sql_malzeme = "SELECT * FROM Malzeme";
            SQLiteDataAdapter da4 = new SQLiteDataAdapter(sql_malzeme, baglantı);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            MalzemeData.DataSource = dt4;
            malzeme_data.DataSource = dt4;
            malzeme2_data.DataSource = dt4;

            string sql_siparis = "SELECT * FROM Siparis";
            SQLiteDataAdapter da5 = new SQLiteDataAdapter(sql_siparis, baglantı);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);
            SiparisData.DataSource = dt5;
            siparisler_data5.DataSource = dt5;
            siparisler_data9.DataSource = dt5;

            string sql_urun_gncle = "SELECT * FROM ÜrünOlusturma";
            SQLiteDataAdapter da6 = new SQLiteDataAdapter(sql_urun_gncle, baglantı);
            DataTable dt6 = new DataTable();
            da6.Fill(dt6);
            ÜrünOluşturmaData.DataSource = dt6;

            string sql_alimlar = "SELECT * FROM Alımislemleri";
            SQLiteDataAdapter da9 = new SQLiteDataAdapter(sql_alimlar, baglantı);
            DataTable dt9 = new DataTable();
            da9.Fill(dt9);
            alimislemleri_data.DataSource = dt9;
            

            string sql_odeme_bilgileri = "SELECT * FROM ÖdemeBilgileri";
            SQLiteDataAdapter da7 = new SQLiteDataAdapter(sql_odeme_bilgileri, baglantı);
            DataTable dt7 = new DataTable();
            da7.Fill(dt7);
            ÖdemeBilgileriData.DataSource = dt7;
            ÖdemeBilgileriData.DataSource = dt7;

            baglantı.Close();


        }
        //switch butonu değişirken Araçların görünür özellikleri değişiyor.
        private void switch_btn_SwitchedChanged(object sender)
        {
            if (Must_Data.Visible == false)
            {
                Must_Data.Visible = true;
                SiparisData.Visible = false;
                lbl_Siparis_ara.Visible = false;
                txt_must2_ara.Visible = true;
                radio_btn_isim_must.Visible = true;
                radio_btn_tc_must.Visible = true;
                txt_siparis_ara.Visible = false;

            }
            else {
                Must_Data.Visible = false;
                lbl_Siparis_ara.Visible = true;
                SiparisData.Visible = true;
                txt_must2_ara.Visible = false;
                radio_btn_isim_must.Visible = false;
                radio_btn_tc_must.Visible = false;
                txt_siparis_ara.Visible = true;


            }
        }
        //radio butonlarına göre tabloda filtreleme işlemleri yapılıyor.
        private void txt_must2_ara_TextChanged(object sender, EventArgs e)
        {
            if (radio_btn_isim_must.Checked == true)
            {
                (Must_Data.DataSource as DataTable).DefaultView.RowFilter = string.Format("Ad LIKE '{0}%'", txt_must2_ara.Text);
            }
            else if (radio_btn_tc_must.Checked == true)
            {
                (Must_Data.DataSource as DataTable).DefaultView.RowFilter = string.Format("TC LIKE '{0}%'", txt_must2_ara.Text);
            }
            else
            {
                radio_btn_isim_must.Checked = true;
                (Must_Data.DataSource as DataTable).DefaultView.RowFilter = string.Format("Ad LIKE '{0}%'", txt_must2_ara.Text);

            }
        }
        //Müşteri tablosundan müşteriId'si textbox'a çekiliyor.

        private void Must_Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçilenalan = Must_Data.SelectedCells[0].RowIndex;
            string mustID = Must_Data.Rows[seçilenalan].Cells[8].Value.ToString();
            MüsteriTelefon1.Text = mustID;

        }
        //filtreleme
        private void txt_siparis_ara_TextChanged(object sender, EventArgs e)
        {
            (SiparisData.DataSource as DataTable).DefaultView.RowFilter = string.Format("ÜrünAdı LIKE '{0}%'", txt_siparis_ara.Text);
        }



        private void txt_fatura_ara_TextChanged(object sender, EventArgs e)
        {
            (SatımİşleriData.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(FaturaNo,System.String) LIKE '{0}%'", txt_fatura_ara.Text);

        }

        private void txt_musteri_ara_TextChanged(object sender, EventArgs e)
        {
            if (radio_btn_m_ad.Checked == true)
            {
                (Must_Data2.DataSource as DataTable).DefaultView.RowFilter = string.Format("Ad LIKE '{0}%'", txt_musteri_ara.Text);
            }
            else if (radio_btn_m_tc.Checked == true)
            {
                (Must_Data2.DataSource as DataTable).DefaultView.RowFilter = string.Format("TC LIKE '{0}%'", txt_musteri_ara.Text);
            }
            else
            {
                radio_btn_m_ad.Checked = true;
                (Must_Data2.DataSource as DataTable).DefaultView.RowFilter = string.Format("Ad LIKE '{0}%'", txt_musteri_ara.Text);

            }
        }

        private void Must_Data2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Faturalandırma MüşteriID getirme
            int seçilenalan = Must_Data2.SelectedCells[0].RowIndex;
            string ID = Must_Data2.Rows[seçilenalan].Cells[8].Value.ToString();

            MüşteriTelefon2.Text = ID.Trim();
        }
        //Ödeme Bilgilerindeki araç görünürlük özelliği.
        private void switch_satim2_SwitchedChanged(object sender)
        {
            if (ÖdemeBilgileriData.Visible == false)
            {
                ÖdemeBilgileriData.Visible = true;
                FaturalandırmaData2.Visible = false;
                txt_FaturaNo.Visible = false;
                lbl_FaturaNo.Visible = false;

            }
            else
            {
                ÖdemeBilgileriData.Visible = false;
                FaturalandırmaData2.Visible = true;
                txt_FaturaNo.Visible = true;
                lbl_FaturaNo.Visible = true;


            }
        }

        private void FaturalandırmaData2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçilenalan = FaturalandırmaData2.SelectedCells[0].RowIndex;
            string FaturaNo = FaturalandırmaData2.Rows[seçilenalan].Cells[0].Value.ToString();
            string mustID = FaturalandırmaData2.Rows[seçilenalan].Cells[1].Value.ToString();

            txt_must3.Text = mustID.Trim();
            FaturaNo1.Text = FaturaNo.Trim();

            baglantı.Open();
            string sql = $"SELECT Ad From Faturalandırma INNER JOIN Müsteri ON Faturalandırma.MüsteriID = Müsteri.MusteriID where Müsteri.MusteriID = {txt_must3.Text}";
            SQLiteCommand cmd = new SQLiteCommand(sql, baglantı);
            string ad = Convert.ToString(cmd.ExecuteScalar());
            string sql2 = $"SELECT Soyad From Faturalandırma INNER JOIN Müsteri ON Faturalandırma.MüsteriID = Müsteri.MusteriID where Müsteri.MusteriID = {txt_must3.Text}";
            SQLiteCommand cmd2 = new SQLiteCommand(sql2, baglantı);
            string soyad = Convert.ToString(cmd2.ExecuteScalar());
            txt_must_adi.Text = ad.Trim() + " " + soyad.Trim();
            baglantı.Close();
        }




        //Alım işlemlerindeki araç görünürlülük
        private void switch_alimlar_SwitchedChanged_1(object sender)
        {
            if (malzeme_data.Visible == false)
            {
                malzeme_data.Visible = true;
                tedarikci_data.Visible = false;
                txt_Malzeme_Adına.Visible = true;
                lbl_Malzeme_Adına.Visible = true;
                radio_button_tedarikci_tc.Visible = false;
                radio_button_tedarikci_adı.Visible = false;
                txt_tedarikci_ara2.Visible = false;

            }
            else
            {
                malzeme_data.Visible = false;
                tedarikci_data.Visible = true;
                txt_Malzeme_Adına.Visible = false;
                lbl_Malzeme_Adına.Visible = false;
                radio_button_tedarikci_tc.Visible = true;
                radio_button_tedarikci_adı.Visible = true;
                txt_tedarikci_ara2.Visible = true;
            }
        }
        //Yeni Ürün ve Kayıtlı Ürün
        private void switch_alim_islemleri_SwitchedChanged(object sender)
        {
            
                if (panel_yeni_urun.Visible == false)
                {
                    panel_yeni_urun.Visible = true;
                    AlımİslemleriKaydet.Text = "Kaydet";
                    panel_kayitli_urun.Visible = false;

                }
                else
                {
                    panel_yeni_urun.Visible = false;
                    panel_kayitli_urun.Visible = true;
                    AlımİslemleriKaydet.Text = "Ekle";

            }
            lbl_ted_adi.Text = String.Empty;
            lbl_ted_adi2.Text = String.Empty;
            lbl_ted_soyadi.Text = String.Empty;
            lbl_ted_soyadi2.Text = String.Empty;
            txt_ted_id.Text = String.Empty;
            TedarikçiTelefon1.Text = String.Empty;
        }

        private void tedarikci_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçilenalan = tedarikci_data.SelectedCells[0].RowIndex;
            string TedID = tedarikci_data.Rows[seçilenalan].Cells[6].Value.ToString();
            string TedAd = tedarikci_data.Rows[seçilenalan].Cells[1].Value.ToString();
            string TedSoyad = tedarikci_data.Rows[seçilenalan].Cells[2].Value.ToString();
            if (panel_yeni_urun.Visible == false)
            {
                lbl_ted_adi2.Text = TedAd.Trim();
                lbl_ted_soyadi2.Text = TedSoyad.Trim();
                txt_ted_id.Text = TedID.Trim();


            }
            else {

                lbl_ted_adi.Text = TedAd.Trim();
                lbl_ted_soyadi.Text = TedSoyad.Trim();
                TedarikçiTelefon1.Text = TedID.Trim();
            }


         

        }

        private void malzeme_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //malzeme_data
            int seçilenalan = malzeme_data.SelectedCells[0].RowIndex;
            string MalzemeID = malzeme_data.Rows[seçilenalan].Cells[0].Value.ToString();

            txt_malzeme_id.Text= MalzemeID.Trim();
    

        }
        // Ürün oluşturma
        private void switch_ürünler_SwitchedChanged(object sender)
        {
            if (malzeme2_data.Visible == false)
            {
                malzeme2_data.Visible = true;
                ÜrünOluşturmaData.Visible = false;
                radio_btn_urunid.Visible = false;
                radio_btn_id.Visible = false;
                txt_urun_ara3.Visible = false;
                txt_Malzeme_Ara.Visible = true;
                lbl_Malzeme_Arama.Visible = true;

            }
            else
            {
                malzeme2_data.Visible = false;
          
                ÜrünOluşturmaData.Visible = true;
                radio_btn_urunid.Visible = true;
                radio_btn_id.Visible = true;
                txt_urun_ara3.Visible = true;
                txt_Malzeme_Ara.Visible = false;
                lbl_Malzeme_Arama.Visible = false;
            }
        }

        private void malzeme2_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçilenalan = malzeme2_data.SelectedCells[0].RowIndex;
            string MalzemeID = malzeme2_data.Rows[seçilenalan].Cells[0].Value.ToString();
            string Adet = malzeme2_data.Rows[seçilenalan].Cells[3].Value.ToString();
 
        

            MalzemeId3.Text = MalzemeID.Trim();
            MalzemeAdedi2.Text = Adet.Trim();
        

;        }

        private void AlımİslemleriKaydet_Click_1(object sender, EventArgs e)
        {
            baglantı.Open();
            if (panel_yeni_urun.Visible == true)
            {
                string sql_kod = $"INSERT INTO Malzeme (Ad,Birim,Adet,MiktarBoyut,Fiyat,AlındıgıTarih) VALUES ('{MalzemeAdı3.Text}','{MalzemeBirimi1.Text}','{MalzemeAdedi1.Text}','{MalzemeMiktarBoyut1.Text}','{AlımFiyatı1.Text}','{AlındıgıTarih1.Text}')";
                SQLiteCommand cmd = new SQLiteCommand(sql_kod, baglantı);
                cmd.ExecuteNonQuery();
                string sql_en_yuksek = $"SELECT MAX(MalzemeID) from Malzeme";
                SQLiteCommand cmd2 = new SQLiteCommand(sql_en_yuksek, baglantı);
                int deger = Convert.ToInt32(cmd2.ExecuteScalar());
                string sql_kod2 = $"INSERT INTO Alımislemleri (AlımFaturaNo,TedarikciID,MalzemeID,MalzemeAdedi,AlımFiyatı,AlındıgıTarih) VALUES ('{AlımFaturaNo1.Text}','{TedarikçiTelefon1.Text}','{deger}','{MalzemeAdedi1.Text}','{AlımFiyatı1.Text}','{AlındıgıTarih1.Text}')";
                SQLiteCommand cmd3 = new SQLiteCommand(sql_kod2, baglantı);
                cmd3.ExecuteNonQuery();

                //Text Temizleme
                AlımFaturaNo1.Text = String.Empty;
                lbl_ted_adi.Text = String.Empty;
                lbl_ted_soyadi.Text = String.Empty;
                TedarikçiTelefon1.Text = String.Empty;
                MalzemeAdı3.Text = String.Empty;
                MalzemeBirimi1.Text = String.Empty;
                MalzemeAdedi1.Text = String.Empty;
                MalzemeMiktarBoyut1.Text = String.Empty;
                AlımFiyatı1.Text = String.Empty;
                AlındıgıTarih1.Text = String.Empty;
                AlımFaturaNo1.Focus();

            }
            else {
                //kayıtlı ürüne ekleme
                string sql = $"SELECT Adet FROM Malzeme where MalzemeID='{txt_malzeme_id.Text}'";
                SQLiteCommand cmd = new SQLiteCommand(sql, baglantı);
                int toplam_adet = Convert.ToInt32(cmd.ExecuteScalar());
                int eklenecek_Adet=Convert.ToInt32(txt_malzeme_adet.Text);
                int sonuc = toplam_adet + eklenecek_Adet;
                string sql2 = $"UPDATE Malzeme set Adet='{sonuc}' where MalzemeID='{txt_malzeme_id.Text}'";
                SQLiteCommand cmd2 = new SQLiteCommand(sql2, baglantı);
                cmd2.ExecuteNonQuery();
                //güncellemeişlemleri
                string sql_kod2 = $"INSERT INTO Alımislemleri (AlımFaturaNo,TedarikciID,MalzemeID,MalzemeAdedi,AlımFiyatı,AlındıgıTarih) VALUES ('{txt_alim_faturano.Text}','{txt_ted_id.Text}','{txt_malzeme_id.Text}','{txt_malzeme_adet.Text}','{txt_malzeme_id.Text}','{txt_malzeme_tarih.Text}')";
                SQLiteCommand cmd3 = new SQLiteCommand(sql_kod2, baglantı);
                cmd3.ExecuteNonQuery();

                //Text Temizleme
                txt_alim_faturano.Text = String.Empty;
                lbl_ted_adi2.Text = String.Empty;
                lbl_ted_soyadi2.Text = String.Empty;
                txt_ted_id.Text = String.Empty;
                txt_malzeme_id.Text = String.Empty;
                txt_malzeme_adet.Text = String.Empty;
                txt_malzeme_fiyat.Text = String.Empty;
                txt_malzeme_tarih.Text = String.Empty;
                txt_alim_faturano.Focus();


            }
            baglantı.Close();
            TabloGuncelle();
        }

        private void AlımislemleriTemizle_Click_1(object sender, EventArgs e)
        {
            if (txt_fatura_no.Text == "")
            {
                MessageBox.Show("Alım işlemini silmek için tablodan bilgileri getiriniz.");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Alım işlemini silmek istediğinizden emin misiniz? Silmek veri kaybına yol açacaktır Silmeniz Önerilmez.", "Emin Misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    baglantı.Open();
                    SQLiteCommand komut = new SQLiteCommand($"DELETE FROM Alımislemleri where AlımFaturaNo='{txt_fatura_no.Text}'", baglantı);
                    komut.ExecuteNonQuery();
                    baglantı.Close();
                    MessageBox.Show("Alım işlemi başarıyla veritabanından silinmiştir.");
                    TabloGuncelle();

                    //Text Temizleme
                    txt_fatura_no.Text = String.Empty;
                    txt_ted_id2.Text = String.Empty;
                    txt_malzeme_id2.Text = String.Empty;
                    txt_malzeme_adedi.Text = String.Empty;
                    txt_alim_fiyati.Text = String.Empty;
                    txt_alindigi_tarih.Text = String.Empty;
                    lbl_Tedarikci_Adı.Text = String.Empty;
                    lbl_Tedarikci_Soyadı.Text = String.Empty;
                    txt_fatura_no.Focus();
                }
            }
        }

        private void AlımislemleriGüncelle_Click_1(object sender, EventArgs e)
        {
            baglantı.Open();
            SQLiteCommand komut = new SQLiteCommand($"update alımislemleri Set TedarikciID='{txt_ted_id2.Text}',malzemeID='{txt_malzeme_id2.Text}',MalzemeAdedi='{txt_malzeme_adedi.Text}',Alımfiyatı='{txt_alim_fiyati.Text}',AlındıgıTarih='{txt_alindigi_tarih.Text}' where AlımFaturaNo='{txt_fatura_no.Text}'",baglantı);
            komut.ExecuteNonQuery();

            baglantı.Close();
            TabloGuncelle();


            //Text Temizleme
            txt_fatura_no.Text = String.Empty;
            txt_ted_id2.Text = String.Empty;
            txt_malzeme_id2.Text = String.Empty;
            txt_malzeme_adedi.Text = String.Empty;
            txt_alim_fiyati.Text = String.Empty;
            txt_alindigi_tarih.Text = String.Empty;
            lbl_Tedarikci_Adı.Text = String.Empty;
            lbl_Tedarikci_Soyadı.Text = String.Empty;
            txt_fatura_no.Focus();
        }

        private void alimislemleri_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçilenalan = alimislemleri_data.SelectedCells[0].RowIndex;
            string faturano = alimislemleri_data.Rows[seçilenalan].Cells[0].Value.ToString();

            string TedarikciID = alimislemleri_data.Rows[seçilenalan].Cells[1].Value.ToString();
            string MalzemeID = alimislemleri_data.Rows[seçilenalan].Cells[2].Value.ToString();
            string MalzemeAdedi = alimislemleri_data.Rows[seçilenalan].Cells[3].Value.ToString();
            string Alımfiyati = alimislemleri_data.Rows[seçilenalan].Cells[4].Value.ToString();
            string AlındıgıTarih = alimislemleri_data.Rows[seçilenalan].Cells[5].Value.ToString();

            txt_fatura_no.Text = faturano.Trim();
            txt_ted_id2.Text = TedarikciID.Trim();
            txt_malzeme_id2.Text = MalzemeID.Trim();
            txt_malzeme_adedi.Text = MalzemeAdedi.Trim();
            txt_alim_fiyati.Text = Alımfiyati.Trim();
            txt_alindigi_tarih.Text = AlındıgıTarih.Trim();
            
            //Alım işlemleri tablosundaki tedarikçi ID'sine göre,tedarikçi tablosundan ;tedarikçinin adı ve soyadı bilgileri ilgili label'ların text özelliklerine göre ayarlanır.
            baglantı.Open();
            string sql_kod = $"select DISTINCT Ad FROM Alımislemleri INNER JOIN Tedarikci ON Alımislemleri.TedarikciID=Tedarikci.TedarikciID where Alımislemleri.TedarikciID={txt_ted_id2.Text}";
            string sql_kod2 = $"select DISTINCT Soyad FROM Alımislemleri INNER JOIN Tedarikci ON Alımislemleri.TedarikciID=Tedarikci.TedarikciID where Alımislemleri.TedarikciID={txt_ted_id2.Text}";
            SQLiteCommand sql = new SQLiteCommand(sql_kod,baglantı);
            SQLiteCommand sql2 = new SQLiteCommand(sql_kod2,baglantı);
            string ad = Convert.ToString(sql.ExecuteScalar());
            string soyad = Convert.ToString(sql2.ExecuteScalar());
            baglantı.Close();
            lbl_Tedarikci_Adı.Text = ad;
            lbl_Tedarikci_Soyadı.Text = soyad;
        }

        private void txt_urun_ara3_TextChanged(object sender, EventArgs e)
        {
            if (radio_btn_urunid.Checked == true)
            {
                (ÜrünOluşturmaData.DataSource as DataTable).DefaultView.RowFilter = string.Format("ÜrünID LIKE '{0}%'", txt_urun_ara3.Text);
            }
            else if (radio_btn_id.Checked == true)
            {
                (ÜrünOluşturmaData.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(ID,System.String) LIKE '{0}%'", txt_urun_ara3.Text);
            }
            else
            {
                radio_btn_urunid.Checked = true;
                (ÜrünOluşturmaData.DataSource as DataTable).DefaultView.RowFilter = string.Format("ÜrünID LIKE '{0}%'", txt_urun_ara3.Text);

            }
        }
        //ComboBox Göre ilgili tablo ve textboxların görünür özellikleri değişiyor.
        private void metroSetComboBox1_TextChanged(object sender, EventArgs e)
        {
            if (cbox_tablolar.Text == "Faturalandırma")
            {
                SatımİşleriData.Visible = true;
                siparisler_data5.Visible = false;
                Must_Data2.Visible = false;
                txt_siparisID_ara.Visible = false;

                txt_musteri_ara.Visible = false;
                radio_btn_m_ad.Visible = false;
                radio_btn_m_tc.Visible = false;
                lbl_siparisID_ara.Visible = false;

                txt_fatura_ara.Visible = true;
                lbl_fatura_no_ara.Visible = true;
            }
            else if (cbox_tablolar.Text == "Müşteriler")
            {

                SatımİşleriData.Visible = false;
                siparisler_data5.Visible = false;
                Must_Data2.Visible = true;

                txt_musteri_ara.Visible = true;
                radio_btn_m_ad.Visible = true;
                radio_btn_m_tc.Visible = true;
                txt_fatura_ara.Visible = false;
                txt_siparisID_ara.Visible = false;
                lbl_siparisID_ara.Visible = false;

                lbl_fatura_no_ara.Visible = false;

            }
            else {
                SatımİşleriData.Visible = false;
                siparisler_data5.Visible = true;
                lbl_siparisID_ara.Visible = true;
                Must_Data2.Visible = false;
                txt_siparisID_ara.Visible = true;

                txt_musteri_ara.Visible = false;
                radio_btn_m_ad.Visible = false;
                radio_btn_m_tc.Visible = false;
                txt_fatura_ara.Visible = false;
                lbl_fatura_no_ara.Visible = false;


            }
        }

        private void siparisler_data5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçilenalan = siparisler_data5.SelectedCells[0].RowIndex;
            string siparisID = siparisler_data5.Rows[seçilenalan].Cells[0].Value.ToString();
            string urunID = siparisler_data5.Rows[seçilenalan].Cells[1].Value.ToString();
            string ÜrünAdi = siparisler_data5.Rows[seçilenalan].Cells[3].Value.ToString();
            string ürünfiyati = siparisler_data5.Rows[seçilenalan].Cells[5].Value.ToString();
            SiparişID2.Text = siparisID.Trim();
            ÜrünID3.Text = urunID.Trim();
            ÜrünAdı1.Text = ÜrünAdi.Trim(); 
            ÜrünFiyat1.Text = ürünfiyati.Trim();
        }
        //Filtreleme
        private void txt_siparisID_ara_TextChanged(object sender, EventArgs e)
        {
            (siparisler_data5.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(MüsteriID ,System.String) LIKE '{0}%'", txt_siparisID_ara.Text);

        }

        private void txt_Malzeme_Ara_TextChanged(object sender, EventArgs e)
        {
            (malzeme2_data.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(Ad ,System.String) LIKE '{0}%'", txt_Malzeme_Ara.Text);

        }
        //Rakam dışı girilemez
        private void TC1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TC1.Text, "[^0-9]"))
                TC1.Text = TC1.Text.Remove(TC1.Text.Length - 1);
        }

        private void Telefon1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Telefon1.Text, "[^0-9]"))
                Telefon1.Text = Telefon1.Text.Remove(Telefon1.Text.Length - 1);
        }

        private void TC2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TC2.Text, "[^0-9]"))
                TC2.Text = TC2.Text.Remove(TC2.Text.Length - 1);
        }

        private void Telefon2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Telefon2.Text, "[^0-9]"))
                Telefon2.Text = Telefon2.Text.Remove(Telefon2.Text.Length - 1);
        }

        private void Adet1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Adet1.Text, "[^0-9]"))
                Adet1.Text = Adet1.Text.Remove(Adet1.Text.Length - 1);
        }

        private void Fiyat1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(Fiyat1.Text, "[^0-9]"))
                Fiyat1.Text =Fiyat1.Text.Remove(Fiyat1.Text.Length - 1);
        }

        private void SiparisAdedi1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(SiparisAdedi1.Text, "[^0-9]"))
                SiparisAdedi1.Text = SiparisAdedi1.Text.Remove(SiparisAdedi1.Text.Length - 1);
        }

        private void ÜrünFiyatı1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(ÜrünFiyatı1.Text, "[^0-9]"))
                ÜrünFiyatı1.Text = ÜrünFiyatı1.Text.Remove(ÜrünFiyatı1.Text.Length - 1);
        }

        private void MalzemeAdedi2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(MalzemeAdedi2.Text, "[^0-9]"))
                MalzemeAdedi2.Text = MalzemeAdedi2.Text.Remove(MalzemeAdedi2.Text.Length - 1);
        }

        private void ToplamFiyat1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(ToplamFiyat1.Text, "[^0-9]"))
                ToplamFiyat1.Text = ToplamFiyat1.Text.Remove(ToplamFiyat1.Text.Length - 1);
        }

        private void ÖdenenFiyat1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(ÖdenenFiyat1.Text, "[^0-9]"))
                ÖdenenFiyat1.Text = ÖdenenFiyat1.Text.Remove(ÖdenenFiyat1.Text.Length - 1);
        }

        private void KalanFiyat1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(KalanFiyat1.Text, "[^0-9]"))
                KalanFiyat1.Text = KalanFiyat1.Text.Remove(KalanFiyat1.Text.Length - 1);
        }

        private void ÜrünFiyat1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(ÜrünFiyat1.Text, "[^0-9]"))
                ÜrünFiyat1.Text = ÜrünFiyat1.Text.Remove(ÜrünFiyat1.Text.Length - 1);
        }

        private void txt_malzeme_fiyat_TextChanged(object sender, EventArgs e)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(txt_malzeme_fiyat.Text, "[^0-9]"))
                txt_malzeme_fiyat.Text = txt_malzeme_fiyat.Text.Remove(txt_malzeme_fiyat.Text.Length - 1);
        }

        private void txt_malzeme_adet_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_malzeme_adet.Text, "[^0-9]"))
                txt_malzeme_adet.Text = txt_malzeme_adet.Text.Remove(txt_malzeme_adet.Text.Length - 1);
        }

        private void txt_alim_fiyati_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_alim_fiyati.Text, "[^0-9]"))
                txt_alim_fiyati.Text = txt_alim_fiyati.Text.Remove(txt_alim_fiyati.Text.Length - 1);
        }

        private void txt_malzeme_adedi_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_malzeme_adedi.Text, "[^0-9]"))
                txt_malzeme_adedi.Text = txt_malzeme_adedi.Text.Remove(txt_malzeme_adedi.Text.Length - 1);
        }

        private void MalzemeAdedi1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(MalzemeAdedi1.Text, "[^0-9]"))
                MalzemeAdedi1.Text = MalzemeAdedi1.Text.Remove(MalzemeAdedi1.Text.Length - 1);
        }

        private void AlımFiyatı1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(AlımFiyatı1.Text, "[^0-9]"))
                AlımFiyatı1.Text = AlımFiyatı1.Text.Remove(AlımFiyatı1.Text.Length - 1);
        }

        private void cbox_urun_olusturma_TextChanged(object sender, EventArgs e)
        {
            if (cbox_urun_olusturma.Text == "Siparişler")
            {
                siparisler_data9.Visible = true;
                ÜrünOluşturmaData.Visible = false;
                malzeme2_data.Visible = false;
                txt_Malzeme_Ara.Visible = false;
                txt_urun_ara3.Visible = false;
                lbl_Malzeme_Arama.Visible = false;
                radio_btn_urunid.Visible = false;
                radio_btn_id.Visible = false;
                txt_siparis_ara2.Visible = true;
                lbl_urun_Adi2.Visible = true;

            }
            else if (cbox_urun_olusturma.Text == "Ürünler")
            {
                siparisler_data9.Visible = false;
                ÜrünOluşturmaData.Visible = true;
                malzeme2_data.Visible = false;
                txt_Malzeme_Ara.Visible = false;
                txt_urun_ara3.Visible = true;
                lbl_Malzeme_Arama.Visible = false;
                radio_btn_urunid.Visible = true;
                radio_btn_id.Visible = true;
                txt_siparis_ara2.Visible = false;
                lbl_urun_Adi2.Visible = false;


            }
            else
            {
                siparisler_data9.Visible = false;
                ÜrünOluşturmaData.Visible = false;
                malzeme2_data.Visible = true;
                txt_Malzeme_Ara.Visible = true;
                txt_urun_ara3.Visible = false;
                lbl_Malzeme_Arama.Visible = true;
                radio_btn_urunid.Visible = false;
                txt_siparis_ara2.Visible = false;
                radio_btn_id.Visible = false;
                lbl_urun_Adi2.Visible = false;






            }
        }

        private void siparisler_data9_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçilenalan = siparisler_data9.SelectedCells[0].RowIndex;
            string ÜrünID = siparisler_data9.Rows[seçilenalan].Cells[1].Value.ToString();
            ÜrünID1.Text = ÜrünID.Trim();

        }

        private void txt_siparis_ara2_TextChanged(object sender, EventArgs e)
        {
            (siparisler_data9.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(ÜrünAdı ,System.String) LIKE '{0}%'", txt_siparis_ara2.Text);

        }

        private void txt_FaturaNo_TextChanged(object sender, EventArgs e)
        {
            (FaturalandırmaData2.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(FaturaNo,System.String) LIKE '{0}%'", txt_FaturaNo.Text);
        }

        private void txt_Malzeme_Adına_TextChanged(object sender, EventArgs e)
        {
            (malzeme_data.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(Ad ,System.String) LIKE '{0}%'", txt_Malzeme_Adına.Text);

        }

        private void txt_tedarikci_ara2_TextChanged(object sender, EventArgs e)
        {

            if (radio_button_tedarikci_adı.Checked == true)
            {
                (tedarikci_data.DataSource as DataTable).DefaultView.RowFilter = string.Format("Ad LIKE '{0}%'", txt_tedarikci_ara2.Text);
            }
            else if (radio_button_tedarikci_tc.Checked == true)
            {
                (tedarikci_data.DataSource as DataTable).DefaultView.RowFilter = string.Format("TC LIKE '{0}%'", txt_tedarikci_ara2.Text);
            }
            else
            {
                radio_button_tedarikci_adı.Checked = true;
                (tedarikci_data.DataSource as DataTable).DefaultView.RowFilter = string.Format("Ad LIKE '{0}%'", txt_tedarikci_ara2.Text);

            }
        }

        private void AlımFatura_txt_TextChanged(object sender, EventArgs e)
        {
            (alimislemleri_data.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(AlımFaturaNo ,System.String) LIKE '{0}%'", AlımFatura_txt.Text);

        }
    }   
}
