using Modul1Termin04.Primer7.Utils;
using System;
using System.IO;
using System.Linq;

namespace Termin4Primer7.UI
{
    /// <summary>
    /// Class of the Aplikacija UI
    /// </summary>
    public class AplikacijaUI
    {
        /// <summary>
        /// Representing method for writting text for menu
        /// </summary>
        public void MeniTekst()
        {
            Console.WriteLine("1.Ispitni Rokovi");
            Console.WriteLine("2.Profesori");
            Console.WriteLine("3.Predmeti");
            Console.WriteLine("4.Predaje");
            Console.WriteLine("0.Exit");
            Console.Write("Opcije:");
        }
        /// <summary>
        /// This method representing menu
        /// </summary>
        public void Application()
        {
            string lokacija = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));
            IspitniRokUI.UcitajIspitneRokoveIzDatoteke(lokacija + "data" + "\\" + "ispitni_rokovi.csv");
            IOPomocnaKlasa.IDispitnogRoka = IspitniRokUI.listaIspitnihRokova.Max(x => x.ID);

            NastavnikUI.UcitajPodatke(lokacija + "data" + "\\" + "nastavnici.csv");
            IOPomocnaKlasa.IDProfesora = NastavnikUI.listaProfesora.Max(x => x.ID);

            PredavanjeUI.UcitajPodatke(lokacija + "data" + "\\" + "predaje.csv");

            PredmetUI.UcitajPodatke(lokacija + "data" + "\\" + "predmeti.csv");
            IOPomocnaKlasa.IDPredmeta = PredmetUI.listaPredmeta.Max(x => x.ID);

            int izabir;

            do
            {
                MeniTekst();
                izabir = IOPomocnaKlasa.OcitajCeoBroj();

                switch (izabir)
                {
                    case 1:
                        Console.Clear();
                        IspitniRokUI.MeniIspitniRok();
                        break;

                    case 2:
                        Console.Clear();
                        NastavnikUI.MeniProfesora();
                        break;

                    case 3:
                        Console.Clear();
                        PredmetUI.MenuPredmet();
                        break;

                    case 4:
                        Console.Clear();
                        PredavanjeUI.MeniPredaja();
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
