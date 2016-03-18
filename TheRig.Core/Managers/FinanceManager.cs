namespace TheRig.Core.Managers
{
    public class FinanceManager
    {
        private decimal _funds = 0.0M;
        public TransactionManager TransactionManager { get; private set; }
        public FinanceManager(decimal startFunds)
        {
            TransactionManager = new TransactionManager();
            CreditFunds(new Transaction { Name = "Start up", Value = startFunds, DateCreated = GameState.Instance.GameTime, Quantity = 1 });
        }

        public void CreditFunds(Transaction transaction)
        {
            _funds += transaction.Value;
            TransactionManager.Add(transaction);
        }

        public void DebitFunds(Transaction transaction)
        {
            _funds -= transaction.Value;
            TransactionManager.Add(transaction);
        }

        public decimal GetFunds()
        {
            return _funds;
        }
    }
}
