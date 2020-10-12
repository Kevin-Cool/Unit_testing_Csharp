using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debet_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debetAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Tom Vervoort", beginningBalance);

            // Act
            account.Debet(debetAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debeted correctly");

        }

        [TestMethod]
        public void Debet_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance=11.99;
            double debetAmount=-100.00;
            BankAccount account=new BankAccount("Mr. Tom Vervoort", beginningBalance);

            // Act
            try    
            {
                account.Debet(debetAmount);    
            }
            catch (System.ArgumentOutOfRangeException e)    
            {
                // Assert
                StringAssert.Contains(e.Message,BankAccount.DebetAmountLessThanZeroMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void Debet_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debetAmount = 13000;
            BankAccount account = new BankAccount("Mr. Tom Vervoort", beginningBalance);

            // Act
            try
            {
                account.Debet(debetAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebetAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double CreditAmount = 4.55;
            double expected = (11.99+4.55);
            BankAccount account = new BankAccount("Mr. Tom Vervoort", beginningBalance);

            // Act
            account.Credit(CreditAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not credited correctly");

        }

        [TestMethod]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double CreditAmount = -69.420;
            BankAccount account = new BankAccount("Mr. Tom Vervoort", beginningBalance);

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
            account.Debet(CreditAmount));

        }
    }
}
