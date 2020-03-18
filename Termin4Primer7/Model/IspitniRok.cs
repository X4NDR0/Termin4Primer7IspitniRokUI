using System;

namespace Modul1Termin04.Primer7.Model
{
    /// <summary>
    /// Class of the ispitni rok
    /// </summary>
    class IspitniRok
    {
        /// <summary>
        /// Empty Constructor of the class
        /// </summary>
        public IspitniRok()
        {

        }

        /// <summary>
        /// Class constructor with parametar(string)
        /// </summary>
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
        /// <summary>
        /// Property representing id of the ispitni rok
        /// </summary>
        public int ID;

        /// <summary>
        /// Property representing name of the ispitni rok
        /// </summary>
        public string Naziv;

        /// <summary>
        /// Property representing start of the ispitni rok
        /// </summary>
        public DateTime Pocetak;

        /// <summary>
        /// Property representing end of the ispitni rok
        /// </summary>
        public DateTime Kraj;

        /// <summary>
        /// Method which put together(ID,Naziv,Pocetak,Kraj) into one string
        /// </summary>
        /// <returns></returns>
        public string ToFileString()
        {
            string podaci = ID + "," + Naziv + "," + Pocetak.ToString("yyyy/MM/dd") + "," + Kraj.ToString("yyyy/MM/dd");
            return podaci;
        }
    }
}
