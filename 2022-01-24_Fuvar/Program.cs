using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2022_01_24_Fuvar
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Fuvar> fuvarok = new List<Fuvar>();
            foreach (var sor in File.ReadAllLines("fuvar.csv").Skip(1))
            {
                fuvarok.Add(new Fuvar(sor));
            }
            Console.WriteLine($"3. feladat : {fuvarok.Count} fuvar");
            //4.
            double Bevétel = 0;
            int db = 0;
            foreach (var f in fuvarok)
            {
                if (f.TaxID == 6185)
                {
                    Bevétel += f.Viteldíj + f.Borravaló;
                    db++;
                }
                Console.WriteLine($"4.feladat: {db} fuvar alatt: {Bevétel}");
                
                //5.
                int bankkártyás = 0;
                int készpénz = 0;
                foreach (var d in fuvarok)
                {
                    if (d.FizetésMód == "bankkártyás")
                    {
                        bankkártyás++;
                    }
                    if (d.FizetésMód == "készpénz")
                    {
                        készpénz++;
                    }
                }
                Console.WriteLine($"Bankkártya: {bankkártyás} fuvar");
                
                //5.b
                Dictionary<string, int> stat = new Dictionary<string, int>();
                foreach (var d in fuvarok)
                {
                    if (stat.ContainsKey(d.FizetésMód))
                    {
                        stat[d.FizetésMód]++;
                    }
                    else
                    {
                        stat.Add(d.FizetésMód, 1);
                    }
                }
                Console.WriteLine($"5.feladat:");
                foreach (var s in stat)
                {
                    Console.WriteLine($"\t{s.Key}: {s.Value} fuvar");
                }
                //5.c
                Console.WriteLine($"5.feladat:");
                fuvarok
                    .GroupBy(x => x.FizetésMód)
                    .Select(g => new { fizetésimód = g.Key, db = g.Count() })
                    .ToList()
                    .ForEach(x => Console.WriteLine($"\t{x.fizetésimód}: {x.db} fuvar"));
                //6.
                double ÖsszMérföld = 0;

                foreach (var d in fuvarok)
                {
                    ÖsszMérföld += d.Távolság;
                }
                Console.WriteLine($"6. feladat: {ÖsszMérföld*1.6:0.00} km");


                Console.ReadKey();
            }
        }
    }
}
