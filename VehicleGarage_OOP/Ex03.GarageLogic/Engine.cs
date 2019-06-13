namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private float m_CurrentAmountOfEnergy;
        private float m_MaximalAmountOfEnergy;

        public float CurrentAmountOfEnergy { get => m_CurrentAmountOfEnergy; set => m_CurrentAmountOfEnergy = value; }

        public float MaximalAmountOfEnergy { get => m_MaximalAmountOfEnergy; set => m_MaximalAmountOfEnergy = value; }

        public void Refuel(float i_AmountToFill)
        {
            float fueledTank = CurrentAmountOfEnergy + i_AmountToFill;
            if (fueledTank < 0 || fueledTank > MaximalAmountOfEnergy)
            {
                throw new ValueOutOfRangeException(0, MaximalAmountOfEnergy - m_CurrentAmountOfEnergy, i_AmountToFill);
            }
            else
            {
                CurrentAmountOfEnergy = fueledTank;
            }
        }
    }
}
