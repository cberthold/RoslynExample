using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoslynExample.Metadata;

namespace RoslynExample.Mapper
{
    public class ClassMetadataMapperAdapter : IClassMapper
    {
        public ClassMetadata Adaptee { get; private set; }

        public void SetAdaptee(ClassMetadata metadata)
        {
            Adaptee = metadata;
        }

        public void DefineClassName(string className)
        {
            Adaptee.ClassName = className;
        }

        public FieldMetadata AddField(string fieldName)
        {
            var field = new FieldMetadata
            {
                FieldName = fieldName,
            };
            Adaptee.Fields.Add(field);
            return field;
        }
    }
}
