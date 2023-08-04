namespace UaiBank.Exceptions;

public class ClientNotFoundException : Exception
{
    public ClientNotFoundException (): base("No client found with the specified id") {}
}