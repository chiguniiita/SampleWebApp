using Microsoft.AspNetCore.Mvc;

namespace SampleWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScriptRedirectController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ScriptRedirectController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var html = @$"<html>
<head></head>
<script type=""text/javascript"">
    function btn1Click(){{
        location.href=""{_configuration.GetValue<string>("HostUrl")}/page1"";
    }}
</script>
</head>
<body>
    <input type=""button"" id=""btn1"" value=""Page1"" onclick=""btn1Click()"" />
</body>
</html>";
            return Content(html, "text/html");
        }
    }
}
