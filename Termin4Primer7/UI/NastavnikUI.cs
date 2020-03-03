﻿using Modul1Termin04.Primer7.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Termin4Primer7.Model;

namespace Termin4Primer7.UI
{
    class NastavnikUI
    {
        public static List<Nastavnik> listaProfesora = new List<Nastavnik>();
        public static void IspisiTextMenija()
        {
            Console.WriteLine("1.Dodaj profesora");
            Console.WriteLine("2.Izmeni profesora");
            Console.WriteLine("3.Ispisi sve profesore");
            Console.WriteLine("4.Ispisi odredjenog profesora");
            Console.WriteLine("0.Nazad");
            Console.Write("Opcija:");
        }
        public static void MeniProfesora()
        {
            int izabir;

            do
            {
                IspisiTextMenija();
                izabir = Convert.ToInt32(Console.ReadLine());
                switch (izabir)
                {
                    case 1:
                        DodajProfesora();
                        break;

                    case 2:
                        IzmeniProfesora();
                        break;

                    case 3:
                        IspisiSveProfesore();
                        break;

                    case 4:
                        IspisiOdredjenogProfesora();
                        break;

                    case 0:

                        break;

                    default:
                        Console.WriteLine("Opcija ne postoji!");
                        break;
                }
            } while (izabir != 0);
        }

        public static void DodajProfesora()
        {
            Console.Write("Unesite ID:");
            int addID = IOPomocnaKlasa.OcitajCeoBroj();

            Console.Write("Unesite ime:");
            string addName = IOPomocnaKlasa.OcitajTekst();

            Console.Write("Unesite prezime:");
            string addLastName = IOPomocnaKlasa.OcitajTekst();

            Console.Write("Unesite posao:");
            string addPosao = IOPomocnaKlasa.OcitajTekst();

            Nastavnik addNastavnik = new Nastavnik { ID = addID, Ime = addName, Prezime = addLastName, Posao = addPosao };

            listaProfesora.Add(addNastavnik);

            string destinacija = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));
            SacuvajPodatke(destinacija + "data" + "\\" + "nastavnici.csv");

            Console.WriteLine("Profesor je uspesno dodat u bazu podataka!");
        }

        public static void IzmeniProfesora()
        {
            Console.Write("Unesite ID profesora kojeg zelite da izmenite:");
            int editID = IOPomocnaKlasa.OcitajCeoBroj();

            Console.Write("Unesite novi ID:");
            int noviID = IOPomocnaKlasa.OcitajCeoBroj();

            Console.Write("Unesite novo ime:");
            string novoIme = IOPomocnaKlasa.OcitajTekst();

            Console.Write("Unesite novo prezime:");
            string novoPrezime = IOPomocnaKlasa.OcitajTekst();

            Console.Write("Unesite novi posao:");
            string noviPosao = IOPomocnaKlasa.OcitajTekst();

            Nastavnik editNastavnik = new Nastavnik { ID = noviID, Ime = novoIme, Prezime = novoPrezime, Posao = noviPosao };

            Nastavnik checkIndex = listaProfesora.Where(x => x.ID == editID).FirstOrDefault();

            int index = listaProfesora.IndexOf(checkIndex);

            string destinacija = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));
            SacuvajPodatke(destinacija + "data" + "nastavnici.csv");

            listaProfesora[index] = editNastavnik;
        }

        public static void IspisiSveProfesore()
        {
            foreach (Nastavnik nastavnik in listaProfesora)
            {
                Console.WriteLine(nastavnik.ID + " " + nastavnik.Ime + " " + nastavnik.Prezime + " " + nastavnik.Prezime);
            }
        }

        public static void IspisiOdredjenogProfesora()
        {
            Console.WriteLine("Unesite ID profesora kojeg zelite da ispisete:");
            int proveraID = IOPomocnaKlasa.OcitajCeoBroj();

            foreach (Nastavnik nastavnik in listaProfesora)
            {
                if (nastavnik.ID == proveraID)
                {
                    Console.WriteLine(nastavnik.ID + " " + nastavnik.Ime + " " + nastavnik.Prezime + " " + nastavnik.Prezime);
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
                        listaProfesora.Add(new Nastavnik(line));
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
                    foreach (Nastavnik ispitniRok in listaProfesora)
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
