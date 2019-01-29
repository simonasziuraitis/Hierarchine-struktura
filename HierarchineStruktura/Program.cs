using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchineStruktura
{
    class Program
    {
        static void Main(string[] args)
        {
            HierarchineStrukura medis = new HierarchineStrukura();

            //Mano struktura
            medis.pagrindas = new Susikirtimas(3);
            medis.pagrindas.kaire = new Susikirtimas(2);
            medis.pagrindas.desine = new Susikirtimas(5);
            medis.pagrindas.kaire.kaire = new Susikirtimas(1);
            medis.pagrindas.kaire.desine = new Susikirtimas(4);

            //Suranda visu reiksmiu lygius

            int giliausiasLygis = 0;

            for (int x = 1; x <= 5; x++)
            {
                int level = medis.RastiLygi(medis.pagrindas, x);
                if (level != 0)
                {
                    Console.WriteLine("Reiksmes " + x + " lygis yra " + medis.RastiLygi(medis.pagrindas, x));
                    if (medis.RastiLygi(medis.pagrindas, x)>giliausiasLygis)
                    {
                        giliausiasLygis = medis.RastiLygi(medis.pagrindas, x);
                    }
                }
                else
                {
                    Console.WriteLine(x + " reiksmes nera hierarchineje strukturoje");
                }
            }

            Console.WriteLine("Giliausias hierarchines strukturos lygys yra: " + giliausiasLygis);
            Console.ReadLine();
        }

        //Hierarchine struktura
        public class Susikirtimas
        {
            public int reiksme;
            public Susikirtimas kaire, desine;

            public Susikirtimas(int d)
            {
                reiksme = d;
                kaire = desine = null;
            }
        }

        public class HierarchineStrukura
        {

            public Susikirtimas pagrindas;

            //Jeigu reiksme egzistuoja hierarchineje strukturoje grazinama lygi, jei ne grazinamas 0
            public virtual int RastiLygiKaiReiksmeEgzistuoja(Susikirtimas susikirtimas, int reiksme, int lygis)
            {
                if (susikirtimas == null)
                {
                    return 0;
                }

                if (susikirtimas.reiksme == reiksme)
                {
                    return lygis;
                }

                int kitasLygis = RastiLygiKaiReiksmeEgzistuoja(susikirtimas.kaire, reiksme, lygis + 1);
                if (kitasLygis != 0)
                {
                    return kitasLygis;
                }

                kitasLygis = RastiLygiKaiReiksmeEgzistuoja(susikirtimas.desine, reiksme, lygis + 1);
                return kitasLygis;
            }
            //Grazina reiksmes lygi
            public virtual int RastiLygi(Susikirtimas node, int reiksme)
            {
                return RastiLygiKaiReiksmeEgzistuoja(node, reiksme, 1);
            }
        }
    }
}

