using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter.Services
{
    public class HarryPotterBook
    {
        public static double BookPrice => 100;

        private Series _series;

        public HarryPotterBook(Series series, int quantity)
        {
            Quantity = quantity;
            _series = series;
        }

        //properties
        public Series Series => _series;
        public int Quantity { get; set; }
    }

    public enum Series
    {
        First,
        Second,
        Third,
        Forth,
        Fifth
    }

    public static class Extension
    {
        public static double GetPrice(this IEnumerable<HarryPotterBook> books)
        {
           
            return 0;
        }
    }
}
