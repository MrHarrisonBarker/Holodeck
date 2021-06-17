using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Holodeck
{
    public interface IMetaDetector
    {
        Task<MetaData> FindAsync(string id, PathString path);
    }

    public class MetaDetector : IMetaDetector
    {
        private ILogger<MetaDetector> Logger;

        public MetaDetector(ILogger<MetaDetector> logger)
        {
            Logger = logger;
        }


        public Task<MetaData> FindAsync(string id, PathString path)
        {
            Logger.LogInformation($"Finding metadata for \"{id}\" {path.Value}");

            return Task.FromResult(new MetaData()
            {
                Id = "NumberOne",
                Name = "Chatsubo"
            });
        }
    }
}