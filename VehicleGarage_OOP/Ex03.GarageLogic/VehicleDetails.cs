using System;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleDetails
    {
        private string m_OwnersName;
        private string m_OwnersPhoneNumber;
        private Vehicle m_CurrentVehicle;
        private EVehicleStatus m_VehicleStatus;

        public string OwnersPhoneNumber { get => m_OwnersPhoneNumber; set => m_OwnersPhoneNumber = value; }

        public Vehicle Vehicle { get => m_CurrentVehicle; set => m_CurrentVehicle = value; }

        public EVehicleStatus VehicleStatus { get => m_VehicleStatus; set => m_VehicleStatus = value; }

        public string OwnersName { get => m_OwnersName; set => m_OwnersName = value; }

        public enum EVehicleStatus
        {
            InRepair,
            Repaired,
            PaidFor
        }

        internal void SetOwnerDetails(string i_OwnersName, string i_OwnersPhoneNumber)
        {
            OwnersName = i_OwnersName;
            OwnersPhoneNumber = i_OwnersPhoneNumber;
        }

        internal string GetVehicleInfo()
        {
            string wheelDetails = getWheelDetails();
            string vehicleGetEngineInfo = getEngineInfo();
            string vehicleDetails = getVehicleDetails();
            string vehicleInfo = string.Format(
@"*** Displaying info of vehicle with License number - {1} ***
VehicleType: {0}
Model Name: {2}
Owners Name: {3}
Owners Phone-Number: {4}
Vehicle Status: {5}
*** Tire specifications *** {6}
*** Charging details ***
{7}
*** other details ***
{8}",
Vehicle.GetType().Name,
Vehicle.LicenseNumber,
Vehicle.ModelName,
OwnersName,
OwnersPhoneNumber,
VehicleStatus.ToString(),
wheelDetails,
vehicleGetEngineInfo,
vehicleDetails);

            return vehicleInfo;
        }

        private string getEngineInfo()
        {
            StringBuilder EngineInfo = new StringBuilder(string.Empty);
            EngineInfo.Append(Vehicle.Engine.GetType().Name + Environment.NewLine);
            EngineInfo.Append("Remaining energy in percentage: " + Vehicle.RemainingEnergy + "%" + Environment.NewLine);
            EngineInfo.Append("Current amount of energy: " + Vehicle.Engine.CurrentAmountOfEnergy + Environment.NewLine);
            EngineInfo.Append("Maximal amount of energy: " + Vehicle.Engine.MaximalAmountOfEnergy);
            if (Vehicle.Engine is FuelBasedEngine)
            {
                EngineInfo.Append(Environment.NewLine + "Fuel type: " + (Vehicle.Engine as FuelBasedEngine).FuelType);
            }

            return EngineInfo.ToString();
        }

        private string getWheelDetails()
        {
            StringBuilder WheelDetails = new StringBuilder(string.Empty);
            foreach (Wheel wheel in Vehicle.Wheels)
            {
                WheelDetails.Append(Environment.NewLine);
                WheelDetails.Append("Manufacturer name: " + wheel.ManufacturerName + " | Current AirPressure: " + wheel.AirPressure + " | Maximal AirPressure: " + wheel.MaximalAirPressure);
            }

            return WheelDetails.ToString();
        }

        private string getVehicleDetails()
        {
            StringBuilder vehicleDetails = new StringBuilder(string.Empty);
            MemberInfo[] myMemberInfo;
            Type myType = Vehicle.GetType();
            myMemberInfo = myType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (MemberInfo mi in myMemberInfo)
            {
                vehicleDetails.Append(mi.Name + ": " + ((PropertyInfo)mi).GetValue(Vehicle, null));
                vehicleDetails.Append(Environment.NewLine);
            }

            return vehicleDetails.ToString();
        }
    }
}
