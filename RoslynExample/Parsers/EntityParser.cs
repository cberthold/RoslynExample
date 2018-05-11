using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RoslynExample.Metadata;

namespace RoslynExample.Parsers
{
    public class EntityParser
    {
        public EntityMetadata Parse(ClassDeclarationSyntax syntax)
        {
            var entity = new EntityMetadata();

            // TODO: Set class name of input dto
            entity.ClassName = "";

            // TODO: Set the namespace of the class
            entity.ClassNamespace = "";

            return entity;
        }
    }
}
