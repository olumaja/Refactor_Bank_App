using BankLibrary;
using NUnit.Framework;
using System;

namespace BankTest
{
    public class BankTest
    {
        
        //Login test
        [Test]
        public void Login()
        {
            //Arrange
            var firstName = "John";
            var lastName = "Paul";
            var email = "johnpaul@gmail.com";
            var password = "12345";

            SignUpLogin existingCustomer = new SignUpLogin();
            existingCustomer.Register(firstName, lastName, email, password);

            //Assert
            Assert.IsNotNull(existingCustomer.Login(email, password));
        }

        //Registration
        [Test]
        public void Register()
        {

            //Arrange
            var firstName = "John";
            var lastName = "Paul";
            var email = "johnpaul@gmail.com";
            var password = "12345";
            SignUpLogin newCustomer = new SignUpLogin();

            //Act and Assert
            Assert.IsNotNull(newCustomer.Register(firstName, lastName, email, password));

        }

        //Transaction
        [Test]
        public void TransactionTest()
        {
            //Arrange
            var name = "James";
            var acctNumber = "1000000001";
            var accountType = "savings";
            decimal amount = 10;
            decimal balance = 200;
            string remark = "Food";

            //Act
            Transaction bills = new Transaction(name, acctNumber, accountType, amount, balance - amount, remark, DateTime.Now);

            //Assert
            Assert.IsNotNull(bills);
        }

        //Negative deposit
        [Test]
        public void NegativeDeposit()
        {
            //Arrange
            var remark = "Allowance";
            decimal amount = -10;
            string name = "Segun";
            decimal openingBalance = 1000;

            SavingsAccount myAccount = new SavingsAccount(name, openingBalance, "Initial balance");
            //Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(
                    () => myAccount.Deposit(amount, remark, DateTime.Now)
                );
        }

        //Initial deposit
        [Test]
        public void InitialDeposit()
        {
            //Arrange
            var remark = "Opening balance";
            decimal amount = 10.0M;
            var name = "Tony";

            //Act and Assert
            Assert.Throws<InvalidOperationException>(
                    () => new SavingsAccount(name, amount, remark)
                );
        }

        //Transfer
        [Test]
        public void Transfer()
        {
            //Arrange
            var remark = "Transfer to account1";
            decimal amount = 1000;
            var name = "Paul";
            var customer = new Customer();
            var account1 = new SavingsAccount(name, 200, "savings");
            var account2 = new SavingsAccount(name, 5000, "Salary");
            decimal expected = 1000;

            //Act
            decimal actual = account2.Transfer(account1.AccountNumber, amount, remark, DateTime.Now);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        //Test for over withdrawal
        [Test]
        public void OverWithdraw()
        {

            //Arrange
            var remake = "Rent";
            decimal amount = 1500;

            SavingsAccount myAccount = new SavingsAccount("Segun", 1000, "savings");
            //Act and Assert
            Assert.Throws<InvalidOperationException>(
                    () => myAccount.Withdrawal(amount, remake, DateTime.Now)
                );
        }

        //Negative withdrawal
        [Test]
        public void negativewithdrawal()
        {

            //arrange
            var remake = "rent";
            decimal amount = -10;

            SavingsAccount myaccount = new SavingsAccount("segun", 1000, "savings");
            //act and assert
            Assert.Throws<ArgumentOutOfRangeException>(
                    () => myaccount.Withdrawal(amount, remake, DateTime.Now)
                );
        }

    }
}