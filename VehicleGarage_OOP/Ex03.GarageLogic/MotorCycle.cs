using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class MotorCycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        public enum eLicenseType
        {
            A = 1,
            A1,
            B1,
            B2
        }

        public MotorCycle(string i_LicenseNumber) : base(i_LicenseNumber)
        {
        }

        public int EngineVolume { get => m_EngineVolume; set => m_EngineVolume = value; }

        public eLicenseType LicenseType { get => m_LicenseType; set => m_LicenseType = value; }
    }
}
