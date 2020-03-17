using System;

namespace Termin4Primer7.Model
{
    class Predmet
    {
        public Predmet()
        {

        }

        public Predmet(string data)
        {
            string[] niz = data.Split(',');

            if (niz.Length != 3)
            {
                Console.WriteLine("Error,while reading file!");
            }
            else
            {
                ID = Convert.ToInt32(niz[0]);
                Indeks = niz[1];
                Naziv = niz[2];
            }
        }

        public int ID;
        public string Indeks;
        public string Naziv;

        public string FileString()
        {
            string data = ID + "," + Indeks + "," + Naziv;
            return data;
        }
    }
}
