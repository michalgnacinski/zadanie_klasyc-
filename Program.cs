/*
* Created by SharpDevelop.
* User: User
* Date: 03.10.2023
* Time: 17:01
* 
* To change this template use Tools | Options | Coding | Edit Standard Headers.
*/
using System;

namespace csw
{
    class Budynek
    {
        private string adres;
        public int powierzchnia;
        private int ilosc_kondygnacji;

        public void Wypisz()
        {
            //Metoda wypisująca
            Console.WriteLine("{0}\n{1}\n{2}", adres, powierzchnia, ilosc_kondygnacji);
            if (ilosc_kondygnacji == 1) Console.WriteLine("Budynek jest parterowy");
            else Console.WriteLine("Dom jest {0} piętrowy", ilosc_kondygnacji);
            powierzchnia = powierzchnia * ilosc_kondygnacji;

            if (adres.Contains("Poznan")) Console.WriteLine("Budynek znajduje sie w moim ulubionym miescie");
        }
        //Metoda ustawiająca dane dla Klasy Budynek
        public void Ustaw()
        {
            adres = "Os. Zwycięstwa 22 Poznan";
            powierzchnia = 60;
            ilosc_kondygnacji = 1;
        }
        //Metody Zwracające
        public string Zwroc_adres()
        {
            return adres;
        }
        public double Zwroc_powierzchnia()
        {
            return powierzchnia;
        }
        public int Zwroc_ilosc()
        {
            return ilosc_kondygnacji;
        }
    }
    //Tworzenie klasy dziedziczącej
    class BudynekMieszkalny : Budynek
    {
        public int ilosc_mieszkan;
        public double srednia;
        public int ile_mieszkancow;
        //Metoda ustawiająca dane klasy dziedziczącej
        public void Ustaw_ilosc()
        {
            ilosc_mieszkan = 7;
            powierzchnia = 200;
        }
        //Metoda obliczająca i zwracająca srednią powierzchnie mieszkania
        public double Srednia()
        {
            return srednia = powierzchnia / ilosc_mieszkan;
        }
        //Metody wypisujące
        public int Zwroc_mieszkanie()
        {
            return ilosc_mieszkan;
        }
        public int Ile_mieszkancow()
        {
            return ile_mieszkancow = powierzchnia / 15;
        }
        //Metoda Wypisująca
        public void Wypisz_ilosc()
        {
            Console.WriteLine("Ilość mieszkań: {0}\nSrednia powierzchnia mieszkania: {1}", ilosc_mieszkan, srednia);
        }
        //Stworzenie kostruktora bazowego
        public BudynekMieszkalny() : base()
        {
            ilosc_mieszkan = 4;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Budynek budynek = new Budynek();
            budynek.Ustaw();
            budynek.Wypisz();
            //Metoda zwracająca
            Console.WriteLine("{0}\n{1}\n{2}", budynek.Zwroc_adres(), budynek.Zwroc_powierzchnia(), budynek.Zwroc_ilosc());
            BudynekMieszkalny budynekM = new BudynekMieszkalny();

            budynekM.Srednia();
            budynekM.Ustaw_ilosc();
            //Wypisanie ilosci mieszkan i sredniej powierzchni na mieszkanie
            Console.WriteLine("Ilość mieszkań: {0}\nSrednia powierzchnia mieszkania: {1}", budynekM.Zwroc_mieszkanie(), budynekM.Srednia());



            BudynekMieszkalny budynekM2 = new BudynekMieszkalny();
            budynekM2.Srednia();
            //Wypisanie ilosci mieszkan i sredniej powierzchni na mieszkanie
            Console.WriteLine("Ilość mieszkań: {0}\nSrednia powierzchnia mieszkania: {1}", budynekM.Zwroc_mieszkanie(), budynekM.Srednia());
            budynekM2.Ustaw_ilosc();
            //Wypisanie ilości mieszkańców na 1 budynek
            Console.WriteLine("Budynek może mieć {0} mieszkańców", budynekM2.Ile_mieszkancow());

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}
