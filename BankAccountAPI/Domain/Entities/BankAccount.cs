namespace BankAccountAPI.Domain.Entities
{
    public class BankAccount
    {
        public Guid Id {get; set;}
        public string AccountNumber {get; set;} = "";
        public string OwnerName {get; set;} = null!;
        public decimal Balance {get; set;}
    }
}