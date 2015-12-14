using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YapayZeka2
{

    class Knight : Piece//Taş sınıfından kalıtılmıştır.
    {
        public Knight()
        {

        }
        //Satır ve Sutun ile Yeni bir at nesnesi yaratan constructor
        public Knight(int satir, int sutun)
        {
            this.basSatir = satir;
            this.basSutun = sutun;
        }
        //At için hareket edebileceği noktaları bularak onun tehdit ettiği noktaları bulur
        public override void hareket()
        {
            //At tahta sınırları içinde max 8 yöne hareket edebilir. Onun kontrolunu yapar ve kendine ait olan tahta matrisinde o gozu 1 yapar
            tahta[basSatir, basSutun] = 1;//Atın bulundugu noktayı tehdit ettiğini ayarlar.

            if ((basSatir - 1) < 9 && (basSatir - 1) >= 0 && (basSutun + 2) >= 0 && (basSutun + 2) < 9)
            {
                tahta[basSatir - 1, basSutun + 2] = 1;
            }
            if ((basSatir - 1) < 9 && (basSatir - 1) >= 0 && (basSutun - 2) >= 0 && (basSutun - 2) < 9)
            {
                tahta[basSatir - 1, basSutun - 2] = 1;
            }
            if ((basSatir + 1) < 9 && (basSatir + 1) >= 0 && (basSutun + 2) >= 0 && (basSutun + 2) < 9)
            {
                tahta[basSatir + 1, basSutun + 2] = 1;
            }
            if ((basSatir + 1) < 9 && (basSatir + 1) >= 0 && (basSutun - 2) >= 0 && (basSutun - 2) < 9)
            {
                tahta[basSatir + 1, basSutun - 2] = 1;
            }
            if ((basSatir - 2) < 9 && (basSatir - 2) >= 0 && (basSutun + 1) >= 0 && (basSutun + 1) < 9)
            {
                tahta[basSatir - 2, basSutun + 1] = 1;
            }
            if ((basSatir + 2) < 9 && (basSatir + 2) >= 0 && (basSutun - 1) >= 0 && (basSutun - 1) < 9)
            {
                tahta[basSatir + 2, basSutun - 1] = 1;
            }
            if ((basSatir + 2) < 9 && (basSatir + 2) >= 0 && (basSutun + 1) >= 0 && (basSutun + 1) < 9)
            {
                tahta[basSatir + 2, basSutun + 1] = 1;
            }
            if ((basSatir - 2) < 9 && (basSatir - 2) >= 0 && (basSutun - 1) >= 0 && (basSutun - 1) < 9)
            {
                tahta[basSatir - 2, basSutun - 1] = 1;
            }

        }


    }

    
    
}
