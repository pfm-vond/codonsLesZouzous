using FizzBuzz.ConsoleApp;
using FluentAssertions;
using System.Text;
using Xunit;

namespace FizzBuzz
{
    public class ReleaseNote
    {
        [Fact]
        public void using_option_note_display_the_list_of_feature()
        {
            StringBuilder output = new();

            Program.OverridenMain(s => output.AppendLine(s), "-notes", "true");

            output.ToString().Should().Be(@"FeatureNotes { FeatureName = defaultBehavior, Description = , Version = 1.0 }
FeatureNotes { FeatureName = fizz, Description = , Version = 2.0 }
FeatureNotes { FeatureName = releasenote, Description = Using parameter 'notes' allow you to display a small feature notes., Version = 3.0 }
");
        }
    }
}
