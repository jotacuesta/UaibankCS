using FluentAssertions;
using UaiBank.Models;
using UaiBank.Services;

namespace UaiBank.UnitTests.Systems;

public class StartUpLogicTest
{
    [Test]
    public void AddClient_OnCreateNewClientsToBank_GenerateUniqueIds()
    {
        
        BankService bankService = new BankService();


        bankService.AddNewClient("Client 1", 18, 100.00);
        bankService.AddNewClient("Client 2", 20, 200.50);

        bankService.Uaibank.Clients.Count.Should().Be(2);
    }
}