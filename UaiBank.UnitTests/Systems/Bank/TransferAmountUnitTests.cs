using FluentAssertions;
using UaiBank.Exceptions;
using UaiBank.UnitTests.Helpers;

namespace UaiBank.UnitTests.Systems.Bank;

public class TransferAmountUnitTests
{
    [Test, Order(1)]
    public void TransferAmount_OnSuccess_ShouldModifyClientsBalance()
    {
        var bankService = BankServiceHelper.GetSharedBankServiceInstance();
        bankService.TransferAmountBetweenClients(1, 2, 10.00);

        var client1 = bankService.FindClientById(1);
        var client2 = bankService.FindClientById(2);

        client1.Balance.Should().Be(client2.Balance - 20);
    }

    [Test, Order(2)]
    public void TransferAmount_OnFail_ThrowsClientNotFoundExceptionIfNotSender()
    {
        var bankService = BankServiceHelper.GetSharedBankServiceInstance();
        var action = () => bankService.TransferAmountBetweenClients(-1, 2, 10.00);

        action.Should().Throw<ClientNotFoundException>();
    }
    
    [Test, Order(3)]
    public void TransferAmount_OnFail_ThrowsClientNotFoundExceptionIfNotBeneficiary()
    {
        var bankService = BankServiceHelper.GetSharedBankServiceInstance();
        var action = () => bankService.TransferAmountBetweenClients(1, -2, 10.00);

        action.Should().Throw<ClientNotFoundException>();
    }

    [Test, Order(4)]
    public void TransferAmount_OnFail_ThrowsInsufficientBalanceException()
    {
        var bankService = BankServiceHelper.GetSharedBankServiceInstance();
        var action = () => bankService.TransferAmountBetweenClients(1, 2, 100000.00);
        
        action.Should().Throw<InsufficientBalanceException>();
    }
}