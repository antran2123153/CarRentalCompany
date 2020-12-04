using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental
{
    class Moto : Vehicle
    {
        private int cylinderVolume;

        public Moto()
        {
        }
        public Moto(string licensePlates, string color, int price, TypeVehicle typeVehicle, int age, TypeStatusVehicle status, int mileage, int cylinderVolume) : base(licensePlates, color, price, typeVehicle, age, status, mileage)
        {
            this.cylinderVolume = cylinderVolume;
        }

        public int CylinderVolume { get => cylinderVolume; set => cylinderVolume = value; }
    }
}
