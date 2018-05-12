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

        private static readonly string[] ClassImplementations = new string[]
        {
            "AbstractCommand",
        };

        public static CompilationUnitSyntax FromSyntaxTree(SyntaxTree inputTree)
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

        private static CompilationUnitSyntax BuildClass(CommandDefinitionModel model)
        {
            // create root node
            var root = CreateRoot();

            // add default usings
            root = root.AddUsings(GetDefaultUsings().ToArray())
                .NormalizeWhitespace();

            // create the namespace
            var @namespace = CreateNamespace(model.Namespace);

            // create the command class
            var classDeclaration = SyntaxFactory.ClassDeclaration(model.ClassName);

            // add set it accessibility to public
            classDeclaration = classDeclaration
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));

            // add on the base class/interface implementations
            classDeclaration = classDeclaration.WithBaseList(BuildBaseList());

            // add on the member properties
            classDeclaration = classDeclaration
                .NormalizeWhitespace()
                .WithMembers(SyntaxFactory.List<MemberDeclarationSyntax>(BuildMemberProperties(model.InputMetadata.Properties)));

            // add the class to the namespace
            @namespace = @namespace
                .AddMembers(classDeclaration);

            root = root
                 // add members to the root compilation unit
                 .AddMembers(@namespace);

            return root;
        }

        private static PropertyDeclarationSyntax[] BuildMemberProperties(IEnumerable<PropertyMetadata> properties)
        {
            List<PropertyDeclarationSyntax> declarations = new List<PropertyDeclarationSyntax>(properties.Count() + 5);

            foreach (var property in properties)
            {
                declarations.Add(BuildMemberProperty(property));
            }

            return declarations.ToArray();
        }

        private static PropertyDeclarationSyntax BuildMemberProperty(PropertyMetadata property)
        {
            var type = SyntaxFactory.IdentifierName(property.TypeName);
            var declaration = SyntaxFactory.PropertyDeclaration(type, property.PropertyName)
                .WithModifiers(
                                    SyntaxFactory.TokenList(
                                        SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                                .WithAccessorList(
                                    SyntaxFactory.AccessorList(
                                        SyntaxFactory.List<AccessorDeclarationSyntax>(
                                            new AccessorDeclarationSyntax[]{
                                                SyntaxFactory.AccessorDeclaration(
                                                    SyntaxKind.GetAccessorDeclaration)
                                                .WithSemicolonToken(
                                                    SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                                                SyntaxFactory.AccessorDeclaration(
                                                    SyntaxKind.SetAccessorDeclaration)
                                                .WithModifiers(
                                                    SyntaxFactory.TokenList(
                                                        SyntaxFactory.Token(SyntaxKind.PrivateKeyword)))
                                                .WithSemicolonToken(
                                                    SyntaxFactory.Token(SyntaxKind.SemicolonToken))})));
            return declaration;
        }

        private static BaseListSyntax BuildBaseList()
        {
            var tokenList = BuildBaseTypeNodeOrTokenList();
            var baseList = SyntaxFactory.BaseList(SyntaxFactory.SeparatedList<BaseTypeSyntax>(tokenList))
                .WithTrailingTrivia(SyntaxFactory.TriviaList(SyntaxFactory.LineFeed));

            return baseList;
        }

        private static IEnumerable<SyntaxNodeOrToken> BuildBaseTypeNodeOrTokenList()
        {
            var baseTypes = GetBaseTypes();
            using (var enumerator = baseTypes.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    return new SyntaxNodeOrToken[0];
                }

                var tokenList = new List<SyntaxNodeOrToken>((baseTypes.Count * 2) + 10);

                var lastBaseType = enumerator.Current;

                while (enumerator.MoveNext())
                {
                    tokenList.Add(lastBaseType);

                    tokenList.Add(SyntaxFactory.Token(
                            SyntaxFactory.TriviaList(),
                            SyntaxKind.CommaToken,
                            SyntaxFactory.TriviaList(
                                SyntaxFactory.LineFeed)));

                    lastBaseType = enumerator.Current;
                }

                tokenList.Add(lastBaseType);

                return tokenList;
            }
        }

        private static List<BaseTypeSyntax> GetBaseTypes()
        {
            Func<string, BaseTypeSyntax> baseTypeFactory = (type) =>
            {
                return SyntaxFactory.SimpleBaseType(SyntaxFactory.IdentifierName(type));
            };

            var baseTypes = ClassImplementations.Select(baseTypeFactory).ToList();

            return baseTypes;
        }

        private static CompilationUnitSyntax CreateRoot()
        {
            return SyntaxFactory.CompilationUnit();
        }

        private static NamespaceDeclarationSyntax CreateNamespace(string namespaceValue)
        {
            return SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(namespaceValue)).NormalizeWhitespace();
        }

        private static IEnumerable<UsingDirectiveSyntax> GetDefaultUsings()
        {
            foreach (var @using in DefaultUsings)
            {
                yield return SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(@using));
            }
        }

    }
}
