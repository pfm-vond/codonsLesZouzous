namespace MeasurementUnit.InternationalSystem
{
    using Lengths;

    public static class ForLength
    {
        public static MetreFactory Base { get; } = new MetreFactory();
        public static LengthFactory In<ScaleUnit>() where ScaleUnit : Factor<UnitOfLength> => new LengthFactory<ScaleUnit>();
    }
}
