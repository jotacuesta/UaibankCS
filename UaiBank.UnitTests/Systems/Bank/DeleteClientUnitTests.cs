using FluentAssertions;
using UaiBank.Exceptions;
using UaiBank.UnitTests.Helpers;

namespace UaiBank.UnitTests.Systems.Bank;

public class DeleteClientUnitTests
{
    [Test, Order(1)]
    public void DeleteClient_OnSuccess_RemoveClientFromList()
    {
        var bankService = BankServiceHelper.GetSharedBankServiceInstance();
        bankService.DeleteClientById(5);
        var action = () => bankService.FindClientById(5);
        action.Should().Throw<ClientNotFoundException>();
    }
    
    [Test, Order(2)]
    public void DeleteClient_OnFail_ThrowsClientNotFoundException()
    {
        var bankService = BankServiceHelper.GetSharedBankServiceInstance();
        var action = () => bankService.DeleteClientById(5);

        action.Should().Throw<ClientNotFoundException>();
    }
}