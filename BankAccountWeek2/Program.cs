using BankLibrary;
using System;
using System.Text;
using System.Collections.Generic;

namespace Bankapp_refactored_week4
{
    class Program
    {
        static void Main(string[] args)
        {

            string userInputs;
            bool userStatus = false;

            SignUpLogin signUp = new SignUpLogin();
            var buildString = new StringBuilder();
            //List<Customer> peopleList = new List<Customer>();

            buildString.Append('-', 120);
            buildString.AppendLine();
            buildString.Append("\t\t\t\t\t\tWelcome to Maja's Bank");
            buildString.AppendLine();
            buildString.Append('-', 120);
            Console.WriteLine(buildString.ToString());
            Console.WriteLine();

            Console.WriteLine(@"                       Register if you are new or login if you alresdy have account");
            Console.WriteLine();

            string anotherAccount;

                Console.Write(@"                       Enter R to register, L to login or Q to terminate this transaction: ");
                userInputs = Console.ReadLine();
                Console.WriteLine();

                do
                {

                    if (String.IsNullOrWhiteSpace(userInputs))
                    {
                        Console.WriteLine(@"                       Input can't be empty, please try again");
                        Console.WriteLine();

                    }
                    else if(userInputs.ToLower() == "q") 
                    {
                        Console.WriteLine("Goodbye! thank you for using Maja's bank");
                        break; 
                    }

                    //Registeration goes in here
                    else if (userInputs.ToLower() == "r")
                    {

                        string firstName = "";
                        string lastName = "";
                        string email = "";
                        string userPassword = "";

                        do
                        {

                                Console.Write("Enter your Firstname: ");
                                firstName = Console.ReadLine();
                                Console.WriteLine();
                                Console.Write("Enter your Lastname: ");
                                lastName = Console.ReadLine();
                                Console.WriteLine();
                                Console.Write("Enter your email address: ");
                                email = Console.ReadLine();
                                Console.WriteLine();
                                Console.Write("Enter a password: ");
                                userPassword = Console.ReadLine();
                                Console.WriteLine();
                            
                            Customer customerCreated = signUp.Register(firstName, lastName, email, userPassword);
                            
                            if (customerCreated != null) 
                            {
                              
                                Console.WriteLine("Customer registration successful");
                                Console.WriteLine();
                                //Implement Banking transaction
                                CreateAccounts creatingAccount = new CreateAccounts(customerCreated.FullName());
                                userStatus = true;
                            }
                       

                        } while (!userStatus);                    

                    }
                    else if (userInputs.ToLower() == "l")
                    {
                        // Call login method
                        //Determine if customer exist
                        Customer existingCustomer = null;
                        Console.WriteLine("Enter email and password to login");
                        Console.WriteLine();

                        do
                        {

                            //Login to create account                           
                            Console.Write("Enter email: ");
                            var userEmail = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Enter password: ");
                            var userPassword = Console.ReadLine();
                            Console.WriteLine();

                            if (!String.IsNullOrWhiteSpace(userEmail) && !String.IsNullOrWhiteSpace(userPassword))
                            {
                               existingCustomer = signUp.Login(userEmail, userPassword);
                            }
                            else
                            {
                                Console.WriteLine("Email and password cannot be empty");
                            }

                            if (existingCustomer != null)
                            {
                                //To implement account transaction
                                var creatingAccount = new CreateAccounts(existingCustomer.FullName());
                                userStatus = true;
                            }

                        } while (!userStatus);
  

                    }

                    if (userStatus)
                    {

                        Console.Write("To create another Account enter Y for Yes or N for No: ");
                        anotherAccount = Console.ReadLine();
                        Console.WriteLine();
                        if (anotherAccount.ToLower() == "y") { userInputs = "l"; }

                    }
                    else { break; }                   

                } while (anotherAccount.ToLower() != "n");

        }
    }
}
    