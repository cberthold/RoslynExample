using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoslynExample.Metadata;

namespace RoslynExample.Mapper
{
    public interface IClassMapper
    {
        void DefineClassName(string className);
        FieldMetadata AddField(string fieldName);
    }
}
