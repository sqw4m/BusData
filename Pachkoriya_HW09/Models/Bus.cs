using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pachkoriya_HW09.Models
{
    public class Bus
    {
        // гос. номер 
        [Required(ErrorMessage = "Обязательно к заполнению")]
        [StringLength(25, ErrorMessage = "Длина имени не более 10 символов")]
        [Display(Name = "Государственный номер")]
        public string GovernmentNumber { get; set; }

        // маршрут
        [Required(ErrorMessage = "Обязательно к заполнению")]
        [StringLength(25, ErrorMessage = "Длина имени не более 50 символов")]
        [Display(Name = "Маршрут")]
        public string Route { get; set; }

        // фамилия и инициалы водителя
        [Required(ErrorMessage = "Обязательно к заполнению")]
        [StringLength(25, ErrorMessage = "Длина имени не более 10 символов")]
        [Display(Name = "Фамилия и инициалы водителя")]
        public string Driver { get; set; }

        // количество мест
        [Range(20, 50, ErrorMessage = "Количество мест должно быть в диапазоне от 20 до 50")]
        [Display(Name = "Количество мест")]
        public int SeatsNumber { get; set; }

        // стоимость билета
        [Range(250, 10000, ErrorMessage = "Стоимость билета должна быть в диапазоне от 250 до 10000")]
        [Display(Name = "Цена билета")]
        public double TicketPrice { get; set; }
        // список пассажиров
        public List<Passenger> Passengers { get; set; }
        // общий вес пассажиров
        public int TotalWeight() => Passengers.Sum(x => x.Weight);
        // общий процент заполненности автобуса
        public string TotalPersent() => $"{Passengers.Count / (double)SeatsNumber * 100d:n2}";
        // общая стоимость проданных билетов
        public string TotalCost() => $"{Passengers.Count * TicketPrice}";
        // сортировка по номеру места
        public List<Passenger> SortPassengersBySeatNumber() => Passengers.OrderBy(x => x.SeatNumber).ToList();
        // сортировка по фамилии и инициалам
        public List<Passenger> SortPassengersBySurnameNP() => Passengers.OrderBy(x => x.SurnameNP).ToList();

        // добавить пассажира
        public void AddPassenger(Passenger passenger)
        {
            passenger.SeatNumber = Passengers.Max(p => p.SeatNumber) + 1;
            Passengers.Add(passenger);
        } // AddPassenger

        // удалить пассажира
        public void DelPassenger(Passenger passenger) => Passengers.Remove(passenger);
    }
}
