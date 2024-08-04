using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// Represents a single customers bank account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Creates a new account with the specified owner name and a zero balance
        /// </summary>
        /// <param name="accOwner"> The customer full name that owns the account </param>
        public Account(string accOwner)
        {
            Owner = accOwner;
        }

        /// <summary>
        /// The account holders full name (first and last)
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// The amount of money currently in the account
        /// </summary>
        public double Balance { get; private set; }

        /// <summary>
        /// Add a specified amount of money to the account
        /// </summary>
        /// <param name="amt"> The positive amount to deposit </param>
        public void deposit(double amt)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Withdraw a specified amount of money from the account
        /// </summary>
        /// <param name="amt"> The positive amount of money to be taken from the account </param>
        public void withdraw(double amt)
        {
            throw new NotImplementedException();
        }
    }
}
