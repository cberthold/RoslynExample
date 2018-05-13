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
    public class CommandMapperBuilder
    {
        private static readonly string[] DefaultUsings = new string[]
        {
            "System",
            "System.Collections.Generic",
            "System.Linq",
            "System.Text",
            "System.Threading.Tasks",
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
            var mapperClass = BuildClass(model);
            return mapperClass;
        }

        private static CommandDefinitionModel BuildModel(InputDtoClassLocator locator)
        {
            var model = new CommandDefinitionModel();
            model.InputDtoClassName = locator.InputDtoName;
            // set the class name to create the mapper with
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

            // create the mapper class
            var classDeclaration = SyntaxFactory.ClassDeclaration(model.ClassName);

            // add set it accessibility to public
            classDeclaration = classDeclaration
                .AddModifiers(
                SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                SyntaxFactory.Token(SyntaxKind.StaticKeyword));

            // add on the member properties
            classDeclaration = classDeclaration
                .NormalizeWhitespace()
                .WithMembers(CreateClassMembers(model));

            // add the class to the namespace
            @namespace = @namespace
                .AddMembers(classDeclaration);

            root = root
                 // add members to the root compilation unit
                 .AddMembers(@namespace);

            return root;
        }

        private static SyntaxList<MemberDeclarationSyntax> CreateClassMembers(CommandDefinitionModel model)
        {
            var memberDeclaration = SyntaxFactory.MethodDeclaration(
                        SyntaxFactory.IdentifierName(model.ClassName),
                        SyntaxFactory.Identifier("ToCommand"))
                    .WithModifiers(
                        SyntaxFactory.TokenList(
                            new[]{
                                SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                                SyntaxFactory.Token(SyntaxKind.StaticKeyword)}))
                    .WithParameterList(
                        SyntaxFactory.ParameterList(
                            SyntaxFactory.SingletonSeparatedList<ParameterSyntax>(
                                SyntaxFactory.Parameter(
                                    SyntaxFactory.Identifier("input"))
                                .WithModifiers(
                                    SyntaxFactory.TokenList(
                                        SyntaxFactory.Token(SyntaxKind.ThisKeyword)))
                                .WithType(
                                    SyntaxFactory.IdentifierName(model.InputDtoClassName)))));


            var argumentList = BuildArgumentsTokenList(model.InputMetadata);

            memberDeclaration = memberDeclaration
                .WithBody(
                    SyntaxFactory.Block(
                        SyntaxFactory.LocalDeclarationStatement(
                            SyntaxFactory.VariableDeclaration(
                                SyntaxFactory.IdentifierName("var"))
                            .WithVariables(
                                SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>(
                                    SyntaxFactory.VariableDeclarator(
                                        SyntaxFactory.Identifier("command"))
                                    .WithInitializer(
                                        SyntaxFactory.EqualsValueClause(
                                            SyntaxFactory.ObjectCreationExpression(
                                                SyntaxFactory.IdentifierName(model.ClassName))
                                            .WithArgumentList(
                                                SyntaxFactory.ArgumentList(argumentList))))))),
                        SyntaxFactory.ReturnStatement(
                            SyntaxFactory.IdentifierName("command"))));

            var memberDeclarationList = SyntaxFactory.SingletonList<MemberDeclarationSyntax>(memberDeclaration);

            return memberDeclarationList;
        }

        private static SeparatedSyntaxList<ArgumentSyntax> BuildArgumentsTokenList(EntityMetadata entity)
        {
            var properties = entity.Properties;
            var parameters = BuildArguments("input", properties);
            using (var enumerator = parameters.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    return SyntaxFactory.SeparatedList<ArgumentSyntax>();
                }

                var tokenList = new List<SyntaxNodeOrToken>((parameters.Count * 2) + 10);

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

                var tokenArray = tokenList.ToArray();
                var list = SyntaxFactory.SeparatedList<ArgumentSyntax>(tokenArray);
                return list;
            }
        }

        private static List<ArgumentSyntax> BuildArguments(string objectName, IEnumerable<PropertyMetadata> properties)
        {
            var arguments = properties
                .Select(p => p.CreateSimpleAccessorArgument(objectName))
                .ToList();
            return arguments;
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
