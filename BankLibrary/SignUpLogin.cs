using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BankLibrary
{
    public class SignUpLogin
    {

        private string errMessage = "";
        private Customer person = new Customer();
        private List<Customer> peopleList = new List<Customer>();

        public Customer Register(string nameFirst, string nameLast, string email, string password)
        {
            try
            {
                person.FirstName = nameFirst;
            }
            catch (ArgumentNullException e)
            {

                errMessage += "Error: " + e.Message + "\n";
            }
            try
            {
                person.LastName = nameLast;
            }
            catch (ArgumentNullException e)
            {
                errMessage += "Error: " + e.Message + "\n";

            }

            try
            {
                person.Email = email;
            }
            catch (ArgumentNullException e)
            {

                errMessage += "Error: " + e.Message + "\n";
            }
            catch(InvalidOperationException e)
            {
                errMessage += "Error: " + e.Message + "\n";
            }

            try
            {
                person.Password = password;
            }
            catch (ArgumentNullException e)
            {

                errMessage += "Error: " + e.Message + "\n";
            }

            if (errMessage != "") { 
                Console.WriteLine(errMessage + "Try again\n");
                return null;
            }
            peopleList.Add(person);
            return person;

        }

        //Login method
        public Customer Login(string mail, string password)
        {

            if (String.IsNullOrWhiteSpace(mail) && String.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Email and password cannot be empty");
            }
            else
            {

                foreach (var content in peopleList)
                {
                    if (content.Email == mail.ToLower() && content.Password == password)
                    {
                        Console.WriteLine("Login successful");
                        Console.WriteLine();

                        // validateUser = true;
                        //To implement account transaction
                        // var creatingAccount = new CreateAccounts(person.FullName());
                        // break;
                        Console.WriteLine(person.FirstName);
                        return person;
                    }

                }

            }

            return null;                

        }



    }
}
