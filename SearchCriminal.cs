using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в картотеку!");
            Dossier dossier = new Dossier();
            dossier.Search();
        }
    }

    class Dossier
    {
        private List<Criminal> _criminals = new List<Criminal>();

        public Dossier()
        {
            Fill();
        }

        public void Fill()
        {
            _criminals.Add(new Criminal("Bob", "Mexican", 160, 70, false));
            _criminals.Add(new Criminal("Carl", "Albanian", 170, 80, false));
            _criminals.Add(new Criminal("John", "British", 180, 90, true));
            _criminals.Add(new Criminal("Sam", "Frenchman", 190, 100, true));
            _criminals.Add(new Criminal("Victor", "Italian", 200, 110, false));
        }

        public void Search()
        {
            Console.WriteLine("Рост");
            int growth; ;
            bool isNumber = Int32.TryParse(Console.ReadLine(), out growth);
            Console.WriteLine("Вес");
            int weight;
            isNumber = Int32.TryParse(Console.ReadLine(), out weight);
            Console.WriteLine("Национальность");
            string nationality = Console.ReadLine();

            var filteredArested2 = _criminals.Where(Criminal =>
   Criminal.Nationality == nationality &&
   Criminal.Weight == weight &&
   Criminal.Growth == growth &&
   Criminal.IsArested == false).Select(Criminal => Criminal.Name);

            foreach (var Criminal in filteredArested2)
            {
                Console.WriteLine(Criminal);
            }
        }
    }

    class Criminal
    {
        public Criminal(string name, string nationality, int growth, int weight, bool isArested)
        {
            Name = name;
            Nationality = nationality;
            Growth = growth;
            Weight = weight;
            IsArested = isArested;
        }

        public bool IsArested { get; private set; }
        public string Name { get; private set; }
        public string Nationality { get; private set; }
        public int Growth { get; private set; }
        public int Weight { get; private set; }
    }
}