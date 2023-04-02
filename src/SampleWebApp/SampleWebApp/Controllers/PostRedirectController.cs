using Microsoft.AspNetCore.Mvc;

namespace SampleWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostRedirectController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public PostRedirectController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var html = @$"<html>
<head></head>
<script type=""text/javascript"">
    window.onload = function(){{
        document.forms[0].submit();
    }}
</script>
</head>
<body>
    <form method=""POST"" name=""form1"" action=""{_configuration.GetValue<string>("HostUrl")}/page1"">
        <input type=""text"" name=""id1"" id=""id1"" value=""testvalue"">
    </form>
</body>
</html>";
            return Content(html, "text/html");
        }
    }
}
