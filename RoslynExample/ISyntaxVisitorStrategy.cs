using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RoslynExample.Mapper;

namespace RoslynExample
{
    public interface ISyntaxVisitorStrategy
    {
        void SetMapperFunc(Func<IClassMapper> classMapperFunc);

        void DefaultVisit(SyntaxNode node);

        void Visit(SyntaxNode node);
        //
        // Summary:
        //     Called when the visitor visits a AccessorDeclarationSyntax node.
        void VisitAccessorDeclaration(AccessorDeclarationSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a AccessorListSyntax node.
        void VisitAccessorList(AccessorListSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a AliasQualifiedNameSyntax node.
        void VisitAliasQualifiedName(AliasQualifiedNameSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a AnonymousMethodExpressionSyntax node.
        void VisitAnonymousMethodExpression(AnonymousMethodExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a AnonymousObjectCreationExpressionSyntax node.
        void VisitAnonymousObjectCreationExpression(AnonymousObjectCreationExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a AnonymousObjectMemberDeclaratorSyntax node.
        void VisitAnonymousObjectMemberDeclarator(AnonymousObjectMemberDeclaratorSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ArgumentSyntax node.
        void VisitArgument(ArgumentSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ArgumentListSyntax node.
        void VisitArgumentList(ArgumentListSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ArrayCreationExpressionSyntax node.
        void VisitArrayCreationExpression(ArrayCreationExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ArrayRankSpecifierSyntax node.
        void VisitArrayRankSpecifier(ArrayRankSpecifierSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ArrayTypeSyntax node.
        void VisitArrayType(ArrayTypeSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ArrowExpressionClauseSyntax node.
        void VisitArrowExpressionClause(ArrowExpressionClauseSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a AssignmentExpressionSyntax node.
        void VisitAssignmentExpression(AssignmentExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a AttributeSyntax node.
        void VisitAttribute(AttributeSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a AttributeArgumentSyntax node.
        void VisitAttributeArgument(AttributeArgumentSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a AttributeArgumentListSyntax node.
        void VisitAttributeArgumentList(AttributeArgumentListSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a AttributeListSyntax node.
        void VisitAttributeList(AttributeListSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a AttributeTargetSpecifierSyntax node.
        void VisitAttributeTargetSpecifier(AttributeTargetSpecifierSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a AwaitExpressionSyntax node.
        void VisitAwaitExpression(AwaitExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a BadDirectiveTriviaSyntax node.
        void VisitBadDirectiveTrivia(BadDirectiveTriviaSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a BaseExpressionSyntax node.
        void VisitBaseExpression(BaseExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a BaseListSyntax node.
        void VisitBaseList(BaseListSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a BinaryExpressionSyntax node.
        void VisitBinaryExpression(BinaryExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a BlockSyntax node.
        void VisitBlock(BlockSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a BracketedArgumentListSyntax node.
        void VisitBracketedArgumentList(BracketedArgumentListSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a BracketedParameterListSyntax node.
        void VisitBracketedParameterList(BracketedParameterListSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a BreakStatementSyntax node.
        void VisitBreakStatement(BreakStatementSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a CasePatternSwitchLabelSyntax node.
        void VisitCasePatternSwitchLabel(CasePatternSwitchLabelSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a CaseSwitchLabelSyntax node.
        void VisitCaseSwitchLabel(CaseSwitchLabelSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a CastExpressionSyntax node.
        void VisitCastExpression(CastExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a CatchClauseSyntax node.
        void VisitCatchClause(CatchClauseSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a CatchDeclarationSyntax node.
        void VisitCatchDeclaration(CatchDeclarationSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a CatchFilterClauseSyntax node.
        void VisitCatchFilterClause(CatchFilterClauseSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a CheckedExpressionSyntax node.
        void VisitCheckedExpression(CheckedExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a CheckedStatementSyntax node.
        void VisitCheckedStatement(CheckedStatementSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ClassDeclarationSyntax node.
        void VisitClassDeclaration(ClassDeclarationSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ClassOrStructConstraintSyntax node.
        void VisitClassOrStructConstraint(ClassOrStructConstraintSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a CompilationUnitSyntax node.
        void VisitCompilationUnit(CompilationUnitSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ConditionalAccessExpressionSyntax node.
        void VisitConditionalAccessExpression(ConditionalAccessExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ConditionalExpressionSyntax node.
        void VisitConditionalExpression(ConditionalExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ConstantPatternSyntax node.
        void VisitConstantPattern(ConstantPatternSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ConstructorConstraintSyntax node.
        void VisitConstructorConstraint(ConstructorConstraintSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ConstructorDeclarationSyntax node.
        void VisitConstructorDeclaration(ConstructorDeclarationSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ConstructorInitializerSyntax node.
        void VisitConstructorInitializer(ConstructorInitializerSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ContinueStatementSyntax node.
        void VisitContinueStatement(ContinueStatementSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ConversionOperatorDeclarationSyntax node.
        void VisitConversionOperatorDeclaration(ConversionOperatorDeclarationSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ConversionOperatorMemberCrefSyntax node.
        void VisitConversionOperatorMemberCref(ConversionOperatorMemberCrefSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a CrefBracketedParameterListSyntax node.
        void VisitCrefBracketedParameterList(CrefBracketedParameterListSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a CrefParameterSyntax node.
        void VisitCrefParameter(CrefParameterSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a CrefParameterListSyntax node.
        void VisitCrefParameterList(CrefParameterListSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a DeclarationExpressionSyntax node.
        void VisitDeclarationExpression(DeclarationExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a DeclarationPatternSyntax node.
        void VisitDeclarationPattern(DeclarationPatternSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a DefaultExpressionSyntax node.
        void VisitDefaultExpression(DefaultExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a DefaultSwitchLabelSyntax node.
        void VisitDefaultSwitchLabel(DefaultSwitchLabelSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a DefineDirectiveTriviaSyntax node.
        void VisitDefineDirectiveTrivia(DefineDirectiveTriviaSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a DelegateDeclarationSyntax node.
        void VisitDelegateDeclaration(DelegateDeclarationSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a DestructorDeclarationSyntax node.
        void VisitDestructorDeclaration(DestructorDeclarationSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a DiscardDesignationSyntax node.
        void VisitDiscardDesignation(DiscardDesignationSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a DocumentationCommentTriviaSyntax node.
        void VisitDocumentationCommentTrivia(DocumentationCommentTriviaSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a DoStatementSyntax node.
        void VisitDoStatement(DoStatementSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ElementAccessExpressionSyntax node.
        void VisitElementAccessExpression(ElementAccessExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ElementBindingExpressionSyntax node.
        void VisitElementBindingExpression(ElementBindingExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ElifDirectiveTriviaSyntax node.
        void VisitElifDirectiveTrivia(ElifDirectiveTriviaSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ElseClauseSyntax node.
        void VisitElseClause(ElseClauseSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ElseDirectiveTriviaSyntax node.
        void VisitElseDirectiveTrivia(ElseDirectiveTriviaSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a EmptyStatementSyntax node.
        void VisitEmptyStatement(EmptyStatementSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a EndIfDirectiveTriviaSyntax node.
        void VisitEndIfDirectiveTrivia(EndIfDirectiveTriviaSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a EndRegionDirectiveTriviaSyntax node.
        void VisitEndRegionDirectiveTrivia(EndRegionDirectiveTriviaSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a EnumDeclarationSyntax node.
        void VisitEnumDeclaration(EnumDeclarationSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a EnumMemberDeclarationSyntax node.
        void VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a EqualsValueClauseSyntax node.
        void VisitEqualsValueClause(EqualsValueClauseSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ErrorDirectiveTriviaSyntax node.
        void VisitErrorDirectiveTrivia(ErrorDirectiveTriviaSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a EventDeclarationSyntax node.
        void VisitEventDeclaration(EventDeclarationSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a EventFieldDeclarationSyntax node.
        void VisitEventFieldDeclaration(EventFieldDeclarationSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ExplicitInterfaceSpecifierSyntax node.
        void VisitExplicitInterfaceSpecifier(ExplicitInterfaceSpecifierSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ExpressionStatementSyntax node.
        void VisitExpressionStatement(ExpressionStatementSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ExternAliasDirectiveSyntax node.
        void VisitExternAliasDirective(ExternAliasDirectiveSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a FieldDeclarationSyntax node.
        void VisitFieldDeclaration(FieldDeclarationSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a FinallyClauseSyntax node.
        void VisitFinallyClause(FinallyClauseSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a FixedStatementSyntax node.
        void VisitFixedStatement(FixedStatementSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ForEachStatementSyntax node.
        void VisitForEachStatement(ForEachStatementSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ForEachVariableStatementSyntax node.
        void VisitForEachVariableStatement(ForEachVariableStatementSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ForStatementSyntax node.
        void VisitForStatement(ForStatementSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a FromClauseSyntax node.
        void VisitFromClause(FromClauseSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a GenericNameSyntax node.
        void VisitGenericName(GenericNameSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a GlobalStatementSyntax node.
        void VisitGlobalStatement(GlobalStatementSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a GotoStatementSyntax node.
        void VisitGotoStatement(GotoStatementSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a GroupClauseSyntax node.
        void VisitGroupClause(GroupClauseSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a IdentifierNameSyntax node.
        void VisitIdentifierName(IdentifierNameSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a IfDirectiveTriviaSyntax node.
        void VisitIfDirectiveTrivia(IfDirectiveTriviaSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a IfStatementSyntax node.
        void VisitIfStatement(IfStatementSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ImplicitArrayCreationExpressionSyntax node.
        void VisitImplicitArrayCreationExpression(ImplicitArrayCreationExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ImplicitElementAccessSyntax node.
        void VisitImplicitElementAccess(ImplicitElementAccessSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a IncompleteMemberSyntax node.
        void VisitIncompleteMember(IncompleteMemberSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a IndexerDeclarationSyntax node.
        void VisitIndexerDeclaration(IndexerDeclarationSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a IndexerMemberCrefSyntax node.
        void VisitIndexerMemberCref(IndexerMemberCrefSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a InitializerExpressionSyntax node.
        void VisitInitializerExpression(InitializerExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a InterfaceDeclarationSyntax node.
        void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a InterpolatedStringExpressionSyntax node.
        void VisitInterpolatedStringExpression(InterpolatedStringExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a InterpolatedStringTextSyntax node.
        void VisitInterpolatedStringText(InterpolatedStringTextSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a InterpolationSyntax node.
        void VisitInterpolation(InterpolationSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a InterpolationAlignmentClauseSyntax node.
        void VisitInterpolationAlignmentClause(InterpolationAlignmentClauseSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a InterpolationFormatClauseSyntax node.
        void VisitInterpolationFormatClause(InterpolationFormatClauseSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a InvocationExpressionSyntax node.
        void VisitInvocationExpression(InvocationExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a IsPatternExpressionSyntax node.
        void VisitIsPatternExpression(IsPatternExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a JoinClauseSyntax node.
        void VisitJoinClause(JoinClauseSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a JoinIntoClauseSyntax node.
        void VisitJoinIntoClause(JoinIntoClauseSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a LabeledStatementSyntax node.
        void VisitLabeledStatement(LabeledStatementSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a LetClauseSyntax node.
        void VisitLetClause(LetClauseSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a LineDirectiveTriviaSyntax node.
        void VisitLineDirectiveTrivia(LineDirectiveTriviaSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a LiteralExpressionSyntax node.
        void VisitLiteralExpression(LiteralExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a LoadDirectiveTriviaSyntax node.
        void VisitLoadDirectiveTrivia(LoadDirectiveTriviaSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a LocalDeclarationStatementSyntax node.
        void VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a LocalFunctionStatementSyntax node.
        void VisitLocalFunctionStatement(LocalFunctionStatementSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a LockStatementSyntax node.
        void VisitLockStatement(LockStatementSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a MakeRefExpressionSyntax node.
        void VisitMakeRefExpression(MakeRefExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a MemberAccessExpressionSyntax node.
        void VisitMemberAccessExpression(MemberAccessExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a MemberBindingExpressionSyntax node.
        void VisitMemberBindingExpression(MemberBindingExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a MethodDeclarationSyntax node.
        void VisitMethodDeclaration(MethodDeclarationSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a NameColonSyntax node.
        void VisitNameColon(NameColonSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a NameEqualsSyntax node.
        void VisitNameEquals(NameEqualsSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a NameMemberCrefSyntax node.
        void VisitNameMemberCref(NameMemberCrefSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a NamespaceDeclarationSyntax node.
        void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a NullableTypeSyntax node.
        void VisitNullableType(NullableTypeSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ObjectCreationExpressionSyntax node.
        void VisitObjectCreationExpression(ObjectCreationExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a OmittedArraySizeExpressionSyntax node.
        void VisitOmittedArraySizeExpression(OmittedArraySizeExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a OmittedTypeArgumentSyntax node.
        void VisitOmittedTypeArgument(OmittedTypeArgumentSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a OperatorDeclarationSyntax node.
        void VisitOperatorDeclaration(OperatorDeclarationSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a OperatorMemberCrefSyntax node.
        void VisitOperatorMemberCref(OperatorMemberCrefSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a OrderByClauseSyntax node.
        void VisitOrderByClause(OrderByClauseSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a OrderingSyntax node.
        void VisitOrdering(OrderingSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ParameterSyntax node.
        void VisitParameter(ParameterSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ParameterListSyntax node.
        void VisitParameterList(ParameterListSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ParenthesizedExpressionSyntax node.
        void VisitParenthesizedExpression(ParenthesizedExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ParenthesizedLambdaExpressionSyntax node.
        void VisitParenthesizedLambdaExpression(ParenthesizedLambdaExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ParenthesizedVariableDesignationSyntax node.
        void VisitParenthesizedVariableDesignation(ParenthesizedVariableDesignationSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a PointerTypeSyntax node.
        void VisitPointerType(PointerTypeSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a PostfixUnaryExpressionSyntax node.
        void VisitPostfixUnaryExpression(PostfixUnaryExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a PragmaChecksumDirectiveTriviaSyntax node.
        void VisitPragmaChecksumDirectiveTrivia(PragmaChecksumDirectiveTriviaSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a PragmaWarningDirectiveTriviaSyntax node.
        void VisitPragmaWarningDirectiveTrivia(PragmaWarningDirectiveTriviaSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a PredefinedTypeSyntax node.
        void VisitPredefinedType(PredefinedTypeSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a PrefixUnaryExpressionSyntax node.
        void VisitPrefixUnaryExpression(PrefixUnaryExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a PropertyDeclarationSyntax node.
        void VisitPropertyDeclaration(PropertyDeclarationSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a QualifiedCrefSyntax node.
        void VisitQualifiedCref(QualifiedCrefSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a QualifiedNameSyntax node.
        void VisitQualifiedName(QualifiedNameSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a QueryBodySyntax node.
        void VisitQueryBody(QueryBodySyntax node);
        //
        // Summary:
        //     Called when the visitor visits a QueryContinuationSyntax node.
        void VisitQueryContinuation(QueryContinuationSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a QueryExpressionSyntax node.
        void VisitQueryExpression(QueryExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ReferenceDirectiveTriviaSyntax node.
        void VisitReferenceDirectiveTrivia(ReferenceDirectiveTriviaSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a RefExpressionSyntax node.
        void VisitRefExpression(RefExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a RefTypeSyntax node.
        void VisitRefType(RefTypeSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a RefTypeExpressionSyntax node.
        void VisitRefTypeExpression(RefTypeExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a RefValueExpressionSyntax node.
        void VisitRefValueExpression(RefValueExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a RegionDirectiveTriviaSyntax node.
        void VisitRegionDirectiveTrivia(RegionDirectiveTriviaSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ReturnStatementSyntax node.
        void VisitReturnStatement(ReturnStatementSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a SelectClauseSyntax node.
        void VisitSelectClause(SelectClauseSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ShebangDirectiveTriviaSyntax node.
        void VisitShebangDirectiveTrivia(ShebangDirectiveTriviaSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a SimpleBaseTypeSyntax node.
        void VisitSimpleBaseType(SimpleBaseTypeSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a SimpleLambdaExpressionSyntax node.
        void VisitSimpleLambdaExpression(SimpleLambdaExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a SingleVariableDesignationSyntax node.
        void VisitSingleVariableDesignation(SingleVariableDesignationSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a SizeOfExpressionSyntax node.
        void VisitSizeOfExpression(SizeOfExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a SkippedTokensTriviaSyntax node.
        void VisitSkippedTokensTrivia(SkippedTokensTriviaSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a StackAllocArrayCreationExpressionSyntax node.
        void VisitStackAllocArrayCreationExpression(StackAllocArrayCreationExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a StructDeclarationSyntax node.
        void VisitStructDeclaration(StructDeclarationSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a SwitchSectionSyntax node.
        void VisitSwitchSection(SwitchSectionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a SwitchStatementSyntax node.
        void VisitSwitchStatement(SwitchStatementSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ThisExpressionSyntax node.
        void VisitThisExpression(ThisExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ThrowExpressionSyntax node.
        void VisitThrowExpression(ThrowExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a ThrowStatementSyntax node.
        void VisitThrowStatement(ThrowStatementSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a TryStatementSyntax node.
        void VisitTryStatement(TryStatementSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a TupleElementSyntax node.
        void VisitTupleElement(TupleElementSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a TupleExpressionSyntax node.
        void VisitTupleExpression(TupleExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a TupleTypeSyntax node.
        void VisitTupleType(TupleTypeSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a TypeArgumentListSyntax node.
        void VisitTypeArgumentList(TypeArgumentListSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a TypeConstraintSyntax node.
        void VisitTypeConstraint(TypeConstraintSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a TypeCrefSyntax node.
        void VisitTypeCref(TypeCrefSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a TypeOfExpressionSyntax node.
        void VisitTypeOfExpression(TypeOfExpressionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a TypeParameterSyntax node.
        void VisitTypeParameter(TypeParameterSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a TypeParameterConstraintClauseSyntax node.
        void VisitTypeParameterConstraintClause(TypeParameterConstraintClauseSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a TypeParameterListSyntax node.
        void VisitTypeParameterList(TypeParameterListSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a UndefDirectiveTriviaSyntax node.
        void VisitUndefDirectiveTrivia(UndefDirectiveTriviaSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a UnsafeStatementSyntax node.
        void VisitUnsafeStatement(UnsafeStatementSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a UsingDirectiveSyntax node.
        void VisitUsingDirective(UsingDirectiveSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a UsingStatementSyntax node.
        void VisitUsingStatement(UsingStatementSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a VariableDeclarationSyntax node.
        void VisitVariableDeclaration(VariableDeclarationSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a VariableDeclaratorSyntax node.
        void VisitVariableDeclarator(VariableDeclaratorSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a WarningDirectiveTriviaSyntax node.
        void VisitWarningDirectiveTrivia(WarningDirectiveTriviaSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a WhenClauseSyntax node.
        void VisitWhenClause(WhenClauseSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a WhereClauseSyntax node.
        void VisitWhereClause(WhereClauseSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a WhileStatementSyntax node.
        void VisitWhileStatement(WhileStatementSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a XmlCDataSectionSyntax node.
        void VisitXmlCDataSection(XmlCDataSectionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a XmlCommentSyntax node.
        void VisitXmlComment(XmlCommentSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a XmlCrefAttributeSyntax node.
        void VisitXmlCrefAttribute(XmlCrefAttributeSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a XmlElementSyntax node.
        void VisitXmlElement(XmlElementSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a XmlElementEndTagSyntax node.
        void VisitXmlElementEndTag(XmlElementEndTagSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a XmlElementStartTagSyntax node.
        void VisitXmlElementStartTag(XmlElementStartTagSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a XmlEmptyElementSyntax node.
        void VisitXmlEmptyElement(XmlEmptyElementSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a XmlNameSyntax node.
        void VisitXmlName(XmlNameSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a XmlNameAttributeSyntax node.
        void VisitXmlNameAttribute(XmlNameAttributeSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a XmlPrefixSyntax node.
        void VisitXmlPrefix(XmlPrefixSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a XmlProcessingInstructionSyntax node.
        void VisitXmlProcessingInstruction(XmlProcessingInstructionSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a XmlTextSyntax node.
        void VisitXmlText(XmlTextSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a XmlTextAttributeSyntax node.
        void VisitXmlTextAttribute(XmlTextAttributeSyntax node);
        //
        // Summary:
        //     Called when the visitor visits a YieldStatementSyntax node.
        void VisitYieldStatement(YieldStatementSyntax node);

    }
}
