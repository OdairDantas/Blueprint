using Microsoft.AspNetCore.Mvc;

namespace $safeprojectname$.V2
{
    [ApiVersion("2.0", Deprecated = false)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        [HttpGet]
        public string Valor()
        {
            return "Sou a V2";
        }
    }
}
