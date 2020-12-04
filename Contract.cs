using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental
{
    class Contract
    {
        private string contractid;
        private string licensePlates;
        private Customer customer;
        private string startDate;
        private string endDate;
        private int cost;
        private string payments;
        private TypePayment typepayment;
        private TypeRent typeRent;

        public Contract()
        {
        }

        public Contract(string contractid, string licensePlates, Customer customer, string startDate, string endDate, int cost, string payments, TypePayment typepayment, TypeRent typeRent)
        {
            this.contractid = contractid;
            this.licensePlates = licensePlates;
            this.customer = customer;
            this.startDate = startDate;
            this.endDate = endDate;
            this.cost = cost;
            this.payments = payments;
            this.typepayment = typepayment;
            this.typeRent = typeRent;
        }

        public string Contractid { get => contractid; set => contractid = value; }
        public string LicensePlates { get => licensePlates; set => licensePlates = value; }
        public string StartDate { get => startDate; set => startDate = value; }
        public string EndDate { get => endDate; set => endDate = value; }
        public int Cost { get => cost; set => cost = value; }
        public string Payments { get => payments; set => payments = value; }
        internal Customer Customer { get => customer; set => customer = value; }
        internal TypePayment Typepayment { get => typepayment; set => typepayment = value; }
        internal TypeRent TypeRent { get => typeRent; set => typeRent = value; }
    }
}
