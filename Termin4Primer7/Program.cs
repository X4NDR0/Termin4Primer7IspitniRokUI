using System;
using System.IO;
using Termin4Primer7.UI;

namespace Termin4Primer7
{
    class Programs
    {
        private static readonly string IsprDat = "ispitni_rokovi.csv";
        private static readonly string NastavnikDat = "nastavnici.csv";
        private static char sep = Path.DirectorySeparatorChar;
        private static string putanjaDataDirRelease = Directory.GetCurrentDirectory() + "\\";
        static void Main(string[] args)
        {
            Console.WriteLine(putanjaDataDirRelease);
            IspitniRokUI.UcitajIspitneRokoveIzDatoteke(putanjaDataDirRelease + IsprDat);
            IspitniRokUI.MeniIspitniRok();
        }
    }
}