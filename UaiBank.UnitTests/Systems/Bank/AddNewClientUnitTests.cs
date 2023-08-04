using FluentAssertions;
using UaiBank.Exceptions;
using UaiBank.Services;
using UaiBank.UnitTests.Helpers;

namespace UaiBank.UnitTests.Systems.Bank;

public class AddNewClientUnitTests
{
    [Test]
    public void AddNewClient_OnCreateNewClientsToBank_GenerateUniqueIds()
    {
        var bankService = BankServiceHelper.GetSharedBankServiceInstance();
        for (int i = 0; i < 7; i++)
        {
            bankService.AddNewClient($"Client {i + 1}", 16 + i, 100.00 );
        }
        bankService.AllClients.Count.Should().Be(7);
    }

    [Test]
    public void AddNewClient_OnCreateNewClientWithoutName_ThrowsException()
    {
        var bankService = BankServiceHelper.GetSharedBankServiceInstance();
        var action = () => bankService.AddNewClient("", 18, 100.00);
        action.Should().Throw<InvalidClientNameException>();
    }

    [Test]
    public void AddNewClient_OnCreateNewClientUnder16Years_ThrowsException()
    {
        var bankService = BankServiceHelper.GetSharedBankServiceInstance();
        var action = () => bankService.AddNewClient("Client 1", 12, 100.00);
        action.Should().Throw<InvalidClientAgeException>();
    }

    [Test]
    public void AddNewClient_OnCreateNewClientWithNegativeBalance_ThrowsException()
    {
        var bankService = BankServiceHelper.GetSharedBankServiceInstance();
        var action = () => bankService.AddNewClient("Client 1", 17, -100.00);
        action.Should().Throw<InvalidClientBalanceException>();
    }
    
}