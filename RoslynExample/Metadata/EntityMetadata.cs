using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynExample.Metadata
{
    public class EntityMetadata
    {
        public string ClassName { get; set; }

        public string ClassNamespace { get; set; }

        public IList<PropertyMetadata> Fields { get; } = new List<PropertyMetadata>(100);
    }
}
