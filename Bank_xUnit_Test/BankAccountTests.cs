using BankAccountNS;

namespace Bank_xUnit_Test
{
    public class BankAccountTests
    {
        [Fact]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            account.Debit(debitAmount);
            Assert.Equal(expected, account.Balance, .001);
        }

        [Fact]
        public void Debit_WithAmountLessThanZero()
        {
            double beginningBalance = 11.99;
            double debitAmount = -10.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        [Fact]
        public void Debit_WithAmountMoreThanBalance()
        {
            double beginningBalance = 11.99;
            double debitAmount = 50.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                String.Equals(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }
    }
}