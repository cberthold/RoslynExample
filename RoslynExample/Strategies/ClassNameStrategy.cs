using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynExample
{
    public class ClassNameStrategy : AbstractSyntaxVisitorStrategy
    {
        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            var className = node.Identifier.Text;
            var mapper = MapperFunction();
            mapper.DefineClassName(className);
        }
    }
}
