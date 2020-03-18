using System;

namespace Termin4Primer7.Model
{
    /// <summary>
    /// Class of the Nastavnik
    /// </summary>
    class Nastavnik
    {
        /// <summary>
        /// Empty Constructor of the class
        /// </summary>
        public Nastavnik()
        {

        }

        /// <summary>
        /// Class constructor with parametar(string)
        /// </summary>
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

        /// <summary>
        /// Property representing id of the profesor
        /// </summary>
        public int ID;

        /// <summary>
        /// Property representing name of the profesor
        /// </summary>
        public string Ime;

        /// <summary>
        /// Property representing lastname of the profesor
        /// </summary>
        public string Prezime;

        /// <summary>
        /// Property representing posao of the profesor
        /// </summary>
        public string Posao;

        /// <summary>
        /// Method which put togher(ID,Ime,Prezime,Posao) into a one string
        /// </summary>
        public string ToFileString()
        {
            string podaci = ID + "," + Ime + "," + Prezime + "," + Posao;
            return podaci;
        }
    }
}
