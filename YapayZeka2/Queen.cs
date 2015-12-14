using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YapayZeka2
{
    class Queen : Piece//Piece Abstract Class'ından türetilmiştir.
    {
        public Queen()
        {

        }
        public Queen(int satir,int sutun)
        {
            this.basSatir = satir;
            this.basSutun = sutun;
        }
        //Vezir için tehdit ettiği noktaları bulur ve kendi matrisinde o gözü 1 yapar.
        public override void hareket()
        {
            int j = 0;
            //Düz hareketleri
            for(int i=0;i<9;i++)
            {
                tahta[basSatir, i] = 1;
                tahta[i, basSutun] = 1;
            }
            //Çapraz hareketler
            j = 0;
            // sağ-asağı
            for (int i = Math.Max(basSatir, basSutun); i < 9; i++)
            {
                tahta[basSatir + j, basSutun + j] = 1;
                j++;
            }
            j = 0;
            // sol yukarı
            for (int i = Math.Min(basSatir, basSutun); i >= 0; i--)
            {
                tahta[basSatir - j, basSutun - j] = 1;
                j++;
            }
            j = 0;
            //sağ yukarı
            while (((basSatir-j) >= 0) && ((basSutun+j) < 9))
            {
                tahta[basSatir - j, basSutun + j] = 1;
                j++;
            }
            j = 0;
            //sol aşağı
            while (((basSutun-j) >= 0) && ((basSatir+j) < 9))
            {
                tahta[basSatir + j, basSutun - j] = 1;
                j++;
            }
        }
    }
}
