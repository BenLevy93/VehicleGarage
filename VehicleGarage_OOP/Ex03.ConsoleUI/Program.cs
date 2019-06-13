using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
using static Ex03.GarageLogic.Car;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            GarageUI Garage = new GarageUI();
            Garage.StartGarage();
        }
    }
}
