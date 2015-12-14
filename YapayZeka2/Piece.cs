using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YapayZeka2
{
    abstract class Piece//At ve Vezirin nitelikleri ve metodu ortak olduğundan üst sınıf yapıldı. Hareket metodu ikisi için farklı olduğundan abstract class tercih edildi.
    {
        public int basSatir { get; set; }//Taşların Satır değeri
        public int basSutun { get; set; }//Taşların Sütun değeri
        public int count { get; set; }//Taşların kendi içlerinde tehdit ettikleri yer sayısı
        public int[,] tahta = new int[9,9];//Taşların kendilerinin tehdit ettikleri satranç tahtası için örnek matris
        public List<Piece> komsuListesi = new List<Piece>();//Taşın komşularını saklayacağımız Liste


        public abstract void hareket();
    }
}
