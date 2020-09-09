using FluentAssertions;
using TDDMicroExercises.Features.UnicodeTextToHtmlTextConverter;
using Xunit;

namespace TDDMicroExercisesTests.Features.UnicodeToHtmlConverterTests
{
    public class UnicodeTextToHtmlTextConverterTests
    {
        [Fact]
        public void Constructor_Initialized_Unicode_Text_To_Empty_String()
        {
            var sut = new UnicodeTextToHtmlTextConverter(string.Empty);

            sut.GetUnicodeText().Should().Be(null);
        }
    }
}