using FluentAssertions;
using UaiBank.Exceptions;
using UaiBank.Models;
using UaiBank.UnitTests.Helpers;

namespace UaiBank.UnitTests.Systems.Bank;

public class FindClientUnitTests
{
    [Test]
    public void FindClient_OnSuccess_ReturnNewInstanceOfUser()
    {
        var bankService = BankServiceHelper.GetSharedBankServiceInstance();
        var user = bankService.FindClientById(3);
        user.Should().BeOfType<User>();
    }

    [Test]
    public void FindClient_OnFail_ThrowsClientNotFoundException()
    {
        var bankService = BankServiceHelper.GetSharedBankServiceInstance();
        var action = () => bankService.FindClientById(-1);
        action.Should().Throw<ClientNotFoundException>();
    }
}