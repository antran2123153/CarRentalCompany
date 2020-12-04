using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental
{
    class Garage
    {
        private string garageid;
        private string status;
        private string type;
        private string address;
        private int numofvehicle;

        public Garage()
        {
        }

        public Garage(string garageid, string status, string type, string address, int numofvehicle)
        {
            this.garageid = garageid;
            this.status = status;
            this.type = type;
            this.address = address;
            this.numofvehicle = numofvehicle;
        }

        public string Garageid { get => garageid; set => garageid = value; }
        public string Status { get => status; set => status = value; }
        public string Type { get => type; set => type = value; }
        public string Address { get => address; set => address = value; }
        public int Numofvehicle { get => numofvehicle; set => numofvehicle = value; }
    }
}
