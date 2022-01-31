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
                foreach (var h in fuvarok)
                {
                    if (h.FizetésMód == "bankkártyás")
                    {
                        bankkártyás++;
                    }
                    if (h.FizetésMód == "készpénz")
                    {
                        készpénz++;
                    }
                }
                
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


                Console.ReadKey();
            }
        }
    }
}
