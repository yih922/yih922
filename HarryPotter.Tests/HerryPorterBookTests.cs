using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using HarryPotter.Services;

namespace HarryPotter.Tests
{
    [TestClass]
    public class HerryPorterBookTests
    {
        [TestMethod]
        [DataRow(1, 0, 0, 0, 0, 100)]
        [DataRow(1, 1, 0, 0, 0, 190)]
        [DataRow(1, 1, 1, 0, 0, 270)]
        [DataRow(1, 1, 1, 1, 0, 320)]
        [DataRow(1, 1, 1, 1, 1, 375)]
        [DataRow(1, 1, 2, 0, 0, 370)]
        [DataRow(1, 2, 2, 0, 0, 460)]
        public void Should_Get_Correct_Price_For_Nonduplicate_Booklist(int FirstQty, int SecondQty, int ThirdQty, int ForthQty, int FifthQty, double expected)
        {
            var hpbooks = new HarryPotterBook[]
                   {
                       new HarryPotterBook(Series.First, FirstQty),
                       new HarryPotterBook(Series.Second, SecondQty),
                       new HarryPotterBook(Series.Third, ThirdQty),
                       new HarryPotterBook(Series.Forth, ForthQty),
                       new HarryPotterBook(Series.Fifth, FifthQty)
                   };

            var result = hpbooks.GetPrice();

            result.Should().Be(expected, result.ToString());
        }
    }
}
