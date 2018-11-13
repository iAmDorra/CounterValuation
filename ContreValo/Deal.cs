namespace ContreValo
{
    public class Deal
    {
        private decimal _amount;

        public Deal(decimal amount)
        {
            _amount = amount;
        }
        public decimal Amount { get => _amount; set => _amount = value; }


    }
}
