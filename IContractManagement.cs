using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental
{
    interface IContractManagement
    {
        void AddContract(Contract contract);
        bool AddContract(string contractid, string licensePlates, Customer customer, string startDate, string endDate, int cost, string payments, TypePayment typepayment, TypeRent typeRent);
        bool AddContract(string contractid, TypeVehicle typeVehicle, Customer customer, string startDate, string endDate, int cost, string payments, TypePayment typepayment, TypeRent typeRent);
        bool AddContract(string contractid, int pricestart, int priceend, TypeVehicle typeVehicle, Customer customer, string startDate, string endDate, int cost, string payments, TypePayment typepayment, TypeRent typeRent);
        bool AddContract(string contractid, int price, TypeVehicle typeVehicle, Customer customer, string startDate, string endDate, int cost, string payments, TypePayment typepayment, TypeRent typeRent);
        void RemoveContract(string contract_id);
        void RemoveContract(Contract contract);
        void viewContact(string contractid);
        void viewContact();
    }
}
