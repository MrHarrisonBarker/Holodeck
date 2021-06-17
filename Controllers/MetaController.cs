using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Holodeck.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetaController : ControllerBase
    {
        private readonly ILogger<MetaController> Logger;
        private readonly MetaDetector MetaDetector;

        public MetaController(ILogger<MetaController> logger, MetaDetector metaDetector)
        {
            MetaDetector = metaDetector;
            Logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetMeta(string key)
        {
            Logger.LogInformation("Getting meta");

            var metaData = await MetaDetector.FindAsync(key,HttpContext.Request.Path);
            
            
            return Ok(MetaUtils.GenerateMetaFile(metaData));
        }
    }
}