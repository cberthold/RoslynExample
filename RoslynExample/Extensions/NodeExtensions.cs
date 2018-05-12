using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Microsoft.CodeAnalysis
{
    public static class NodeExtensions
    {
        public static TNode AppendWhitespace<TNode>(this TNode node, int count = 1)
            where TNode : SyntaxNode
        {
            return node.WithTrailingTrivia(node.GetTrailingTrivia().Add(SyntaxFactory.Whitespace(new String(' ', count))));
        }

        public static TNode PrependWhitespace<TNode>(this TNode node, int count = 1)
            where TNode : SyntaxNode
        {
            return node.WithLeadingTrivia(node.GetLeadingTrivia().Add(SyntaxFactory.Whitespace(new String(' ', count))));
        }
    }
}
