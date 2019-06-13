using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, VehicleDetails> m_VehiclesList;

        public Dictionary<string, VehicleDetails> VehiclesList { get => m_VehiclesList; set => m_VehiclesList = value; }

        public Garage()
        {
            VehiclesList = new Dictionary<string, VehicleDetails>();
        }

        /**
         * inserts a new vehicle into the garage,
         * user will be asked to select a vehicle type out of the supported vehicle types
         * and to input the license number of the vehicle.
         * if the vehicle is already in the garage (based on license number)
         * the system will display an appropriate message and will use the existing vehicle
         * and will change the existing vehicle state to In Repair,
         * otherwise create a new vehicle object and the user will be prompted to input the values for the properties of his vehicle,
         * according to the type of vehicle he wishes to add. 
         * */
        public void Insert(Vehicle i_Vehicle)
        {
            VehicleDetails VehicleDetails = new VehicleDetails
            {
                Vehicle = i_Vehicle
            };

            VehicleDetails.VehicleStatus = VehicleDetails.EVehicleStatus.InRepair;
            VehiclesList.Add(i_Vehicle.LicenseNumber, VehicleDetails);
        }

        public void SetOwnerDetails(string i_LicenseNumber, string i_OwnersName, string i_OwnersPhoneNumber)
        {
            VehiclesList[i_LicenseNumber].SetOwnerDetails(i_OwnersName, i_OwnersPhoneNumber);
        }

        /* Display a list of license numbers currently in the garage */
        public string[] DisplayAll()
        {
            string[] licenseNumbers = new string[VehiclesList.Count];
            int i = 0;

            foreach(KeyValuePair<string, VehicleDetails> pair in VehiclesList)
            {
                licenseNumbers[i++] = pair.Key;
            }

            return licenseNumbers;
        }

        private string[] displayLicensesWithStatus(VehicleDetails.EVehicleStatus i_Status)
        {
            string[] licenseNumbers = new string[VehiclesList.Count];
            int i = 0;
            foreach (KeyValuePair<string, VehicleDetails> pair in VehiclesList)
            {
                if (pair.Value.VehicleStatus == i_Status)
                {
                    licenseNumbers[i++] = pair.Key;
                }
            }

            return licenseNumbers;
        }

        /* Display a list of license numbers currently in repair */
        public string[] DisplayInRepair()
        {
            return displayLicensesWithStatus(VehicleDetails.EVehicleStatus.InRepair);
        }

        public string[] DisplayRepaired()
        {
            return displayLicensesWithStatus(VehicleDetails.EVehicleStatus.Repaired);
        }

        public string[] DisplayPaid()
        {
            return displayLicensesWithStatus(VehicleDetails.EVehicleStatus.PaidFor);
        }

        /* Inflate tires to maximum (Prompting the user for the license number) */
        public void InflateToMaximum(string i_LicenseNumber)
        {
            if(Contains(i_LicenseNumber))
            {
                Vehicle VehicleToFuel = VehiclesList[i_LicenseNumber].Vehicle;
                VehicleToFuel.inflateWheelsToMaximum();
            }
            else
            {
                throw new ArgumentException("Vehicle does not exist");
            }
        }

        /* Refuel a fuel-based vehicle (Prompting the user for the license number, fuel type and amount to fill) */
        public void Refuel(string i_LicenseNumber, FuelBasedEngine.eFuelType i_FuelType, float i_AmountToFill)
        {
            Vehicle VehicleToFuel = VehiclesList[i_LicenseNumber].Vehicle;
            if (!(VehicleToFuel.Engine is FuelBasedEngine) || (VehicleToFuel.Engine as FuelBasedEngine).FuelType != i_FuelType)
            {
                throw new ArgumentException("Vehicle is not FuelBased or FuelType is wrong");
            }
            else
            {
                VehicleToFuel.Refuel(i_AmountToFill);
            }
        }

        /* Charge an electric-based vehicle (Prompting the user for the license number and number of minutes to charge) */
        public void Charge(string i_LicenseNumber,  float i_AmountToFill)
        {
            if (Contains(i_LicenseNumber))
            {
                Vehicle VehicleToFuel = VehiclesList[i_LicenseNumber].Vehicle;
                if (!(VehicleToFuel.Engine is ElectricBasedEngine))
                {
                    throw new ArgumentException("Vehicle is not ElectricBased");
                }
                else
                {
                    VehicleToFuel.Refuel(i_AmountToFill);
                }
            }
            else
            {
                throw new ArgumentException("Vehicle does not exist");
            }
        }

        /* Display vehicle information (License number, Model name, Owner name, Status in garage,
         * Tire specifications (manufacturer and air pressure), Fuel status + Fuel type / Battery status,
         * other relevant information based on vehicle type) */
         public string DisplayVehicleInformation(string i_LicenseNumber)
        {
            return VehiclesList[i_LicenseNumber].GetVehicleInfo();
        }

        public bool Contains(string i_LicenseNumber)
        {
            return VehiclesList.ContainsKey(i_LicenseNumber);
        }

        /* Change a certain vehicle’s status (Prompting the user for the license number and new desired status) */
        public void SetDefaultState(string i_LicenseNumber)
        {
            VehiclesList[i_LicenseNumber].VehicleStatus = VehicleDetails.EVehicleStatus.InRepair;
        }

        public void SetRepairedState(string i_LicenseNumber)
        {
            VehiclesList[i_LicenseNumber].VehicleStatus = VehicleDetails.EVehicleStatus.Repaired;
        }

        public void SetPaidState(string i_LicenseNumber)
        {
            VehiclesList[i_LicenseNumber].VehicleStatus = VehicleDetails.EVehicleStatus.PaidFor;
        }

        public bool CanRefuel(float i_AddLiters, string i_LicenseNum)
        {
            Vehicle VehicleToCheck = VehiclesList[i_LicenseNum].Vehicle;
            bool canRefuel = false;
            float fueledTank = VehicleToCheck.Engine.CurrentAmountOfEnergy + i_AddLiters;
            if (fueledTank <= VehicleToCheck.Engine.MaximalAmountOfEnergy && fueledTank > 0)
            {
                canRefuel = true;
            }
            else
            {
                throw new ValueOutOfRangeException(0, VehicleToCheck.Engine.MaximalAmountOfEnergy, i_AddLiters);
            }

            return canRefuel;
        }

        public bool IsFuelBased(string i_LicenseNum)
        {
            Vehicle VehicleToCheck = VehiclesList[i_LicenseNum].Vehicle;

            return VehicleToCheck.Engine is FuelBasedEngine;
        }

        public bool IsElectricBased(string i_LicenseNum)
        {
            Vehicle VehicleToCheck = VehiclesList[i_LicenseNum].Vehicle;

            return VehicleToCheck.Engine is ElectricBasedEngine;
        }
    }
}
