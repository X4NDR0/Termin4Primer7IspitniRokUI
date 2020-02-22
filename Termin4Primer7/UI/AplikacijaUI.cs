using System;
using System.Collections.Generic;
using System.Text;
using Modul1Termin04.Primer7.Utils;

namespace Termin4Primer7.UI
{
    public class AplikacijaUI
    {
        public void MeniTekst()
        {
            Console.WriteLine("1.Ispitni Rokovi");
            Console.WriteLine("2.Profesori");
            Console.WriteLine("3.Predaje");
            Console.WriteLine("0.Exit");
        }
        public void Application()
        {
            int izabir;

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
                    
                    break;

                case 0:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opcija ne postoji!");
                    break;
            }
        }
    }
}
