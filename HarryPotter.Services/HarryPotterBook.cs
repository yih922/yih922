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
            double totalPrice = 0;

            books = books.ToLookup(p => p.Series)
                         .Select(p => new HarryPotterBook(p.Key, p.Sum(g => g.Quantity)))
                         .Where(p => p.Quantity > 0).ToList();

            while (books.Count() > 0)
            {
                var minbookQty = books.Where(p => p.Quantity > 0).Min(p => p.Quantity);
                var bookseriesCount = books.Count();

                totalPrice += minbookQty * HarryPotterBook.BookPrice * bookseriesCount * GetDiscount(bookseriesCount);


                foreach (var book in books)
                {
                    book.Quantity = book.Quantity - minbookQty;
                }
                books = books.Where(p => p.Quantity > 0).ToList();
            }
            return totalPrice;
        }

        private static double GetDiscount(int bookseriesCount)
        {
            switch (bookseriesCount)
            {
                case 1:
                    return 1.0;
                case 2:
                    return 0.95;
                case 3:
                    return 0.9;
                case 4:
                    return 0.8;
                case 5:
                    return 0.75;
                default:
                    return 0;
            }
        }
    }
}
