using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_CarriesDangerousMaterials;
        private float m_VolumeOfCargo;

        public Truck(string i_LicenseNumber)
            : base(i_LicenseNumber)
        {
        }

        public bool CarriesDangerousMaterials { get => m_CarriesDangerousMaterials; set => m_CarriesDangerousMaterials = value; }

        public float VolumeOfCargo { get => m_VolumeOfCargo; set => m_VolumeOfCargo = value; }
    }
}