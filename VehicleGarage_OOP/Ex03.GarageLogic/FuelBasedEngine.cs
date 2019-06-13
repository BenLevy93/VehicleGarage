namespace Ex03.GarageLogic
{
    public class FuelBasedEngine : Engine
    {
        private eFuelType m_FuelType;

        public enum eFuelType
        {
            Soler,
            Octane95,
            Octane96,
            Octane98,
        }

        public eFuelType FuelType { get => m_FuelType; }

        public FuelBasedEngine(eFuelType i_FuelType)
        {
            m_FuelType = i_FuelType;
        }
    }
}
