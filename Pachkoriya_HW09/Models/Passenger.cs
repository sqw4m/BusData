using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pachkoriya_HW09.Models
{
    public class Passenger
    {
        // фамилия инициалы
        [Required(ErrorMessage = "Обязательно к заполнению")]
        [StringLength(25, ErrorMessage = "Длина имени не более 50 символов")]
        [Display(Name = "Ф.И.О.")]
        public string SurnameNP { get; set; }

        // год рождения
        [Range(1920, 2020, ErrorMessage = "Год рождения должен быть в диапазоне от 1920 до 2020")]
        [DataType(DataType.Currency, ErrorMessage = "от 1920 до 2020")]
        [Display(Name = "Год рождения")]
        public int BirthYear { get; set; }

        // рост в сантиметрах
        [Range(25, 250, ErrorMessage = "Рост должен быть в диапазоне от 25 до 250")]
        [DataType(DataType.Currency, ErrorMessage = "от 25 до 250")]
        [Display(Name = "Рост")]
        public int Height { get; set; }

        // вес в килограммах
        [Range(25, 250, ErrorMessage = "Вес должен быть в диапазоне от 25 до 250")]
        [DataType(DataType.Currency)]
        [Display(Name = "Вес")]
        public int Weight { get; set; }

        // номер места
        [Display(Name = "Номер места")]
        public int SeatNumber { get; set; }
    }
}
