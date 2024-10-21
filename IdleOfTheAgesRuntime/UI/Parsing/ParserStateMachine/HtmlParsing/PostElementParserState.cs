// <copyright file="PostElementParserState.cs" company="DaanStout">
// Copyright (c) DaanStout. All rights reserved.
// </copyright>

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.FSM;
using IdleOfTheAgesLib.UI.Parsing.Trees;

namespace IdleOfTheAgesRuntime.UI.Parsing.ParserStateMachine.HtmlParsing;

/// <summary>
/// A state that decides what to do after parsing the tag's element.
/// </summary>
public class PostElementParserState : State<ParserData<HtmlNode>>
{
    /// <summary>
    ///  Gets a static instance to use.
    /// </summary>
    public static PostElementParserState Instance { get; } = new();

    private PostElementParserState() { }

    /// <inheritdoc/>
    public override Result<State<ParserData<HtmlNode>>> Tick(ParserData<HtmlNode> input)
    {
        input.ParsingInput.SkipWhiteSpace();

        if (input.ParsingInput.GetCurrentChar() == '>')
        {
            if (!input.ParsingInput.Advance())
                return (null, $"Encountered a closing bracket at {input.ParsingInput.CurrentCharacterIndex - 1}, but then the input ended!");

            if (input.CloseNodeWhenFinished)
            {
                input.CurrentNode = input.CurrentNode.Parent!;
                input.CloseNodeWhenFinished = false;
            }

            return HtmlStarterState.Instance;
        }
        else if (input.ParsingInput.GetCurrentChar() == '/')
        {
            if (!input.ParsingInput.Advance())
                return (null, $"Encountered a tag closing slash at {input.ParsingInput.CurrentCharacterIndex - 1}, but then the input ended!");

            if (input.ParsingInput.GetCurrentChar() == '>')
            {
                if (!input.ParsingInput.Advance())
                    return (null, $"Encountered a closing bracket at {input.ParsingInput.CurrentCharacterIndex - 1}, but then the input ended!");

                input.CurrentNode = input.CurrentNode.Parent!;

                return HtmlStarterState.Instance;
            }
            else
            {
                return (null, $"Encountered a tag closing slash at {input.ParsingInput.CurrentCharacterIndex - 1}, but no closing bracket!");
            }
        }
        else
        {
            return MetadataParserState.Instance;
        }
    }
}
