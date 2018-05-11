using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoslynExample.Metadata;

namespace RoslynExample.Models
{
    public class CommandDefinitionModel
    {
        public string Namespace { get; set; } = "Command";
        public string ClassName { get; set; }
        public EntityMetadata InputMetadata { get; set; }
    }
}
