using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lotto
{
    class Lotto
    {
        Random random = new Random();
        int talalt = 0, nyeremeny, sorsolas, b,beolv;
        double egy,ketto,harom,negy,ot;
        int[] szam = new int[5], 
            jatekosszam = new int[5] ;
        bool mehet = true;
        public Lotto() { }
        public void szamok()
        {
            
            ot = (9*8.9*8.8*8.7*8.6)/(0.5*0.4*0.3*0.2*0.1);
            negy = ot/ ((5 * 4 * 3 * 2) / (4 * 3 * 2 * 1) * 85 / 1);
            
            Console.WriteLine("5 esélyed lesz megnyerni a FŐDIJAT :) Viszont az esélyeid nagyon jók ennyi esélyed van nyerni:");
            //--------------------------------------------------------Esélyeid------------------------------------------------------------------------------
            Console.WriteLine("öt találatra \t 1:"+ot+ "\tnegy találatra 1:"+negy+ "\tharom találatra 1:" + harom);
            //--------------------------------------------------------SORSOLÁS---------------------------------------------------------------------------------------------------------------
            for (int q = 0; q < 5; q++)
            {


            Console.WriteLine("A nyerőszámok:");
            Console.WriteLine("==============");

            for (int i = 0; i < szam.Length; i++)//nyerőszámok, ismétlésmentesen
            {
                sorsolas = random.Next(1, 91);//a random szám mind egy számmal visszább generál
                b = 0;
                mehet = true; //true érték adás, hogy legalább 1x lefusson a program, ezt meg lehet adni do while-al is, de nekem így egyszerűbb
                while (b < i && mehet == true)
                {
                    if (szam[b] == sorsolas)//ha a sorsolt számunk megegyezik az adott indexen lévő számmal, akkor false értéket kap az ellenőrzőváltozóm
                    {
                        mehet = false;
                        Console.WriteLine("ujra");
                    }
                    else //ha nem egyenlő, akkor a "mehet" marad true és megnöveljük a "b" változót, az indexét a tömbnek
                    {
                        mehet = true;
                        b++;
                    }
                } // ha minden passzol és az ellenőrző true marad, akkor a szám[i] megkapja a sorsolt számot
                if (mehet == true)
                {
                    szam[i] = sorsolas;
                }
                else //ha false lett, akkor 1-el visszalépünk az index-en, mivel a for ciklus miatt minden futás után nő 1-el és ugyanezen az indexen fusson le megint
                {
                    i--;
                }
            }
            Array.Sort(szam);
            foreach (var item in szam)
            {
                Console.WriteLine(item + " ");

            }
//--------------------------------------------------------JÁTÉKOS---------------------------------------------------------------------------------------------------------------
            for (int i = 0; i < jatekosszam.Length; i++)//játékos számai, ismétlésmentesen
            {
                Console.WriteLine("Irj be szamot");
                beolv = Convert.ToInt32(Console.ReadLine());//beolvasok egy számot
                b = 0;
                mehet = true; //true érték adás, hogy legalább 1x lefusson a program, ezt meg lehet adni do while-al is, de nekem így egyszerűbb
                while (b < i && mehet == true)
                {
                    if (jatekosszam[b] == beolv)//ha a bekért számunk megegyezik az adott indexen lévő számmal, akkor false értéket kap az ellenőrzőváltozóm
                    {
                        mehet = false;
                        Console.WriteLine("Ez a szám már szerepelt");
                    }
                        if (beolv > 90)
                        {
                            mehet = false;
                            Console.WriteLine("90 alatt tippelj");
                        }
                    else //ha nem egyenlő, akkor a "mehet" marad true és megnöveljük a "b" változót, az indexét a tömbnek
                    {
                        mehet = true;
                        b++;
                    }
                    } // ha minden passzol és az ellenőrző true marad, akkor a szám[i] megkapja a beolvasott számot
                if (mehet == true)
                {
                    jatekosszam[i] = beolv;
                }
                else //ha false lett, akkor 1-el visszalépünk az index-en, mivel a for ciklus miatt minden futás után nő 1-el és ugyanezen az indexen fusson le megint
                {
                    i--;
                }
            }
            //----------------------------------------------------------NYERÉS---------------------------------------------------------------------------------------------------------
            for (int i = 0; i < 5; i++) // játékos számainak, bekérése után összehasonlítjuk
            {
                for (int j = 0; j < 5; j++)
                {
                    if (jatekosszam[i] == szam[j])
                    {
                        talalt++; //ha volt egy találatunk a talalt változó kap +1 et
                    }
                }
            }
            switch (talalt) //megnézzük mennyit talált el a pajtás és eredményének megfelelően, kap egy üzenetet, illetve a nyereményének összegét is megtudja
            {
                case 0:
                    Console.WriteLine("Nem nyertél semmit, majd legközelebb");
                    break;
                case 1:
                    nyeremeny = random.Next(200, 500);
                    Console.WriteLine("1 darab találatod volt. Nyereményed:  {0} Forint. Gratulálok!", nyeremeny);
                    break;
                case 2:
                    nyeremeny = random.Next(501, 1000);
                    Console.WriteLine("2 darab találatod volt. Nyereményed:  {0} Forint. Gratulálok!", nyeremeny);
                    break;
                case 3:
                    nyeremeny = random.Next(1001, 3000);
                    Console.WriteLine("3 darab találatod volt. Nyereményed:  {0} Forint. Gratulálok!", nyeremeny);
                    break;
                case 4:
                    nyeremeny = random.Next(3001, 10000);
                    Console.WriteLine("4 darab találatod volt. Nyereményed:  {0} Forint. Gratulálok!", nyeremeny);
                    break;
                case 5:
                    nyeremeny = random.Next(1000001, 99999999);
                    Console.WriteLine("TELITALÁLAT!!! 5 darab találatod volt. Nyereményed:  {0} Forint. Gratulálok a főnyereményhez!", nyeremeny);
                    break;
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string k = " ";
            Lotto lotto = new Lotto();
            lotto.szamok();


            Console.ReadLine();
        }
    }
}
