using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynExample.Formatters
{
    public class AddLineFeedsSyntaxRewriter<TSyntax> : CSharpSyntaxRewriter
        where TSyntax : SyntaxNode
    {
        public bool AddLineFeedBefore { get; set; }
        public bool AddLineFeedAfter { get; set; }

        public TSyntax AddLineFeeds(TSyntax syntax)
        {
            var replacedNode = Visit(syntax);
            return (TSyntax)replacedNode;
        }

        public override SyntaxNode Visit(SyntaxNode node)
        {
            var returnNode = base.Visit(node);

            if(returnNode is TSyntax syntaxNode)
            {
                returnNode = AddLineFeed(syntaxNode);
            }

            return returnNode;
        }

        private TSyntax AddLineFeed(TSyntax node)
        {
            if (AddLineFeedBefore)
            {
                node = node.WithLeadingTrivia(CreateLineFeedTrivia());
            }

            if (AddLineFeedAfter)
            {
                node = node.WithTrailingTrivia(CreateLineFeedTrivia());
            }

            return node;
        }

        private static SyntaxTriviaList CreateLineFeedTrivia()
        {
            return SyntaxFactory.TriviaList(SyntaxFactory.LineFeed);
        }
    }
}
