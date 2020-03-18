using Modul1Termin04.Primer7.Model;
using Modul1Termin04.Primer7.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Termin4Primer7.UI
{
    class IspitniRokUI
    {
        public static List<IspitniRok> listaIspitnihRokova = new List<IspitniRok>();

        public static void IspisiMenuText()
        {
            Console.WriteLine("1.Dodaj ispitni rok");
            Console.WriteLine("2.Izmeni ispitni rok");
            Console.WriteLine("3.Ispisi sve ispitne rokove");
            Console.WriteLine("4.Ispisi odredjeni ispitni rok");
            Console.WriteLine("0.Nazad");
            Console.Write("Opcija:");
        }
        public static void MeniIspitniRok()
        {

            int select;
            do
            {
                IspisiMenuText();
                select = IOPomocnaKlasa.OcitajCeoBroj();
                switch (select)
                {
                    case 1:
                        Console.Clear();
                        DodajIspitniRok();
                        break;

                    case 2:
                        Console.Clear();
                        IzmeniIspitniRok();
                        break;

                    case 3:
                        Console.Clear();
                        IspisiSveIspitneRokove();
                        Console.WriteLine("Pritisnite bilo koje dugme da se vratite u meni");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 4:
                        Console.Clear();
                        IspisiOdredjeniIspitniRok();
                        break;

                    case 0:
                        Console.Clear();
                        break;

                    default:

                        break;
                }
            } while (select != 0);
        }

        public static void DodajIspitniRok()
        {
            Console.Clear();
            IOPomocnaKlasa.IDispitnogRoka++;
            DateTime addPocetak;
            DateTime addKraj;

            Console.Write("Unesite naziv:");
            string addNaziv = IOPomocnaKlasa.OcitajTekst();

            Console.Write("Unesite pocetak ispitnog roka:");
            addPocetak = IOPomocnaKlasa.ProveraVremena();

            Console.Write("Unesite kraj ispitnog roka:");
            addKraj = IOPomocnaKlasa.ProveraVremena();

            IspitniRok addIspitniRok = new IspitniRok { ID = IOPomocnaKlasa.IDispitnogRoka, Naziv = addNaziv, Pocetak = addPocetak, Kraj = addKraj };
            listaIspitnihRokova.Add(addIspitniRok);

            string lokacija = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));

            SacuvajIspitneRokoveUDatoteku(lokacija + "data" + "\\" + "ispitni_rokovi.csv");

            Console.Clear();

            Console.WriteLine("Ispitni rok je uspesno kreiran!");

            Console.WriteLine("Pritiniste bilo koje dugme da se vratite u meni");
            Console.ReadLine();

            Console.Clear();
        }

        public static void IzmeniIspitniRok()
        {
            Console.Clear();
            IspisiSveIspitneRokove();

            DateTime newPocetak;
            DateTime newKraj;

            Console.Write("Unesite ID za izmenu:");
            int edit = IOPomocnaKlasa.OcitajCeoBroj();

            bool proveraID = ProveraID(edit);

            if (!proveraID)
            {
                Console.WriteLine("Taj ID ne postoji!");
                return;
            }

            Console.Write("Unesite novi naziv:");
            string newNaziv = IOPomocnaKlasa.OcitajTekst();

            Console.Write("Unesite novi pocetak(yyyy,MM,dd):");
            newPocetak = IOPomocnaKlasa.ProveraVremena();

            Console.Write("Unesite novi kraj:(yyyy,MM,dd):");
            newKraj = IOPomocnaKlasa.ProveraVremena();

            IspitniRok FindIspitniRok = listaIspitnihRokova.Where(x => x.ID == edit).FirstOrDefault();

            IspitniRok izmenaIspitnogRoka = new IspitniRok { ID = FindIspitniRok.ID, Naziv = newNaziv, Pocetak = newPocetak, Kraj = newKraj };

            int index = listaIspitnihRokova.IndexOf(FindIspitniRok);

            listaIspitnihRokova[index] = izmenaIspitnogRoka;

            string lokacija = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));
            SacuvajIspitneRokoveUDatoteku(lokacija + "data" + "\\" + "ispitni_rokovi.csv");

            Console.Clear();

            Console.WriteLine("Ispitni rok je uspesno izmenjen!");

            Console.WriteLine("Pritisnite bilo koje dugme da se vratite u meni");
            Console.ReadLine();
            Console.Clear();
        }

        public static void IspisiSveIspitneRokove()
        {
            Console.Clear();
            foreach (IspitniRok ispitniRok in listaIspitnihRokova)
            {
                Console.WriteLine("ID:" + ispitniRok.ID + " Naziv:" + ispitniRok.Naziv + " Pocetak:" + ispitniRok.Pocetak.ToString("yyyy/MM/dd") + " Kraj:" + ispitniRok.Kraj.ToString("yyyy/MM/dd"));
            }
        }

        public static void IspisiOdredjeniIspitniRok()
        {
            Console.Clear();
            Console.Write("Unesite ID:");
            int select = IOPomocnaKlasa.OcitajCeoBroj();

            bool provera = ProveraID(select);

            if (!provera)
            {
                Console.WriteLine("Taj ID ne postoji!");
                return;
            }

            foreach (IspitniRok ispitniRok in listaIspitnihRokova)
            {
                if (select == ispitniRok.ID)
                {
                    Console.WriteLine("ID:" + ispitniRok.ID + " Naziv: " + ispitniRok.Naziv + " Pocetak:" + ispitniRok.Pocetak.ToString("yyyy/MM/dd") + " Kraj:" + ispitniRok.Kraj.ToString("yyyy/MM/dd"));
                }
            }

            Console.WriteLine("Pritisnite bilo koje dugme da se vratite u meni");
            Console.ReadLine();
            Console.Clear();
        }

        public static void UcitajIspitneRokoveIzDatoteke(string fileName)
        {
            string line = string.Empty;
            if (File.Exists(fileName))
            {
                using (StreamReader citac = File.OpenText(fileName))
                {
                    while ((line = citac.ReadLine()) != null)
                    {
                        listaIspitnihRokova.Add(new IspitniRok(line));
                    }
                }
            }
            else
            {
                Console.WriteLine("Greska,datoteka nije pronadjena!");
            }
        }


        public static void SacuvajIspitneRokoveUDatoteku(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (StreamWriter recorder = new StreamWriter(fileName, false, Encoding.UTF8))
                {
                    foreach (IspitniRok ispitniRok in listaIspitnihRokova)
                    {
                        recorder.WriteLine(ispitniRok.ToFileString());
                    }
                }
            }
            else
            {
                Console.WriteLine("Greska,datoteka ne postoji!!");
            }
        }

        public static bool ProveraID(int id)
        {
            foreach (IspitniRok ispitniRok in listaIspitnihRokova)
            {
                if (ispitniRok.ID == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
