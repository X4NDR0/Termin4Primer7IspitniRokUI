using System;

namespace Termin4Primer7.Model
{
    public class Predavanje
    {
        public Predavanje()
        {

        }

        public Predavanje(string podaci)
        {
            string[] nizPodataka = podaci.Split(',');
            if (nizPodataka.Length != 2)
            {
                Console.WriteLine("Greska prilikom citanja fajla!");
            }
            else
            {
                IDProfesora = Convert.ToInt32(nizPodataka[0]);
                IDPredmeta = Convert.ToInt32(nizPodataka[1]);
            }
        }

        public string ToFileString()
        {
            string data = IDPredmeta + "," + IDProfesora;
            return data;
        }

        public int ID;
        public int IDProfesora;
        public int IDPredmeta;
    }
}
