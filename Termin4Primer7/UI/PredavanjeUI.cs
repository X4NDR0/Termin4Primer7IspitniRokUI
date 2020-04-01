using Modul1Termin04.Primer7.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Termin4Primer7.Model;

namespace Termin4Primer7.UI
{
    class PredavanjeUI
    {
        public static List<Predavanje> listaPredavanja = new List<Predavanje>();

        public static void TekstMenija()
        {
            Console.WriteLine("1.Dodaj predavanje");
            Console.WriteLine("2.Izmeni predavanje");
            Console.WriteLine("3.Ispisi sva predavanja");
            Console.WriteLine("4.Ispisi odredjeno predavanje");
            Console.WriteLine("0.Nazad");
            Console.Write("Opcija:");
        }

        public static void MeniPredavanja()
        {
            int izabir;

            Console.Clear();

            do
            {
                TekstMenija();
                izabir = IOPomocnaKlasa.OcitajCeoBroj();

                switch (izabir)
                {
                    case 1:
                        Console.Clear();
                        DodajPredavanje();
                        break;

                    case 2:
                        Console.Clear();
                        IzmeniPredavanje();
                        break;

                    case 3:
                        Console.Clear();
                        IspisiSvaPredavanja();
                        Console.WriteLine("Pritisnite bilo koje dugme da se vratite u meni");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 4:
                        Console.Clear();
                        IspisiOdredjenoPredavanje();
                        break;

                    case 0:
                        Console.Clear();
                        break;

                    default:
                        break;
                }
            } while (izabir != 0);
        }

        public static void DodajPredavanje()
        {
            PredmetUI.IspisiSvePredmete();

            Console.Write("Unesite ID predmeta:");
            int IDPredmeta = IOPomocnaKlasa.OcitajCeoBroj();

            bool proveraPredmetID = PredmetUI.ProveraID(IDPredmeta);

            if (!proveraPredmetID)
            {
                Console.WriteLine("Taj ID vec postoji!");
                return;
            }

            Console.Clear();

            NastavnikUI.IspisiSveProfesore();
            Console.Write("Unesite ID profesora:");
            int idProfesora = IOPomocnaKlasa.OcitajCeoBroj();

            bool proveraProfesorID = NastavnikUI.ProveraID(idProfesora);

            if (!proveraProfesorID)
            {
                Console.WriteLine("Taj ID vec postoji!");
                return;
            }

            Predavanje predavanjeAdd = new Predavanje { ID = IOPomocnaKlasa.IDPredavanja++, IDPredmeta = IDPredmeta, IDProfesora = idProfesora };

            listaPredavanja.Add(predavanjeAdd);
            string lokacija = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));
            SacuvajPodatke(lokacija + "data" + "\\" + "predaje.csv");

            Console.Clear();

            Console.WriteLine("Predavanje je uspesno dodato!");

            Console.WriteLine("Pritisnite bilo koje dugme da se vratite u meni");
            Console.ReadLine();
            Console.Clear();
        }

        public static void IzmeniPredavanje()
        {
            IspisiSvaPredavanja();

            Console.Write("Unesite ID predavanja kojeg zelite da izmenite:");
            int IDPredavanja = IOPomocnaKlasa.OcitajCeoBroj();

            bool provera = ProveriIDPredavanja(IDPredavanja);

            if (!provera)
            {
                Console.WriteLine("To predavanje ne postoji!");
                return;
            }

            Console.Write("Unesite novi ID predmeta:");
            int IDPredmetaEdit = IOPomocnaKlasa.OcitajCeoBroj();

            Console.Write("Unesite novi ID profesora:");
            int idProfesora = IOPomocnaKlasa.OcitajCeoBroj();

            Predavanje FindObject = listaPredavanja.Where(b => b.IDPredmeta == IDPredavanja).FirstOrDefault();

            int index = listaPredavanja.IndexOf(FindObject);

            Predavanje predavanjeEdit = new Predavanje { ID = FindObject.ID, IDPredmeta = IDPredmetaEdit, IDProfesora = idProfesora };

            listaPredavanja[index] = predavanjeEdit;

            string lokacija = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));
            SacuvajPodatke(lokacija + "data" + "\\" + "predaje.csv");

            Console.Clear();

            Console.WriteLine("Predavanje je uspesno izmenjeno");

            Console.WriteLine("Pritisnite bilo koje dugme da se vratite u meni");
            Console.ReadLine();
            Console.Clear();
        }

        public static void IspisiSvaPredavanja()
        {
            foreach (Predavanje predavanje in listaPredavanja)
            {
                Nastavnik FoundNastavnik = NastavnikUI.listaProfesora.Where(x => x.ID == predavanje.IDProfesora).FirstOrDefault();
                Predmet FoundPredmet = PredmetUI.listaPredmeta.Where(x => x.ID == predavanje.IDPredmeta).FirstOrDefault();

                Console.WriteLine("Id Predavanja: " + predavanje.ID + " Ime Profesora:" + FoundNastavnik.Ime + " Prezime profesora:" + FoundNastavnik.Prezime + " Predmet:" + FoundPredmet.Naziv);
            }
        }

        public static void IspisiOdredjenoPredavanje()
        {
            int IDPredavanja;

            Console.Write("Unesite ID predavanja:");

            IDPredavanja = IOPomocnaKlasa.OcitajCeoBroj();

            foreach (Predavanje predavanje in listaPredavanja)
            {
                if (IDPredavanja == predavanje.ID)
                {
                    Console.WriteLine("Predavanje pod ID-om:" + predavanje.IDPredmeta + " predaje profesor pod ID-om:" + predavanje.IDProfesora);
                }
            }
            Console.WriteLine("Pritisnite bilo koje dugme da se vratite u meni");
            Console.ReadLine();
            Console.Clear();
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
                        listaPredavanja.Add(new Predavanje(line));
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
                    foreach (Predavanje predavanje in listaPredavanja)
                    {
                        recorder.WriteLine(predavanje.ToFileString());
                    }
                }
            }
            else
            {
                Console.WriteLine("Greska,datoteka ne postoji!!");
            }
        }

        public static bool ProveriIDPredavanja(int idPredavanja)
        {
            foreach (Predavanje predavanje in listaPredavanja)
            {
                if (predavanje.ID == idPredavanja)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool ProveriIDPredmeta(int idPredmeta)
        {
            foreach (Predmet predmet in PredmetUI.listaPredmeta)
            {
                if (predmet.ID == idPredmeta)
                {
                    return true;
                }
            }
            return false;
        }

    }
}

