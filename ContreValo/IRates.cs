using System.Collections.Generic;

namespace ContreValo
{
    public interface IRates
    {
        List<Rate> GetRates(Currency currency);
    }
}
