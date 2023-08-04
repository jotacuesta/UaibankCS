namespace UaiBank.Exceptions;

public class InvalidClientNameException : Exception
{
    public InvalidClientNameException() : base("The client name is not valid") { }
    
}