namespace Holodeck
{
    public static class MetaUtils
    {
        public static string GenerateMetaFile(MetaData metaData)
        {
            return "const meta = \"Hello world\"";
        }

        public static string GenerateSingleMetaFile(SingleMeta singleMeta)
        {
            var meta = "const singleMeta = {";

            meta += $"Name:\"{singleMeta.Name}\",";
            meta += $"Template:\"{singleMeta.Template.Source}\",";
            
            return meta + "};";
        }
    }
}