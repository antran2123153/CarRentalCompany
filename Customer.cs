using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental
{
    class Customer
    {
        private string customerid;
        private string fullname;
        private string birthday;
        private string address;
        private string phonenumber;
        private string bankAccountNumber;

        public Customer()
        {
        }

        public Customer(string customerid, string fullname, string birthday, string address, string phonenumber, string bankAccountNumber)
        {
            this.customerid = customerid;
            this.fullname = fullname;
            this.birthday = birthday;
            this.address = address;
            this.phonenumber = phonenumber;
            this.bankAccountNumber = bankAccountNumber;
        }

        public string Customerid { get => customerid; set => customerid = value; }
        public string Fullname { get => fullname; set => fullname = value; }
        public string Birthday { get => birthday; set => birthday = value; }
        public string Address { get => address; set => address = value; }
        public string Phonenumber { get => phonenumber; set => phonenumber = value; }
        public string BankAccountNumber { get => bankAccountNumber; set => bankAccountNumber = value; }
    }
}
