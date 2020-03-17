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

        public static void MeniPredaja()
        {
            int izabir;

            do
            {
                TekstMenija();
                izabir = IOPomocnaKlasa.OcitajCeoBroj();

                switch (izabir)
                {
                    case 1:
                        DodajPredavanje();
                        break;

                    case 2:
                        IzmeniPredavanje();
                        break;

                    case 3:
                        IspisiSvaPredavanja();
                        break;

                    case 4:
                        IspisiOdredjenuPredaju();
                        break;

                    case 0:

                        break;

                    default:

                        break;
                }
            } while (izabir != 0);
        }

        public static void DodajPredavanje()
        {
            IOPomocnaKlasa.IDPredavanja++;
            PredmetUI.IspisiSvePredmete();

            Console.Write("Unesite ID predmeta:");
            int IDPredmeta = IOPomocnaKlasa.OcitajCeoBroj();

            bool proveraPredmetID = PredmetUI.ProveraID(IDPredmeta);

            if (!proveraPredmetID)
            {
                Console.WriteLine("Taj ID vec postoji!");
                return;
            }


            NastavnikUI.IspisiSveProfesore();
            Console.Write("Unesite ID profesora:");
            int idProfesora = IOPomocnaKlasa.OcitajCeoBroj();

            bool proveraProfesorID = NastavnikUI.ProveraID(idProfesora);

            if (!proveraProfesorID)
            {
                Console.WriteLine("Taj ID vec postoji!");
                return;
            }

            Predavanje predajaAdd = new Predavanje { ID = IOPomocnaKlasa.IDPredavanja, IDPredmeta = IDPredmeta, IDProfesora = idProfesora };

            listaPredavanja.Add(predajaAdd);

            string lokacija = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));
            SacuvajPodatke(lokacija + "data" + "\\" + "predaje.csv");
        }

        public static void IzmeniPredavanje()
        {
            Console.Write("Unesite ID predavanja kojeg zelite da izmenite:");
            int IDPredmeta = IOPomocnaKlasa.OcitajCeoBroj();

            bool provera = ProveriIDPredmeta(IDPredmeta);

            if (!provera)
            {
                Console.WriteLine("Taj ID ne postoji!");
                return;
            }

            Console.Write("Unesite novi ID predmeta:");
            int IDPredmetaEdit = IOPomocnaKlasa.OcitajCeoBroj();

            Console.Write("Unesite novi ID profesora:");
            int idProfesora = IOPomocnaKlasa.OcitajCeoBroj();

            Predavanje FindObject = listaPredavanja.Where(b => b.IDPredmeta == IDPredmeta).FirstOrDefault();

            int index = listaPredavanja.IndexOf(FindObject);

            Predavanje predajaEdit = new Predavanje { ID = FindObject.ID, IDPredmeta = IDPredmetaEdit, IDProfesora = idProfesora };

            listaPredavanja[index] = predajaEdit;

            string lokacija = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));
            SacuvajPodatke(lokacija + "data" + "\\" + "predaje.csv");
        }

        public static void IspisiSvaPredavanja()
        {
            foreach (Predavanje predavanje in listaPredavanja)
            {
                Nastavnik FoundNastavnik = NastavnikUI.listaProfesora.Where(x => x.ID == predavanje.IDProfesora).FirstOrDefault();
                Predmet FoundPredmet = PredmetUI.listaPredmeta.Where(x => x.ID == predavanje.IDPredmeta).FirstOrDefault();

                Console.WriteLine("Ime Profesora:" + FoundNastavnik.Ime + " Prezime profesora:" + FoundNastavnik.Prezime + " Predmet:" + FoundPredmet.Naziv);
            }
        }

        public static void IspisiOdredjenuPredaju()
        {
            int IDPredavanja;

            Console.Write("Unesite ID predavanja:");

            IDPredavanja = IOPomocnaKlasa.OcitajCeoBroj();

            foreach (Predavanje predaja in listaPredavanja)
            {
                if (IDPredavanja == predaja.ID)
                {
                    Console.WriteLine("Predaja pod ID-om:" + predaja.IDPredmeta + " predaje profesor pod ID-om:" + predaja.IDProfesora);
                }
            }
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
                    foreach (Predavanje predaja in listaPredavanja)
                    {
                        recorder.WriteLine(predaja.ToFileString());
                    }
                }
            }
            else
            {
                Console.WriteLine("Greska,datoteka ne postoji!!");
            }
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

