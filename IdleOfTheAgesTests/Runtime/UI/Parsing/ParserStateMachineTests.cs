// <copyright file="ParserStateMachineTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using IdleOfTheAgesLib.FSM;
using IdleOfTheAgesLib.UI.Parsing;
using IdleOfTheAgesLib.UI.Parsing.Trees;
using IdleOfTheAgesRuntime.UI.Parsing.ParserStateMachine;
using IdleOfTheAgesRuntime.UI.Parsing.ParserStateMachine.HtmlParsing;
using NSubstitute;

namespace IdleOfTheAgesTests.Runtime.UI.Parsing;

/// <summary>
/// Unit tests that cover the parser state machine.
/// </summary>
[TestFixture]
public class ParserStateMachineTests {
    private StateMachine<ParserData<HtmlNode>> instance;

    [SetUp]
    public void SetUp() {
        instance = new StateMachine<ParserData<HtmlNode>>(HtmlStarterState.Instance);
    }

    [Test]
    public void WhenRun_ProperlyParsesTag() {
        // Arrange
        string html = "<test/>";

        ParserData<HtmlNode> state = new(html);

        // Act
        var result = instance.RunToCompletion(state);

        // Assert
        Assert.Multiple(() => {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Errors, Is.Empty);
            Assert.That(state.RootNode, Is.Not.Null);
            Assert.That(state.CurrentNode, Is.EqualTo(state.RootNode));
            Assert.That(state.RootNode.ChildNodes, Is.Not.Empty);
            var firstChild = state.RootNode.ChildNodes[0];
            Assert.That(firstChild, Is.Not.Null);
            Assert.That(firstChild.Identifier, Is.EqualTo("test"));
        });
    }

    [Test]
    public void WhenRunWithOneMetadata_ProperlyParsesMetadata() {
        // Arrange
        string html = "<test metadata=\"test\"/>";

        ParserData<HtmlNode> state = new(html);

        // Act
        var result = instance.RunToCompletion(state);

        // Assert
        Assert.Multiple(() => {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Errors, Is.Empty);
            Assert.That(state.RootNode, Is.Not.Null);
            Assert.That(state.CurrentNode, Is.EqualTo(state.RootNode));
            Assert.That(state.RootNode.ChildNodes, Is.Not.Empty);
            var firstChild = state.RootNode.ChildNodes[0];
            Assert.That(firstChild, Is.Not.Null);
            Assert.That(firstChild.Identifier, Is.EqualTo("test"));
            Assert.That(firstChild.Metadata, Is.Not.Empty);
            Assert.That(firstChild.Metadata, Contains.Key("metadata"));
            Assert.That(firstChild.Metadata["metadata"], Is.EqualTo("test"));
        });
    }

    [Test]
    public void WhenRunWithTwoMetadata_ProperlyParsesMetadata() {
        // Arrange
        string html = "<test metadata=\"test\" metadata2=\"test2\"/>";

        ParserData<HtmlNode> state = new(html);

        // Act
        var result = instance.RunToCompletion(state);

        // Assert
        Assert.Multiple(() => {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Errors, Is.Empty);
            Assert.That(state.RootNode, Is.Not.Null);
            Assert.That(state.CurrentNode, Is.EqualTo(state.RootNode));
            Assert.That(state.RootNode.ChildNodes, Is.Not.Empty);
            var firstChild = state.RootNode.ChildNodes[0];
            Assert.That(firstChild, Is.Not.Null);
            Assert.That(firstChild.Identifier, Is.EqualTo("test"));
            Assert.That(firstChild.Metadata, Is.Not.Empty);
            Assert.That(firstChild.Metadata, Contains.Key("metadata"));
            Assert.That(firstChild.Metadata["metadata"], Is.EqualTo("test"));
            Assert.That(firstChild.Metadata, Contains.Key("metadata2"));
            Assert.That(firstChild.Metadata["metadata2"], Is.EqualTo("test2"));
        });
    }

    [Test]
    public void WhenRunWithTwoElements_ProperlyParsesBothElements() {
        // Arrange
        string html = "<test1 /><test2 />";

        ParserData<HtmlNode> state = new(html);

        // Act
        var result = instance.RunToCompletion(state);

        // Assert
        Assert.Multiple(() => {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Errors, Is.Empty);
            Assert.That(state.RootNode, Is.Not.Null);
            Assert.That(state.CurrentNode, Is.EqualTo(state.RootNode));
            Assert.That(state.RootNode.ChildNodes, Is.Not.Empty);
            Assert.That(state.RootNode.ChildNodes, Has.Count.EqualTo(2));
            var firstChild = state.RootNode.ChildNodes[0];
            Assert.That(firstChild, Is.Not.Null);
            Assert.That(firstChild.Identifier, Is.EqualTo("test1"));
            var secondChild = state.RootNode.ChildNodes[1];
            Assert.That(secondChild, Is.Not.Null);
            Assert.That(secondChild.Identifier, Is.EqualTo("test2"));
        });
    }

    [Test]
    public void WhenRunWithNestedElements_ProperlyParsesNestedElements() {
        // Arrange
        string html = "<test1><test2 /></test1>";

        ParserData<HtmlNode> state = new(html);

        // Act
        var result = instance.RunToCompletion(state);

        // Assert
        Assert.Multiple(() => {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Errors, Is.Empty);
            Assert.That(state.RootNode, Is.Not.Null);
            Assert.That(state.CurrentNode, Is.EqualTo(state.RootNode));
            Assert.That(state.RootNode.ChildNodes, Is.Not.Empty);
            Assert.That(state.RootNode.ChildNodes, Has.Count.EqualTo(1));
            var firstChild = state.RootNode.ChildNodes[0];
            Assert.That(firstChild, Is.Not.Null);
            Assert.That(firstChild.Identifier, Is.EqualTo("test1"));
            Assert.That(firstChild.ChildNodes, Is.Not.Empty);
            var secondChild = firstChild.ChildNodes[0];
            Assert.That(secondChild, Is.Not.Null);
            Assert.That(secondChild.Identifier, Is.EqualTo("test2"));
        });
    }

    [Test]
    public void WhenRunWithPropertyReference_ProperlyParsesPropertyReference() {
        // Arrange
        string html = "<test source=\"@property\" />";

        ParserData<HtmlNode> state = new(html);

        // Act
        var result = instance.RunToCompletion(state);

        // Assert
        Assert.Multiple(() => {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Errors, Is.Empty);
            Assert.That(state.RootNode, Is.Not.Null);
            Assert.That(state.CurrentNode, Is.EqualTo(state.RootNode));
            Assert.That(state.RootNode.ChildNodes, Is.Not.Empty);
            Assert.That(state.RootNode.ChildNodes, Has.Count.EqualTo(1));
            var child = state.RootNode.ChildNodes[0];
            Assert.That(child, Is.Not.Null);
            Assert.That(child.Identifier, Is.EqualTo("test"));
            Assert.That(child.Metadata, Has.Count.EqualTo(1));
            Assert.That(child.Metadata, Contains.Key("source"));
            Assert.That(child.Metadata, Contains.Value("@property"));
        });
    }

    [Test]
    public void WhenRunWithMethodReference_ProperlyParsesMethodReference() {
        // Arrange
        string html = "<test source=\"@method()\" />";

        ParserData<HtmlNode> state = new(html);

        // Act
        var result = instance.RunToCompletion(state);

        // Assert
        Assert.Multiple(() => {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Errors, Is.Empty);
            Assert.That(state.RootNode, Is.Not.Null);
            Assert.That(state.CurrentNode, Is.EqualTo(state.RootNode));
            Assert.That(state.RootNode.ChildNodes, Is.Not.Empty);
            Assert.That(state.RootNode.ChildNodes, Has.Count.EqualTo(1));
            var child = state.RootNode.ChildNodes[0];
            Assert.That(child, Is.Not.Null);
            Assert.That(child.Identifier, Is.EqualTo("test"));
            Assert.That(child.Metadata, Has.Count.EqualTo(1));
            Assert.That(child.Metadata, Contains.Key("source"));
            Assert.That(child.Metadata, Contains.Value("@method()"));
        });
    }
}
