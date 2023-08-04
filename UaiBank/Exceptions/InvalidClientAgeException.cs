namespace UaiBank.Exceptions;

public class InvalidClientAgeException : Exception
{
    public InvalidClientAgeException() : base("The client must be at least 16 years old") { }
}