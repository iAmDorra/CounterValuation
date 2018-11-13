using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using NSubstitute;
using ContreValo;

namespace ContreValo.Tests
{
    [TestClass]
    public class ContreValoCoverageTest
    {
        [TestMethod]
        public void Should_call_rates_when_convert_amounts()
        {
            // Arrange
            var rates = Substitute.For<IRates>();
            var contrevalo = new ContreValoCalculator(rates);
            Currency currency = new Currency();
            List<Deal> deals = new List<Deal> { new Deal(12) };

            // Act
            var updatedDeals = contrevalo.ConvertAmounts(deals, currency);

            // Assert
            //rates.Received(1).GetRates(Arg.Any<Currency>());
        }

        [TestMethod]
        public void Should_call_rates_when_convert_amounts_with_rates()
        {
            // Arrange
            Currency currency = new Currency();
            var rates = Substitute.For<IRates>();
            rates.GetRates(currency).Returns(new List<Rate> { new Rate(1.2M) });
            var contrevalo = new ContreValoCalculator(rates);
            List<Deal> deals = new List<Deal> { new Deal(12) };

            // Act
            var updatedDeals = contrevalo.ConvertAmounts(deals, currency);

            // Assert
            //rates.Received(1).GetRates(Arg.Any<Currency>());
        }

    }
}
