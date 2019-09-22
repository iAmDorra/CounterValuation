using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NFluent;

namespace ContreValo.Tests
{
    /// <summary>
    /// Description résumée pour ContreValoBusinessTest
    /// </summary>
    [TestClass]
    public class ContreValoBusinessTest
    {
        [TestMethod]
        public void Should_return_same_deal_amounts_when_no_rate_found()
        {
            // Arrange
            var rates = Substitute.For<IRates>();
            var contrevalo = new ContreValoCalculator(rates);
            Currency currency = new Currency();
            List<Deal> deals = new List<Deal> { new Deal(12) };

            // Act
            var updatedDeals = contrevalo.ConvertAmounts(deals, currency);

            //Assert
            Check.That(updatedDeals[0].Amount).IsEqualTo(12);
        }

        [TestMethod]
        public void Should_calculate_deal_amount_when_rate_found()
        {
            // Arrange
            Currency currency = new Currency();
            var rates = Substitute.For<IRates>();
            rates.GetRates(currency).Returns(new List<Rate> { new Rate(1.2M) });

            var contrevalo = new ContreValoCalculator(rates);
            List<Deal> deals = new List<Deal> { new Deal(12) };

            // Act
            var updatedDeals = contrevalo.ConvertAmounts(deals, currency);

            //Assert
            Check.That(updatedDeals[0].Amount).IsEqualTo(14.4M);
        }
    }
}
