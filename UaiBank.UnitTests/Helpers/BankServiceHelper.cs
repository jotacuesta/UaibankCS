using UaiBank.Services;

namespace UaiBank.UnitTests.Helpers;

public static class BankServiceHelper
{
    private static BankService bankServiceInstance = new ();

    public static BankService GetSharedBankServiceInstance ()
    {
        return bankServiceInstance;
    }
}