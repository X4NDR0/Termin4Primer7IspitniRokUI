using System;

namespace Termin4Primer7.Model
{
    public class Predaja
    {
        public Predaja()
        {

        }

        public Predaja(string podaci)
        {
            string[] nizPodataka = podaci.Split(',');
            if (nizPodataka.Length != 2)
            {
                Console.WriteLine("Greska prilikom citanja fajla!");
            }
            else
            {
                IDProfesora = Convert.ToInt32(nizPodataka[0]);
                IDPredaje = Convert.ToInt32(nizPodataka[1]);
            }
        }

        public string ToFileString()
        {
            string data = IDPredaje + " " + IDProfesora;
            return data;
        }

        public int IDProfesora;
        public int IDPredaje;
    }
}
