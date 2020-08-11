using BankLibrary;
using NUnit.Framework;
using System;

namespace BankTest
{
    public class BankTest
    {

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

        [Test]
        public void NegativeDeposit()
        {
            //Arrange
            var remake = "Allowance";
            decimal amount = -10;

            SavingsAccount myAccount = new SavingsAccount("Segun", 1000, "savings");
            //Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(
                    () => myAccount.Deposit(amount, remake, DateTime.Now)
                );
        }

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

        //[Test]
        //public void Transfer()
        //{



        //    Assert.Pass();
        //}

    }
}