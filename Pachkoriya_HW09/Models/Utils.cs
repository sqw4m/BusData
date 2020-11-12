using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pachkoriya_HW09.Models
{
    static class Utils
    {
        // объект для получения случайных чисел
        public static readonly Random Random = new Random(Environment.TickCount);

        // Получение случайного числа
        public static int GetRand(int lo, int hi) => Random.Next(lo, hi + 1);
        public static double GetRand(double lo, double hi) => lo + (hi - lo) * Random.NextDouble();
    } // class Utils
}