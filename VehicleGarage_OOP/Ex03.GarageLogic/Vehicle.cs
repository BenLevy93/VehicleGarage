using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_RemainingEnergyPercentage;
        private List<Wheel> m_Wheels;
        private Engine m_Engine;

        public Vehicle(string i_LicenseNumber)
        {
            LicenseNumber = i_LicenseNumber;
            Wheels = new List<Wheel>();
        }

        public float RemainingEnergy { get => m_RemainingEnergyPercentage; set => m_RemainingEnergyPercentage = value; }

        public string LicenseNumber { get => m_LicenseNumber; set => m_LicenseNumber = value; }

        public string ModelName { get => m_ModelName; set => m_ModelName = value; }

        public List<Wheel> Wheels { get => m_Wheels; set => m_Wheels = value; }

        public Engine Engine { get => m_Engine; set => m_Engine = value; }

        /**
         * Refuel a fuel-based vehicle (Prompting the user for the license number, fuel type and amount to fill)
         * or, Charge an electric-based vehicle (Prompting the user for the license number 
         * and number of minutes to charge)  **/
        internal void Refuel(float i_AmountToFill)
        {
            this.Engine.Refuel(i_AmountToFill);
            RemainingEnergy = (this.Engine.CurrentAmountOfEnergy / this.Engine.MaximalAmountOfEnergy) * 100;
        }

        internal void insertWheel(Wheel i_WheelToInsert)
        {
            Wheels.Add(i_WheelToInsert);
        }

        /* Inflate tires to maximum (Prompting the user for the license number) */
        internal void inflateWheelsToMaximum()
        {
            foreach(Wheel wheel in Wheels)
            {
                wheel.InflateToMaximum();
            }
        }

        public void setWheelsManufacturerName(string i_ManufacturerName)
        {
            foreach (Wheel wheel in Wheels)
            {
                wheel.ManufacturerName = i_ManufacturerName;
            }
        }

        public void setWheelsAirPressure(float i_CurrentPressure)
        {
            foreach (Wheel wheel in Wheels)
            {
                wheel.AirPressure = i_CurrentPressure;
            }
        }
    }
}