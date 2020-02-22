using System;
using System.IO;
using System.Reflection;
using Termin4Primer7.UI;

namespace Termin4Primer7
{
    class Programs
    {
        private static readonly string IsprDat = "ispitni_rokovi.csv";
        private static readonly string NastavnikDat = "nastavnici.csv";
        private static char sep = Path.DirectorySeparatorChar;
        private static string putanjaDataDirRelease = "data";
        static void Main(string[] args)
        {
            AplikacijaUI ap = new AplikacijaUI();
            ap.Application();
            IspitniRokUI.UcitajIspitneRokoveIzDatoteke(putanjaDataDirRelease + sep + IsprDat);
            IspitniRokUI.MeniIspitniRok();
        }
    }
}