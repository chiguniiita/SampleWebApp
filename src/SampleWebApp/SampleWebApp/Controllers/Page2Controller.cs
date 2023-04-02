using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Text;

namespace SampleWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Page2Controller : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public Page2Controller(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"<html><body><h1>Page2</h1><a href=\"{_configuration.GetValue<string>("HostUrl")}/page1\">Page1</a>");

            sb.AppendLine(CreateHtmlTable("Request Headers", Request.Headers));

            sb.AppendLine("</body></html>");

            return Content(sb.ToString(), "text/html");
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"<html><body><h1>Page2</h1><a href=\"{_configuration.GetValue<string>("HostUrl")}/page1\">Page1</a>");

            sb.AppendLine(CreateHtmlTable("Request Headers", Request.Headers));

            var form = await Request.ReadFormAsync();
            var bodyData = form.ToDictionary(x => x.Key, x => x.Value);
            sb.AppendLine(CreateHtmlTable("Request Bodys", bodyData));

            sb.AppendLine("</body></html>");

            return Content(sb.ToString(), "text/html");
        }


        private static string CreateHtmlTable(string title, IDictionary<string, StringValues> data)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"<h2>{title}</h2>");
            sb.AppendLine("<table>");

            foreach (var item in data)
            {
                sb.AppendLine($"<tr><th>{item.Key}</th><td>{item.Value}</td></tr>");
            }
            sb.AppendLine("</table>");

            return sb.ToString();
        }
    }
}