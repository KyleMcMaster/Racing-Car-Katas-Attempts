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

            sut.GetUnicodeText().Should().Be(string.Empty);
        }

        [Fact]
        public void Converter_Takes_In_Empty_String_And_Returns_Line_Break()
        {
            var sut = new UnicodeTextToHtmlTextConverter(string.Empty);

            string result = sut.ConvertToHtml();

            result.Should().Be("<br />");
        }

        //[Fact]
        //public void Converter_Takes_In_Null_And_Returns_Line_Break()
        //{
        //    var sut = new UnicodeTextToHtmlTextConverter(null);

        //    string result = sut.ConvertToHtml();

        //    result.Should().Be("<br />");
        //}

        [Fact]
        public void Converter_Takes_In_Ampersand_And_Returns_Html()
        {
            var sut = new UnicodeTextToHtmlTextConverter("&");

            string result = sut.ConvertToHtml();

            result.Should().Be("&amp;<br />");
        }

        [Fact]
        public void Converter_Takes_Closing_Bracket_And_Returns_Html()
        {
            var sut = new UnicodeTextToHtmlTextConverter(">");

            string result = sut.ConvertToHtml();

            result.Should().Be("&gt;<br />");
        }

        [Fact]
        public void Converter_Takes_Open_Bracket_And_Returns_Html()
        {
            var sut = new UnicodeTextToHtmlTextConverter("<");

            string result = sut.ConvertToHtml();

            result.Should().Be("&lt;<br />");
        }

        [Fact]
        public void Converter_Takes_Slashand_DoubleQuote_And_Returns_Html()
        {
            var sut = new UnicodeTextToHtmlTextConverter("\"");

            string result = sut.ConvertToHtml();

            result.Should().Be("&quot;<br />");
        }

        [Fact]
        public void Converter_Takes_Slash_And_Apostrophe_And_Returns_Html()
        {
            var sut = new UnicodeTextToHtmlTextConverter("\'");

            string result = sut.ConvertToHtml();

            result.Should().Be("&apos;<br />");
        }

        [Fact]
        public void Converter_Takes_All_Input_And_Returns_Html()
        {
            var sut = new UnicodeTextToHtmlTextConverter("&<>\"\'");

            string result = sut.ConvertToHtml();

            result.Should().Be("&amp;&lt;&gt;&quot;&apos;<br />");
        }

        [Fact]
        public void Converter_Takes_Arbitrary_Input_And_Returns_Html()
        {
            var sut = new UnicodeTextToHtmlTextConverter("ntg & jdawg");

            string result = sut.ConvertToHtml();

            result.Should().Be("ntg &amp; jdawg<br />");
        }
    }
}