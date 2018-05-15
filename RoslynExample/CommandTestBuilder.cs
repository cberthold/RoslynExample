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
    public class CommandTestBuilder
    {

        private static readonly string[] DefaultUsings = new string[]
        {
            "System",
            "System.Collections.Generic",
            "System.Linq",
            "System.Text",
            "System.Threading.Tasks",
            "Flightdocs.Ops.Domain.Commands.Scheduling",
            "Flightdocs.Ops.Domain.Shared",
            "Xunit"
        };

        private static readonly string[] ClassImplementations = new string[]
        {
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
            var className = locator.InputDtoName.Replace("InputDTO", "CommandTest");
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
            // classDeclaration = classDeclaration.WithBaseList(BuildBaseList());

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
            return SyntaxFactory.SingletonList<MemberDeclarationSyntax>(
                SyntaxFactory.MethodDeclaration(
                    SyntaxFactory.PredefinedType(
                        SyntaxFactory.Token(SyntaxKind.VoidKeyword)),
                    SyntaxFactory.Identifier("Constructor_Should_Set_Values"))
                .WithAttributeLists(
                    SyntaxFactory.SingletonList<AttributeListSyntax>(
                        SyntaxFactory.AttributeList(
                            SyntaxFactory.SingletonSeparatedList<AttributeSyntax>(
                                SyntaxFactory.Attribute(
                                    SyntaxFactory.IdentifierName("Fact"))))))
                .WithModifiers(
                    SyntaxFactory.TokenList(
                        SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                .WithBody(
                    GetConstructorSetValueTestBody(model.InputMetadata)));
        }

        private static BlockSyntax GetConstructorSetValueTestBody(EntityMetadata entityMetadata)
        {
            var variableDeclarations = entityMetadata.Properties.Select(a => CreateLocalStringVariable(a.PropertyName.LowerCaseFirstLetter(), a.PropertyName));
            var assertions = entityMetadata.Properties.Select(a => AssertValues(a.PropertyName.LowerCaseFirstLetter(), a.PropertyName)).ToArray();

            var block = SyntaxFactory.Block(variableDeclarations);
            block = block.AddStatements(InstantiateCommand(entityMetadata.Properties))
                    .AddStatements(assertions);
            return block;
        }

        private static ExpressionStatementSyntax AssertValues(string localProperty, string commandProperty)
        {
            var expressionStatement = SyntaxFactory.ExpressionStatement(
                                                    SyntaxFactory.InvocationExpression(
                                                        SyntaxFactory.MemberAccessExpression(
                                                            SyntaxKind.SimpleMemberAccessExpression,
                                                            SyntaxFactory.IdentifierName("Assert"),
                                                            SyntaxFactory.IdentifierName("Equal")))
                                                    .WithArgumentList(
                                                        SyntaxFactory.ArgumentList(
                                                            SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                                                new SyntaxNodeOrToken[]{
                                            SyntaxFactory.Argument(
                                                SyntaxFactory.IdentifierName(localProperty)),
                                            SyntaxFactory.Token(SyntaxKind.CommaToken),
                                            SyntaxFactory.Argument(
                                                SyntaxFactory.MemberAccessExpression(
                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                    SyntaxFactory.IdentifierName("command"),
                                                    SyntaxFactory.IdentifierName(commandProperty)))}))));

            return expressionStatement;
        }

        private static LocalDeclarationStatementSyntax InstantiateCommand(IEnumerable<PropertyMetadata> properties)
        {
            var arguments = new List<SyntaxNodeOrToken>();
            bool first = true;
            foreach (var property in properties)
            {
                if (!first)
                {
                    arguments.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
                }
                first = false;

                arguments.Add(SyntaxFactory.Argument(SyntaxFactory.IdentifierName(property.PropertyName.LowerCaseFirstLetter())));
            }

            return SyntaxFactory.LocalDeclarationStatement(
                                                    SyntaxFactory.VariableDeclaration(
                                                        SyntaxFactory.IdentifierName("var"))
                                                    .WithVariables(
                                                        SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>(
                                                            SyntaxFactory.VariableDeclarator(
                                                                SyntaxFactory.Identifier("command"))
                                                            .WithInitializer(
                                                                SyntaxFactory.EqualsValueClause(
                                                                    SyntaxFactory.ObjectCreationExpression(
                                                                        SyntaxFactory.IdentifierName("TestCommand"))
                                                                    .WithArgumentList(
                                                                        SyntaxFactory.ArgumentList(
                                                                            SyntaxFactory.SeparatedList<ArgumentSyntax>(arguments))))))));
        }

        private static LocalDeclarationStatementSyntax CreateLocalStringVariable(string propertyName, string value)
        {
            return SyntaxFactory.LocalDeclarationStatement(
                                                    SyntaxFactory.VariableDeclaration(
                                                        SyntaxFactory.IdentifierName("var"))
                                                    .WithVariables(
                                                        SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>(
                                                            SyntaxFactory.VariableDeclarator(
                                                                SyntaxFactory.Identifier(propertyName))
                                                            .WithInitializer(
                                                                SyntaxFactory.EqualsValueClause(
                                                                    SyntaxFactory.LiteralExpression(
                                                                        SyntaxKind.StringLiteralExpression,
                                                                        SyntaxFactory.Literal(value)))))));
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
