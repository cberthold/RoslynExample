using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynExample.Metadata
{
    public class ClassMetadata
    {
        public string ClassName { get; set; }

        public IList<FieldMetadata> Fields { get; } = new List<FieldMetadata>(100);
    }
}
