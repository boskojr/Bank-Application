using System;
using System.Collections.Generic;
using System.Linq;

namespace Banken_ATM
{
    class Program
    {
        public class CardHolder
        {
            private string cardNum;
            private int pin;
            private string firstName;
            private string lastName;
            private decimal balance;

            public CardHolder(string cardNum, int pin, string firstName, string lastName, decimal balance)
            {
                this.cardNum = cardNum;
                this.pin = pin;
                this.firstName = firstName;
                this.lastName = lastName;
                this.balance = balance;
            }

            public string getCardNum()
            {
                return cardNum;
            }

            public int getPin()
            {
                return pin;
            }

            public string getFirstName()
            {
                return firstName;
            }

            public string getLastName()
            {
                return lastName;
            }

            public decimal getBalance()
            {
                return balance;
            }

            public void setCardNum(string newCardNum)
            {
                cardNum = newCardNum;
            }

            public void setPin(int newPin)
            {
                pin = newPin;
            }

            public void setFirstName(string newFirstName)
            {
                firstName = newFirstName;
            }

            public void setLastName(string newLastName)
            {
                lastName = newLastName;
            }

            public void setBalance(decimal newBalance)
            {
                balance = newBalance;
            }
        }

        static void printOptions()
        {
            Console.WriteLine("Please choose one of the following options:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show balance");
            Console.WriteLine("4. Exit");
        }

        static void Deposit(CardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit? ");
            decimal deposit = decimal.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your deposit. Your new balance is: " + currentUser.getBalance(), "Kr");
        }

        static void Withdraw(CardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw? ");
            decimal withdrawal = decimal.Parse(Console.ReadLine());

            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance :(");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You are good to go! Thank you :)");
            }
        }

        static void Balance(CardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance(), "Kr");
        }

        static void Main(string[] args)
        {
            List<CardHolder> cardHolders = new List<CardHolder>();
            cardHolders.Add(new CardHolder("1234", 1111, "Bosko", "Derik", 5032m));
            cardHolders.Add(new CardHolder("4321", 2222, "Maria", "Djord", 8290m));
            cardHolders.Add(new CardHolder("9999", 3333, "Borr", "Kel", 6274m));
            cardHolders.Add(new CardHolder("2468", 4444, "Burre", "Derk", 4356m));
            cardHolders.Add(new CardHolder("4826", 5555, "Borran", "John", 3476m));

            Console.WriteLine("Welcome to the ATM");
            Console.WriteLine("Please insert your debit cardnumber: ");
            string debitCardNum = "";
            CardHolder currentUser = null;

            while (true)
            {
                try
                {
                    debitCardNum = Console.ReadLine();
                    currentUser = cardHolders.FirstOrDefault(a => a.getCardNum() == debitCardNum);
                    if (currentUser != null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Card not recognized. Please try again");
                    }
                }
                catch
                {
                    Console.WriteLine("Card not recognized. Please try again");
                }
            }

            Console.WriteLine("Please enter your PIN: ");
            int userPin = 0;
            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    if (currentUser.getPin() == userPin)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect PIN. Please try again");
                    }
                }
                catch
                {
                    Console.WriteLine("Incorrect PIN. Please try again");
                }
            }

            Console.WriteLine("Welcome, " + currentUser.getFirstName() + "!");
            int option = 0;
            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch
                {
                    option = 0;
                }
                if (option == 1)
                {
                    Deposit(currentUser);
                }
                else if (option == 2)
                {
                    Withdraw(currentUser);
                }
                else if (option == 3)
                {
                    Balance(currentUser);
                }
                else if (option == 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again");
                }
            }
            while (option != 4);
            Console.WriteLine("Thank you! Have a nice day :)");
        }
    }
}

