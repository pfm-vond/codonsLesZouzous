namespace MeasurementUnit.InternationalSystem
{
    internal class Kilo<T> : Factor<T>
    {
        private T measurement;

        public Kilo(T measurement)
        {
            this.measurement = measurement;
        }
    }
}