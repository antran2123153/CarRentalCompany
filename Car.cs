using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental
{
    class Car : Vehicle
    {
        private int seating;

        public Car()
        {
        }
        public Car(string licensePlates, string color, int price, TypeVehicle typeVehicle, int age, TypeStatusVehicle status, int mileage, int seating) : base(licensePlates, color, price, typeVehicle, age, status, mileage)
        {
            this.seating = seating;
        }
        public int Seating { get => seating; set => seating = value; }
    }
}
