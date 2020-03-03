using Modul1Termin04.Primer7.Utils;
using System;
using System.IO;

namespace Termin4Primer7.UI
{
    public class AplikacijaUI
    {
        public void MeniTekst()
        {
            Console.WriteLine("1.Ispitni Rokovi");
            Console.WriteLine("2.Profesori");
            Console.WriteLine("3.Predmeti");
            Console.WriteLine("4.Predaje");
            Console.WriteLine("0.Exit");
            Console.Write("Opcije:");
        }
        public void Application()
        {
            string lokacija = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(),@"..\..\..\"));
            IspitniRokUI.UcitajIspitneRokoveIzDatoteke(lokacija + "data" + "\\" + "ispitni_rokovi.csv");
            NastavnikUI.UcitajPodatke(lokacija + "data" + "\\" + "nastavnici.csv");
            PredajeUI.UcitajPodatke(lokacija + "data" + "\\" + "predaje.csv");
            PredmetUI.UcitajPodatke(lokacija + "data" + "\\" + "predmeti.csv");


            int izabir;

            do
            {
                MeniTekst();
                izabir = IOPomocnaKlasa.OcitajCeoBroj();

                switch (izabir)
                {
                    case 1:
                        IspitniRokUI.MeniIspitniRok();
                        break;

                    case 2:
                        NastavnikUI.MeniProfesora();
                        break;

                    case 3:
                        PredmetUI.MenuPredmet();
                        break;

                    case 4:
                        PredajeUI.MeniPredaja();
                        break;

                    case 0:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Opcija ne postoji!");
                        break;
                }
            } while (izabir != 0);
        }
    }
}
