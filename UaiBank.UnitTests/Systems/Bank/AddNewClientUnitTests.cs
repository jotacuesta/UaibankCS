using FluentAssertions;
using UaiBank.Exceptions;
using UaiBank.Services;

namespace UaiBank.UnitTests.Systems.Bank;

public class AddNewClientUnitTests
{
    [Test]
    public void AddNewClient_OnCreateNewClientsToBank_GenerateUniqueIds()
    {
        var bankService = new BankService();
        bankService.AddNewClient("Client 1", 18, 100.00);
        bankService.AddNewClient("Client 2", 20, 200.50);

        bankService.AllClients.Count.Should().Be(2);
    }

    [Test]
    public void AddNewClient_OnCreateNewClientWithoutName_ThrowsException()
    {
        var bankService = new BankService();
        var action = () => bankService.AddNewClient("", 18, 100.00);
        action.Should().Throw<InvalidClientNameException>();
    }

    [Test]
    public void AddNewClient_OnCreateNewClientUnder16Years_ThrowsException()
    {
        var bankService = new BankService();
        var action = () => bankService.AddNewClient("Client 1", 12, 100.00);
        action.Should().Throw<InvalidClientAgeException>();
    }

    [Test]
    public void AddNewClient_OnCreateNewClientWithNegativeBalance_ThrowsException()
    {
        var bankService = new BankService();
        var action = () => bankService.AddNewClient("Client 1", 17, -100.00);
        action.Should().Throw<InvalidClientBalanceException>();
    }
    
}