using Modul1Termin04.Primer7.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Termin4Primer7.Model;

namespace Termin4Primer7.UI
{
    class PredajeUI
    {
        public static List<Predaja> listaPredaja = new List<Predaja>();

        public static void TekstMenija()
        {
            Console.WriteLine("1.Dodaj predaju");
            Console.WriteLine("2.Izmeni predaju");
            Console.WriteLine("3.Ispisi sve predaje");
            Console.WriteLine("4.Ispisi odredjenu predaju");
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
                        DodajPredaju();
                        break;

                    case 2:
                        IzmeniPredaju();
                        break;

                    case 3:
                        IspisiSvePredaje();
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

        public static void DodajPredaju()
        {
            PredmetUI.IspisiSvePredmete();
            Console.Write("Unesite ID predmeta:");
            int IDPredmeta = IOPomocnaKlasa.OcitajCeoBroj();

            bool predmetProvera = ProveriIDPredmeta(IDPredmeta);

            if (!predmetProvera)
            {
                Console.WriteLine("Taj id ne postoji!");
                return;
            }


            NastavnikUI.IspisiSveProfesore();
            Console.Write("Unesite ID profesora:");
            int idProfesora = IOPomocnaKlasa.OcitajCeoBroj();

            bool profesorProvera = ProveriIDProfesora(idProfesora);

            if (!profesorProvera)
            {
                Console.WriteLine("Taj id ne postoji!");
                return;
            }


            ProveriIDProfesora(idProfesora);

            Predaja predajaAdd = new Predaja { IDPredmeta = IDPredmeta, IDProfesora = idProfesora };

            listaPredaja.Add(predajaAdd);

            string lokacija = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));
            SacuvajPodatke(lokacija + "data" + "\\" + "predaje.csv");
        }

        public static void IzmeniPredaju()
        {
            Console.Write("Unesite ID predaje koju zelite da izmenite:");
            int IDPredmeta = IOPomocnaKlasa.OcitajCeoBroj();

            Console.Write("Unesite novi ID predaje:");
            int IDPredmetaEdit = IOPomocnaKlasa.OcitajCeoBroj();

            Console.Write("Unesite novi ID profesora:");
            int idProfesora = IOPomocnaKlasa.OcitajCeoBroj();

            Predaja FindObject = listaPredaja.Where(b => b.IDPredmeta == IDPredmeta).FirstOrDefault();

            int index = listaPredaja.IndexOf(FindObject);

            Predaja predajaEdit = new Predaja { IDPredmeta = IDPredmeta, IDProfesora = idProfesora };

            listaPredaja[index] = predajaEdit;

            string lokacija = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));
            SacuvajPodatke(lokacija + "data" + "\\" + "predaje.csv");
        }

        public static void IspisiSvePredaje()
        {
            foreach (Predaja predaja in listaPredaja)
            {
                Nastavnik FoundNastavnik = NastavnikUI.listaProfesora.Where(x => x.ID == predaja.IDProfesora).FirstOrDefault();
                Predmet FoundPredmet = PredmetUI.listaPredmeta.Where(x => x.ID == predaja.IDPredmeta).FirstOrDefault();

                Console.WriteLine("Ime Profesora:" + FoundNastavnik.Ime + " Prezime profesora:" + FoundNastavnik.Prezime + " Predmet:" + FoundPredmet.Naziv);
            }
        }

        public static void IspisiOdredjenuPredaju()
        {
            int IDPredmeta;

            Console.Write("Unesite ID predaje:");

            IDPredmeta = IOPomocnaKlasa.OcitajCeoBroj();

            foreach (Predaja predaja in listaPredaja)
            {
                if (IDPredmeta == predaja.IDPredmeta)
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
                        listaPredaja.Add(new Predaja(line));
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
                    foreach (Predaja predaja in listaPredaja)
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

        public static bool ProveriIDProfesora(int idProfesora)
        {
            foreach (Nastavnik nastavnik in NastavnikUI.listaProfesora)
            {
                if (nastavnik.ID == idProfesora)
                {
                    return true;
                }
            }
            return false;
        }

    }
}

