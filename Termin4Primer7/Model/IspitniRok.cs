using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul1Termin04.Primer7.Model
{
    class IspitniRok
    {
        public IspitniRok()
        {

        }
        public IspitniRok(string text)
        {
            string[] splitter = text.Split(',');
            if (splitter.Length != 4)
            {
                Console.WriteLine("Error while reading the file!");
            }
            else
            {
                ID = Convert.ToInt32(splitter[0]);
                Naziv = splitter[1];
                Pocetak = DateTime.Parse(splitter[2]);
                Kraj = DateTime.Parse(splitter[3]);
            }
        }

        public string ToFileString()
        {
            string podaci = ID + "," + Naziv + "," + Pocetak.ToString("yyyy/MM/dd") + "," + Kraj.ToString("yyyy/MM/dd");
            return podaci;
        }

        public int ID;
        public string Naziv;
        public DateTime Pocetak;
        public DateTime Kraj;
    }
}
