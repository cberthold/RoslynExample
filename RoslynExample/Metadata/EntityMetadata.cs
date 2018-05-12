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

        public IEnumerable<PropertyMetadata> Properties { get; set; }
    }
}
