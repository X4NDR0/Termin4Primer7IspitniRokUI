using System;
using System.IO;
using Termin4Primer7.UI;

namespace Termin4Primer7
{
    class Program
    {
        private static readonly string IsprDat = "ispitni_rokovi.csv";
        private static char sep = Path.DirectorySeparatorChar;
        private static string putanjaDataDirRelease = "C:\\Users\\XANDRO\\source\\repos\\Termin4Primer7\\Termin4Primer7\\bin\\Debug\\netcoreapp3.1\\";
        static void Main(string[] args)
        {
            IspitniRokUI.UcitajIspitneRokoveIzDatoteke(putanjaDataDirRelease + IsprDat);
            IspitniRokUI.MeniIspitniRok();
        }
    }
}