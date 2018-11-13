namespace ContreValo
{
    public class Rate
    {
        private decimal _quote;

        public Rate(decimal quote)
        {
            _quote = quote;
        }

        public decimal Quote { get => _quote; }
    }
}
