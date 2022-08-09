namespace MeasurementUnit.InternationalSystem.Lengths
{
    public class LengthFactory<ScaleUnit> where ScaleUnit : Factor<UnitOfLength>, new(UnitOfLength)
    {
        public Length FromInt(int measurement)
        {
            return new Length(new ScaleUnit(new Metre(measurement)));
        }
    }
}