using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental
{
    interface IVehicleManagement
    {
        void AddVehicle(Vehicle vehicle);
        void AddVehicle(Car car);
        void AddVehicle(Moto moto);
        void AddVehicle(Truck truck);
        void UpdateVehicle(string licensePlates, Vehicle vehicle);
        void RemoveVehicle(Vehicle vehicle);
        void RemoveVehicle(String licensePlates);
        void ViewVehicle(string licensePlates);
        void ViewVehicle();
    }
}
