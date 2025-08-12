using System;
using System.Data;
using System.Text.Json;

class Program
{
    public class veriler    
    {
        public int id { get; set; }
        public string isim { get; set; }
        
        public string aciklama { get; set; }
           
        public string anahtar_kelime { get; set; }
    }

    static void Main()
    {

        string path = "veri.json";
        string json = File.ReadAllText(path);
        List<veriler> liste = JsonSerializer.Deserialize<List<veriler>>(json);
        Console.WriteLine("-------------------------------------------------------------------------------");
        foreach (var item in liste)
        {
            Console.WriteLine(item.id + " - " + item.isim + " - " + item.aciklama + " - " + item.anahtar_kelime);
        }
        Console.WriteLine("-------------------------------------------------------------------------------");


            Console.WriteLine("Nasıl bir istekte bulunmaktasınız?");
        string kabacumle = Console.ReadLine();
        Console.WriteLine("");
     
        

        string[] cumle_kelimeleri = kabacumle.Split(' ');
        cumle_kelimeleri = kelimeduzenle(cumle_kelimeleri);

        int[] yazilanid = new int[10];   // liste büyürse artırılmalı 
        int i = 0;
        foreach (var kelime in cumle_kelimeleri)
        {
            kelimeara(kelime);
        }



        void kelimeara(string cumle_kelimeleri) 
            {
            
            
            foreach (var item in liste) {
                if (ayirma(item.anahtar_kelime, cumle_kelimeleri) || ayirma(item.isim, cumle_kelimeleri) || ayirma(item.aciklama, cumle_kelimeleri))
                {
                    if (!yazilanid.Contains((item.id))) {
                        Console.WriteLine(item.id + " - " + item.isim + " - " + item.aciklama + " - " + item.anahtar_kelime);
                        yazilanid[i++] = item.id;
                    }
                    
                }
            } }




        Boolean ayirma(string asd,string cumlekelimeleri) {
            string[] temp = asd.Split(" ");
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = temp[i].ToLower();
            }

            if (temp.Contains(cumlekelimeleri))
            {
                return true;
            }
            else {  return false; }
        }

        string[] kelimeduzenle(string[] yenidizi) {

            for(var i = 0; i<yenidizi.Length;i++)
            { yenidizi[i]=yenidizi[i].ToLower(); }

            var istenmeyenler = new[] { "a", "am", "is", "are" ,"to"};

            for (int i = 0; i < yenidizi.Length; i++) {

                if (istenmeyenler.Contains(yenidizi[i]) ) {
                    yenidizi[i] = null;}
                }
            return yenidizi;

        }

    }
}
