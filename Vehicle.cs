using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental
{
    class Vehicle
    {
        private String licensePlates;
        private String color;
        private int price;
        private TypeVehicle typeVehicle;
        private int age;
        private TypeStatusVehicle status;
        private int mileage;

        public Vehicle()
        {
        }

        public Vehicle(string licensePlates, string color, int price, TypeVehicle typeVehicle, int age, TypeStatusVehicle status, int mileage)
        {
            this.licensePlates = licensePlates;
            this.color = color;
            this.price = price;
            this.typeVehicle = typeVehicle;
            this.age = age;
            this.status = status;
            this.mileage = mileage;
        }

        public string LicensePlates { get => licensePlates; set => licensePlates = value; }
        public string Color { get => color; set => color = value; }
        public int Price { get => price; set => price = value; }
        public int Age { get => age; set => age = value; }
        public TypeStatusVehicle Status { get => status; set => status = value; }
        public int Mileage { get => mileage; set => mileage = value; }
        internal TypeVehicle TypeVehicle { get => typeVehicle; set => typeVehicle = value; }
    }
}
