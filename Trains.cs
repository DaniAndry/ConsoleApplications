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
                Console.WriteLine($"Для создания маршрута нажмите {CommandEnter}");
                EnterToContinue();
                Directon directon = new Directon();
                Console.WriteLine($"Для продажи билетов нажмите {CommandEnter}");
                EnterToContinue();
                SendTrain(directon.CityArrival, directon.CityDeparture);
                Console.WriteLine($"Для отравки поезда нажмите {CommandEnter}");
                EnterToContinue();
                ShowSendsTrains();
            }
        }

        public void ShowInfo(Train train)
        {
            Console.WriteLine($"Поезд {train.CityArrival} - {train.CityDeparture} с {train.CountCarriages} вагонами");
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
                    Console.WriteLine($"Такой команды нет");
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
            Console.WriteLine($"На данном направлении {train.Passengers} пассажиров приобрели билеты," +
     $"  нажмите {ConsoleKey.Enter} чтобы сформировать поезд");
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
            Console.WriteLine("Отправленные поезда:\n");

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
            string[] cities = { "Питер", "Москва", "Екатеринбург", "Новосибирск", "Владивосток" };
            Random random = new Random();

            while (CityArrival == CityDeparture)
            {
                int cityIndex = random.Next(cities.Length);
                int cityIndex2 = random.Next(cities.Length);
                CityArrival = cities[cityIndex];
                CityDeparture = cities[cityIndex2];
            }

            Console.WriteLine($"Направление поезда {CityArrival} - {CityDeparture}");
        }
    }

    class Carriage
    {
        public int MaxPlace { get; private set; } = 38;
    }
}