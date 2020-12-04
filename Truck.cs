using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental
{
    class Truck : Vehicle
    {
        private int weight;

        public Truck()
        {
        }

        public Truck(string licensePlates, string color, int price, TypeVehicle typeVehicle, int age, TypeStatusVehicle status, int mileage, int weight) : base(licensePlates, color, price, typeVehicle, age, status, mileage)
        {
            this.weight = weight;
        }

        public int Weight { get => weight; set => weight = value; }
    }
}
