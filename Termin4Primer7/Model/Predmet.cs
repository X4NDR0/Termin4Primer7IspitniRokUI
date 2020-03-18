using System;

namespace Termin4Primer7.Model
{
    /// <summary>
    /// Class of the predmet
    /// </summary>
    class Predmet
    {
        /// <summary>
        /// Empty Constructor of the class
        /// </summary>
        public Predmet()
        {

        }

        /// <summary>
        /// Class constructor with parametar(string)
        /// </summary>
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

        /// <summary>
        /// Property representing id of the predmet
        /// </summary>
        public int ID;

        /// <summary>
        /// Property representing index of the predmet
        /// </summary>
        public string Indeks;

        /// <summary>
        /// Property representing name of the predmet
        /// </summary>
        public string Naziv;

        /// <summary>
        /// Method which put together(ID,Index,Naziv) into a one string
        /// </summary>
        /// <returns></returns>
        public string FileString()
        {
            string data = ID + "," + Indeks + "," + Naziv;
            return data;
        }
    }
}
