using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace CarRental
{
    class Management : IBookVehicle, IVehicleManagement, IService, IContractManagement
    {
        private List<Vehicle> listvehicle = null;
        private List<Garage> listgarage = null;
        private List<Contract> listcontract = null;
        private List<ServiceHistory> listservicehistory = null;

        public Management()
        {
            this.listcontract = new List<Contract>();
            this.listgarage = new List<Garage>();
            this.listservicehistory = new List<ServiceHistory>();
            this.listvehicle = new List<Vehicle>();
        }

        public Management(List<Vehicle> listvehicle, List<Garage> listgarage, List<Contract> listcontract, List<ServiceHistory> listservicehistory)
        {
            this.listvehicle = listvehicle;
            this.listgarage = listgarage;
            this.listcontract = listcontract;
            this.listservicehistory = listservicehistory;
        }

        internal List<Vehicle> Listvehicle { get => listvehicle; set => listvehicle = value; }
        internal List<Garage> Listgarage { get => listgarage; set => listgarage = value; }
        internal List<Contract> Listcontract { get => listcontract; set => listcontract = value; }
        internal List<ServiceHistory> Listservicehistory { get => listservicehistory; set => listservicehistory = value; }

        // ========================================= Contract Management ===========================================================
        public void AddContract(Contract contract)
        {
            this.listcontract.Add(contract);
        }

        public bool AddContract(string contractid, string licensePlates, Customer customer, string startDate, string endDate, int cost, string payments, TypePayment typepayment, TypeRent typeRent)
        {
            Vehicle vehicle = this.BookVehicle(licensePlates);
            if (vehicle == null)
                return false;
            Contract contract = new Contract(contractid, vehicle.LicensePlates, customer, startDate, endDate, cost, payments, typepayment, typeRent);
            this.listcontract.Add(contract);
            return true;
        }

        public bool AddContract(string contractid, TypeVehicle typeVehicle, Customer customer, string startDate, string endDate, int cost, string payments, TypePayment typepayment, TypeRent typeRent)
        {
            Vehicle vehicle = this.BookVehicle(typeVehicle);
            if (vehicle == null)
                return false;
            Contract contract = new Contract(contractid, vehicle.LicensePlates, customer, startDate, endDate, cost, payments, typepayment, typeRent);
            this.listcontract.Add(contract);
            return true;
        }

        public bool AddContract(string contractid, int pricestart, int priceend, TypeVehicle typeVehicle, Customer customer, string startDate, string endDate, int cost, string payments, TypePayment typepayment, TypeRent typeRent)
        {
            Vehicle vehicle = this.BookVehicle(pricestart, priceend, typeVehicle);
            if (vehicle == null)
                return false;
            Contract contract = new Contract(contractid, vehicle.LicensePlates, customer, startDate, endDate, cost, payments, typepayment, typeRent);
            this.listcontract.Add(contract);
            return true;
        }

        public bool AddContract(string contractid, int price, TypeVehicle typeVehicle, Customer customer, string startDate, string endDate, int cost, string payments, TypePayment typepayment, TypeRent typeRent)
        {
            Vehicle vehicle = this.BookVehicle(price, typeVehicle);
            if (vehicle == null)
                return false;
            Contract contract = new Contract(contractid, vehicle.LicensePlates, customer, startDate, endDate, cost, payments, typepayment, typeRent);
            this.listcontract.Add(contract);
            return true;
        }

        public void RemoveContract(string contractid)
        {
            foreach (Contract contract in this.listcontract)
            {
                if (contract.Contractid == contractid)
                {
                    foreach (Vehicle vehicle in this.listvehicle)
                    {
                        if (vehicle.LicensePlates == contract.LicensePlates)
                        {
                            vehicle.Status = TypeStatusVehicle.normal;
                            break;
                        }
                    }
                    this.listcontract.Remove(contract);
                    break;
                }
            }
        }

        public void RemoveContract(Contract contract)
        {
            this.listcontract.Remove(contract);
        }
        public void viewContact(string contractid)
        {
            foreach (Contract contract in this.listcontract)
                if (contract.Contractid == contractid)
                {
                    byte[] jsonUtf8Bytes;
                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true
                    };
                    jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(this.Listcontract, options);
                    string jsonString;
                    jsonString = JsonSerializer.Serialize(this.Listcontract, options);
                    Console.WriteLine(jsonString);
                    break;
                }
        }
        public void viewContact()
        {
            byte[] jsonUtf8Bytes;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(this.Listcontract, options);
            string jsonString;
            jsonString = JsonSerializer.Serialize(this.Listcontract, options);
            Console.WriteLine(jsonString);
        }

        // ========================================= Vehicle Management ===========================================================
        public void AddVehicle(Vehicle vehicle)
        {
            this.listvehicle.Add(vehicle);
        }

        public void AddVehicle(Car car)
        {
            this.listvehicle.Add(car);
        }

        public void AddVehicle(Moto moto)
        {
            this.listvehicle.Add(moto);
        }

        public void AddVehicle(Truck truck)
        {
            this.listvehicle.Add(truck);
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            this.listvehicle.Remove(vehicle);
        }

        public void RemoveVehicle(string licensePlates)
        {
            foreach (Vehicle vehicle in this.listvehicle)
            {
                if (vehicle.LicensePlates == licensePlates)
                {
                    this.listvehicle.Remove(vehicle);
                    break;
                }
            }
        }
        public void UpdateVehicle(string licensePlates, Vehicle vehicle)
        {
            foreach (Vehicle veh in this.listvehicle)
            {
                if (veh.LicensePlates == licensePlates)
                {
                    this.listvehicle.Remove(veh);
                    this.listvehicle.Add(vehicle);
                    break;
                }
            }
        }
        public void ViewVehicle(string licensePlates)
        {
            foreach (Vehicle vehicle in this.listvehicle)
                if (vehicle.LicensePlates == licensePlates)
                {
                    byte[] jsonUtf8Bytes;
                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true
                    };
                    jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(vehicle, options);
                    string jsonString;
                    jsonString = JsonSerializer.Serialize(vehicle, options);
                    Console.WriteLine(jsonString);
                    break;
                }
        }
        public void ViewVehicle()
        {
            byte[] jsonUtf8Bytes;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(this.listvehicle, options);
            string jsonString;
            jsonString = JsonSerializer.Serialize(this.listvehicle, options);
            Console.WriteLine(jsonString);
        }

        // ========================================= Service ===========================================================
        public void serviceEngineCar(Car car, string garageid, int mileage, string date, int cost)
        {
            foreach (Garage garage in this.listgarage)
            {
                if (garage.Garageid == garageid)
                {
                    garage.Numofvehicle++;
                    break;
                }
            }
            car.Status = TypeStatusVehicle.repaired;
            ServiceHistory service = new ServiceHistory(this.listservicehistory.Count + 1, car.LicensePlates, garageid, mileage, date, TypeService.Engine, cost);
            this.listservicehistory.Add(service);
        }

        public void serviceEngineMoto(Moto moto, string garageid, int mileage, string date, int cost)
        {
            foreach (Garage garage in this.listgarage)
            {
                if (garage.Garageid == garageid)
                {
                    garage.Numofvehicle++;
                    break;
                }
            }
            moto.Status = TypeStatusVehicle.repaired;
            ServiceHistory service = new ServiceHistory(this.listservicehistory.Count + 1, moto.LicensePlates, garageid, mileage, date, TypeService.Engine, cost);
            this.listservicehistory.Add(service);
        }

        public void serviceEngineTruck(Truck truck, string garageid, int mileage, string date, int cost)
        {
            foreach (Garage garage in this.listgarage)
            {
                if (garage.Garageid == garageid)
                {
                    garage.Numofvehicle++;
                    break;
                }
            }
            truck.Status = TypeStatusVehicle.repaired;
            ServiceHistory service = new ServiceHistory(this.listservicehistory.Count + 1, truck.LicensePlates, garageid, mileage, date, TypeService.Engine, cost);
            this.listservicehistory.Add(service);
        }

        public void serviceTiresCar(Car car, string garageid, int mileage, string date, int cost)
        {
            foreach (Garage garage in this.listgarage)
            {
                if (garage.Garageid == garageid)
                {
                    garage.Numofvehicle++;
                    break;
                }
            }
            car.Status = TypeStatusVehicle.repaired;
            ServiceHistory service = new ServiceHistory(this.listservicehistory.Count + 1, car.LicensePlates, garageid, mileage, date, TypeService.Tires, cost);
            this.listservicehistory.Add(service);
        }

        public void serviceTiresMoto(Moto moto, string garageid, int mileage, string date, int cost)
        {
            foreach (Garage garage in this.listgarage)
            {
                if (garage.Garageid == garageid)
                {
                    garage.Numofvehicle++;
                    break;
                }
            }
            moto.Status = TypeStatusVehicle.repaired;
            ServiceHistory service = new ServiceHistory(this.listservicehistory.Count + 1, moto.LicensePlates, garageid, mileage, date, TypeService.Tires, cost);
            this.listservicehistory.Add(service);
        }

        public void serviceTiresTruck(Truck truck, string garageid, int mileage, string date, int cost)
        {
            foreach (Garage garage in this.listgarage)
            {
                if (garage.Garageid == garageid)
                {
                    garage.Numofvehicle++;
                    break;
                }
            }
            truck.Status = TypeStatusVehicle.repaired;
            ServiceHistory service = new ServiceHistory(this.listservicehistory.Count + 1, truck.LicensePlates, garageid, mileage, date, TypeService.Tires, cost);
            this.listservicehistory.Add(service);
        }

        public void serviceTransmissionCar(Car car, string garageid, int mileage, string date, int cost)
        {
            foreach (Garage garage in this.listgarage)
            {
                if (garage.Garageid == garageid)
                {
                    garage.Numofvehicle++;
                    break;
                }
            }
            car.Status = TypeStatusVehicle.repaired;
            ServiceHistory service = new ServiceHistory(this.listservicehistory.Count + 1, car.LicensePlates, garageid, mileage, date, TypeService.Transmission, cost);
            this.listservicehistory.Add(service);
        }
        
        public void serviceTransmissionMoto(Moto moto, string garageid, int mileage, string date, int cost)
        {
            foreach (Garage garage in this.listgarage)
            {
                if (garage.Garageid == garageid)
                {
                    garage.Numofvehicle++;
                    break;
                }
            }
            moto.Status = TypeStatusVehicle.repaired;
            ServiceHistory service = new ServiceHistory(this.listservicehistory.Count + 1, moto.LicensePlates, garageid, mileage, date, TypeService.Transmission, cost);
            this.listservicehistory.Add(service);
        }

        public void serviceTransmissionTruck(Truck truck, string garageid, int mileage, string date, int cost)
        {
            foreach (Garage garage in this.listgarage)
            {
                if (garage.Garageid == garageid)
                {
                    garage.Numofvehicle++;
                    break;
                }
            }
            truck.Status = TypeStatusVehicle.repaired;
            ServiceHistory service = new ServiceHistory(this.listservicehistory.Count + 1, truck.LicensePlates, garageid, mileage, date, TypeService.Transmission, cost);
            this.listservicehistory.Add(service);
        }
        public void serviceOilChangeTruck(Truck truck, string garageid, int mileage, string date, int cost)
        {
            foreach (Garage garage in this.listgarage)
            {
                if (garage.Garageid == garageid)
                {
                    garage.Numofvehicle++;
                    break;
                }
            }
            truck.Status = TypeStatusVehicle.repaired;
            ServiceHistory service = new ServiceHistory(this.listservicehistory.Count + 1, truck.LicensePlates, garageid, mileage, date, TypeService.oilChange, cost);
            this.listservicehistory.Add(service);
        }
        public void serviceOilChangeCar(Car car, string garageid, int mileage, string date, int cost)
        {
            foreach (Garage garage in this.listgarage)
            {
                if (garage.Garageid == garageid)
                {
                    garage.Numofvehicle++;
                    break;
                }
            }
            car.Status = TypeStatusVehicle.repaired;
            ServiceHistory service = new ServiceHistory(this.listservicehistory.Count + 1, car.LicensePlates, garageid, mileage, date, TypeService.oilChange, cost);
            this.listservicehistory.Add(service);
        }
        public void serviceOilChangeMoto(Moto moto, string garageid, int mileage, string date, int cost)
        {
            foreach(Garage garage in this.listgarage)
            {
                if(garage.Garageid == garageid)
                {
                    garage.Numofvehicle++;
                    break;
                }
            }
            moto.Status = TypeStatusVehicle.repaired;
            ServiceHistory service = new ServiceHistory(this.listservicehistory.Count + 1, moto.LicensePlates, garageid, mileage, date, TypeService.oilChange, cost);
            this.listservicehistory.Add(service);
        }
        public void serviceFleet(string garageid, int mileage, string date, int cost)
        {
            foreach (Vehicle vehicle in this.listvehicle)
            {
                if (vehicle.TypeVehicle == TypeVehicle.Car)
                {
                    if (vehicle.Mileage >= ConstantKm.engineCarKm)
                        this.serviceEngineCar((Car)vehicle, garageid, vehicle.Mileage, date, cost);
                    else if(vehicle.Mileage >= ConstantKm.tiresCarKm)
                        this.serviceTiresCar((Car)vehicle, garageid, vehicle.Mileage, date, cost);
                    else if (vehicle.Mileage >= ConstantKm.oilChangeCarKm)
                        this.serviceOilChangeCar((Car)vehicle, garageid, vehicle.Mileage, date, cost);
                }
                else if(vehicle.TypeVehicle == TypeVehicle.Moto)
                {
                    if (vehicle.Mileage >= ConstantKm.engineMotoKm)
                        this.serviceEngineMoto((Moto)vehicle, garageid, vehicle.Mileage, date, cost);
                    else if (vehicle.Mileage >= ConstantKm.tiresMotoKm)
                        this.serviceTiresMoto((Moto)vehicle, garageid, vehicle.Mileage, date, cost);
                    else if (vehicle.Mileage >= ConstantKm.oilChangeMotoKm)
                        this.serviceOilChangeMoto((Moto)vehicle, garageid, vehicle.Mileage, date, cost);
                }
                else if (vehicle.TypeVehicle == TypeVehicle.Truck)
                {
                    if (vehicle.Mileage >= ConstantKm.engineTruckKm)
                        this.serviceEngineTruck((Truck)vehicle, garageid, vehicle.Mileage, date, cost);
                    else if (vehicle.Mileage >= ConstantKm.tiresTruckKm)
                        this.serviceTiresTruck((Truck)vehicle, garageid, vehicle.Mileage, date, cost);
                    else if (vehicle.Mileage >= ConstantKm.oilChangeTruckKm)
                        this.serviceOilChangeTruck((Truck)vehicle, garageid, vehicle.Mileage, date, cost);
                }
            }
        }
        public void endService(int serviceid)
        {
            foreach(ServiceHistory service in this.listservicehistory)
                if(service.Serviceid == serviceid)
                {
                    foreach(Vehicle vehicle in this.listvehicle)
                        if(vehicle.LicensePlates == service.LicensePlates)
                            vehicle.Status = TypeStatusVehicle.normal;
                    foreach(Garage garage in this.listgarage)
                        if (garage.Garageid == service.Garageid)
                            garage.Numofvehicle--;
                    break;
                }
        }
        public void printService()
        {
            byte[] jsonUtf8Bytes;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(this.listservicehistory, options);
            string jsonString;
            jsonString = JsonSerializer.Serialize(this.listservicehistory, options);
            Console.WriteLine(jsonString);
        }
        public void printService(string licensePlates)
        {
            List<ServiceHistory> save = new List<ServiceHistory>();
            foreach (ServiceHistory service in this.listservicehistory)
                if (service.LicensePlates == licensePlates)
                    save.Add(service);
            byte[] jsonUtf8Bytes;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(save, options);
            string jsonString;
            jsonString = JsonSerializer.Serialize(save, options);
            Console.WriteLine(jsonString);
        }
        public void saveJsonService()
        {
            byte[] jsonUtf8Bytes;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(this.listservicehistory, options);
            string jsonString;
            jsonString = JsonSerializer.Serialize(this.listservicehistory, options);
            File.WriteAllText("AllService.json", jsonString);
        }
        public void saveJsonService(string licensePlates)
        {
            List<ServiceHistory> save = new List<ServiceHistory>();
            foreach (ServiceHistory service in this.listservicehistory)
                if (service.LicensePlates == licensePlates)
                    save.Add(service);
            byte[] jsonUtf8Bytes;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(save, options);
            string jsonString;
            jsonString = JsonSerializer.Serialize(save, options);
            File.WriteAllText("ServiceVehicle.json", jsonString);
        }

        // ========================================= Book Vehicle ===========================================================

        public Vehicle BookVehicle(string licensePlates)
        {
            foreach (Vehicle vehicle in this.listvehicle)
            {
                if (vehicle.LicensePlates == licensePlates && vehicle.Status == TypeStatusVehicle.normal)
                {
                    vehicle.Status = TypeStatusVehicle.hired;
                    return vehicle;
                }
            }
            return null;
        }

        public Vehicle BookVehicle(TypeVehicle typeVehicle)
        {
            foreach (Vehicle vehicle in this.listvehicle)
            {
                if (vehicle.TypeVehicle == typeVehicle && vehicle.Status == TypeStatusVehicle.normal)
                {
                    vehicle.Status = TypeStatusVehicle.hired;
                    return vehicle;
                }
            }
            return null;
        }

        public Vehicle BookVehicle(int pricestart, int priceend, TypeVehicle typeVehicle)
        {
            foreach (Vehicle vehicle in this.listvehicle)
            {
                if (vehicle.TypeVehicle == typeVehicle && vehicle.Price >= pricestart && vehicle.Price <= priceend && vehicle.Status == TypeStatusVehicle.normal)
                {
                    vehicle.Status = TypeStatusVehicle.hired;
                    return vehicle;
                }
            }
            return null;
        }

        public Vehicle BookVehicle(int price, TypeVehicle typeVehicle)
        {
            foreach (Vehicle vehicle in this.listvehicle)
            {
                if (vehicle.TypeVehicle == typeVehicle && vehicle.Price <= price && vehicle.Status == TypeStatusVehicle.normal)
                {
                    vehicle.Status = TypeStatusVehicle.hired;
                    return vehicle;
                }
            }
            return null;
        }

        // ========================================= Vehicle Management ===========================================================

        public void addGarage(Garage garage)
        {
            this.listgarage.Add(garage);
        }
        public void addGarage(string garageid, string status, string type, string address, int numofvehicle)
        {
            this.listgarage.Add(new Garage(garageid, status, type, address, numofvehicle));
        }
        public void removeGarage(string garageid)
        {
            foreach(Garage garage in this.listgarage)
                if(garage.Garageid == garageid)
                {
                    this.listgarage.Remove(garage);
                    break;
                }
        }
        public void viewGarage()
        {
            byte[] jsonUtf8Bytes;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(this.listgarage, options);
            string jsonString;
            jsonString = JsonSerializer.Serialize(this.listgarage, options);
            Console.WriteLine(jsonString);
        }
    }
}

