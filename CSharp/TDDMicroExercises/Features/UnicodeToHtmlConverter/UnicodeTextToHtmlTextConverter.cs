namespace TDDMicroExercises.Features.UnicodeTextToHtmlTextConverter
{
    public class UnicodeTextToHtmlTextConverter : IUnicodeTextToHtmlTextConverter
    {
        public string ConvertToHtml(string unicodeText)
        {
            string html = string.Empty;

            html = HttpUtility.HtmlEncode(unicodeText);
            html += "<br />";

            return html;
        }
    }

    class HttpUtility
    {
        public static string HtmlEncode(string line)
        {
            line = line.Replace("&", "&amp;");
            line = line.Replace("<", "&lt;");
            line = line.Replace(">", "&gt;");
            line = line.Replace("\"", "&quot;");
            line = line.Replace("\'", "&apos;");
            return line;
        }
    }
}