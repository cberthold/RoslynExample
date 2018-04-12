using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RoslynExample.Metadata;

namespace RoslynExample
{
    public class FieldStrategy : AbstractSyntaxVisitorStrategy
    {
        private FieldMetadata metadata;

        public override void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        {
            var fieldName = node.Identifier.Text;
            metadata = MapperFunction().AddField(fieldName);
        }

        public override void VisitAccessorDeclaration(AccessorDeclarationSyntax node)
        {
            if (node.Kind() == SyntaxKind.GetAccessorDeclaration)
            {
                metadata.HasGet = true;
            }
            else if (node.Kind() == SyntaxKind.SetAccessorDeclaration)
            {
                metadata.HasSet = true;
            }
        }
    }
}
