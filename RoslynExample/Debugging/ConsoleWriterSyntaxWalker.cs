using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace RoslynExample.Debugging
{
    public class ConsoleWriterSyntaxWalker : CSharpSyntaxWalker
    {

        private const string INDENT_STRING = "  ";
        private const int INITIAL_INDENT_COUNT = 20;

        public int Indents { get; private set; } = -1;

        private IDictionary<int, string> indentValues = new Dictionary<int, string>(INITIAL_INDENT_COUNT);
        private StringBuilder indentBuilder = new StringBuilder(INITIAL_INDENT_COUNT);


        public ConsoleWriterSyntaxWalker()
        {
            BuildIndentValues(INITIAL_INDENT_COUNT);
        }

        public override void Visit(SyntaxNode node)
        {
            IncrementIndent();
            WriteConsoleText(node);
            base.Visit(node);
            DecrementIndent();
        }

        private void WriteConsoleText(SyntaxNode node)
        {
            var indentText = GetIndentText(Indents);
            var nodeText = GetNodeText(node);

            Console.WriteLine($"{indentText}{nodeText}");
        }

        private void IncrementIndent()
        {
            Indents++;
        }

        private void DecrementIndent()
        {
            Indents--;
        }

        private string GetNodeText(SyntaxNode node)
        {
            return node.Kind().ToString();
        }

        private void BuildIndentValues(int toIndentValue, int fromIndentValue = 0)
        {

            for (var i = fromIndentValue; i < toIndentValue; i++)
            {
                indentValues.Add(i, indentBuilder.ToString());
                indentBuilder.Append(INDENT_STRING);
            }
        }

        private string GetIndentText(int indents)
        {
            if (indentValues.ContainsKey(indents))
            {
                return indentValues[indents];
            }

            var fromValue = indentValues.Count;
            var toValue = fromValue + INITIAL_INDENT_COUNT;
            BuildIndentValues(toValue, fromValue);

            return GetIndentText(indents);    
        }
    }
}
