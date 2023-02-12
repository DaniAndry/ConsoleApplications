using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Terminal terminal = new Terminal();
            terminal.Work();
        }
    }

    class Terminal
    {
        private const ConsoleKey CommandEnter = ConsoleKey.Enter;
        private List<Train> _trains = new List<Train>();
        private Random _random = new Random();

        public void Work()
        {
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"��� �������� �������� ������� {CommandEnter}");
                EnterToContinue();
                Directon directon = new Directon();
                Console.WriteLine($"��� ������� ������� ������� {CommandEnter}");
                EnterToContinue();
                SendTrain(directon.CityArrival, directon.CityDeparture);
                Console.WriteLine($"��� ������� ������ ������� {CommandEnter}");
                EnterToContinue();
                ShowSendsTrains();
            }
        }

        public void ShowInfo(Train train)
        {
            Console.WriteLine($"����� {train.CityArrival} - {train.CityDeparture} � {train.CountCarriages} ��������");
        }

        private void EnterToContinue()
        {
            bool isWork = true;

            while (isWork)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();

                if (userInput.Key == CommandEnter)
                {
                    return;
                }
                else
                {
                    Console.WriteLine($"����� ������� ���");
                }
            }
        }

        private int SellTickets(int passengers)
        {
            int minPassengers = 70;
            int maxPassengers = 550;
            passengers = _random.Next(minPassengers, maxPassengers);
            return passengers;
        }

        private void ShowPassengersInfo(Train train)
        {
            Console.WriteLine($"�� ������ ����������� {train.Passengers} ���������� ��������� ������," +
     $"  ������� {ConsoleKey.Enter} ����� ������������ �����");
        }

        private void SendTrain(string cityArrival, string cityDeparture)
        {
            int passengers = 0;
            passengers = SellTickets(passengers);
            Train train = new Train(passengers, cityArrival, cityDeparture);
            _trains.Add(train);
            ShowPassengersInfo(train);
        }

        private void ShowSendsTrains()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("������������ ������:\n");

            for (int i = 0; i < _trains.Count; i++)
            {
                ShowInfo(_trains[i]);
            }

            Console.WriteLine();
        }
    }

    class Train
    {
        private Carriage _carriage = new Carriage();
        public int Passengers { get; private set; }
        public int CountCarriages { get; private set; }
        public string CityArrival { get; private set; }
        public string CityDeparture { get; private set; }

        public Train(int passengers, string cityArrival, string cityDeparture)
        {
            Passengers = passengers;
            CityArrival = cityArrival;
            CityDeparture = cityDeparture;
            CountCarriages = CreateCarriages(Passengers);
        }

        private int CreateCarriages(int passengers)
        {
            int needCountCarriage = passengers / _carriage.MaxPlace;

            if (passengers % _carriage.MaxPlace != 0)
            {
                needCountCarriage++;
            }

            return needCountCarriage;
        }
    }

    class Directon
    {
        public string CityDeparture { get; private set; }
        public string CityArrival { get; private set; }

        public Directon()
        {
            Select();
        }

        private void Select()
        {
            string[] cities = { "�����", "������", "������������", "�����������", "�����������" };
            Random random = new Random();

            while (CityArrival == CityDeparture)
            {
                int cityIndex = random.Next(cities.Length);
                int cityIndex2 = random.Next(cities.Length);
                CityArrival = cities[cityIndex];
                CityDeparture = cities[cityIndex2];
            }

            Console.WriteLine($"����������� ������ {CityArrival} - {CityDeparture}");
        }
    }

    class Carriage
    {
        public int MaxPlace { get; private set; } = 38;
    }
}