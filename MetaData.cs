using System;
using System.Collections.Generic;

namespace Holodeck
{
    public class MetaData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<Template> Templates { get; set; }
    }

    public class SingleMeta
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Template Template { get; set; }
    }
}