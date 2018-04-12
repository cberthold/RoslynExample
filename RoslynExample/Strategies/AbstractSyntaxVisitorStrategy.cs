﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RoslynExample.Mapper;

namespace RoslynExample
{
    public abstract class AbstractSyntaxVisitorStrategy : ISyntaxVisitorStrategy
    {
        public Func<IClassMapper> MapperFunction { get; private set; }

        public virtual void DefaultVisit(SyntaxNode node)
        {
            
        }

        public void SetMapperFunc(Func<IClassMapper> classMapperFunc)
        {
            MapperFunction = classMapperFunc;
        }

        public virtual void Visit(SyntaxNode node)
        {
            
        }

        public virtual void VisitAccessorDeclaration(AccessorDeclarationSyntax node)
        {
            
        }

        public virtual void VisitAccessorList(AccessorListSyntax node)
        {
            
        }

        public virtual void VisitAliasQualifiedName(AliasQualifiedNameSyntax node)
        {
            
        }

        public virtual void VisitAnonymousMethodExpression(AnonymousMethodExpressionSyntax node)
        {
            
        }

        public virtual void VisitAnonymousObjectCreationExpression(AnonymousObjectCreationExpressionSyntax node)
        {
            
        }

        public virtual void VisitAnonymousObjectMemberDeclarator(AnonymousObjectMemberDeclaratorSyntax node)
        {
            
        }

        public virtual void VisitArgument(ArgumentSyntax node)
        {
            
        }

        public virtual void VisitArgumentList(ArgumentListSyntax node)
        {
            
        }

        public virtual void VisitArrayCreationExpression(ArrayCreationExpressionSyntax node)
        {
            
        }

        public virtual void VisitArrayRankSpecifier(ArrayRankSpecifierSyntax node)
        {
            
        }

        public virtual void VisitArrayType(ArrayTypeSyntax node)
        {
            
        }

        public virtual void VisitArrowExpressionClause(ArrowExpressionClauseSyntax node)
        {
            
        }

        public virtual void VisitAssignmentExpression(AssignmentExpressionSyntax node)
        {
            
        }

        public virtual void VisitAttribute(AttributeSyntax node)
        {
            
        }

        public virtual void VisitAttributeArgument(AttributeArgumentSyntax node)
        {
            
        }

        public virtual void VisitAttributeArgumentList(AttributeArgumentListSyntax node)
        {
            
        }

        public virtual void VisitAttributeList(AttributeListSyntax node)
        {
            
        }

        public virtual void VisitAttributeTargetSpecifier(AttributeTargetSpecifierSyntax node)
        {
            
        }

        public virtual void VisitAwaitExpression(AwaitExpressionSyntax node)
        {
            
        }

        public virtual void VisitBadDirectiveTrivia(BadDirectiveTriviaSyntax node)
        {
            
        }

        public virtual void VisitBaseExpression(BaseExpressionSyntax node)
        {
            
        }

        public virtual void VisitBaseList(BaseListSyntax node)
        {
            
        }

        public virtual void VisitBinaryExpression(BinaryExpressionSyntax node)
        {
            
        }

        public virtual void VisitBlock(BlockSyntax node)
        {
            
        }

        public virtual void VisitBracketedArgumentList(BracketedArgumentListSyntax node)
        {
            
        }

        public virtual void VisitBracketedParameterList(BracketedParameterListSyntax node)
        {
            
        }

        public virtual void VisitBreakStatement(BreakStatementSyntax node)
        {
            
        }

        public virtual void VisitCasePatternSwitchLabel(CasePatternSwitchLabelSyntax node)
        {
            
        }

        public virtual void VisitCaseSwitchLabel(CaseSwitchLabelSyntax node)
        {
            
        }

        public virtual void VisitCastExpression(CastExpressionSyntax node)
        {
            
        }

        public virtual void VisitCatchClause(CatchClauseSyntax node)
        {
            
        }

        public virtual void VisitCatchDeclaration(CatchDeclarationSyntax node)
        {
            
        }

        public virtual void VisitCatchFilterClause(CatchFilterClauseSyntax node)
        {
            
        }

        public virtual void VisitCheckedExpression(CheckedExpressionSyntax node)
        {
            
        }

        public virtual void VisitCheckedStatement(CheckedStatementSyntax node)
        {
            
        }

        public virtual void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            
        }

        public virtual void VisitClassOrStructConstraint(ClassOrStructConstraintSyntax node)
        {
            
        }

        public virtual void VisitCompilationUnit(CompilationUnitSyntax node)
        {
            
        }

        public virtual void VisitConditionalAccessExpression(ConditionalAccessExpressionSyntax node)
        {
            
        }

        public virtual void VisitConditionalExpression(ConditionalExpressionSyntax node)
        {
            
        }

        public virtual void VisitConstantPattern(ConstantPatternSyntax node)
        {
            
        }

        public virtual void VisitConstructorConstraint(ConstructorConstraintSyntax node)
        {
            
        }

        public virtual void VisitConstructorDeclaration(ConstructorDeclarationSyntax node)
        {
            
        }

        public virtual void VisitConstructorInitializer(ConstructorInitializerSyntax node)
        {
            
        }

        public virtual void VisitContinueStatement(ContinueStatementSyntax node)
        {
            
        }

        public virtual void VisitConversionOperatorDeclaration(ConversionOperatorDeclarationSyntax node)
        {
            
        }

        public virtual void VisitConversionOperatorMemberCref(ConversionOperatorMemberCrefSyntax node)
        {
            
        }

        public virtual void VisitCrefBracketedParameterList(CrefBracketedParameterListSyntax node)
        {
            
        }

        public virtual void VisitCrefParameter(CrefParameterSyntax node)
        {
            
        }

        public virtual void VisitCrefParameterList(CrefParameterListSyntax node)
        {
            
        }

        public virtual void VisitDeclarationExpression(DeclarationExpressionSyntax node)
        {
            
        }

        public virtual void VisitDeclarationPattern(DeclarationPatternSyntax node)
        {
            
        }

        public virtual void VisitDefaultExpression(DefaultExpressionSyntax node)
        {
            
        }

        public virtual void VisitDefaultSwitchLabel(DefaultSwitchLabelSyntax node)
        {
            
        }

        public virtual void VisitDefineDirectiveTrivia(DefineDirectiveTriviaSyntax node)
        {
            
        }

        public virtual void VisitDelegateDeclaration(DelegateDeclarationSyntax node)
        {
            
        }

        public virtual void VisitDestructorDeclaration(DestructorDeclarationSyntax node)
        {
            
        }

        public virtual void VisitDiscardDesignation(DiscardDesignationSyntax node)
        {
            
        }

        public virtual void VisitDocumentationCommentTrivia(DocumentationCommentTriviaSyntax node)
        {
            
        }

        public virtual void VisitDoStatement(DoStatementSyntax node)
        {
            
        }

        public virtual void VisitElementAccessExpression(ElementAccessExpressionSyntax node)
        {
            
        }

        public virtual void VisitElementBindingExpression(ElementBindingExpressionSyntax node)
        {
            
        }

        public virtual void VisitElifDirectiveTrivia(ElifDirectiveTriviaSyntax node)
        {
            
        }

        public virtual void VisitElseClause(ElseClauseSyntax node)
        {
            
        }

        public virtual void VisitElseDirectiveTrivia(ElseDirectiveTriviaSyntax node)
        {
            
        }

        public virtual void VisitEmptyStatement(EmptyStatementSyntax node)
        {
            
        }

        public virtual void VisitEndIfDirectiveTrivia(EndIfDirectiveTriviaSyntax node)
        {
            
        }

        public virtual void VisitEndRegionDirectiveTrivia(EndRegionDirectiveTriviaSyntax node)
        {
            
        }

        public virtual void VisitEnumDeclaration(EnumDeclarationSyntax node)
        {
            
        }

        public virtual void VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
        {
            
        }

        public virtual void VisitEqualsValueClause(EqualsValueClauseSyntax node)
        {
            
        }

        public virtual void VisitErrorDirectiveTrivia(ErrorDirectiveTriviaSyntax node)
        {
            
        }

        public virtual void VisitEventDeclaration(EventDeclarationSyntax node)
        {
            
        }

        public virtual void VisitEventFieldDeclaration(EventFieldDeclarationSyntax node)
        {
            
        }

        public virtual void VisitExplicitInterfaceSpecifier(ExplicitInterfaceSpecifierSyntax node)
        {
            
        }

        public virtual void VisitExpressionStatement(ExpressionStatementSyntax node)
        {
            
        }

        public virtual void VisitExternAliasDirective(ExternAliasDirectiveSyntax node)
        {
            
        }

        public virtual void VisitFieldDeclaration(FieldDeclarationSyntax node)
        {
            
        }

        public virtual void VisitFinallyClause(FinallyClauseSyntax node)
        {
            
        }

        public virtual void VisitFixedStatement(FixedStatementSyntax node)
        {
            
        }

        public virtual void VisitForEachStatement(ForEachStatementSyntax node)
        {
            
        }

        public virtual void VisitForEachVariableStatement(ForEachVariableStatementSyntax node)
        {
            
        }

        public virtual void VisitForStatement(ForStatementSyntax node)
        {
            
        }

        public virtual void VisitFromClause(FromClauseSyntax node)
        {
            
        }

        public virtual void VisitGenericName(GenericNameSyntax node)
        {
            
        }

        public virtual void VisitGlobalStatement(GlobalStatementSyntax node)
        {
            
        }

        public virtual void VisitGotoStatement(GotoStatementSyntax node)
        {
            
        }

        public virtual void VisitGroupClause(GroupClauseSyntax node)
        {
            
        }

        public virtual void VisitIdentifierName(IdentifierNameSyntax node)
        {
            
        }

        public virtual void VisitIfDirectiveTrivia(IfDirectiveTriviaSyntax node)
        {
            
        }

        public virtual void VisitIfStatement(IfStatementSyntax node)
        {
            
        }

        public virtual void VisitImplicitArrayCreationExpression(ImplicitArrayCreationExpressionSyntax node)
        {
            
        }

        public virtual void VisitImplicitElementAccess(ImplicitElementAccessSyntax node)
        {
            
        }

        public virtual void VisitIncompleteMember(IncompleteMemberSyntax node)
        {
            
        }

        public virtual void VisitIndexerDeclaration(IndexerDeclarationSyntax node)
        {
            
        }

        public virtual void VisitIndexerMemberCref(IndexerMemberCrefSyntax node)
        {
            
        }

        public virtual void VisitInitializerExpression(InitializerExpressionSyntax node)
        {
            
        }

        public virtual void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
        {
            
        }

        public virtual void VisitInterpolatedStringExpression(InterpolatedStringExpressionSyntax node)
        {
            
        }

        public virtual void VisitInterpolatedStringText(InterpolatedStringTextSyntax node)
        {
            
        }

        public virtual void VisitInterpolation(InterpolationSyntax node)
        {
            
        }

        public virtual void VisitInterpolationAlignmentClause(InterpolationAlignmentClauseSyntax node)
        {
            
        }

        public virtual void VisitInterpolationFormatClause(InterpolationFormatClauseSyntax node)
        {
            
        }

        public virtual void VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            
        }

        public virtual void VisitIsPatternExpression(IsPatternExpressionSyntax node)
        {
            
        }

        public virtual void VisitJoinClause(JoinClauseSyntax node)
        {
            
        }

        public virtual void VisitJoinIntoClause(JoinIntoClauseSyntax node)
        {
            
        }

        public virtual void VisitLabeledStatement(LabeledStatementSyntax node)
        {
            
        }

        public virtual void VisitLetClause(LetClauseSyntax node)
        {
            
        }

        public virtual void VisitLineDirectiveTrivia(LineDirectiveTriviaSyntax node)
        {
            
        }

        public virtual void VisitLiteralExpression(LiteralExpressionSyntax node)
        {
            
        }

        public virtual void VisitLoadDirectiveTrivia(LoadDirectiveTriviaSyntax node)
        {
            
        }

        public virtual void VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
        {
            
        }

        public virtual void VisitLocalFunctionStatement(LocalFunctionStatementSyntax node)
        {
            
        }

        public virtual void VisitLockStatement(LockStatementSyntax node)
        {
            
        }

        public virtual void VisitMakeRefExpression(MakeRefExpressionSyntax node)
        {
            
        }

        public virtual void VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
        {
            
        }

        public virtual void VisitMemberBindingExpression(MemberBindingExpressionSyntax node)
        {
            
        }

        public virtual void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            
        }

        public virtual void VisitNameColon(NameColonSyntax node)
        {
            
        }

        public virtual void VisitNameEquals(NameEqualsSyntax node)
        {
            
        }

        public virtual void VisitNameMemberCref(NameMemberCrefSyntax node)
        {
            
        }

        public virtual void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
        {
            
        }

        public virtual void VisitNullableType(NullableTypeSyntax node)
        {
            
        }

        public virtual void VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
        {
            
        }

        public virtual void VisitOmittedArraySizeExpression(OmittedArraySizeExpressionSyntax node)
        {
            
        }

        public virtual void VisitOmittedTypeArgument(OmittedTypeArgumentSyntax node)
        {
            
        }

        public virtual void VisitOperatorDeclaration(OperatorDeclarationSyntax node)
        {
            
        }

        public virtual void VisitOperatorMemberCref(OperatorMemberCrefSyntax node)
        {
            
        }

        public virtual void VisitOrderByClause(OrderByClauseSyntax node)
        {
            
        }

        public virtual void VisitOrdering(OrderingSyntax node)
        {
            
        }

        public virtual void VisitParameter(ParameterSyntax node)
        {
            
        }

        public virtual void VisitParameterList(ParameterListSyntax node)
        {
            
        }

        public virtual void VisitParenthesizedExpression(ParenthesizedExpressionSyntax node)
        {
            
        }

        public virtual void VisitParenthesizedLambdaExpression(ParenthesizedLambdaExpressionSyntax node)
        {
            
        }

        public virtual void VisitParenthesizedVariableDesignation(ParenthesizedVariableDesignationSyntax node)
        {
            
        }

        public virtual void VisitPointerType(PointerTypeSyntax node)
        {
            
        }

        public virtual void VisitPostfixUnaryExpression(PostfixUnaryExpressionSyntax node)
        {
            
        }

        public virtual void VisitPragmaChecksumDirectiveTrivia(PragmaChecksumDirectiveTriviaSyntax node)
        {
            
        }

        public virtual void VisitPragmaWarningDirectiveTrivia(PragmaWarningDirectiveTriviaSyntax node)
        {
            
        }

        public virtual void VisitPredefinedType(PredefinedTypeSyntax node)
        {
            
        }

        public virtual void VisitPrefixUnaryExpression(PrefixUnaryExpressionSyntax node)
        {
            
        }

        public virtual void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        {
            
        }

        public virtual void VisitQualifiedCref(QualifiedCrefSyntax node)
        {
            
        }

        public virtual void VisitQualifiedName(QualifiedNameSyntax node)
        {
            
        }

        public virtual void VisitQueryBody(QueryBodySyntax node)
        {
            
        }

        public virtual void VisitQueryContinuation(QueryContinuationSyntax node)
        {
            
        }

        public virtual void VisitQueryExpression(QueryExpressionSyntax node)
        {
            
        }

        public virtual void VisitReferenceDirectiveTrivia(ReferenceDirectiveTriviaSyntax node)
        {
            
        }

        public virtual void VisitRefExpression(RefExpressionSyntax node)
        {
            
        }

        public virtual void VisitRefType(RefTypeSyntax node)
        {
            
        }

        public virtual void VisitRefTypeExpression(RefTypeExpressionSyntax node)
        {
            
        }

        public virtual void VisitRefValueExpression(RefValueExpressionSyntax node)
        {
            
        }

        public virtual void VisitRegionDirectiveTrivia(RegionDirectiveTriviaSyntax node)
        {
            
        }

        public virtual void VisitReturnStatement(ReturnStatementSyntax node)
        {
            
        }

        public virtual void VisitSelectClause(SelectClauseSyntax node)
        {
            
        }

        public virtual void VisitShebangDirectiveTrivia(ShebangDirectiveTriviaSyntax node)
        {
            
        }

        public virtual void VisitSimpleBaseType(SimpleBaseTypeSyntax node)
        {
            
        }

        public virtual void VisitSimpleLambdaExpression(SimpleLambdaExpressionSyntax node)
        {
            
        }

        public virtual void VisitSingleVariableDesignation(SingleVariableDesignationSyntax node)
        {
            
        }

        public virtual void VisitSizeOfExpression(SizeOfExpressionSyntax node)
        {
            
        }

        public virtual void VisitSkippedTokensTrivia(SkippedTokensTriviaSyntax node)
        {
            
        }

        public virtual void VisitStackAllocArrayCreationExpression(StackAllocArrayCreationExpressionSyntax node)
        {
            
        }

        public virtual void VisitStructDeclaration(StructDeclarationSyntax node)
        {
            
        }

        public virtual void VisitSwitchSection(SwitchSectionSyntax node)
        {
            
        }

        public virtual void VisitSwitchStatement(SwitchStatementSyntax node)
        {
            
        }

        public virtual void VisitThisExpression(ThisExpressionSyntax node)
        {
            
        }

        public virtual void VisitThrowExpression(ThrowExpressionSyntax node)
        {
            
        }

        public virtual void VisitThrowStatement(ThrowStatementSyntax node)
        {
            
        }

        public virtual void VisitTryStatement(TryStatementSyntax node)
        {
            
        }

        public virtual void VisitTupleElement(TupleElementSyntax node)
        {
            
        }

        public virtual void VisitTupleExpression(TupleExpressionSyntax node)
        {
            
        }

        public virtual void VisitTupleType(TupleTypeSyntax node)
        {
            
        }

        public virtual void VisitTypeArgumentList(TypeArgumentListSyntax node)
        {
            
        }

        public virtual void VisitTypeConstraint(TypeConstraintSyntax node)
        {
            
        }

        public virtual void VisitTypeCref(TypeCrefSyntax node)
        {
            
        }

        public virtual void VisitTypeOfExpression(TypeOfExpressionSyntax node)
        {
            
        }

        public virtual void VisitTypeParameter(TypeParameterSyntax node)
        {
            
        }

        public virtual void VisitTypeParameterConstraintClause(TypeParameterConstraintClauseSyntax node)
        {
            
        }

        public virtual void VisitTypeParameterList(TypeParameterListSyntax node)
        {
            
        }

        public virtual void VisitUndefDirectiveTrivia(UndefDirectiveTriviaSyntax node)
        {
            
        }

        public virtual void VisitUnsafeStatement(UnsafeStatementSyntax node)
        {
            
        }

        public virtual void VisitUsingDirective(UsingDirectiveSyntax node)
        {
            
        }

        public virtual void VisitUsingStatement(UsingStatementSyntax node)
        {
            
        }

        public virtual void VisitVariableDeclaration(VariableDeclarationSyntax node)
        {
            
        }

        public virtual void VisitVariableDeclarator(VariableDeclaratorSyntax node)
        {
            
        }

        public virtual void VisitWarningDirectiveTrivia(WarningDirectiveTriviaSyntax node)
        {
            
        }

        public virtual void VisitWhenClause(WhenClauseSyntax node)
        {
            
        }

        public virtual void VisitWhereClause(WhereClauseSyntax node)
        {
            
        }

        public virtual void VisitWhileStatement(WhileStatementSyntax node)
        {
            
        }

        public virtual void VisitXmlCDataSection(XmlCDataSectionSyntax node)
        {
            
        }

        public virtual void VisitXmlComment(XmlCommentSyntax node)
        {
            
        }

        public virtual void VisitXmlCrefAttribute(XmlCrefAttributeSyntax node)
        {
            
        }

        public virtual void VisitXmlElement(XmlElementSyntax node)
        {
            
        }

        public virtual void VisitXmlElementEndTag(XmlElementEndTagSyntax node)
        {
            
        }

        public virtual void VisitXmlElementStartTag(XmlElementStartTagSyntax node)
        {
            
        }

        public virtual void VisitXmlEmptyElement(XmlEmptyElementSyntax node)
        {
            
        }

        public virtual void VisitXmlName(XmlNameSyntax node)
        {
            
        }

        public virtual void VisitXmlNameAttribute(XmlNameAttributeSyntax node)
        {
            
        }

        public virtual void VisitXmlPrefix(XmlPrefixSyntax node)
        {
            
        }

        public virtual void VisitXmlProcessingInstruction(XmlProcessingInstructionSyntax node)
        {
            
        }

        public virtual void VisitXmlText(XmlTextSyntax node)
        {
            
        }

        public virtual void VisitXmlTextAttribute(XmlTextAttributeSyntax node)
        {
            
        }

        public virtual void VisitYieldStatement(YieldStatementSyntax node)
        {
            
        }
    }
}