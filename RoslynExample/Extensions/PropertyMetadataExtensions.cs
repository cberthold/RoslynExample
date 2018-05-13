using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RoslynExample.Models;

namespace RoslynExample.Metadata
{
    public static class PropertyMetadataExtensions
    {
        public static ConstructorDeclarationSyntax CreateConstructorDeclaration(this CommandDefinitionModel entity)
        {
            var constructor = SyntaxFactory.ConstructorDeclaration(entity.ClassName)
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword)));
            return constructor;
        }

        public static ExpressionStatementSyntax CreateConstructorAssignment(this PropertyMetadata property)
        {
            var parameterName = property.PropertyName.LowerCaseFirstLetter();
            var propertyName = property.PropertyName;

            var parameterNameIdentifier = parameterName.ToIdentifierName();
            var propertyNameIdentifier = propertyName.ToIdentifierName();

            ExpressionStatementSyntax statement;

            if (parameterName != propertyName)
            {
                statement = SyntaxFactory.ExpressionStatement(
                                        SyntaxFactory.AssignmentExpression(
                                            SyntaxKind.SimpleAssignmentExpression,
                                            propertyNameIdentifier,
                                            parameterNameIdentifier));
            }
            else
            {
                statement = SyntaxFactory.ExpressionStatement(
                                       SyntaxFactory.AssignmentExpression(
                                           SyntaxKind.SimpleAssignmentExpression,
                                           SyntaxFactory.MemberAccessExpression(
                                               SyntaxKind.SimpleMemberAccessExpression,
                                               SyntaxFactory.ThisExpression(),
                                               propertyNameIdentifier),
                                           parameterNameIdentifier));
            }

            return statement;
        }

        public static ArgumentSyntax CreateSimpleAccessorArgument(this PropertyMetadata property, string objectName)
        {
            var argument = SyntaxFactory.Argument(
                            SyntaxFactory.MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                SyntaxFactory.IdentifierName(objectName),
                                SyntaxFactory.IdentifierName(property.PropertyName)));
            return argument;
        }

        public static ParameterSyntax CreateParameter(this PropertyMetadata property)
        {
            var parameterName = property.PropertyName.LowerCaseFirstLetter();
            var parameterType = SyntaxFactory.ParseTypeName(property.TypeName);
            var parameter = SyntaxFactory.Parameter(parameterName.ToIdentifier())
                .WithType(parameterType);
            return parameter;
        }

        public static PropertyDeclarationSyntax CreatePropertyDeclaration(this PropertyMetadata property)
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
    }
}
