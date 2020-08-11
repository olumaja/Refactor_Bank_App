using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using Utility;

namespace BankLibrary
{
    public class Customer
    {

        private static int _idNumber = 1;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _passowrd;

        Validator checkStatus = new Validator();

        public string Id
        { get; set; }

        

        public Customer()
        {
           
            this.Id = _idNumber.ToString();
            _idNumber++;
        }

        

        public string FirstName
        {
            get { return this._firstName;}
            set
           {
                if (String.IsNullOrWhiteSpace(value.Trim()))
                {
                    throw new ArgumentNullException("", "FirstName cannot be empty");
                }
                this._firstName = char.ToUpper(value[0]) + value.Substring(1);
            }
        }

        public string LastName
        {
            get { return this._lastName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value.Trim()))
                {
                    throw new ArgumentNullException("", "LastName cannot be empty");
                }
                this._lastName = char.ToUpper(value[0]) + value.Substring(1) ;
            }
        }

        public string Email
        {
            get { return this._email; }
            set
            {
                if (String.IsNullOrWhiteSpace(value.Trim()))
                {
                    //Console.WriteLine(checkStatus.IsValideEmail(value));
                    throw new ArgumentNullException("", "Email cannot be empty");
                }
                else if (!checkStatus.IsValideEmail(value.Trim()))
                {
                    throw new InvalidOperationException("Email not vaild");
                }
                this._email = value;
            }
        }

        public string Password
        {
            get
            {
                return this._passowrd;
            }
            set
            {

                if (String.IsNullOrWhiteSpace(value.Trim()))
                {
                    throw new ArgumentNullException("", "Password cannot be empty");
                }
                this._passowrd = value;
            }
        }

        public string FullName()
        {
            return ($"{FirstName} {LastName}");
        }

    }
}
