using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace Pachkoriya_HW09.Models
{
    public class BusRepository
    {
        private readonly string path = "App_Data/bus.json";
        public Bus Bus { get; set; }

        public BusRepository()
        {
            if (File.Exists(path))
            {
                Bus = DeserializeBus();
            }
            else
            {
                Bus = new Bus();
                Initializer();
            } // if
        } // BusApplication

        public void Initializer()
        {
            Passenger[] passengers =
            {
                new Passenger{ SurnameNP = "Лапина И.И.", BirthYear = 1985, Height = 165, Weight = 53, SeatNumber = 22 },
                new Passenger{ SurnameNP = "Кульманов В.З.", BirthYear = 1955, Height = 185, Weight = 98, SeatNumber = 14 },
                new Passenger{ SurnameNP = "Шапкина У.Г.", BirthYear = 1995, Height = 169, Weight = 61, SeatNumber = 17 },
                new Passenger{ SurnameNP = "Новикова Л.Б.", BirthYear = 2001, Height = 155, Weight = 44, SeatNumber = 20 },
                new Passenger{ SurnameNP = "Кузнецов П.Л.", BirthYear = 1977, Height = 204, Weight = 102, SeatNumber = 15 },
                new Passenger{ SurnameNP = "Голубев В.В.", BirthYear = 1989, Height = 178, Weight = 82, SeatNumber = 9 },
                new Passenger{ SurnameNP = "Любимова Р.А.", BirthYear = 1992, Height = 175, Weight = 59, SeatNumber = 23 },
                new Passenger{ SurnameNP = "Гаврилов О.Н.", BirthYear = 1969, Height = 192, Weight = 97, SeatNumber = 16 },
                new Passenger{ SurnameNP = "Мамонтова А.В.", BirthYear = 1997, Height = 162, Weight = 55, SeatNumber = 6 },
                new Passenger{ SurnameNP = "Гусев Л.П.", BirthYear = 1955, Height = 169, Weight = 85, SeatNumber = 19 },
                new Passenger{ SurnameNP = "Шабусова Н.Б.", BirthYear = 1987, Height = 187, Weight = 87, SeatNumber = 13 },
                new Passenger{ SurnameNP = "Яниева Д.Р.", BirthYear = 1993, Height = 175, Weight = 78, SeatNumber = 18 },
                new Passenger{ SurnameNP = "Колесников О.Н.", BirthYear = 1988, Height = 189, Weight = 91, SeatNumber = 11 },
                new Passenger{ SurnameNP = "Янченко А.Д.", BirthYear = 1971, Height = 182, Weight = 123, SeatNumber = 2 },
                new Passenger{ SurnameNP = "Вергизова А.А.", BirthYear = 2000, Height = 153, Weight = 43, SeatNumber = 5 },
                new Passenger{ SurnameNP = "Авдеенко Н.Р.", BirthYear = 1998, Height = 167, Weight = 59, SeatNumber = 8 },
                new Passenger{ SurnameNP = "Павлов П.А.", BirthYear = 1988, Height = 177, Weight = 92, SeatNumber = 21 },
                new Passenger{ SurnameNP = "Минченко М.В.", BirthYear = 1999, Height = 171, Weight = 69, SeatNumber = 12 },
                new Passenger{ SurnameNP = "Вознюк Н.В.", BirthYear = 1958, Height = 164, Weight = 65, SeatNumber = 10 },
                new Passenger{ SurnameNP = "Хлеб Б.Б.", BirthYear = 1995, Height = 195, Weight = 79, SeatNumber = 4 },
                new Passenger{ SurnameNP = "Добрый В.И.", BirthYear = 1991, Height = 172, Weight = 67, SeatNumber = 3 },
                new Passenger{ SurnameNP = "Артемьева Л.И.", BirthYear = 1982, Height = 175, Weight = 61, SeatNumber = 1 },
                new Passenger{ SurnameNP = "Вереитина Н.П.", BirthYear = 1970, Height = 173, Weight = 75, SeatNumber = 7 }
            };

            Bus.GovernmentNumber = "Т612ПР";
            Bus.Route = "Донецк-Анапа";
            Bus.Driver = "Вольнов И.К.";
            Bus.SeatsNumber = 32;
            Bus.TicketPrice = 2000;
            Bus.Passengers = new List<Passenger>();

            foreach (var passenger in passengers)
                Bus.Passengers.Add(passenger);

            SerializeBus();
        } // BusInitializer

        public void SerializeBus()
        {
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(Bus));
            using (FileStream fs = new FileStream(path, FileMode.Create))
                formatter.WriteObject(fs, Bus);
        } // SerializeBus

        public Bus DeserializeBus()
        {
            Bus bus = new Bus();

            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Bus));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                bus = (Bus)json.ReadObject(fs);

            return bus;
        } // DeserializeBus

        public void EditBus(Bus bus)
        {
            Bus.GovernmentNumber = bus.GovernmentNumber;
            Bus.Route = bus.Route;
            Bus.Driver = bus.Driver;
            Bus.SeatsNumber = bus.SeatsNumber;
            Bus.TicketPrice = bus.TicketPrice;
            
            SerializeBus();
        } // EditBus
    }
}
