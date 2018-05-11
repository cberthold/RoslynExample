using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynExample.Metadata
{
    public class PropertyMetadata
    {
        public string FieldName { get; set; }
        public bool HasGet { get; set; }
        public bool HasSet { get; set; }
        public Type FieldType { get; set; }
    }
}
