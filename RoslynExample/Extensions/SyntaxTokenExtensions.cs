using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Microsoft.CodeAnalysis
{
    public static class SyntaxTokenExtensions
    {
        public static SyntaxToken AppendWhitespace(this SyntaxToken node)
        {
            return node.WithTrailingTrivia(node.TrailingTrivia.Add(SyntaxFactory.Whitespace(" ")));
        }

        public static SyntaxToken ToIdentifier(this string identifier)
        {
            var token = SyntaxFactory.Identifier(identifier);
            return token;
        }

        public static IdentifierNameSyntax ToIdentifierName(this string identifier)
        {
            var syntax = SyntaxFactory.IdentifierName(identifier);
            return syntax;
        }
    }
}
