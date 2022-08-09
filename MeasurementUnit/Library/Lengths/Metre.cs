namespace MeasurementUnit.InternationalSystem.Lengths
{
    public class Metre : UnitOfLength
    {
        private int Value;

        public Metre(int value)
        {
            Value = value;
        }

        private const string _m = "m";
        public string Symbol => _m;
    }
}