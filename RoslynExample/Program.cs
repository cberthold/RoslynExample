using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RoslynExample.Mapper;
using RoslynExample.Metadata;

namespace RoslynExample
{
    

    

    

    

    public class Program
    {
        public static void Main(string[] args)
        {
            var tree = CSharpSyntaxTree.ParseText(@"
        public class Test {
            public string TestField { get; set; }
            public int AnotherField {get;set;}
        }
       ");
            var fromClassMetadata = new ClassMetadata();
            var adapter = new ClassMetadataMapperAdapter();
            adapter.SetAdaptee(fromClassMetadata);
            var walker = new CustomWalker(adapter);
            walker.Visit(tree.GetRoot());

            Console.ReadKey();
        }
    }
}
