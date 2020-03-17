using Modul1Termin04.Primer7.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Termin4Primer7.Model;

namespace Termin4Primer7.UI
{
    class PredmetUI
    {
        public static List<Predmet> listaPredmeta = new List<Predmet>();
        public static void MenuText()
        {
            Console.WriteLine("1.Dodaj predmet");
            Console.WriteLine("2.Izmeni predmet");
            Console.WriteLine("3.Ispisi sve predmete");
            Console.WriteLine("4.Ispisi odredjen predmet");
            Console.WriteLine("0.Nazad");
            Console.Write("Opcija:");
        }

        public static void MenuPredmet()
        {
            int izabir;

            do
            {
                MenuText();
                izabir = IOPomocnaKlasa.OcitajCeoBroj();
                switch (izabir)
                {
                    case 1:
                        DodajPredmet();
                        break;

                    case 2:
                        IzmeniPredmet();
                        break;

                    case 3:
                        IspisiSvePredmete();
                        break;

                    case 4:
                        IspisiOdredjeniPredmet();
                        break;

                    default:
                        break;
                }
            } while (izabir != 0);


        }

        public static void IspisiSvePredmete()
        {
            foreach (Predmet predmet in listaPredmeta)
            {
                Console.WriteLine(predmet.ID + " " + predmet.Indeks + " " + predmet.Naziv);
            }
        }

        public static void IspisiOdredjeniPredmet()
        {
            Console.Write("Unesite ID predmeta:");
            int id = IOPomocnaKlasa.OcitajCeoBroj();

            bool provera = ProveraID(id);

            if (!provera)
            {
                Console.WriteLine("Taj ID ne postoji!");
                return;
            }

            foreach (Predmet predmet in listaPredmeta)
            {
                if (predmet.ID == id)
                {
                    Console.WriteLine(predmet.ID + " " + predmet.Indeks + " " + predmet.Naziv);
                }
            }
        }

        public static void IzmeniPredmet()
        {
            Console.Write("Unesite ID predmeta za izmenu:");
            int izmena = IOPomocnaKlasa.OcitajCeoBroj();

            bool provera = ProveraID(izmena);

            if (!provera)
            {
                Console.WriteLine("ID koji ste izabrali ne postoji!");
                return;
            }

            Console.Write("Unesite indeks:");
            string editIndeks = IOPomocnaKlasa.OcitajTekst();

            Console.Write("Unesite naziv predmeta:");
            string editNaziv = IOPomocnaKlasa.OcitajTekst();

            Predmet FindObject = listaPredmeta.Where(x => x.ID == izmena).FirstOrDefault();

            Predmet predmet = new Predmet { ID = FindObject.ID, Indeks = editIndeks, Naziv = editNaziv };

            int index = listaPredmeta.IndexOf(FindObject);

            string mesto = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));
            SacuvajPodatke(mesto + "data" + "\\" + "predmeti.csv");

            listaPredmeta[index] = FindObject;
        }

        public static void DodajPredmet()
        {
            IOPomocnaKlasa.IDPredmeta++;
            Console.Write("Unesite indeks:");
            string addIndeks = IOPomocnaKlasa.OcitajTekst();

            Console.Write("Unesite naziv predmeta:");
            string addNaziv = IOPomocnaKlasa.OcitajTekst();

            Predmet addPredmet = new Predmet { ID = IOPomocnaKlasa.IDPredmeta, Indeks = addIndeks, Naziv = addNaziv };

            listaPredmeta.Add(addPredmet);

            string mesto = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));
            SacuvajPodatke(mesto + "data" + "\\" + "predmeti.csv");
        }

        public static void UcitajPodatke(string fileName)
        {
            string line = string.Empty;
            if (File.Exists(fileName))
            {
                using (StreamReader citac = File.OpenText(fileName))
                {
                    while ((line = citac.ReadLine()) != null)
                    {
                        listaPredmeta.Add(new Predmet(line));
                    }
                }
            }
            else
            {
                Console.WriteLine("Greska,datoteka nije pronadjena!");
            }
        }


        public static void SacuvajPodatke(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (StreamWriter recorder = new StreamWriter(fileName, false, Encoding.UTF8))
                {
                    foreach (Predmet predmet in listaPredmeta)
                    {
                        recorder.WriteLine(predmet.FileString());
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
            foreach (Predmet predmet in listaPredmeta)
            {
                if (predmet.ID == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
