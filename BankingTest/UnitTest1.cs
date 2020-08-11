using BankLibrary;
using System;
using Xunit;

namespace BankingTest
{
    public class BankAppTest
    {
        [Fact]
        public void InitialDeposit()
        {
            //Opening Balance must be equal
            Assert.Throws<InvalidOperationException>(

                () => new SavingsAccount("Segun", 50, "savings")

                );

        }

        [Fact]
        public void NegativeDeposit()
        {
            //Deposit must be positive
            var personSavingsAccount = new SavingsAccount("Segun", 2000, "savings");

            Assert.Throws<ArgumentOutOfRangeException>(

                    () => personSavingsAccount.Deposit(-200, "Tip", DateTime.Now)

                );

        }

        //[Fact]
        //public void 

    }
}
