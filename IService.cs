using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental
{
    interface IService
    {
        void serviceFleet(string garageid, int mileage, string date, int cost);
        void serviceEngineCar(Car car, string garageid, int mileage, string date, int cost);
        void serviceTransmissionCar(Car car, string garageid, int mileage, string date, int cost);
        void serviceTiresCar(Car car, string garageid, int mileage, string date, int cost);
        void serviceOilChangeCar(Car car, string garageid, int mileage, string date, int cost);
        void serviceEngineTruck(Truck truck, string garageid, int mileage, string date, int cost);
        void serviceTransmissionTruck(Truck truck, string garageid, int mileage, string date, int cost);
        void serviceTiresTruck(Truck truck, string garageid, int mileage, string date, int cost);
        void serviceOilChangeTruck(Truck truck, string garageid, int mileage, string date, int cost);
        void serviceEngineMoto(Moto moto, string garageid, int mileage, string date, int cost);
        void serviceTransmissionMoto(Moto moto, string garageid, int mileage, string date, int cost);
        void serviceTiresMoto(Moto moto, string garageid, int mileage, string date, int cost);
        void serviceOilChangeMoto(Moto moto, string garageid, int mileage, string date, int cost);
        void endService(int serviceid);
        void printService();
        void printService(string licensePlates);
        void saveJsonService();
        void saveJsonService(string licensePlates);
    }
}
