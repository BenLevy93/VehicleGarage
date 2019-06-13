using System;

namespace Ex03.GarageLogic
{
    public class VehiclesCreator
    {
        public enum eSupportedVehicles
        {
            Fuel_Based_Motorcycle = 1,
            Electric_Motorcycle,
            Fuel_Based_Car,
            Electric_Car,
            Fuel_Based_Truck,
        }

        public static Vehicle createVehicle(string i_SupportedVehicleNumber, string i_LicenseNumber)
        {
            Vehicle VehicleToReturn = null;
            int supportedVehicleNumber = int.Parse(i_SupportedVehicleNumber);
            switch (supportedVehicleNumber)
            {
                case 1:
                    VehicleToReturn = CreateFuelBasedMotorCycle(i_LicenseNumber);
                    break;
                case 2:
                    VehicleToReturn = CreateElectricMotorCycle(i_LicenseNumber);
                    break;
                case 3:
                    VehicleToReturn = CreateFuelBasedCar(i_LicenseNumber);
                    break;
                case 4:
                    VehicleToReturn = CreateElectricCar(i_LicenseNumber);
                    break;
                case 5:
                    VehicleToReturn = CreateFuelBasedTruck(i_LicenseNumber);
                    break;
                default:
                    throw new ArgumentException();
            }

            return VehicleToReturn;
        }

        /* 2 tires with max air pressure of 30 (psi), Octane 96 (fuel), 6 liters fuel tank */
        public static MotorCycle CreateFuelBasedMotorCycle(string i_LicenseNumber)
        {
            MotorCycle MotorCycleToReturn = createMotorCycle(i_LicenseNumber);
            MotorCycleToReturn.Engine = new FuelBasedEngine(FuelBasedEngine.eFuelType.Octane96)
            {
                MaximalAmountOfEnergy = 6
            };

            return MotorCycleToReturn;
        }

        /* 2 tires with max air pressure of 30 (psi), Max battery life – 1.8 hours */
        public static MotorCycle CreateElectricMotorCycle(string i_LicenseNumber)
        {
            MotorCycle MotorCycleToReturn = createMotorCycle(i_LicenseNumber);
            MotorCycleToReturn.Engine = new ElectricBasedEngine
            {
                MaximalAmountOfEnergy = 1.8f * 60
            };

            return MotorCycleToReturn;
        }

        /* 4 tires with max air pressure of 32 (psi), Octane 98 fuel, 45 liter fuel tank */
        public static Car CreateFuelBasedCar(string i_LicenseNumber)
        {
            Car CarToReturn = createCar(i_LicenseNumber);
            CarToReturn.Engine = new FuelBasedEngine(FuelBasedEngine.eFuelType.Octane98)
            {
                MaximalAmountOfEnergy = 45
            };

            return CarToReturn;
        }

        /* 4 tires with max air pressure of 32 (psi), Max battery life – 3.2 hours */
        public static Car CreateElectricCar(string i_LicenseNumber)
        {
            Car CarToReturn = createCar(i_LicenseNumber);
            CarToReturn.Engine = new ElectricBasedEngine
            {
                MaximalAmountOfEnergy = 3.2f * 60
            };

            return CarToReturn;
        }

        /* 12 tires with max air pressure of 28 (psi), Octane 96 fuel, 115 liter fuel tank */
        public static Truck CreateFuelBasedTruck(string i_LicenseNumber)
        {
            Truck TruckToReturn = new Truck(i_LicenseNumber);
            createTires(12, 28, TruckToReturn);
            TruckToReturn.Engine = new FuelBasedEngine(FuelBasedEngine.eFuelType.Octane96)
            {
                MaximalAmountOfEnergy = 115
            };

            return TruckToReturn;
        }

        private static void createTires(int i_NumOfTires, int i_MaxAirPressure, Vehicle io_Vehicle)
        {
            for (int i = 0; i < i_NumOfTires; i++)
            {
                Wheel wheel = new Wheel(i_MaxAirPressure);
                io_Vehicle.insertWheel(wheel);
            }
        }

        private static MotorCycle createMotorCycle(string i_LicenseNumber)
        {
            MotorCycle MotorCycleToReturn = new MotorCycle(i_LicenseNumber);
            createTires(2, 30, MotorCycleToReturn);

            return MotorCycleToReturn;
        }

        private static Car createCar(string i_LicenseNumber)
        {
            Car CarToReturn = new Car(i_LicenseNumber);
            createTires(4, 32, CarToReturn);

            return CarToReturn;
        }

        public static bool IsSupportedVehicleNumber(string i_Input)
        {
            int inputNumber = 0;
            int numberOfSupportedVehicles = Enum.GetNames(typeof(eSupportedVehicles)).Length;

            return int.TryParse(i_Input, out inputNumber) && inputNumber >= 1 && inputNumber <= numberOfSupportedVehicles;
        }
    }
}
