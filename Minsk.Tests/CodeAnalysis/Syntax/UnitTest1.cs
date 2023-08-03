using System;
using System.Collections.Generic;

namespace Minsk.Tests.CodeAnalysis.Syntax;

public class LexerTest
{
    [Theory]
    [MemberData(nameof(GetTokensData))]
    public void Lexer_Lexes_Token(SyntaxKind kind, string text)
    {
        var tokens = SyntaxTree.ParseTokens(text);

        var token = Assert.Single(tokens);
        Assert.Equal(kind, token.Kind);
        Assert.Equal(text, token.Text);
    }

    public static IEnumerable<object[]> GetTokensData()
    {
        foreach (var t in GetTokens())
            yield return new object[] {t.kind, t.text };
    }

    private static IEnumerable<(SyntaxKind kind, string text)> GetTokens()
    {
        return new[] 
        {
            (SyntaxKind.PlusToken, "+"),
            (SyntaxKind.MinusToken, "-"),
            (SyntaxKind.StarToken, "*"),
            (SyntaxKind.SlashToken, "/"),
            (SyntaxKind.BangToken, "!"),
            (SyntaxKind.AmpersandAmpersandToken, "&&"),
            (SyntaxKind.PipePipeToken, "||"),
            (SyntaxKind.EqualsToken, "="),
            (SyntaxKind.EqualsEqualsToken, "=="),
            (SyntaxKind.BangEqualsToken, "!="),

            (SyntaxKind.OpenParethesisToken, "("),
            (SyntaxKind.CloseParenthesisToken, ")"),

            (SyntaxKind.TrueKeyword, "true"),
            (SyntaxKind.FalseKeyword, "false"),

            (SyntaxKind.NumberToken, "1"),
            (SyntaxKind.NumberToken, "123"),

            (SyntaxKind.IdentifierToken, "a"),
            (SyntaxKind.IdentifierToken, "abc"),

            (SyntaxKind.WhiteSpaceToken, " "),
            (SyntaxKind.WhiteSpaceToken, "  "),
            (SyntaxKind.WhiteSpaceToken, "\r"),
            (SyntaxKind.WhiteSpaceToken, "\n"),
            (SyntaxKind.WhiteSpaceToken, "\r\n")
        };
    }
}