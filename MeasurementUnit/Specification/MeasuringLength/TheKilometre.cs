namespace MeasurementUnit.MeasuringLength
{
    public class TheKilometre
    {
        [Fact]
        public void is_equal_to_one_thousand_metres()
        {
            InternationalSystem.ForLength.In<Kilo<Meter>>().FromInt(1).Measurement.Should().BeOfType<Kilo<Metre>>();
        }
    }
}
