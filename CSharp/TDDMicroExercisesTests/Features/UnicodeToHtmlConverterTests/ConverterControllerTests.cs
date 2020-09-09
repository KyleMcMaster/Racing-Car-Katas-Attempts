using FluentAssertions;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using TDDMicroExercises;
using TDDMicroExercises.Features.UnicodeTextToHtmlTextConverter;
using TDDMicroExercisesTests.Infrastructure;
using Xunit;

namespace TDDMicroExercisesTests.Features.UnicodeToHtmlConverterTests
{
    public class ConverterControllerTests
    {
        private readonly CustomWebApplicationFactory<Startup> factory;
        private readonly HttpClient client;

        public ConverterControllerTests()
        {
            factory = new CustomWebApplicationFactory<Startup>();

            client = factory.CreateClient();
        }

        [Fact]
        public async void Client_Should_Be_Able_To_Call_Endpoint()
        {
            var factory = new CustomWebApplicationFactory<Startup>();

            var request = new UnicodeTextToHtmlTextRequest
            {
                UnicodeText = string.Empty
            };

            var requestContent = new StringContent(
                content: JsonConvert.SerializeObject(request),
                encoding: Encoding.UTF8,
                mediaType: "application/json");

            var response = await client.PostAsync("/converter", requestContent);

            response.EnsureSuccessStatusCode();
        }

        [Theory]
        [InlineData("&", "&amp;<br />")]
        [InlineData("<", "&lt;<br />")]
        [InlineData(">", "&gt;<br />")]
        [InlineData("\"", "&quot;<br />")]
        [InlineData("\'", "&apos;<br />")]
        public async void Request_With_Unicode_Text_Returns_Valid_Html(
            string unicodeText,
            string expectedValue)
        {
            var request = new UnicodeTextToHtmlTextRequest
            {
                UnicodeText = unicodeText
            };

            var requestContent = new StringContent(
                content: JsonConvert.SerializeObject(request),
                encoding: Encoding.UTF8,
                mediaType: "application/json");

            var response = await client.PostAsync("/converter", requestContent);

            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<HtmlTextResponse>(responseContent);

            result.HtmlText.Should().Be(expectedValue);
        }
    }
}
