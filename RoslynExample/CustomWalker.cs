using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RoslynExample.Mapper;

namespace RoslynExample
{
    public class CustomWalker : CSharpSyntaxWalker
    {
        private readonly Func<IClassMapper> mapperFunc;
        private readonly IList<ISyntaxVisitorStrategy> strategies;
        public CustomWalker(IClassMapper mapper)
        {
            mapperFunc = () => mapper;
            strategies = new List<ISyntaxVisitorStrategy>()
            {
                new ClassNameStrategy(),
                new FieldStrategy(),
            };
            SetAllMapperFunctions(strategies);
        }
        private void ExecuteStrategies(Action<ISyntaxVisitorStrategy> action)
        {
            foreach (var strategy in strategies)
            {
                action(strategy);
            }
        }
        private void SetAllMapperFunctions(IList<ISyntaxVisitorStrategy> strategies)
        {
            foreach (var strategy in strategies)
            {
                strategy.SetMapperFunc(mapperFunc);
            }
        }
        static int Tabs = 0;
        public override void Visit(SyntaxNode node)
        {
            Tabs++;
            var indents = new String('\t', Tabs);
            Console.WriteLine(indents + node.Kind());
            ExecuteStrategies((s) => s.Visit(node));
            base.Visit(node);
            Tabs--;
        }
        public override void VisitAccessorDeclaration(AccessorDeclarationSyntax node)
        {
            ExecuteStrategies((s) => s.VisitAccessorDeclaration(node));
            base.VisitAccessorDeclaration(node);
        }
        public override void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        {

            ExecuteStrategies((s) => s.VisitPropertyDeclaration(node));
            base.VisitPropertyDeclaration(node);
        }
        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            ExecuteStrategies((s) => s.VisitClassDeclaration(node));
            base.VisitClassDeclaration(node);
        }
        public override void VisitIdentifierName(IdentifierNameSyntax node)
        {
            ExecuteStrategies((s) => s.VisitIdentifierName(node));
            base.VisitIdentifierName(node);
        }
        public override void VisitQualifiedName(QualifiedNameSyntax node)
        {
            ExecuteStrategies((s) => s.VisitQualifiedName(node));
            base.VisitQualifiedName(node);
        }
        public override void VisitGenericName(GenericNameSyntax node)
        {
            ExecuteStrategies((s) => s.VisitGenericName(node));
            base.VisitGenericName(node);
        }
        public override void VisitTypeArgumentList(TypeArgumentListSyntax node)
        {
            ExecuteStrategies((s) => s.VisitTypeArgumentList(node));
            base.VisitTypeArgumentList(node);
        }
        public override void VisitAliasQualifiedName(AliasQualifiedNameSyntax node)
        {
            ExecuteStrategies((s) => s.VisitAliasQualifiedName(node));
            base.VisitAliasQualifiedName(node);
        }
        public override void VisitPredefinedType(PredefinedTypeSyntax node)
        {
            ExecuteStrategies((s) => s.VisitPredefinedType(node));
            base.VisitPredefinedType(node);
        }
        public override void VisitArrayType(ArrayTypeSyntax node)
        {
            ExecuteStrategies((s) => s.VisitArrayType(node));
            base.VisitArrayType(node);
        }
        public override void VisitArrayRankSpecifier(ArrayRankSpecifierSyntax node)
        {
            ExecuteStrategies((s) => s.VisitArrayRankSpecifier(node));
            base.VisitArrayRankSpecifier(node);
        }
        public override void VisitPointerType(PointerTypeSyntax node)
        {
            ExecuteStrategies((s) => s.VisitPointerType(node));
            base.VisitPointerType(node);
        }
        public override void VisitNullableType(NullableTypeSyntax node)
        {
            ExecuteStrategies((s) => s.VisitNullableType(node));
            base.VisitNullableType(node);
        }
        public override void VisitTupleType(TupleTypeSyntax node)
        {
            ExecuteStrategies((s) => s.VisitTupleType(node));
            base.VisitTupleType(node);
        }
        public override void VisitTupleElement(TupleElementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitTupleElement(node));
            base.VisitTupleElement(node);
        }
        public override void VisitOmittedTypeArgument(OmittedTypeArgumentSyntax node)
        {
            ExecuteStrategies((s) => s.VisitOmittedTypeArgument(node));
            base.VisitOmittedTypeArgument(node);
        }
        public override void VisitRefType(RefTypeSyntax node)
        {
            ExecuteStrategies((s) => s.VisitRefType(node));
            base.VisitRefType(node);
        }
        public override void VisitParenthesizedExpression(ParenthesizedExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitParenthesizedExpression(node));
            base.VisitParenthesizedExpression(node);
        }
        public override void VisitTupleExpression(TupleExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitTupleExpression(node));
            base.VisitTupleExpression(node);
        }
        public override void VisitPrefixUnaryExpression(PrefixUnaryExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitPrefixUnaryExpression(node));
            base.VisitPrefixUnaryExpression(node);
        }
        public override void VisitAwaitExpression(AwaitExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitAwaitExpression(node));
            base.VisitAwaitExpression(node);
        }
        public override void VisitPostfixUnaryExpression(PostfixUnaryExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitPostfixUnaryExpression(node));
            base.VisitPostfixUnaryExpression(node);
        }
        public override void VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitMemberAccessExpression(node));
            base.VisitMemberAccessExpression(node);
        }
        public override void VisitConditionalAccessExpression(ConditionalAccessExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitConditionalAccessExpression(node));
            base.VisitConditionalAccessExpression(node);
        }
        public override void VisitMemberBindingExpression(MemberBindingExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitMemberBindingExpression(node));
            base.VisitMemberBindingExpression(node);
        }
        public override void VisitElementBindingExpression(ElementBindingExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitElementBindingExpression(node));
            base.VisitElementBindingExpression(node);
        }
        public override void VisitImplicitElementAccess(ImplicitElementAccessSyntax node)
        {
            ExecuteStrategies((s) => s.VisitImplicitElementAccess(node));
            base.VisitImplicitElementAccess(node);
        }
        public override void VisitBinaryExpression(BinaryExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitBinaryExpression(node));
            base.VisitBinaryExpression(node);
        }
        public override void VisitAssignmentExpression(AssignmentExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitAssignmentExpression(node));
            base.VisitAssignmentExpression(node);
        }
        public override void VisitConditionalExpression(ConditionalExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitConditionalExpression(node));
            base.VisitConditionalExpression(node);
        }
        public override void VisitThisExpression(ThisExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitThisExpression(node));
            base.VisitThisExpression(node);
        }
        public override void VisitBaseExpression(BaseExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitBaseExpression(node));
            base.VisitBaseExpression(node);
        }
        public override void VisitLiteralExpression(LiteralExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitLiteralExpression(node));
            base.VisitLiteralExpression(node);
        }
        public override void VisitMakeRefExpression(MakeRefExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitMakeRefExpression(node));
            base.VisitMakeRefExpression(node);
        }
        public override void VisitRefTypeExpression(RefTypeExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitRefTypeExpression(node));
            base.VisitRefTypeExpression(node);
        }
        public override void VisitRefValueExpression(RefValueExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitRefValueExpression(node));
            base.VisitRefValueExpression(node);
        }
        public override void VisitCheckedExpression(CheckedExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitCheckedExpression(node));
            base.VisitCheckedExpression(node);
        }
        public override void VisitDefaultExpression(DefaultExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitDefaultExpression(node));
            base.VisitDefaultExpression(node);
        }
        public override void VisitTypeOfExpression(TypeOfExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitTypeOfExpression(node));
            base.VisitTypeOfExpression(node);
        }
        public override void VisitSizeOfExpression(SizeOfExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitSizeOfExpression(node));
            base.VisitSizeOfExpression(node);
        }
        public override void VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitInvocationExpression(node));
            base.VisitInvocationExpression(node);
        }
        public override void VisitElementAccessExpression(ElementAccessExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitElementAccessExpression(node));
            base.VisitElementAccessExpression(node);
        }
        public override void VisitArgumentList(ArgumentListSyntax node)
        {
            ExecuteStrategies((s) => s.VisitArgumentList(node));
            base.VisitArgumentList(node);
        }
        public override void VisitBracketedArgumentList(BracketedArgumentListSyntax node)
        {
            ExecuteStrategies((s) => s.VisitBracketedArgumentList(node));
            base.VisitBracketedArgumentList(node);
        }
        public override void VisitArgument(ArgumentSyntax node)
        {
            ExecuteStrategies((s) => s.VisitArgument(node));
            base.VisitArgument(node);
        }
        public override void VisitNameColon(NameColonSyntax node)
        {
            ExecuteStrategies((s) => s.VisitNameColon(node));
            base.VisitNameColon(node);
        }
        public override void VisitDeclarationExpression(DeclarationExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitDeclarationExpression(node));
            base.VisitDeclarationExpression(node);
        }
        public override void VisitCastExpression(CastExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitCastExpression(node));
            base.VisitCastExpression(node);
        }
        public override void VisitAnonymousMethodExpression(AnonymousMethodExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitAnonymousMethodExpression(node));
            base.VisitAnonymousMethodExpression(node);
        }
        public override void VisitSimpleLambdaExpression(SimpleLambdaExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitSimpleLambdaExpression(node));
            base.VisitSimpleLambdaExpression(node);
        }
        public override void VisitRefExpression(RefExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitRefExpression(node));
            base.VisitRefExpression(node);
        }
        public override void VisitParenthesizedLambdaExpression(ParenthesizedLambdaExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitParenthesizedLambdaExpression(node));
            base.VisitParenthesizedLambdaExpression(node);
        }
        public override void VisitInitializerExpression(InitializerExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitInitializerExpression(node));
            base.VisitInitializerExpression(node);
        }
        public override void VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitObjectCreationExpression(node));
            base.VisitObjectCreationExpression(node);
        }
        public override void VisitAnonymousObjectMemberDeclarator(AnonymousObjectMemberDeclaratorSyntax node)
        {
            ExecuteStrategies((s) => s.VisitAnonymousObjectMemberDeclarator(node));
            base.VisitAnonymousObjectMemberDeclarator(node);
        }
        public override void VisitAnonymousObjectCreationExpression(AnonymousObjectCreationExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitAnonymousObjectCreationExpression(node));
            base.VisitAnonymousObjectCreationExpression(node);
        }
        public override void VisitArrayCreationExpression(ArrayCreationExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitArrayCreationExpression(node));
            base.VisitArrayCreationExpression(node);
        }
        public override void VisitImplicitArrayCreationExpression(ImplicitArrayCreationExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitImplicitArrayCreationExpression(node));
            base.VisitImplicitArrayCreationExpression(node);
        }
        public override void VisitStackAllocArrayCreationExpression(StackAllocArrayCreationExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitStackAllocArrayCreationExpression(node));
            base.VisitStackAllocArrayCreationExpression(node);
        }
        public override void VisitQueryExpression(QueryExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitQueryExpression(node));
            base.VisitQueryExpression(node);
        }
        public override void VisitQueryBody(QueryBodySyntax node)
        {
            ExecuteStrategies((s) => s.VisitQueryBody(node));
            base.VisitQueryBody(node);
        }
        public override void VisitFromClause(FromClauseSyntax node)
        {
            ExecuteStrategies((s) => s.VisitFromClause(node));
            base.VisitFromClause(node);
        }
        public override void VisitLetClause(LetClauseSyntax node)
        {
            ExecuteStrategies((s) => s.VisitLetClause(node));
            base.VisitLetClause(node);
        }
        public override void VisitJoinClause(JoinClauseSyntax node)
        {
            ExecuteStrategies((s) => s.VisitJoinClause(node));
            base.VisitJoinClause(node);
        }
        public override void VisitJoinIntoClause(JoinIntoClauseSyntax node)
        {
            ExecuteStrategies((s) => s.VisitJoinIntoClause(node));
            base.VisitJoinIntoClause(node);
        }
        public override void VisitWhereClause(WhereClauseSyntax node)
        {
            ExecuteStrategies((s) => s.VisitWhereClause(node));
            base.VisitWhereClause(node);
        }
        public override void VisitOrderByClause(OrderByClauseSyntax node)
        {
            ExecuteStrategies((s) => s.VisitOrderByClause(node));
            base.VisitOrderByClause(node);
        }
        public override void VisitOrdering(OrderingSyntax node)
        {
            ExecuteStrategies((s) => s.VisitOrdering(node));
            base.VisitOrdering(node);
        }
        public override void VisitSelectClause(SelectClauseSyntax node)
        {
            ExecuteStrategies((s) => s.VisitSelectClause(node));
            base.VisitSelectClause(node);
        }
        public override void VisitGroupClause(GroupClauseSyntax node)
        {
            ExecuteStrategies((s) => s.VisitGroupClause(node));
            base.VisitGroupClause(node);
        }
        public override void VisitQueryContinuation(QueryContinuationSyntax node)
        {
            ExecuteStrategies((s) => s.VisitQueryContinuation(node));
            base.VisitQueryContinuation(node);
        }
        public override void VisitOmittedArraySizeExpression(OmittedArraySizeExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitOmittedArraySizeExpression(node));
            base.VisitOmittedArraySizeExpression(node);
        }
        public override void VisitInterpolatedStringExpression(InterpolatedStringExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitInterpolatedStringExpression(node));
            base.VisitInterpolatedStringExpression(node);
        }
        public override void VisitIsPatternExpression(IsPatternExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitIsPatternExpression(node));
            base.VisitIsPatternExpression(node);
        }
        public override void VisitThrowExpression(ThrowExpressionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitThrowExpression(node));
            base.VisitThrowExpression(node);
        }
        public override void VisitWhenClause(WhenClauseSyntax node)
        {
            ExecuteStrategies((s) => s.VisitWhenClause(node));
            base.VisitWhenClause(node);
        }
        public override void VisitDeclarationPattern(DeclarationPatternSyntax node)
        {
            ExecuteStrategies((s) => s.VisitDeclarationPattern(node));
            base.VisitDeclarationPattern(node);
        }
        public override void VisitConstantPattern(ConstantPatternSyntax node)
        {
            ExecuteStrategies((s) => s.VisitConstantPattern(node));
            base.VisitConstantPattern(node);
        }
        public override void VisitInterpolatedStringText(InterpolatedStringTextSyntax node)
        {
            ExecuteStrategies((s) => s.VisitInterpolatedStringText(node));
            base.VisitInterpolatedStringText(node);
        }
        public override void VisitInterpolation(InterpolationSyntax node)
        {
            ExecuteStrategies((s) => s.VisitInterpolation(node));
            base.VisitInterpolation(node);
        }
        public override void VisitInterpolationAlignmentClause(InterpolationAlignmentClauseSyntax node)
        {
            ExecuteStrategies((s) => s.VisitInterpolationAlignmentClause(node));
            base.VisitInterpolationAlignmentClause(node);
        }
        public override void VisitInterpolationFormatClause(InterpolationFormatClauseSyntax node)
        {
            ExecuteStrategies((s) => s.VisitInterpolationFormatClause(node));
            base.VisitInterpolationFormatClause(node);
        }
        public override void VisitGlobalStatement(GlobalStatementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitGlobalStatement(node));
            base.VisitGlobalStatement(node);
        }
        public override void VisitBlock(BlockSyntax node)
        {
            ExecuteStrategies((s) => s.VisitBlock(node));
            base.VisitBlock(node);
        }
        public override void VisitLocalFunctionStatement(LocalFunctionStatementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitLocalFunctionStatement(node));
            base.VisitLocalFunctionStatement(node);
        }
        public override void VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitLocalDeclarationStatement(node));
            base.VisitLocalDeclarationStatement(node);
        }
        public override void VisitVariableDeclaration(VariableDeclarationSyntax node)
        {
            ExecuteStrategies((s) => s.VisitVariableDeclaration(node));
            base.VisitVariableDeclaration(node);
        }
        public override void VisitVariableDeclarator(VariableDeclaratorSyntax node)
        {
            ExecuteStrategies((s) => s.VisitVariableDeclarator(node));
            base.VisitVariableDeclarator(node);
        }
        public override void VisitEqualsValueClause(EqualsValueClauseSyntax node)
        {
            ExecuteStrategies((s) => s.VisitEqualsValueClause(node));
            base.VisitEqualsValueClause(node);
        }
        public override void VisitSingleVariableDesignation(SingleVariableDesignationSyntax node)
        {
            ExecuteStrategies((s) => s.VisitSingleVariableDesignation(node));
            base.VisitSingleVariableDesignation(node);
        }
        public override void VisitDiscardDesignation(DiscardDesignationSyntax node)
        {
            ExecuteStrategies((s) => s.VisitDiscardDesignation(node));
            base.VisitDiscardDesignation(node);
        }
        public override void VisitParenthesizedVariableDesignation(ParenthesizedVariableDesignationSyntax node)
        {
            ExecuteStrategies((s) => s.VisitParenthesizedVariableDesignation(node));
            base.VisitParenthesizedVariableDesignation(node);
        }
        public override void VisitExpressionStatement(ExpressionStatementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitExpressionStatement(node));
            base.VisitExpressionStatement(node);
        }
        public override void VisitEmptyStatement(EmptyStatementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitEmptyStatement(node));
            base.VisitEmptyStatement(node);
        }
        public override void VisitLabeledStatement(LabeledStatementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitLabeledStatement(node));
            base.VisitLabeledStatement(node);
        }
        public override void VisitGotoStatement(GotoStatementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitGotoStatement(node));
            base.VisitGotoStatement(node);
        }
        public override void VisitBreakStatement(BreakStatementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitBreakStatement(node));
            base.VisitBreakStatement(node);
        }
        public override void VisitContinueStatement(ContinueStatementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitContinueStatement(node));
            base.VisitContinueStatement(node);
        }
        public override void VisitReturnStatement(ReturnStatementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitReturnStatement(node));
            base.VisitReturnStatement(node);
        }
        public override void VisitThrowStatement(ThrowStatementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitThrowStatement(node));
            base.VisitThrowStatement(node);
        }
        public override void VisitYieldStatement(YieldStatementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitYieldStatement(node));
            base.VisitYieldStatement(node);
        }
        public override void VisitWhileStatement(WhileStatementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitWhileStatement(node));
            base.VisitWhileStatement(node);
        }
        public override void VisitDoStatement(DoStatementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitDoStatement(node));
            base.VisitDoStatement(node);
        }
        public override void VisitForStatement(ForStatementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitForStatement(node));
            base.VisitForStatement(node);
        }
        public override void VisitForEachStatement(ForEachStatementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitForEachStatement(node));
            base.VisitForEachStatement(node);
        }
        public override void VisitForEachVariableStatement(ForEachVariableStatementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitForEachVariableStatement(node));
            base.VisitForEachVariableStatement(node);
        }
        public override void VisitUsingStatement(UsingStatementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitUsingStatement(node));
            base.VisitUsingStatement(node);
        }
        public override void VisitFixedStatement(FixedStatementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitFixedStatement(node));
            base.VisitFixedStatement(node);
        }
        public override void VisitCheckedStatement(CheckedStatementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitCheckedStatement(node));
            base.VisitCheckedStatement(node);
        }
        public override void VisitUnsafeStatement(UnsafeStatementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitUnsafeStatement(node));
            base.VisitUnsafeStatement(node);
        }
        public override void VisitLockStatement(LockStatementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitLockStatement(node));
            base.VisitLockStatement(node);
        }
        public override void VisitIfStatement(IfStatementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitIfStatement(node));
            base.VisitIfStatement(node);
        }
        public override void VisitElseClause(ElseClauseSyntax node)
        {
            ExecuteStrategies((s) => s.VisitElseClause(node));
            base.VisitElseClause(node);
        }
        public override void VisitSwitchStatement(SwitchStatementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitSwitchStatement(node));
            base.VisitSwitchStatement(node);
        }
        public override void VisitSwitchSection(SwitchSectionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitSwitchSection(node));
            base.VisitSwitchSection(node);
        }
        public override void VisitCasePatternSwitchLabel(CasePatternSwitchLabelSyntax node)
        {
            ExecuteStrategies((s) => s.VisitCasePatternSwitchLabel(node));
            base.VisitCasePatternSwitchLabel(node);
        }
        public override void VisitCaseSwitchLabel(CaseSwitchLabelSyntax node)
        {
            ExecuteStrategies((s) => s.VisitCaseSwitchLabel(node));
            base.VisitCaseSwitchLabel(node);
        }
        public override void VisitDefaultSwitchLabel(DefaultSwitchLabelSyntax node)
        {
            ExecuteStrategies((s) => s.VisitDefaultSwitchLabel(node));
            base.VisitDefaultSwitchLabel(node);
        }
        public override void VisitTryStatement(TryStatementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitTryStatement(node));
            base.VisitTryStatement(node);
        }
        public override void VisitCatchClause(CatchClauseSyntax node)
        {
            ExecuteStrategies((s) => s.VisitCatchClause(node));
            base.VisitCatchClause(node);
        }
        public override void VisitCatchDeclaration(CatchDeclarationSyntax node)
        {
            ExecuteStrategies((s) => s.VisitCatchDeclaration(node));
            base.VisitCatchDeclaration(node);
        }
        public override void VisitCatchFilterClause(CatchFilterClauseSyntax node)
        {
            ExecuteStrategies((s) => s.VisitCatchFilterClause(node));
            base.VisitCatchFilterClause(node);
        }
        public override void VisitFinallyClause(FinallyClauseSyntax node)
        {
            ExecuteStrategies((s) => s.VisitFinallyClause(node));
            base.VisitFinallyClause(node);
        }
        public override void VisitCompilationUnit(CompilationUnitSyntax node)
        {
            ExecuteStrategies((s) => s.VisitCompilationUnit(node));
            base.VisitCompilationUnit(node);
        }
        public override void VisitExternAliasDirective(ExternAliasDirectiveSyntax node)
        {
            ExecuteStrategies((s) => s.VisitExternAliasDirective(node));
            base.VisitExternAliasDirective(node);
        }
        public override void VisitUsingDirective(UsingDirectiveSyntax node)
        {
            ExecuteStrategies((s) => s.VisitUsingDirective(node));
            base.VisitUsingDirective(node);
        }
        public override void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
        {
            ExecuteStrategies((s) => s.VisitNamespaceDeclaration(node));
            base.VisitNamespaceDeclaration(node);
        }
        public override void VisitAttributeList(AttributeListSyntax node)
        {
            ExecuteStrategies((s) => s.VisitAttributeList(node));
            base.VisitAttributeList(node);
        }
        public override void VisitAttributeTargetSpecifier(AttributeTargetSpecifierSyntax node)
        {
            ExecuteStrategies((s) => s.VisitAttributeTargetSpecifier(node));
            base.VisitAttributeTargetSpecifier(node);
        }
        public override void VisitAttribute(AttributeSyntax node)
        {
            ExecuteStrategies((s) => s.VisitAttribute(node));
            base.VisitAttribute(node);
        }
        public override void VisitAttributeArgumentList(AttributeArgumentListSyntax node)
        {
            ExecuteStrategies((s) => s.VisitAttributeArgumentList(node));
            base.VisitAttributeArgumentList(node);
        }
        public override void VisitAttributeArgument(AttributeArgumentSyntax node)
        {
            ExecuteStrategies((s) => s.VisitAttributeArgument(node));
            base.VisitAttributeArgument(node);
        }
        public override void VisitNameEquals(NameEqualsSyntax node)
        {
            ExecuteStrategies((s) => s.VisitNameEquals(node));
            base.VisitNameEquals(node);
        }
        public override void VisitTypeParameterList(TypeParameterListSyntax node)
        {
            ExecuteStrategies((s) => s.VisitTypeParameterList(node));
            base.VisitTypeParameterList(node);
        }
        public override void VisitTypeParameter(TypeParameterSyntax node)
        {
            ExecuteStrategies((s) => s.VisitTypeParameter(node));
            base.VisitTypeParameter(node);
        }
        public override void VisitStructDeclaration(StructDeclarationSyntax node)
        {
            ExecuteStrategies((s) => s.VisitStructDeclaration(node));
            base.VisitStructDeclaration(node);
        }
        public override void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
        {
            ExecuteStrategies((s) => s.VisitInterfaceDeclaration(node));
            base.VisitInterfaceDeclaration(node);
        }
        public override void VisitEnumDeclaration(EnumDeclarationSyntax node)
        {
            ExecuteStrategies((s) => s.VisitEnumDeclaration(node));
            base.VisitEnumDeclaration(node);
        }
        public override void VisitDelegateDeclaration(DelegateDeclarationSyntax node)
        {
            ExecuteStrategies((s) => s.VisitDelegateDeclaration(node));
            base.VisitDelegateDeclaration(node);
        }
        public override void VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
        {
            ExecuteStrategies((s) => s.VisitEnumMemberDeclaration(node));
            base.VisitEnumMemberDeclaration(node);
        }
        public override void VisitBaseList(BaseListSyntax node)
        {
            ExecuteStrategies((s) => s.VisitBaseList(node));
            base.VisitBaseList(node);
        }
        public override void VisitSimpleBaseType(SimpleBaseTypeSyntax node)
        {
            ExecuteStrategies((s) => s.VisitSimpleBaseType(node));
            base.VisitSimpleBaseType(node);
        }
        public override void VisitTypeParameterConstraintClause(TypeParameterConstraintClauseSyntax node)
        {
            ExecuteStrategies((s) => s.VisitTypeParameterConstraintClause(node));
            base.VisitTypeParameterConstraintClause(node);
        }
        public override void VisitConstructorConstraint(ConstructorConstraintSyntax node)
        {
            ExecuteStrategies((s) => s.VisitConstructorConstraint(node));
            base.VisitConstructorConstraint(node);
        }
        public override void VisitClassOrStructConstraint(ClassOrStructConstraintSyntax node)
        {
            ExecuteStrategies((s) => s.VisitClassOrStructConstraint(node));
            base.VisitClassOrStructConstraint(node);
        }
        public override void VisitTypeConstraint(TypeConstraintSyntax node)
        {
            ExecuteStrategies((s) => s.VisitTypeConstraint(node));
            base.VisitTypeConstraint(node);
        }
        public override void VisitFieldDeclaration(FieldDeclarationSyntax node)
        {
            ExecuteStrategies((s) => s.VisitFieldDeclaration(node));
            base.VisitFieldDeclaration(node);
        }
        public override void VisitEventFieldDeclaration(EventFieldDeclarationSyntax node)
        {
            ExecuteStrategies((s) => s.VisitEventFieldDeclaration(node));
            base.VisitEventFieldDeclaration(node);
        }
        public override void VisitExplicitInterfaceSpecifier(ExplicitInterfaceSpecifierSyntax node)
        {
            ExecuteStrategies((s) => s.VisitExplicitInterfaceSpecifier(node));
            base.VisitExplicitInterfaceSpecifier(node);
        }
        public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            ExecuteStrategies((s) => s.VisitMethodDeclaration(node));
            base.VisitMethodDeclaration(node);
        }
        public override void VisitOperatorDeclaration(OperatorDeclarationSyntax node)
        {
            ExecuteStrategies((s) => s.VisitOperatorDeclaration(node));
            base.VisitOperatorDeclaration(node);
        }
        public override void VisitConversionOperatorDeclaration(ConversionOperatorDeclarationSyntax node)
        {
            ExecuteStrategies((s) => s.VisitConversionOperatorDeclaration(node));
            base.VisitConversionOperatorDeclaration(node);
        }
        public override void VisitConstructorDeclaration(ConstructorDeclarationSyntax node)
        {
            ExecuteStrategies((s) => s.VisitConstructorDeclaration(node));
            base.VisitConstructorDeclaration(node);
        }
        public override void VisitConstructorInitializer(ConstructorInitializerSyntax node)
        {
            ExecuteStrategies((s) => s.VisitConstructorInitializer(node));
            base.VisitConstructorInitializer(node);
        }
        public override void VisitDestructorDeclaration(DestructorDeclarationSyntax node)
        {
            ExecuteStrategies((s) => s.VisitDestructorDeclaration(node));
            base.VisitDestructorDeclaration(node);
        }
        public override void VisitArrowExpressionClause(ArrowExpressionClauseSyntax node)
        {
            ExecuteStrategies((s) => s.VisitArrowExpressionClause(node));
            base.VisitArrowExpressionClause(node);
        }
        public override void VisitEventDeclaration(EventDeclarationSyntax node)
        {
            ExecuteStrategies((s) => s.VisitEventDeclaration(node));
            base.VisitEventDeclaration(node);
        }
        public override void VisitIndexerDeclaration(IndexerDeclarationSyntax node)
        {
            ExecuteStrategies((s) => s.VisitIndexerDeclaration(node));
            base.VisitIndexerDeclaration(node);
        }
        public override void VisitAccessorList(AccessorListSyntax node)
        {
            ExecuteStrategies((s) => s.VisitAccessorList(node));
            base.VisitAccessorList(node);
        }
        public override void VisitParameterList(ParameterListSyntax node)
        {
            ExecuteStrategies((s) => s.VisitParameterList(node));
            base.VisitParameterList(node);
        }
        public override void VisitBracketedParameterList(BracketedParameterListSyntax node)
        {
            ExecuteStrategies((s) => s.VisitBracketedParameterList(node));
            base.VisitBracketedParameterList(node);
        }
        public override void VisitParameter(ParameterSyntax node)
        {
            ExecuteStrategies((s) => s.VisitParameter(node));
            base.VisitParameter(node);
        }
        public override void VisitIncompleteMember(IncompleteMemberSyntax node)
        {
            ExecuteStrategies((s) => s.VisitIncompleteMember(node));
            base.VisitIncompleteMember(node);
        }
        public override void VisitSkippedTokensTrivia(SkippedTokensTriviaSyntax node)
        {
            ExecuteStrategies((s) => s.VisitSkippedTokensTrivia(node));
            base.VisitSkippedTokensTrivia(node);
        }
        public override void VisitDocumentationCommentTrivia(DocumentationCommentTriviaSyntax node)
        {
            ExecuteStrategies((s) => s.VisitDocumentationCommentTrivia(node));
            base.VisitDocumentationCommentTrivia(node);
        }
        public override void VisitTypeCref(TypeCrefSyntax node)
        {
            ExecuteStrategies((s) => s.VisitTypeCref(node));
            base.VisitTypeCref(node);
        }
        public override void VisitQualifiedCref(QualifiedCrefSyntax node)
        {
            ExecuteStrategies((s) => s.VisitQualifiedCref(node));
            base.VisitQualifiedCref(node);
        }
        public override void VisitNameMemberCref(NameMemberCrefSyntax node)
        {
            ExecuteStrategies((s) => s.VisitNameMemberCref(node));
            base.VisitNameMemberCref(node);
        }
        public override void VisitIndexerMemberCref(IndexerMemberCrefSyntax node)
        {
            ExecuteStrategies((s) => s.VisitIndexerMemberCref(node));
            base.VisitIndexerMemberCref(node);
        }
        public override void VisitOperatorMemberCref(OperatorMemberCrefSyntax node)
        {
            ExecuteStrategies((s) => s.VisitOperatorMemberCref(node));
            base.VisitOperatorMemberCref(node);
        }
        public override void VisitConversionOperatorMemberCref(ConversionOperatorMemberCrefSyntax node)
        {
            ExecuteStrategies((s) => s.VisitConversionOperatorMemberCref(node));
            base.VisitConversionOperatorMemberCref(node);
        }
        public override void VisitCrefParameterList(CrefParameterListSyntax node)
        {
            ExecuteStrategies((s) => s.VisitCrefParameterList(node));
            base.VisitCrefParameterList(node);
        }
        public override void VisitCrefBracketedParameterList(CrefBracketedParameterListSyntax node)
        {
            ExecuteStrategies((s) => s.VisitCrefBracketedParameterList(node));
            base.VisitCrefBracketedParameterList(node);
        }
        public override void VisitCrefParameter(CrefParameterSyntax node)
        {
            ExecuteStrategies((s) => s.VisitCrefParameter(node));
            base.VisitCrefParameter(node);
        }
        public override void VisitXmlElement(XmlElementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitXmlElement(node));
            base.VisitXmlElement(node);
        }
        public override void VisitXmlElementStartTag(XmlElementStartTagSyntax node)
        {
            ExecuteStrategies((s) => s.VisitXmlElementStartTag(node));
            base.VisitXmlElementStartTag(node);
        }
        public override void VisitXmlElementEndTag(XmlElementEndTagSyntax node)
        {
            ExecuteStrategies((s) => s.VisitXmlElementEndTag(node));
            base.VisitXmlElementEndTag(node);
        }
        public override void VisitXmlEmptyElement(XmlEmptyElementSyntax node)
        {
            ExecuteStrategies((s) => s.VisitXmlEmptyElement(node));
            base.VisitXmlEmptyElement(node);
        }
        public override void VisitXmlName(XmlNameSyntax node)
        {
            ExecuteStrategies((s) => s.VisitXmlName(node));
            base.VisitXmlName(node);
        }
        public override void VisitXmlPrefix(XmlPrefixSyntax node)
        {
            ExecuteStrategies((s) => s.VisitXmlPrefix(node));
            base.VisitXmlPrefix(node);
        }
        public override void VisitXmlTextAttribute(XmlTextAttributeSyntax node)
        {
            ExecuteStrategies((s) => s.VisitXmlTextAttribute(node));
            base.VisitXmlTextAttribute(node);
        }
        public override void VisitXmlCrefAttribute(XmlCrefAttributeSyntax node)
        {
            ExecuteStrategies((s) => s.VisitXmlCrefAttribute(node));
            base.VisitXmlCrefAttribute(node);
        }
        public override void VisitXmlNameAttribute(XmlNameAttributeSyntax node)
        {
            ExecuteStrategies((s) => s.VisitXmlNameAttribute(node));
            base.VisitXmlNameAttribute(node);
        }
        public override void VisitXmlText(XmlTextSyntax node)
        {
            ExecuteStrategies((s) => s.VisitXmlText(node));
            base.VisitXmlText(node);
        }
        public override void VisitXmlCDataSection(XmlCDataSectionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitXmlCDataSection(node));
            base.VisitXmlCDataSection(node);
        }
        public override void VisitXmlProcessingInstruction(XmlProcessingInstructionSyntax node)
        {
            ExecuteStrategies((s) => s.VisitXmlProcessingInstruction(node));
            base.VisitXmlProcessingInstruction(node);
        }
        public override void VisitXmlComment(XmlCommentSyntax node)
        {
            ExecuteStrategies((s) => s.VisitXmlComment(node));
            base.VisitXmlComment(node);
        }
        public override void VisitIfDirectiveTrivia(IfDirectiveTriviaSyntax node)
        {
            ExecuteStrategies((s) => s.VisitIfDirectiveTrivia(node));
            base.VisitIfDirectiveTrivia(node);
        }
        public override void VisitElifDirectiveTrivia(ElifDirectiveTriviaSyntax node)
        {
            ExecuteStrategies((s) => s.VisitElifDirectiveTrivia(node));
            base.VisitElifDirectiveTrivia(node);
        }
        public override void VisitElseDirectiveTrivia(ElseDirectiveTriviaSyntax node)
        {
            ExecuteStrategies((s) => s.VisitElseDirectiveTrivia(node));
            base.VisitElseDirectiveTrivia(node);
        }
        public override void VisitEndIfDirectiveTrivia(EndIfDirectiveTriviaSyntax node)
        {
            ExecuteStrategies((s) => s.VisitEndIfDirectiveTrivia(node));
            base.VisitEndIfDirectiveTrivia(node);
        }
        public override void VisitRegionDirectiveTrivia(RegionDirectiveTriviaSyntax node)
        {
            ExecuteStrategies((s) => s.VisitRegionDirectiveTrivia(node));
            base.VisitRegionDirectiveTrivia(node);
        }
        public override void VisitEndRegionDirectiveTrivia(EndRegionDirectiveTriviaSyntax node)
        {
            ExecuteStrategies((s) => s.VisitEndRegionDirectiveTrivia(node));
            base.VisitEndRegionDirectiveTrivia(node);
        }
        public override void VisitErrorDirectiveTrivia(ErrorDirectiveTriviaSyntax node)
        {
            ExecuteStrategies((s) => s.VisitErrorDirectiveTrivia(node));
            base.VisitErrorDirectiveTrivia(node);
        }
        public override void VisitWarningDirectiveTrivia(WarningDirectiveTriviaSyntax node)
        {
            ExecuteStrategies((s) => s.VisitWarningDirectiveTrivia(node));
            base.VisitWarningDirectiveTrivia(node);
        }
        public override void VisitBadDirectiveTrivia(BadDirectiveTriviaSyntax node)
        {
            ExecuteStrategies((s) => s.VisitBadDirectiveTrivia(node));
            base.VisitBadDirectiveTrivia(node);
        }
        public override void VisitDefineDirectiveTrivia(DefineDirectiveTriviaSyntax node)
        {
            ExecuteStrategies((s) => s.VisitDefineDirectiveTrivia(node));
            base.VisitDefineDirectiveTrivia(node);
        }
        public override void VisitUndefDirectiveTrivia(UndefDirectiveTriviaSyntax node)
        {
            ExecuteStrategies((s) => s.VisitUndefDirectiveTrivia(node));
            base.VisitUndefDirectiveTrivia(node);
        }
        public override void VisitLineDirectiveTrivia(LineDirectiveTriviaSyntax node)
        {
            ExecuteStrategies((s) => s.VisitLineDirectiveTrivia(node));
            base.VisitLineDirectiveTrivia(node);
        }
        public override void VisitPragmaWarningDirectiveTrivia(PragmaWarningDirectiveTriviaSyntax node)
        {
            ExecuteStrategies((s) => s.VisitPragmaWarningDirectiveTrivia(node));
            base.VisitPragmaWarningDirectiveTrivia(node);
        }
        public override void VisitPragmaChecksumDirectiveTrivia(PragmaChecksumDirectiveTriviaSyntax node)
        {
            ExecuteStrategies((s) => s.VisitPragmaChecksumDirectiveTrivia(node));
            base.VisitPragmaChecksumDirectiveTrivia(node);
        }
        public override void VisitReferenceDirectiveTrivia(ReferenceDirectiveTriviaSyntax node)
        {
            ExecuteStrategies((s) => s.VisitReferenceDirectiveTrivia(node));
            base.VisitReferenceDirectiveTrivia(node);
        }
        public override void VisitLoadDirectiveTrivia(LoadDirectiveTriviaSyntax node)
        {
            ExecuteStrategies((s) => s.VisitLoadDirectiveTrivia(node));
            base.VisitLoadDirectiveTrivia(node);
        }
        public override void VisitShebangDirectiveTrivia(ShebangDirectiveTriviaSyntax node)
        {
            ExecuteStrategies((s) => s.VisitShebangDirectiveTrivia(node));
            base.VisitShebangDirectiveTrivia(node);
        }
        public override void DefaultVisit(SyntaxNode node)
        {
            ExecuteStrategies((s) => s.DefaultVisit(node));
            base.DefaultVisit(node);
        }
        public override void VisitToken(SyntaxToken token)
        {
            base.VisitToken(token);
        }
        public override void VisitLeadingTrivia(SyntaxToken token)
        {
            base.VisitLeadingTrivia(token);
        }
        public override void VisitTrailingTrivia(SyntaxToken token)
        {
            base.VisitTrailingTrivia(token);
        }
        public override void VisitTrivia(SyntaxTrivia trivia)
        {
            base.VisitTrivia(trivia);
        }
    }
}
