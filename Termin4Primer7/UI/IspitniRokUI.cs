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
            Console.WriteLine("1. Dodaj ispitni rok");
            Console.WriteLine("2.Izmeni ispitni rok");
            Console.WriteLine("3.Ispisi sve ispitne rokove");
            Console.WriteLine("4.Ispisi odredjeni ispitni rok");
            Console.WriteLine("0.Vrati se u glavni meni");
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
                        DodajIspitniRok();
                        break;

                    case 2:
                        IzmeniIspitniRok();
                        break;

                    case 3:
                        IspisiSveIspitneRokove();
                        break;

                    case 4:
                        IspisiOdredjeniIspitniRok();
                        break;

                    default:
                        Console.WriteLine("Izabrana opcija ne postoji!");
                        break;
                }
            } while (select != 0);
        }

        public static void DodajIspitniRok()
        {
            DateTime addPocetak;
            DateTime addKraj;

            Console.Write("Unesite ID:");
            int addID = IOPomocnaKlasa.OcitajCeoBroj();

            Console.Write("Unesite naziv:");
            string addNaziv = IOPomocnaKlasa.OcitajTekst();

            Console.Write("Unesite pocetak ispitnog roka(yyyy/MM/dd):");
            DateTime.TryParse(Console.ReadLine(), out addPocetak);

            Console.Write("Unesite kraj ispitnog roka(yyyy/MM/dd):");
            DateTime.TryParse(Console.ReadLine(), out addKraj);

            IspitniRok addIspitniRok = new IspitniRok { ID = addID, Naziv = addNaziv, Pocetak = addPocetak, Kraj = addKraj };
            listaIspitnihRokova.Add(addIspitniRok);

            Console.WriteLine("Ispitni rok je uspesno kreiran!");
        }

        public static void IzmeniIspitniRok()
        {
            IspisiSveIspitneRokove();

            DateTime newPocetak;
            DateTime newKraj;

            Console.Write("Unesite ID ispitnog roka za izmenu:");
            int edit = IOPomocnaKlasa.OcitajCeoBroj();

            Console.Write("Unesite novi ID:");
            int newID = IOPomocnaKlasa.OcitajCeoBroj();

            Console.Write("Unesite novi naziv:");
            string newNaziv = IOPomocnaKlasa.OcitajTekst();

            Console.Write("Unesite novi pocetak(yyyy,MM,dd):");
            newPocetak = IOPomocnaKlasa.ProveraVremena();

            Console.Write("Unesite novi kraj:(yyyy,MM,dd):");
            newKraj = IOPomocnaKlasa.ProveraVremena();

            IspitniRok izmenaIspitnogRoka = new IspitniRok {ID = newID,Naziv = newNaziv,Pocetak = newPocetak,Kraj = newKraj};

            IspitniRok FindIspitniRok = listaIspitnihRokova.Where(x => x.ID == edit).FirstOrDefault();
            listaIspitnihRokova[edit] = izmenaIspitnogRoka;
        }

        public static void IspisiSveIspitneRokove()
        {
            foreach (IspitniRok ispitniRok in listaIspitnihRokova)
            {
                Console.WriteLine("ID:" + ispitniRok.ID + " Naziv:" + ispitniRok.Naziv + " Pocetak:" + ispitniRok.Pocetak.ToString("yyyy/MM/dd") + " Kraj:" + ispitniRok.Kraj.ToString("yyyy/MM/dd"));
            }
        }

        public static void IspisiOdredjeniIspitniRok()
        {
            Console.Write("Unesite ID:");
            int select = IOPomocnaKlasa.OcitajCeoBroj();

            foreach (IspitniRok ispitniRok in listaIspitnihRokova)
            {
                if (select == ispitniRok.ID)
                {
                    Console.WriteLine("ID:" + ispitniRok.ID + " Naziv: " + ispitniRok.Naziv + " Pocetak:" + ispitniRok.Pocetak.ToString("yyyy/MM/dd") + " Kraj:" + ispitniRok.Kraj.ToString("yyyy/MM/dd"));
                }
            }

        }

        public static void UcitajIspitneRokoveIzDatoteke(string fileName)
        {
            string line = "";
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

    }
}
 