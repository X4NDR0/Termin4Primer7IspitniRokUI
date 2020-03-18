using Modul1Termin04.Primer7.Utils;
using System;

namespace Termin4Primer7.Model
{
    /// <summary>
    /// Representing class of the Predavanje
    /// </summary>
    public class Predavanje
    {
        /// <summary>
        /// Empty Constructor of the class
        /// </summary>
        public Predavanje()
        {

        }

        /// <summary>
        /// Class constructor with parametar(string)
        /// </summary>
        public Predavanje(string podaci)
        {
            string[] nizPodataka = podaci.Split(',');
            if (nizPodataka.Length != 2)
            {
                Console.WriteLine("Greska prilikom citanja fajla!");
            }
            else
            {
                ID = IOPomocnaKlasa.IDPredavanja++;
                IDProfesora = Convert.ToInt32(nizPodataka[0]);
                IDPredmeta = Convert.ToInt32(nizPodataka[1]);
            }
        }
        /// <summary>
        /// Property representing ID of the Predavanja
        /// </summary>
        public int ID;

        /// <summary>
        /// Property representing ID of the Profesor
        /// </summary>
        public int IDProfesora;

        /// <summary>
        /// Property representing ID of the Predmet
        /// </summary>
        public int IDPredmeta;

        /// <summary>
        /// Method used to put together IDPredmeta and IDProfesora into a one string
        /// </summary>
        public string ToFileString()
        {
            string data = IDPredmeta + "," + IDProfesora;
            return data;
        }
    }
}
