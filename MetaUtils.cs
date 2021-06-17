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
            var meta = "const meta = {";

            meta += $"name:\"{singleMeta.Name}\",";
            meta += $"template:\"{singleMeta.Template.Source}\",";
            
            return meta + "};";
        }
    }
}