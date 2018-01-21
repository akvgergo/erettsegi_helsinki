using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using helsinki1952.Properties;
using System.Diagnostics;

namespace helsinki1952 {
    class helsinki1952 {
        static void Main(string[] args) {
            string forrás = Resources.Forrás;
            List<Helyezés> helyezések = new List<Helyezés>(200);

            //2
            foreach (var item in forrás.Split('\n')) {
                var hely = new Helyezés();
                var vals = item.Split(' ');
                hely.ElértHely = int.Parse(vals[0]);
                hely.CsapatLétszám = int.Parse(vals[1]);
                hely.Sportág = vals[2];
                hely.Versenyszám = vals[3];
                helyezések.Add(hely);
            }

            //3
            Console.WriteLine("3. Feladat:");
            Console.WriteLine("Pontszerző helyezések száma: {0}",helyezések.Count);

            //4
            Console.WriteLine("4. Feladat:");
            Console.WriteLine("Arany: {0}", helyezések.Count(h => h.ElértHely == 1));
            Console.WriteLine("Ezüst: {0}", helyezések.Count(h => h.ElértHely == 2));
            Console.WriteLine("Bronz: {0}", helyezések.Count(h => h.ElértHely == 3));
            Console.WriteLine("Összesen: {0}", helyezések.Count(h => h.ElértHely <= 3));

            //5
            Console.WriteLine("5. Feladat:");
            Console.WriteLine("Olimpiai pontok száma: {0}", helyezések.Select(h => h.ElértHely == 1 ? 7 : 7 - h.ElértHely).Sum());

            //6
            Console.WriteLine("6. Feladta:");
            int torna = helyezések.Count(h => h.ElértHely <= 3 && h.Sportág == "torna");
            int uszas = helyezések.Count(h => h.ElértHely <= 3 && h.Sportág == "uszás");
            if (torna > uszas) {
                Console.WriteLine("Torna sportágban szereztek több érmet");
            } else if (uszas > torna) {
                Console.WriteLine("Úszás sportágban szereztek több érmet");
            } else {
                Console.WriteLine("Egyenlő volt az érmek száma");
            }

            //7
            string newFile = "";
            foreach (var item in helyezések) {
                newFile += item.ElértHely + " ";
                newFile += item.CsapatLétszám + " ";
                newFile += (item.ElértHely == 1 ? 7 : 7 - item.ElértHely) + " ";
                newFile += item.Sportág == "kajakkenu" ? "kajak-kenu" : item.Sportág;
                newFile +=  " " + item.Versenyszám;
                newFile += "\n";
            }
            File.WriteAllText("helsinki2.txt", newFile);


            //8
            Console.WriteLine("8. Feladat:");
            var legtöbbSportoló = helyezések.OrderByDescending(h => h.CsapatLétszám).First();
            Console.WriteLine("Helyezés: {0}", legtöbbSportoló.ElértHely);
            Console.WriteLine("Sportág: {0}", legtöbbSportoló.Sportág);
            Console.WriteLine("Versenyszám: {0}", legtöbbSportoló.Versenyszám);
            Console.WriteLine("Sportolók száma: {0}", legtöbbSportoló.CsapatLétszám);
            
            Console.ReadKey();
        }

        public class Helyezés {
            public int ElértHely;
            public int CsapatLétszám;
            public string Sportág;
            public string Versenyszám;
        }
    }
}
