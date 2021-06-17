using System;

namespace Holodeck
{
    public class Template
    {
        public Guid Id { get; set; }
        public Guid MetaId { get; set; }
        public MetaData MetaData { get; set; }
        public DateTime Updated { get; set; }
        public string Path { get; set; }
        public string Source { get; set; }
    }
}   