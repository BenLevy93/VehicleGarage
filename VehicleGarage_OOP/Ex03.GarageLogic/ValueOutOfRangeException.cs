using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, float i_UserValue)
            : base(string.Format("an error occured while you entered {0}, please notice that the min-value is {1} and the max value is {2}", i_UserValue, i_MinValue, i_MaxValue))
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }

        public float MaxValue { get => m_MaxValue; }

        public float MinValue { get => m_MinValue; }
    }
}
