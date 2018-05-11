using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RoslynExample.Locators;
using RoslynExample.Metadata;
using RoslynExample.Models;
using RoslynExample.Parsers;

namespace RoslynExample
{
    public class CommandBuilder
    {

        private static readonly string[] DefaultUsings = new string[]
        {
            "System",
            "System.Collections.Generic",
            "System.Linq",
            "System.Text",
            "System.Threading.Tasks",
        };

        public static NamespaceDeclarationSyntax FromSyntaxTree(SyntaxTree inputTree)
        {
            var root = inputTree.GetRoot();

            var inputLocator = new InputDtoClassLocator();
            inputLocator.Visit(root);

            if (inputLocator.InputDtoName == null)
            {
                return null;
            }

            var model = BuildModel(inputLocator);
            var commandClass = BuildClass(model);
            return commandClass;
        }

        private static CommandDefinitionModel BuildModel(InputDtoClassLocator locator)
        {
            var model = new CommandDefinitionModel();

            // set the class name to create the command with
            var className = locator.InputDtoName.Replace("InputDTO", "Command");
            model.ClassName = className;

            // parse the input class
            var entityParser = new EntityParser();
            var entityMetadata = entityParser.Parse(locator.InputDtoNode);
            model.InputMetadata = entityMetadata;

            return model;
        }
        
        private static NamespaceDeclarationSyntax BuildClass(CommandDefinitionModel model)
        {
            // create the namespace
            var @namespace = CreateNamespace(model.Namespace);

            // add default usings
            @namespace = AddUsings(@namespace);

            // create the command class
            var classDeclaration = SyntaxFactory.ClassDeclaration(model.ClassName)
                // add set it accessibility to public
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));

            // add the class to the namespace
            @namespace = @namespace
                .AddMembers(classDeclaration)
                .NormalizeWhitespace();

            return @namespace;
        }

        private static NamespaceDeclarationSyntax CreateNamespace(string namespaceValue)
        {
            return SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(namespaceValue)).NormalizeWhitespace();
        }

        private static NamespaceDeclarationSyntax AddUsings(NamespaceDeclarationSyntax @namespace)
        {
            foreach (var @using in DefaultUsings)
            {
                @namespace = @namespace.AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(@using)));
            }

            return @namespace;
        }

    }
}
