using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CSharpLight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Platoon platoon = new Platoon();
            Console.WriteLine("Полная информация:");
            platoon.DisplayFullInformation();
            Console.WriteLine();
            Console.WriteLine("Выборка:");
            platoon.DisplayRequiredInformation();
        }
    }

    class Platoon
    {
        private List<Soldier> _soldiers = new List<Soldier>();

        public Platoon()
        {
            Fill();
        }

        private void Fill()
        {
            _soldiers.Add(new Soldier("Петров Л.А.", "Сержант", "Автомат", 18));
            _soldiers.Add(new Soldier("Сидоров В.Е.", "Ефрейтор", "Пулемет", 15));
            _soldiers.Add(new Soldier("Яковлев И.К.", "Сержант", "Винтовка", 30));
            _soldiers.Add(new Soldier("Антов И.О.", "Рядовой", "Штык-нож", 5));
            _soldiers.Add(new Soldier("Богданов В.К.", "Прапорщик", "Пистолет", 45));
            _soldiers.Add(new Soldier("Вовченко Ф.В.", "Старшина", "Автомат", 25));
            _soldiers.Add(new Soldier("Данченко Г.И.", "Лейтнант", "Револьвер", 55));
            _soldiers.Add(new Soldier("Зиновьев А.П.", "Полковник", "Пистолет", 175));
        }

        public void DisplayFullInformation()
        {
            foreach (var information in _soldiers)
            {
                Console.WriteLine($"{information.Name}\t {information.Rank}\t {information.Armament} \t {information.Time}");
            }
        }

        public void DisplayRequiredInformation()
        {
            var needInformatiom = from Soldier soldier in _soldiers select new { Name = soldier.Name, Rank = soldier.Rank };

            foreach (var information in needInformatiom)
            {
                Console.WriteLine($"{information.Name} \t {information.Rank}");
            }
        }
    }

    class Soldier
    {
        public string Name;
        public string Rank;
        public string Armament;
        public int Time;

        public Soldier(string name, string rank, string arnament, int soldiersTime)
        {
            Name = name;
            Rank = rank;
            Armament = arnament;
            Time = soldiersTime;
        }
    }
}