

namespace TDDMicroExercises.Features.UnicodeTextToHtmlTextConverter
{
    public class UnicodeTextToHtmlTextConverter
    {
        private string _unicodeText;

        public UnicodeTextToHtmlTextConverter(string unicodeText)
        {
            _unicodeText = unicodeText;
        }

        public string GetUnicodeText()
        {
            return _unicodeText;
        }

        public string ConvertToHtml()
        {
            string html = string.Empty;

            html = HttpUtility.HtmlEncode(_unicodeText);
            html += "<br />";
            
            return html;
        }
    }
    class HttpUtility
    {
        public static string HtmlEncode(string line)
        {
            line = line.Replace("<", "&lt;");
            line = line.Replace(">", "&gt;");
            line = line.Replace("&", "&amp;");
            line = line.Replace("\"", "&quot;");
            line = line.Replace("\'", "&quot;");
            return line;
        }
    }
}