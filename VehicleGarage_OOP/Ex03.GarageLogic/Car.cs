using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eColor m_Color;
        private eNumOfDoors m_NumOfDoors;

        public enum eColor
        {
            Grey = 1,
            Blue,
            White,
            Black
        }

        public enum eNumOfDoors
        {
            Two = 2,
            Three,
            Four,
            Five,
        }

        public Car(string i_LicenseNumber) : base(i_LicenseNumber)
        {
        }

        public eNumOfDoors NumOfDoors { get => m_NumOfDoors; set => m_NumOfDoors = value; }

        public eColor Color { get => m_Color; set => m_Color = value; }
    }
}
