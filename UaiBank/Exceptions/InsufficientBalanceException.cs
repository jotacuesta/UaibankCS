namespace UaiBank.Exceptions;

public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException() : base("Insufficient balance for the transfer.") { }
}