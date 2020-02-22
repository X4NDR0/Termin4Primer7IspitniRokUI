using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Modul1Termin04.Primer7.Utils;
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
            Console.WriteLine("0.Exit");
            Console.Write("Opcija:");
        }

        public static void MeniPredaja()
        {
            TekstMenija();
            int izabir = IOPomocnaKlasa.OcitajCeoBroj();

            switch (izabir)
            {
                case 1:
                    DodajPredaju();
                    break;

                case 2:

                    break;

                case 3:
                    IspisiSvePredaje();
                    break;

                case 4:
                    IspisiOdredjenuPredaju();
                    break;

                case 0:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Izabrana opcija ne postoji!");
                    break;
            }
        }

        public static void DodajPredaju()
        {
            Console.Write("Unesite ID predaje:");
            int idPredaje = IOPomocnaKlasa.OcitajCeoBroj();

            Console.Write("Unesite ID profesora:");
            int idProfesora = IOPomocnaKlasa.OcitajCeoBroj();

            Predaja predajaAdd = new Predaja { IDPredaje = idPredaje,IDProfesora= idProfesora};

            listaPredaja.Add(predajaAdd);
        }

        public static void IzmeniPredaju()
        {
            Console.Write("Unesite ID predaje koju zelite da izmenite:");
            int idPredaje = IOPomocnaKlasa.OcitajCeoBroj();

            Console.Write("Unesite novi ID predaje:");
            int idPredajeEdit = IOPomocnaKlasa.OcitajCeoBroj();

            Console.Write("Unesite novi ID profesora:");
            int idProfesora = IOPomocnaKlasa.OcitajCeoBroj();

            Predaja FindObject = listaPredaja.Where(b => b.IDPredaje == idPredaje).FirstOrDefault();

            int index = listaPredaja.IndexOf(FindObject);

            Predaja predajaEdit = new Predaja { IDPredaje = idPredaje, IDProfesora = idProfesora };

            listaPredaja[index] = predajaEdit;
        }

        public static void IspisiSvePredaje()
        {
            foreach (Predaja predaja in listaPredaja)
            {
                Console.WriteLine("ID Profesora:" + predaja.IDProfesora + "        " + "ID Predaje:" + predaja.IDPredaje);
            }
        }

        public static void IspisiOdredjenuPredaju()
        {
            int idPredaje;

            Console.Write("Unesite ID predaje:");

            idPredaje = IOPomocnaKlasa.OcitajCeoBroj();

            foreach (Predaja predaja in listaPredaja)
            {
                if (idPredaje == predaja.IDPredaje)
                {
                    Console.WriteLine("Predaja pod ID-om:" + predaja.IDPredaje + " predaje profesor pod ID-om:" + predaja.IDProfesora);
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

    }
}
