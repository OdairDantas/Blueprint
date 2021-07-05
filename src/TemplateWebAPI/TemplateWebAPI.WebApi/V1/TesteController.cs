using Microsoft.AspNetCore.Mvc;
using System;

namespace $safeprojectname$.V1
{
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Obsolete("Este método é obsoleto, por favor, não utilize essa versão.")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        [HttpGet]
        public string Valor()
        {
            return "Sou a V1";
        }
    }
}
