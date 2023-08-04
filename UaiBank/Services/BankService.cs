using UaiBank.Models;

namespace UaiBank.Services;

public class BankService
{
    public readonly Bank Uaibank;
    public BankService()
    {
        Uaibank = new Bank();
    }

    public void AddNewClient(string name, int age, double balance)
    {
        throw new NotImplementedException();
    }
}