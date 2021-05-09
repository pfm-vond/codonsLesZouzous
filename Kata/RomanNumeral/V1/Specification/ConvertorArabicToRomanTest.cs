using FluentAssertions;
using Xunit;

namespace RomanNumeral.Specification
{
    public class ConvertorTest
    {
        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        public void The_easiest_way_to_note_down_a_number_is_to_make_that_many_marks_little_I_s(int arabic, string roman)
        {
            var convertor = new Convertor();

            convertor.Convert(arabic).Should().Be(roman);
            convertor.Convert(roman).Should().Be(arabic);

        }

        [Fact]
        public void However_four_strokes_seemed_like_too_many_so_the_romans_moved_on_to_the_symbol_for_5_V()
        {
            var convertor = new Convertor();

            convertor.Convert(5).Should().Be("V");
            convertor.Convert("V").Should().Be(5);

        }

        [Fact]
        public void Placing_I_in_front_of_the_V_or_placing_any_smaller_number_in_front_of_any_larger_number_indicates_subtraction_so_IV_means_4()
        {
            new Convertor().Convert(4).Should().Be("IV");
        }

        [Theory]
        [InlineData(6, "VI")]
        [InlineData(7, "VII")]
        [InlineData(8, "VIII")]
        public void After_V_comes_a_series_of_additions_VI_means_6_VII_means_7_VIII_means_8(int arabic, string roman)
        {
            new Convertor().Convert(arabic).Should().Be(roman);
        }

        [Fact]
        public void X_means_10()
        {
            new Convertor().Convert(10).Should().Be("X");
        }

        [Fact]
        public void But_wait_what_about_9_same_deal_i_x_means_to_subtract_i_from_x_leaving_9()
        {
            new Convertor().Convert(9).Should().Be("IX");
        }

        [Theory]
        [InlineData(31, "XXXI")]
        [InlineData(24, "XXIV")]
        public void Numbers_in_the_teens_twenties_and_thirties_follow_the_same_form_as_the_first_set_only_with_x_s_indicating_the_number_of_tens(
            int arabic,
            string roman)
        {
            new Convertor().Convert(arabic).Should().Be(roman);
        }

        [Fact]
        public void L_means_50()
        {
            new Convertor().Convert(50).Should().Be("L");
        }

        [Fact]
        public void based_on_what_you_ve_learned_i_bet_you_can_figure_out_that_40_is_XL()
        {
            new Convertor().Convert(40).Should().Be("XL");
        }

        [Theory]
        [InlineData(60, "LX")]
        [InlineData(70, "LXX")]
        [InlineData(80, "LXXX")]
        public void And_thus_60_70_and_80_are_LX_LXX_and_LXXX(
            int arabic,
            string roman)
        {
            new Convertor().Convert(arabic).Should().Be(roman);
        }

        [Fact]
        public void C_stands_for_centum_the_latin_word_for_100_a_centurion_led_100_men_we_still_use_this_in_words_like_century_and_cent()
        {
            new Convertor().Convert(100).Should().Be("C");
        }

        [Fact]
        public void The_subtraction_rule_means_90_is_written_as_XC()
        {
            new Convertor().Convert(90).Should().Be("XC");
        }

        [Theory]
        [InlineData(369, "CCCLXIX")]
        public void Like_the_X_s_and_L_s_the_C_s_are_tacked_on_to_the_beginning_of_numbers_to_indicate_how_many_hundreds_there_are(
            int arabic,
            string roman)
        {
            new Convertor().Convert(arabic).Should().Be(roman);
        }

        [Fact]
        public void D_stands_for_500()
        {
            new Convertor().Convert(500).Should().Be("D");
        }

        [Fact]
        public void As_you_can_probably_guess_by_this_time_CD_means_400()
        {
            new Convertor().Convert(400).Should().Be("CD");
        }

        [Theory]
        [InlineData(448, "CDXLVIII")]
        [InlineData(1998, "MCMXCVIII")]
        [InlineData(2751, "MMDCCLI")]
        public void Subtraction_rule_can_be_mixed_with_addition_to_obtain_more_complex_number(
            int arabic,
            string roman)
        {
            new Convertor().Convert(arabic).Should().Be(roman);
            new Convertor().Convert(roman).Should().Be(arabic);
        }

        [Fact]
        public void M_is_1_000_you_see_a_lot_of_Ms_because_roman_numerals_are_used_a_lot_to_indicate_dates()
        {
            new Convertor().Convert(1000).Should().Be("M");
        }
    }
}
