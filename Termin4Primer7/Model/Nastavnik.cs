using System;
using System.Collections.Generic;
using System.Text;

namespace Termin4Primer7.Model
{
    class Nastavnik
    {
        public Nastavnik()
        {

        }

        public Nastavnik(string data)
        {
            string[] nizPodataka = data.Split(',');

            if (nizPodataka.Length != 4)
            {
                Console.WriteLine("Error while file reading!");
            }
            else
            {
                ID = Convert.ToInt32(nizPodataka[0]);
                Ime = nizPodataka[1];
                Prezime = nizPodataka[2];
                Posao = nizPodataka[3];
            }
        }

        public string ToFileString()
        {
            string podaci = ID + " " + Ime + " " + Prezime + " " + Posao;
            return podaci;
        }

        public int ID;
        public string Ime;
        public string Prezime;
        public string Posao;
    }
}
