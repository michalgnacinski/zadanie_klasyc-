using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Osoba
{
    public string Imie
    {
        get;
        set;
    }
    public string Nazwisko
    {
        get;
        set;
    }
    public string DataUrodzenia
    {
        get;
        set;
    }

    public Osoba(string imie, string nazwisko, string dataUrodzenia)
    {
        Imie = imie;
        Nazwisko = nazwisko;
        DataUrodzenia = dataUrodzenia;
    }
    public virtual void WypiszInfo()
    {
        Console.WriteLine("Imię: {0}", Imie);
        Console.WriteLine("Nazwisko: {0}", Nazwisko);
        Console.WriteLine("Data urodzenia: {0}", DataUrodzenia);
    }
}
class Student : Osoba
{
    public int Rok
    {
        get;
        set;
    }
    public int Grupa
    {
        get;
        set;
    }
    public int NrIndeksu
    {
        get;
        set;
    }
    public Student(string imie, string nazwisko, string dataUrodzenia, int rok, int grupa, int nrIndeksu)
        : base(imie, nazwisko, dataUrodzenia)
    {
        Rok = rok;
        Grupa = grupa;
        NrIndeksu = nrIndeksu;
    }
    public override void WypiszInfo()
    {
        base.WypiszInfo();
        Console.WriteLine("Rok: {0}", Rok);
        Console.WriteLine("Grupa: {0}", Grupa);
        Console.WriteLine("Numer indeksu: {0}", NrIndeksu);
        foreach (Ocena oc in oceny)
        {
            Console.WriteLine("{0}, {1}, {2}", oc.NazwaPrzedmiotu, oc.Data, oc.Wartosc);
        }

    }

    private List<Ocena> oceny = new List<Ocena>();

    public void DodajOcene(string nazwaPrzedmiotu, string data, double wartosc)
    {
        Ocena nowaOcena = new Ocena(nazwaPrzedmiotu, data, wartosc);
        oceny.Add(nowaOcena);
    }

    public void WypiszOceny()
    {
        foreach(Ocena oc in oceny)
        {
            Console.WriteLine("{0}, {1}, {2}", oc.NazwaPrzedmiotu, oc.Data, oc.Wartosc);
        }
    }

    public void WypiszOceny(string nazwaPrzedmiotu)
    {
        foreach (Ocena oc in oceny)
        {
            if (oc.NazwaPrzedmiotu == nazwaPrzedmiotu)
            {
                Console.WriteLine("{0}, {1}, {2}", oc.NazwaPrzedmiotu, oc.Data, oc.Wartosc);
            }
        }
    }

    public void UsunOcene(string nazwaPrzedmiotu, string data, double wartosc)
    {
        for(int i = oceny.Count-1; i>=0 ; i--)
        {
            if (oceny[i].NazwaPrzedmiotu == nazwaPrzedmiotu && oceny[i].Data == data && oceny[i].Wartosc == wartosc)
            {
                oceny.RemoveAt(i);
            }
        }
    }
    
    public void UsunOceny()
    {
        oceny.Clear();
    }

    public void UsunOceny(string nazwaPrzedmiotu)
    {
        for (int i = oceny.Count - 1; i >= 0; i--)
        {
            if (oceny[i].NazwaPrzedmiotu == nazwaPrzedmiotu)
            {
                oceny.RemoveAt(i);
            }
        }
    }


    class Ocena 
    {
        public string NazwaPrzedmiotu
        {
            get; set;
        }
        public string Data
        {
            get; set;
        }
        public double Wartosc
        {
            get; set;
        }

        public Ocena(string nazwaPrzedmiotu, string data, double wartosc)
        {
            NazwaPrzedmiotu = nazwaPrzedmiotu;
            Data = data;
            Wartosc = wartosc;
        }
    }
}
class Pilkarz : Osoba
{
    public string Pozycja
    {
        get;
        set;
    }
    public string Klub
    {
        get;
        set;
    }
    public int LiczbaGoli
    {
        get;
        set;
    }

    public Pilkarz(string imie, string nazwisko, string dataUrodzenia,string pozycja, string klub)
        : base(imie, nazwisko, dataUrodzenia)
    {
        Pozycja = pozycja;
        Klub = klub;
      
    }

    public override void WypiszInfo()
    {
        base.WypiszInfo();
        Console.WriteLine("Pozycja: {0}", Pozycja);
        Console.WriteLine("Klub: {0}", Klub);
        Console.WriteLine("Liczba goli: {0}", LiczbaGoli);
    }
    public void StrzelGola()
    {
        LiczbaGoli++;
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Zadanie 1");
        Osoba o = new Osoba("Adam", "Miś", "20.03.1980");
        Student o2 = new Student("Michał", "Kot", "13.04.1990",2,1,12345);
        Pilkarz o3 = new Pilkarz("Mateusz", "Żbik", "10.08.1986", "obronca", "FC czestochowa");
       
        o.WypiszInfo();
        o2.WypiszInfo();
        o3.WypiszInfo();

        Student s = new Student("Krzysztof","Jeż","22.12.1990",2,5,54321);
        Pilkarz p = new Pilkarz("Piotr", "Kos", "14.09.1984", "napastnik", "FC Politechnika");

        s.WypiszInfo();
        p.WypiszInfo();

        ((Pilkarz)o3).StrzelGola();
        p.StrzelGola();
        p.StrzelGola();

        o3.WypiszInfo();
        p.WypiszInfo();

        Console.WriteLine("Zadanie 2");

        Console.WriteLine();
        ((Student)o2).DodajOcene("PO", "20.02.2011", 5.0);
        ((Student)o2).DodajOcene("Bazy danych", "13.02.2011", 4.0);

        o2.WypiszInfo();

        s.DodajOcene("Bazy danych", "01.05.2011", 5.0);
        s.DodajOcene("AWWW", "11.05.2011", 5.0);
        s.DodajOcene("AWWW", "02.04.2011", 4.5);

        s.WypiszInfo();

        s.UsunOcene("AWWW", "02.04.2011", 4.5);
        s.WypiszInfo();

        s.DodajOcene("AWWW", "02.04.2011", 4.5);
        s.UsunOceny("AWWW");

        s.WypiszInfo();

        s.DodajOcene("AWWW", "02.04.2011", 4.5);
        s.UsunOceny();

        s.WypiszInfo();

    }
}