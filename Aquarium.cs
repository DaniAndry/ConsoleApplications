using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Concurrent;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddFish = "1";
            const string CommandRemoveFish = "2";
            const string CommandExitProgramm = "3";

            Aquarium aquarium = new Aquarium();
            bool isOpen = true;

            while (isOpen)
            {
                Console.WriteLine($"��� ����������� ����� � �������� ������� {CommandAddFish}.\n" +
                    $"��� �������� ����� �� ��������� ������� {CommandRemoveFish}\n" +
                    $"��� ������ �� ��������� ������� {CommandExitProgramm}");
                Console.WriteLine("� ���������: ");
                aquarium.ShowFishes();
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddFish:
                        aquarium.AddFish();
                        break;

                    case CommandRemoveFish:
                        aquarium.TryRemoveFish();
                        break;

                    case CommandExitProgramm:
                        isOpen = false;
                        break;

                    default:
                        Console.WriteLine("����� ������� ���.");
                        break;
                }

                aquarium.Live();
                Console.Clear();
            }
        }
    }

    class Aquarium
    {
        private List<Fish> _fishes = new List<Fish>();
        private int _maxFishCount = 16;
        private Random _random = new Random();

        public Aquarium()
        {
            Fill();
        }

        public void AddFish()
        {
            Fish[] kindOfFishes = Create();
            Console.Clear();
            int userInputNumber;

            if (_fishes.Count == _maxFishCount)
            {
                Console.WriteLine("������� �����.");
            }
            else
            {
                Console.WriteLine("�������� ����, ������� ����� ��������� �������������.");

                ShowFish(kindOfFishes.ToList());

                bool isNumber = Int32.TryParse(Console.ReadLine(), out userInputNumber);

                if (isNumber && userInputNumber <= kindOfFishes.Length && userInputNumber > 0)
                {
                    _fishes.Add(kindOfFishes[userInputNumber - 1]);
                }
                else
                {
                    Console.WriteLine("����� ����� ���.");
                }
            }
        }

        public void ShowFishes()
        {
            ShowFish(_fishes);
        }

        private void ShowFish(List<Fish> fish)
        {
            for (int i = 0; i < fish.Count; i++)
            {
                Console.Write(i + 1 + ". ");
                fish[i].ShowInfo();
            }
        }

        public bool TryRemoveFish()
        {
            int userInputNumber;
            Console.WriteLine("������� ����� �����:");
            bool isNumber = Int32.TryParse(Console.ReadLine(), out userInputNumber);

            if (isNumber == true && userInputNumber - 1 < _fishes.Count && userInputNumber > 0)
            {
                Fish fish = _fishes[userInputNumber - 1];
                _fishes.Remove(fish);
                Console.WriteLine($"�� ������� {fish.Name}");
                return true;
            }
            else
            {
                Console.WriteLine("����� ���� ���.");
                return false;
            }
        }

        public void Live()
        {
            for (int i = 0; i < _fishes.Count; i++)
            {
                _fishes[i].Live();
            }
        }

        private void Fill()
        {
            Fish[] fishes = Create();
            int fishCount = 10;

            for (int i = 0; i < fishCount; i++)
            {
                _fishes.Add(fishes[_random.Next(0, fishes.Length)]);
            }
        }

        private Fish[] Create()
        {
            Fish[] fishes = new Fish[] { new Guppy(), new Molliesia(), new GoldFish(), new CatFish() };
            return fishes;
        }
    }

    class Fish
    {
        private static Random _random = new Random();

        public Fish()
        {
            int minimumAge = 1;
            int maximumAge = 5;
            Age = _random.Next(minimumAge, maximumAge);
        }

        public string Name { get; protected set; }
        public int Age { get; private set; }
        public int MaxAge { get; protected set; }

        public void Live()
        {
            Age++;

            if (Age >= MaxAge)
            {
                Name = "�������";
                Age = MaxAge;
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} ��������� {Age}");
        }
    }

    class Guppy : Fish
    {
        public Guppy()
        {
            Name = "�����";
            MaxAge = 11;
        }
    }

    class GoldFish : Fish
    {
        public GoldFish()
        {
            Name = "������� �����";
            MaxAge = 8;
        }
    }

    class Molliesia : Fish
    {
        public Molliesia()
        {
            Name = "����������";
            MaxAge = 9;
        }
    }

    class CatFish : Fish
    {
        public CatFish()
        {
            Name = "���";
            MaxAge = 22;
        }
    }
}