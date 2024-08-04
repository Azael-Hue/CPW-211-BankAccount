using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        private Account acc;

        [TestInitialize]
        public void CreateDefaultAccount()
        {
            acc = new Account("John Doe");
        }

        [TestMethod()]
        [DataRow(100)]
        [DataRow(.01)]
        [DataRow(1.99)]
        [DataRow(9_999.99)]
        public void Deposit_APositiveAmount_AddToBalance(double depositAmount)
        {
            acc.Deposit(depositAmount);

            Assert.AreEqual(depositAmount, acc.Balance);
        }

        [TestMethod]
        public void Deposit_APositiveAmount_ReturnsUpdatedBalance()
        {
            // AAA - Arrange, Act, Assert
            // Arrange
            double depositAmount = 100;
            double expectedReturn = 100;

            // Act
            double returnValue = acc.Deposit(depositAmount);

            // Assert
            Assert.AreEqual(expectedReturn, returnValue);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        public void Deposit_ZeroOrLess_ThrowsArgumentException(double invalidDepositAmount)
        {
            // Arrange
            // Nothing to add here

            // Assert => Act
            Assert.ThrowsException<ArgumentOutOfRangeException>
                (() => acc.Deposit(invalidDepositAmount));
        }

        // withdrawing a positive amount - decrease the balance
        // withdrawing 0 - Throws ArgumentOutException exception
        // withdrawing a negative amount - throws an ArgumentOutException exception
        // withdrawing more than the balance - throws an ArgumentException

        [TestMethod]
        public void MyTestMethod()
        {
            // Arrange
            double initialDeposit = 100;
            double withdrawAmount = 50;
            double expectedBalance = initialDeposit - withdrawAmount;

            // Act
            acc.Deposit(initialDeposit);
            acc.withdraw(withdrawAmount);

            double actualBalance = acc.Balance;

            // Assert
            Assert.AreEqual(expectedBalance, actualBalance);
        }
    }
}