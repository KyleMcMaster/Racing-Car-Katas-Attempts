using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace TDDMicroExercises.Features.UnicodeTextToHtmlTextConverter
{
    [ApiController]
    [Route("[controller]")]
    public class ConverterController : ControllerBase
    {
        private readonly ILogger<ConverterController> logger;

        public ConverterController(ILogger<ConverterController> logger) => this.logger = logger;

        [HttpPost()]
        [SwaggerOperation(
            Summary = "Converts a unicode string to html",
            Description = "Takes an input unicode string and outputs an html string",
            OperationId = "Converter.Post",
            Tags = new[] { "Converter" })
        ]
        public HtmlTextResponse Post([FromBody] UnicodeTextToHtmlTextRequest request)
        {
            var converter = new UnicodeTextToHtmlTextConverter(request.UnicodeText);

            return new HtmlTextResponse
            {
                HtmlText = converter.GetUnicodeText()
            };
        }
    }

    public class UnicodeTextToHtmlTextRequest 
    {
        public string UnicodeText { get; set; }
    }

    public class HtmlTextResponse
    {
        public string HtmlText { get; set; }
    }
}
