using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

delegate void yazdir(string veri);
delegate void islem();
namespace DelegateOrnek
{
    class Program
    {
        static public void EkranaYaz(string veri)
        {
            Console.WriteLine(veri);
        }

        static public void DosyayaYaz(string veri)
        {
            StreamWriter sw = new StreamWriter("dosya.txt", true);
            sw.WriteLine(veri);
            sw.Close();
        }
        
        static public void ekranaIslemYaz()
        {
            Console.WriteLine("Bu işlem ekrana yazılıyor!");
        }

        static public void Logla(string metin, yazdir yontem, islem once, islem sonra)
        {
            once();
            yontem(metin);
            sonra();
        }

        static void Main(string[] args)
        {
            /*
            yazdir anonimFonksiyon;
            StreamReader ayarlar = new StreamReader("ayarlar.txt");
            if(ayarlar.ReadLine() == "ekrana")
            {
                anonimFonksiyon = new yazdir(EkranaYaz);
            } else
            {
                anonimFonksiyon = new yazdir(DosyayaYaz);
            }
            anonimFonksiyon("DenemeLog");
            */
            yazdir yontemler = null;
            yontemler += new yazdir(EkranaYaz);
            yontemler += new yazdir(DosyayaYaz);
            Logla("Deneme Metin", yontemler, new islem(ekranaIslemYaz), new islem(ekranaIslemYaz));
            Console.ReadLine();
        }
    }
}
