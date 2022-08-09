using System;

namespace MeasurementUnit.InternationalSystem.Lengths
{
    public class MetreFactory
    {
        public Length FromInt(int measurement)
        {
            return new Length(new Metre(measurement));
        }
    }
}