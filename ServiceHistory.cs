using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental
{
    class ServiceHistory
    {
        private int serviceid;
        private string licensePlates;
        private string garageid;
        private int mileage;
        private string date;
        private TypeService typeService;
        private int cost;

        public ServiceHistory()
        {
        }

        public ServiceHistory(int serviceid, string licensePlates, string garageid, int mileage, string date, TypeService typeService, int cost)
        {
            this.serviceid = serviceid;
            this.licensePlates = licensePlates;
            this.garageid = garageid;
            this.mileage = mileage;
            this.date = date;
            this.typeService = typeService;
            this.cost = cost;
        }

        public int Serviceid { get => serviceid; set => serviceid = value; }
        public string LicensePlates { get => licensePlates; set => licensePlates = value; }
        public string Garageid { get => garageid; set => garageid = value; }
        public int Mileage { get => mileage; set => mileage = value; }
        public string Date { get => date; set => date = value; }
        public int Cost { get => cost; set => cost = value; }
        internal TypeService TypeService { get => typeService; set => typeService = value; }

        public static int operator -(ServiceHistory service1, ServiceHistory service2)
        {
            if (service1.LicensePlates != service2.LicensePlates)
                return -1;
            return Math.Abs(service1.Mileage - service2.Mileage);
        }
        public static bool operator ==(ServiceHistory service1, ServiceHistory service2)
        {
            if (service1.Serviceid == service2.Serviceid)
                return true;
            return false;
        }
        public static bool operator !=(ServiceHistory service1, ServiceHistory service2)
        {
            if (service1.Serviceid != service2.Serviceid)
                return true;
            return false;
        }
        public static bool operator <(ServiceHistory service1, ServiceHistory service2)
        {
            if (service1.LicensePlates != service2.LicensePlates)
                return false;
            return (service1.Mileage < service2.Mileage);
        }
        public static bool operator >(ServiceHistory service1, ServiceHistory service2)
        {
            if (service1.LicensePlates != service2.LicensePlates)
                return false;
            return (service1.Mileage > service2.Mileage);
        }
        public static bool operator >=(ServiceHistory service1, ServiceHistory service2)
        {
            if (service1.LicensePlates != service2.LicensePlates)
                return false;
            return (service1.Mileage >= service2.Mileage);
        }
        public static bool operator <=(ServiceHistory service1, ServiceHistory service2)
        {
            if (service1.LicensePlates != service2.LicensePlates)
                return false;
            return (service1.Mileage <= service2.Mileage);
        }

    }
}
