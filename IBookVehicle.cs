using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental
{
    interface IBookVehicle
    {
        Vehicle BookVehicle(string licensePlates);
        Vehicle BookVehicle(TypeVehicle typeVehicle);
        Vehicle BookVehicle(int pricestart, int priceend, TypeVehicle typeVehicle);
        Vehicle BookVehicle(int price, TypeVehicle typeVehicle);
    }
}
