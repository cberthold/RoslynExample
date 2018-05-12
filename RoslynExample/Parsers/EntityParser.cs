using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RoslynExample.Metadata;

namespace RoslynExample.Parsers
{
    public class EntityParser
    {
        public EntityMetadata Parse(ClassDeclarationSyntax syntax)
        {
            var root = syntax.SyntaxTree.GetRoot();
            var entity = new EntityMetadata();

            // Set class name of entity class
            entity.ClassName = syntax.Identifier.Text;

            // TODO: Set the namespace of the class
            entity.ClassNamespace = "";

            var properties = GetProperties(syntax);
            entity.Properties = properties;

            return entity;
        }

        private static IEnumerable<PropertyMetadata> GetProperties(ClassDeclarationSyntax classNode)
        {
            var propertyDeclarations = (from p in classNode.DescendantNodes()
                                        .OfType<PropertyDeclarationSyntax>()
                                        where p.Modifiers.Any(m => m.Kind() == SyntaxKind.PublicKeyword)
                                        select p).ToArray();

            var properties = new List<PropertyMetadata>(propertyDeclarations.Length);

            foreach (var declaration in propertyDeclarations)
            {
                var property = new PropertyMetadata();

                var propertyName = declaration.Identifier.Text;
                property.PropertyName = propertyName;

                var typeName = declaration.Type.ToString();
                property.TypeName = typeName;

                var accessorKinds = declaration.AccessorList?.Accessors.Select(a => a.Kind());

                if (!accessorKinds.Any())
                {
                    continue;
                }

                foreach (var kind in accessorKinds)
                {
                    switch(kind)
                    {
                        case SyntaxKind.GetAccessorDeclaration:
                            property.HasGet = true;
                            break;
                        case SyntaxKind.SetAccessorDeclaration:
                            property.HasSet = true;
                            break;
                    }
                }

                properties.Add(property);
            }

            return properties;
        }
    }
}
