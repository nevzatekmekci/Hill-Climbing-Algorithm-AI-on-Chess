using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace YapayZeka2
{
    public partial class Form1 : Form
    {
        Stopwatch stopwatch = new Stopwatch();
        int[,] satranc = new int[9, 9];//Olusturulan tasların aynı yerde olusturulmasını engellemek için kullanılan satranc tahtası ornegı
        Label[,] satrancTahtasi = new Label[9, 9];//9*9 lik satranç tahtasının her bir karesi label olarak oluşturulacak.Arayüz için
        List<Piece> listePiece = new List<Piece>();//Ana taşlarımızı tutan liste
        int satir, sutun, count = 0, count2 = 0, gate = 0,gate2=0, toplam, dongu = 1, vezirSayisi, hafiza=0,max, maxSatir, maxSutun, atSayisi;
        Random random = new Random();//Taşların satır ve sutun değerleri için random atama yapıldı
        Queen yedek2 = new Queen();//yedek olarak olusturuldular
        Knight yedek3 = new Knight();//Amaç türleri arasında max olan nesneyi ara olarak tutabilmekti. Program akışında o nesneyi kullanabilmek
        public int[,] tahta = new int[9, 9];//Asıl tahtamız(tehdit edilen yerlerin değeri 1 olarak edilmeyenler 0)
        public Form1()
        {
            InitializeComponent();
        }
        //9*9 lik satranç tahtası oluşturan metod
        private void Form1_Load(object sender, EventArgs e)
        {
            stopwatch.Start();
            int en = 65;
            int boy = 65;
            int yukseklik = 65;
            int sol = 65;


            for (int satir = 0; satir < 9; satir++)
            {
                for (int sutun = 0; sutun < 9; sutun++)
                {
                    satrancTahtasi[satir, sutun] = new Label();
                    satrancTahtasi[satir, sutun].Size = new Size(en, boy);
                    satrancTahtasi[satir, sutun].Left = sol;
                    satrancTahtasi[satir, sutun].Top = yukseklik;
                    satrancTahtasi[satir, sutun].TextAlign = ContentAlignment.MiddleCenter;
                    satrancTahtasi[satir, sutun].Font = new Font("Times New Roman", 12);

                    if ((satir + sutun) % 2 == 0)
                    {
                        satrancTahtasi[satir, sutun].BackColor = Color.Black;
                        satrancTahtasi[satir, sutun].ForeColor = Color.White;
                    }
                    else
                    {
                        satrancTahtasi[satir, sutun].BackColor = Color.White;
                        satrancTahtasi[satir, sutun].ForeColor = Color.Black;
                    }

                    this.Controls.Add(satrancTahtasi[satir, sutun]);
                    sol += en;
                }
                sol = 65;
                yukseklik += boy;
            }
            stopwatch.Stop();
        }
        //Program içinde hareket ettireceğimiz taşın komşuları ile arasındaki tehdit farkını anlayabilmemiz için kullandığımız hareket ettirilecek olan taş dışında başlangıçtaki taşların tahtadaki tehdit sayısını hesaplar
        private void eksikHesap(int deger)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    for (int k = 0; k < atSayisi + vezirSayisi; k++)
                    {
                        if (k != deger)//eğer o taştan farklı ise hesabı yap
                        {
                            tahta[i, j] = (listePiece[k].tahta[i, j] | tahta[i, j]);
                        }
                    }
                }
            }
        }
        //Ana taşlarımızın güncel yerlerine göre tehdit durumunu hesaplayan metod
        private void hesap()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    for (int k = 0; k < atSayisi + vezirSayisi; k++)
                    {
                        tahta[i, j] = (listePiece[k].tahta[i, j] | tahta[i, j]);
                    }
                }
            }
        }
        //Ana tahtamızı diğer hesaplarda düzgün kullanabilmek için 0 layan metod
        private void sifir()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    tahta[i, j] = 0;
                }
            }
        }
        private void btnGonder_Click(object sender, EventArgs e)
        {
            stopwatch.Start();
            vezirSayisi = Convert.ToInt32(vezirTxt.Text.ToString());
            atSayisi = Convert.ToInt32(atTxt.Text.ToString());//At ve vezir sayısı kullanıcıdan alınır.
            toplam = (vezirSayisi + atSayisi);
            for (int i = 0; i < vezirSayisi; i++)//Vezirler tahtada random yerlerine atanır
            {
                while (gate == 0)
                {
                    satir = random.Next(0, 8);
                    sutun = random.Next(0, 8);
                    if (satranc[satir, sutun] == 0)
                    {
                        satrancTahtasi[satir, sutun].Text = (i + 1) + ". Q";
                        listePiece.Add(new Queen(satir, sutun));
                        satranc[satir, sutun] = 1;
                        gate = 1;
                    }
                }
                gate = 0;
            }
            for (int i = 0; i < atSayisi; i++)//Vezirler tahtada random yerlerine atanır
            {
                while (gate == 0)
                {
                    satir = random.Next(0, 8);
                    sutun = random.Next(0, 8);
                    if (satranc[satir, sutun] == 0)
                    {
                        satrancTahtasi[satir, sutun].Text = (i + 1) + ". K";
                        satranc[satir, sutun] = 1;
                        listePiece.Add(new Knight(satir, sutun));
                        gate = 1;
                    }
                }
                gate = 0;
            }

            for (int i = 0; i < vezirSayisi + atSayisi; i++)//Atanan taşların hareket metodları çağırılır böylece kendi içlerinde tahtaları(tehditlik durumlarını içeren) oluşturulur.
            {
                listePiece[i].hareket();
            }

            hesap();//Ana tahtaya aktraımı yapılır

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    count += tahta[i, j];//İlk durumdaki tehdit edilen kare syısı bulunur
                }
            }

            label3.Text += "\nBaşlangıç durumu: " + count + " hane tehdit ediliyor.\n";
            stopwatch.Stop();
        }
        private void btnBaslat_Click(object sender, EventArgs e)
        {
            stopwatch.Start();
            while ((toplam > count2)&&(gate2==0))//Her yeni taşa geildiğinde 1 artan count2 değişkeni toplam taş saıyısından küçük oldugu surece dönecek while döngüsü
            {
                gate = 0;
                while (gate == 0)
                {
                    if (count == 81)
                    {
                        label3.Text += "Tüm noktalar tehdit ediliyor.";
                        gate2 = 1;
                        break;
                    }
                    satir = listePiece[count2].basSatir;
                    sutun = listePiece[count2].basSutun;

                    //At ve vezir için hesaplamaları ayrı ayrı yapıldı. Bu kontrolle işlenen taşın at mı vezirmi olduguna bakılıyor. İlk eklenen taşlar vezir oldugundan vezir sayısından kucuk oldugu surece bu kontrole girecek. Değilse else kolu calısıracak atlara gore islemler yapılacak
                    if (count2 < vezirSayisi)
                    {
                        //Teker teker 4 yanında ki 4 komşusu için hareket metodu cagırılıyor ve tehdit ettikleri noktalar hesaplanıyor
                        //Bu komsu nesneler asıl nesne ıcınde ki listede saklanıyor
                        //üst komşu
                        if (satir - 1 >= 0)
                        {
                            Queen quenn = new Queen(satir - 1, sutun);
                            listePiece[count2].komsuListesi.Add(quenn);
                            quenn.hareket();
                            sifir();
                            eksikHesap(count2);
                            for (int i = 0; i < 9; i++)
                            {
                                for (int j = 0; j < 9; j++)
                                {
                                    quenn.count += tahta[i, j] | quenn.tahta[i, j];
                                }
                            }
                        }
                        //alt komşu
                        if (satir + 1 < 9)
                        {
                            Queen quenn2 = new Queen(satir + 1, sutun);
                            listePiece[count2].komsuListesi.Add(quenn2);
                            quenn2.hareket();
                            sifir();
                            eksikHesap(count2);
                            for (int i = 0; i < 9; i++)
                            {
                                for (int j = 0; j < 9; j++)
                                {
                                    quenn2.count += tahta[i, j] | quenn2.tahta[i, j];
                                }
                            }
                        }
                        //sol komşu
                        if (sutun - 1 >= 0)
                        {
                            Queen quenn3 = new Queen(satir, sutun - 1);
                            listePiece[count2].komsuListesi.Add(quenn3);
                            quenn3.hareket();
                            sifir();
                            eksikHesap(count2);
                            for (int i = 0; i < 9; i++)
                            {
                                for (int j = 0; j < 9; j++)
                                {
                                    quenn3.count += tahta[i, j] | quenn3.tahta[i, j];
                                }
                            }
                        }
                        //sağ komşu
                        if (sutun + 1 < 9)
                        {
                            Queen quenn4 = new Queen(satir, sutun + 1);
                            listePiece[count2].komsuListesi.Add(quenn4);
                            quenn4.hareket();
                            sifir();
                            eksikHesap(count2);
                            for (int i = 0; i < 9; i++)
                            {
                                for (int j = 0; j < 9; j++)
                                {
                                    quenn4.count += tahta[i, j] | quenn4.tahta[i, j];
                                }
                            }
                        }
                        //İlk değer en buyuk olarak alınıyor
                        max = listePiece[count2].komsuListesi[0].count;
                        maxSatir = listePiece[count2].komsuListesi[0].basSatir;
                        maxSutun = listePiece[count2].komsuListesi[0].basSutun;

                        //Tehdit eden en iyi komşu aranıyor.
                        for (int i = 1; i < listePiece[count2].komsuListesi.Count; i++)
                        {
                            if (listePiece[count2].komsuListesi[i].count > max)
                            {
                                max = listePiece[count2].komsuListesi[i].count;
                                maxSatir = listePiece[count2].komsuListesi[i].basSatir;
                                maxSutun = listePiece[count2].komsuListesi[i].basSutun;
                                yedek2 = (Queen)listePiece[count2].komsuListesi[i];
                            }
                        }
                        //Tehdit eden komşu önceki durumdan iyiyse artık o taş buraya hareket ettiriliyor
                        if (max > count)
                        {
                            listePiece[count2].basSatir = yedek2.basSatir;
                            listePiece[count2].basSutun = yedek2.basSutun;
                            count = yedek2.count;
                            for (int i = 0; i < 9; i++)
                            {
                                for (int j = 0; j < 9; j++)
                                {
                                    tahta[i, j] = tahta[i, j] | yedek2.tahta[i, j];
                                }
                            }
                        }
                        //Değilse hiçbirşey yapılmıyor ve bu taş ile iş bitirilmesi için gate 1 yapılarak yeni taşa geçilmesi sağlanıyor
                        else
                        {
                            gate = 1;
                        }
                        label3.Text += dongu + ". iterasyon";
                        label3.Text += "\n" + count + " hane tehdit ediliyor.\n";
                        dongu++;


                    }
                    //Atlar için yapılan hesapların oldugu bolum
                    else
                    {
                        //üst komşu
                        if (satir - 1 >= 0)
                        {
                            Knight knight = new Knight(satir - 1, sutun);
                            listePiece[count2].komsuListesi.Add(knight);
                            knight.hareket();
                            sifir();
                            eksikHesap(count2);
                            for (int i = 0; i < 9; i++)
                            {
                                for (int j = 0; j < 9; j++)
                                {
                                    knight.count += tahta[i, j] | knight.tahta[i, j];
                                }
                            }
                        }
                        //alt komşu
                        if (satir + 1 < 9)
                        {
                            Knight knight2 = new Knight(satir + 1, sutun);
                            listePiece[count2].komsuListesi.Add(knight2);
                            knight2.hareket();
                            sifir();
                            eksikHesap(count2);
                            for (int i = 0; i < 9; i++)
                            {
                                for (int j = 0; j < 9; j++)
                                {
                                    knight2.count += tahta[i, j] | knight2.tahta[i, j];
                                }
                            }
                        }
                        //sol komşu
                        if (sutun - 1 >= 0)
                        {
                            Knight knight3 = new Knight(satir, sutun - 1);
                            listePiece[count2].komsuListesi.Add(knight3);
                            knight3.hareket();
                            sifir();
                            eksikHesap(count2);
                            for (int i = 0; i < 9; i++)
                            {
                                for (int j = 0; j < 9; j++)
                                {
                                    knight3.count += tahta[i, j] | knight3.tahta[i, j];
                                }
                            }
                        }
                        //sağ komşu
                        if (sutun + 1 < 9)
                        {
                            Knight knight4 = new Knight(satir, sutun + 1);
                            listePiece[count2].komsuListesi.Add(knight4);
                            knight4.hareket();
                            sifir();
                            eksikHesap(count2);
                            for (int i = 0; i < 9; i++)
                            {
                                for (int j = 0; j < 9; j++)
                                {
                                    knight4.count += tahta[i, j] | knight4.tahta[i, j];
                                }
                            }
                        }


                        max = listePiece[count2].komsuListesi[0].count;
                        maxSatir = listePiece[count2].komsuListesi[0].basSatir;
                        maxSutun = listePiece[count2].komsuListesi[0].basSutun;
                        for (int i = 1; i < listePiece[count2].komsuListesi.Count; i++)
                        {
                            if (listePiece[count2].komsuListesi[i].count > max)
                            {
                                max = listePiece[count2].komsuListesi[i].count;
                                maxSatir = listePiece[count2].komsuListesi[i].basSatir;
                                maxSutun = listePiece[count2].komsuListesi[i].basSutun;
                                yedek3 = (Knight)listePiece[count2].komsuListesi[i];
                            }
                        }
                        if (max > count)
                        {
                            listePiece[count2].basSatir = yedek3.basSatir;
                            listePiece[count2].basSutun = yedek3.basSutun;
                            count = yedek3.count;
                            for (int i = 0; i < 9; i++)
                            {
                                for (int j = 0; j < 9; j++)
                                {
                                    tahta[i, j] = tahta[i, j] | yedek3.tahta[i, j];
                                }
                            }
                        }
                        else
                        {
                            gate = 1;
                        }
                        label3.Text += dongu + ". iterasyon";
                        label3.Text += "\n" + count + " hane tehdit ediliyor.\n";
                        dongu++;
                    }
                }
                //Daha ıyı bır komus olmaması durumunda yeni taşa geçilmesi için yukarıda bu donguden cıkmak ıcın gate 1 yapılmıstı.
                //Ayrıca yeni tasa gecmek icin count2 artırılıyor
                count2++;
            }

            label3.Text += "Program " + (dongu-1) + " iterasyonda sona erdi. Son durumda tahtada " + count + " yer tehdit ediliyor.";
            stopwatch.Stop();
            hafiza = (54 * 4) + (toplam * 88 * 4) + (9 * 9 * 4);
            label3.Text += "\nProgram "+stopwatch.ElapsedMilliseconds.ToString()+" milisaniyede tamamlandı.";
            label3.Text += "\nProgramda " + hafiza + " byte hafıza kullanıldı.";
        }
    }
}
