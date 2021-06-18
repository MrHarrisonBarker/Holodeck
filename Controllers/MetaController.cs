using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Holodeck.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class MetaController : ControllerBase
    {
        private readonly ILogger<MetaController> Logger;
        private readonly MetaDetector MetaDetector;

        public MetaController(ILogger<MetaController> logger, MetaDetector metaDetector)
        {
            MetaDetector = metaDetector;
            Logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetMeta(string key = "Chatsubo")
        {
            Logger.LogInformation("Getting meta");

            if (HttpContext.Request.Headers.TryGetValue("Referer", out var referer))
            {
                var metaData = await MetaDetector.FindAsync(key, new Uri(referer));

                return new JavascriptResult(MetaUtils.GenerateSingleMetaFile(metaData));   
            }

            return BadRequest();
        }
    }
}