namespace MeasuringLength
{
    public class TheMetre
    {
        [Fact]
        public void is_the_base_unit_of_length_in_the_international_system_of_units()
        {
            InternationalSystem.ForLength.Base.FromInt(1).Measurement.Should().BeOfType<Metre>();
        }

        [Fact]
        public void has_for_symbol_m_in_the_international_system_of_units()
        {
            InternationalSystem.ForLength.Base.FromInt(1).Measurement.Symbol.Should().Be("m");
        }
    }
}
