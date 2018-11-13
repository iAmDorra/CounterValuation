using System.Collections.Generic;

namespace ContreValo
{
    public class ContreValoCalculator
    {
        private readonly IRates rates;

        public ContreValoCalculator(IRates rates)
        {
            this.rates = rates;
        }

        public List<Deal> ConvertAmounts(List<Deal> deals, Currency targetCcy)
        {
            var rateCollection = rates.GetRates(targetCcy);
            if (rateCollection == null)
                return deals;
            CalculateAmounts(deals, rateCollection);

            return deals;
        }

        private static void CalculateAmounts(List<Deal> deals, List<Rate> rateCollection)
        {
            foreach (var deal in deals)
            {
                deal.Amount = rateCollection[0].Quote * deal.Amount;
            }
        }
    }
}
