using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Holodeck
{
    public interface IMetaDetector
    {
        Task<SingleMeta> FindAsync(string name, Uri uri);
    }

    public class MetaDetector : IMetaDetector
    {
        private readonly ILogger<MetaDetector> Logger;
        private readonly MetaContext MetaContext;

        public MetaDetector(ILogger<MetaDetector> logger, MetaContext metaContext)
        {
            Logger = logger;
            MetaContext = metaContext;
        }


        public async Task<SingleMeta> FindAsync(string name, Uri uri)
        {
            Logger.LogInformation($"Finding metadata for \"{name}\" {uri.AbsolutePath}");

            try
            {
                var singleMeta =  await MetaContext.Metas.Select(x => new SingleMeta()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Template = x.Templates.FirstOrDefault(x => x.Path == uri.AbsolutePath)
                }).FirstOrDefaultAsync(x => x.Name == name);

                if (singleMeta == null) throw new Exception($"Meta for \"{name}\" not found");
                
                return singleMeta;
            }
            catch (Exception e)
            {
                Logger.LogInformation(e.Message);
                throw;
            }
        }
    }
}