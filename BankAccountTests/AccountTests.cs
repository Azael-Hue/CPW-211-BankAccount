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
        [TestCategory("Deposit")]
        public void Deposit_APositiveAmount_AddToBalance(double depositAmount)
        {
            acc.Deposit(depositAmount);

            Assert.AreEqual(depositAmount, acc.Balance);
        }

        [TestMethod]
        [TestCategory("Deposit")]
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
        [TestCategory("Deposit")]
        public void Deposit_ZeroOrLess_ThrowsArgumentException(double invalidDepositAmount)
        {
            // Arrange
            // Nothing to add here

            // Assert => Act
            Assert.ThrowsException<ArgumentOutOfRangeException>
                (() => acc.Deposit(invalidDepositAmount));
        }

        [TestMethod]
        [TestCategory("Withdraw")]
        public void Withdraw_PositiveAmount_DecreaseBalance()
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

        [TestMethod]
        [DataRow(100, 50)]
        [DataRow(100, .99)]
        [TestCategory("Withdraw")]
        public void Withdraw_PositiveAmount_ReturnsUpdatedBalance(double initialDeposit, double withdrawalAmount)
        {
            // Arrange
            double expectedBalance = initialDeposit - withdrawalAmount;
            acc.Deposit(initialDeposit);

            // Act
            double returnBalance = acc.withdraw(withdrawalAmount);

            // Assert
            Assert.AreEqual(expectedBalance, returnBalance);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-.01)]
        [DataRow(-1000)]
        [TestCategory("Withdraw")]
        public void Withdraw_ZeroOrLess_ThrowArgumentOutOfRangeException(double withdrawalAmount)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => acc.withdraw(withdrawalAmount));
        }

        [TestMethod]
        [TestCategory("Withdraw")]
        public void Withdraw_MoreThanAvailableBalance_ThrowsArgumentException()
        {
            double withdrawalAmount = 1000;

            Assert.ThrowsException<ArgumentException>(() => acc.withdraw(withdrawalAmount));
        }

        [TestMethod]
        public void Owner_SetAsNull_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => acc.Owner = null);
        }

        [TestMethod]
        public void Owner_SetAsWhiteSpaceOrEmptyString_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = String.Empty);
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = "    ");
        }

        [TestMethod]
        [DataRow("John")]
        [DataRow("John Doe")]
        [DataRow("Jonathan Jojo Joseph")]
        public void Owner_SetAsUpTo20Characters_SetsSuccessfully(string ownerName)
        {
            acc.Owner = ownerName;
            Assert.AreEqual(ownerName, acc.Owner);
        }

        [TestMethod]
        [DataRow("Jonathan Joseph Joestar")]
        [DataRow("Phillip J Fry 3rd")]
        [DataRow("BBNO$")]
        public void Owner_InvalidOwnerName_ThrowsArgumentException(string ownerName)
        {
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = ownerName);
        }
    }
}
