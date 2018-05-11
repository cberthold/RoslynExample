using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using RoslynExample.Metadata;

namespace RoslynExample
{








    public class Program
    {
        public static Solution AddProjectWithMetadataReferences(Solution solution, string projectName, string languageName, string code, MetadataReference metadataReference, params ProjectId[] projectReferences)
        {
            var suffix = languageName == LanguageNames.CSharp ? "cs" : "vb";
            var pid = ProjectId.CreateNewId();
            var did = DocumentId.CreateNewId(pid);
            var pi = ProjectInfo.Create(
                pid,
                VersionStamp.Default,
                projectName,
                projectName,
                languageName,
                metadataReferences: new[] { metadataReference },
                projectReferences: projectReferences.Select(p => new ProjectReference(p)));
            return solution.AddProject(pi).AddDocument(did, $"{projectName}.{suffix}", SourceText.From(code));
        }

        private static Solution GetSingleDocumentSolution(string sourceText)
        {
            var mscorlibLocation = typeof(int).Assembly.Location;
            var mscorlibReference = MetadataReference.CreateFromFile(mscorlibLocation);
            var _ = typeof(Microsoft.CodeAnalysis.CSharp.Formatting.CSharpFormattingOptions);
            var pid = ProjectId.CreateNewId();
            var did = DocumentId.CreateNewId(pid);
            return CreateSolution()
                    .AddProject(pid, "source", "source", LanguageNames.CSharp)
                    .AddMetadataReference(pid, mscorlibReference)
                    .AddDocument(did, "sourcefile.cs", SourceText.From(sourceText));
        }

        private static Solution CreateSolution()
        {
            return new AdhocWorkspace().CurrentSolution;
        }

        public static void Main(string[] args)
        {
            // var tree = CSharpSyntaxTree.ParseText(SOURCE_TEXT);
            var solution = GetSingleDocumentSolution(SOURCE_TEXT);
            var project = solution.Projects.First();
            var compilation = project.GetCompilationAsync().Result;
            var tree = compilation.SyntaxTrees.First();

            var root = tree.GetCompilationUnitRoot();
            // walker.Visit(tree.GetRoot());
            var command = CommandBuilder.FromSyntaxTree(tree);
            Console.WriteLine(command.ToFullString());
            Console.ReadKey();
        }

        private static readonly string SOURCE_TEXT = @"
using System;

namespace {
    public class CreateCustomerInputDTO
    {
        #region Properties

        public int? Id { get; set; }

        public string Designation { get; set; }

        public string Name { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public string City { get; set; }

        public int? StateId { get; set; }

        public string Province { get; set; }

        public string Postal { get; set; }

        public int? CountryId { get; set; }

        public string ContactPhone { get; set; }

        public string ContactPhone2 { get; set; }

        public string ContactFax { get; set; }

        public string ContactEmail { get; set; }

        public int CustomerTypeId { get; set; }

        public Guid? LogoImageId { get; set; }

        public int? PreferredContactUserId { get; set; }

        public string Notes { get; set; }

        public CustomerStatuses StatusId { get; set; }

        public bool UseInventoryIntegration { get; set; }

        public string Website { get; set; }

        public int? DefaultCountryId { get; set; }

        public string DefaultCurrencyCode { get; set; }

        /// <summary>
        /// ID linking Flightdocs customer to Salesforce(TM) Account
        /// </summary>
        public string SalesforceAccountId { get; set; }

        /// <summary>
        /// Display name for linked salesforce account to prevent having to do an api lookup by id
        /// </summary>
        public string SalesforceAccountName { get; set; }

        public Guid? DefaultRtsId { get; set; }

        public bool? ShowHoursInHHMM { get; set; }

        public bool RequireDivision { get; set; }
        #endregion
    }

    public enum CustomerStatuses
    {
        Active = 1,
        Inactive = 2
    }
}
       ";
    }
}
