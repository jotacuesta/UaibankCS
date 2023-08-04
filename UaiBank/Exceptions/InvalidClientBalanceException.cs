namespace UaiBank.Exceptions;

public class InvalidClientBalanceException : Exception
{
    public InvalidClientBalanceException() : base("The balance must be a value greater than 0") { }
}