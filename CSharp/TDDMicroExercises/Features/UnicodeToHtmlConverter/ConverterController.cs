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
        private readonly IUnicodeTextToHtmlTextConverter unicodeTextToHtmlTextConverter;

        public ConverterController(ILogger<ConverterController> logger, IUnicodeTextToHtmlTextConverter unicodeTextToHtmlTextConverter)
        { 
            this.logger = logger;
            this.unicodeTextToHtmlTextConverter = unicodeTextToHtmlTextConverter;
        }

        [HttpPost()]
        [SwaggerOperation(
            Summary = "Converts a unicode string to html",
            Description = "Takes an input unicode string and outputs an html string",
            OperationId = "Converter.Post",
            Tags = new[] { "Converter" })
        ]
        public HtmlTextResponse Post([FromBody] UnicodeTextToHtmlTextRequest request)
        {
            string htmlText = unicodeTextToHtmlTextConverter.ConvertToHtml(request.UnicodeText);

            return new HtmlTextResponse
            {
                HtmlText = htmlText
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
