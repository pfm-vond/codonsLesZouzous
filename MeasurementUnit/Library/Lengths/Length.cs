using MeasurementUnit.InternationalSystem.Factors;

namespace MeasurementUnit.InternationalSystem.Lengths
{
    public class Length
    {
        public Factor<UnitOfLength> Measurement { get; }

        public Length(UnitOfLength measurement)
        {
            Measurement = new Base<UnitOfLength>(measurement);
        }

        public Length(Factor<UnitOfLength> measurement)
        {
            Measurement = measurement;
        }
    }
}