using UaiBank.Exceptions;
using UaiBank.Models;

namespace UaiBank.Services;

public class BankService
{
    private int nextId = 1; 
    private readonly Bank uaibank;
    
    // This property returns a fresh instance of the bank's client list. Any modifications made to this new list will not affect the original list stored within this class.
    public List<User> AllClients => new (uaibank.Clients);

    public BankService()
    {
        uaibank = new Bank();
    }

    public void AddNewClient(string name, int age, double balance)
    {
        if (name.Equals(""))
        {
            throw new InvalidClientNameException();
        }
        if (age < 16)
        {
            throw new InvalidClientAgeException();
        }

        if (balance < 0)
        {
            throw new InvalidClientBalanceException();
        }
        uaibank.Clients.Add(new User(nextId, name, age, balance));
        nextId += 1;
    }


    public User FindClientById(int id)
    {
        var client = uaibank.Clients.FirstOrDefault(client => client.Id == id);
        if (client == null)
        {
            throw new ClientNotFoundException();
        }

        return client;
    }

    public void DeleteClientById(int id)
    {
        var client = FindClientById(id);
        uaibank.Clients.Remove(client);
    }

    public void TransferAmountBetweenClients(int idSender, int idBeneficiary, double amount)
    {
        int indexOfSender = uaibank.Clients.FindIndex(client => client.Id == idSender);
        int indexOfBeneficiary = uaibank.Clients.FindIndex(client => client.Id == idBeneficiary);

        if (indexOfSender < 0 || indexOfBeneficiary < 0 )
        {
            throw new ClientNotFoundException();
        }

        if (uaibank.Clients[indexOfSender].Balance < amount)
        {
            throw new InsufficientBalanceException();
        }
        uaibank.Clients[indexOfSender].Balance -= amount;
        uaibank.Clients[indexOfBeneficiary].Balance += amount;

    }
}