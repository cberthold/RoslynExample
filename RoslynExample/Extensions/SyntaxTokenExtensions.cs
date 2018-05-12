using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;

namespace Microsoft.CodeAnalysis
{
    public static class SyntaxTokenExtensions
    {
        public static SyntaxToken AppendWhitespace(this SyntaxToken node)
        {
            return node.WithTrailingTrivia(node.TrailingTrivia.Add(SyntaxFactory.Whitespace(" ")));
        }
    }
}
