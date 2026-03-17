using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    class Vehicle
    {
        public int VechileNumber;
        public string Brand ;

        public void StartVehicle()
        {
            Console.WriteLine("Vehicle Started");
        }
    }
    class Car : Vehicle
    {
        public string FuelType;
    }

    class Bike : Vehicle
    {
        public int EngineCapacity;
    }

    sealed class ElectricCar : Car
    {

    }
  /*  class Tesla : ElectricCar
    {
        //cause compile Time Error
    }*/
}
