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
        private string owner;

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
        public string Owner 
        { 
            get { return owner; }
            set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(Owner)} cannot be null");
                }

                if (value.Trim() == string.Empty)
                {
                    throw new ArgumentException($"{nameof(Owner)} cannot be empty");
                }

                if (IsOwnerValid(value))
                {
                    owner = value;
                }
                else
                {
                    throw new ArgumentException($"{nameof(Owner)} can be up to 20 characters, A-Z/spaces only");
                }
                owner = value;
            }
        }

        /// <summary>
        /// Checks if owner name is less than or equal to 20 characters and contains only A-Z
        /// and whitespaces characters are allowed
        /// </summary>
        /// <returns></returns>
        private bool IsOwnerValid(string ownerName)
        {
            char[] validCharacters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j'
                    , 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w'
                    , 'x', 'y', 'z' };

            ownerName = ownerName.ToLower(); // Only need to compare to one casing

            const int maxLengthOwnerName = 20;

            if (ownerName.Length > maxLengthOwnerName)
            {
                return false;
            }

            foreach(char letter in ownerName)
            {
                if( letter != ' ' && !validCharacters.Contains(letter))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// The amount of money currently in the account
        /// </summary>
        public double Balance { get; private set; }

        /// <summary>
        /// Add a specified amount of money to the account. Returns the new balance
        /// </summary>
        /// <param name="amt"> The positive amount to deposit </param>
        /// <return> The new balance after the deposit </return>
        public double Deposit(double amt)
        {
            if (amt <=0)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(amt)} must be more than 0");
            }

            Balance += amt;
            return Balance;
        }

        /// <summary>
        /// Withdraw a specified amount of money from the balance and
        /// returns the updated balance
        /// </summary>
        /// <param name="amount"> The positive amount of money to be
        /// taken from the balance </param>
        /// <returns> Returns updated balance after withdrawal</returns>
        public double withdraw(double amount)
        {
            if ( amount > Balance)
            {
                throw new ArgumentException($"{nameof(amount)} cannot be greater than {nameof(Balance)}");
            }

            if ( amount <= 0 )
            {
                throw new ArgumentOutOfRangeException($"The {nameof(amount)} must be more than 0");
            }
            Balance -= amount;
            return Balance;
        }
    }
}
