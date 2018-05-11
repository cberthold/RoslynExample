using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynExample.Locators
{
    public class InputDtoClassLocator : CSharpSyntaxWalker
    {
        public string InputDtoName { get; private set; }
        public ClassDeclarationSyntax InputDtoNode { get; private set; }

        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            var nodeClassName = node.Identifier.ValueText;

            if (nodeClassName.EndsWith("InputDTO", StringComparison.OrdinalIgnoreCase))
            {
                InputDtoName = nodeClassName;
                InputDtoNode = node;
            }

            base.VisitClassDeclaration(node);
        }
    }
}
