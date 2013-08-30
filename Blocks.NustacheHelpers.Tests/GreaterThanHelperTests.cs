using System;
using Blocks.NustacheHelpers.Tests.Models;
using FluentAssertions;
using NUnit.Framework;
using Nustache.Core;

namespace Blocks.NustacheHelpers.Tests
{
    [TestFixture]
    public class GreaterThanHelperTests
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            EqualityHelpers.Register();
        }

        [Test, Category("if_gt")]
        public void IfGtHelper_renders_expected_result_when_greater()
        {
            var one = new Comparable {Thing = "b"};
            var two = new Comparable {Thing = "a"};

            var result = Render.StringToString("{{#if_gt one compare=two}}greater{{/if_gt}}", new {one, two});

            result.Should().Be("greater");
        }

        [Test, Category("if_gt")]
        public void IfGtHelper_renders_expected_result_when_not_greater()
        {
            var one = new Comparable {Thing = "a"};
            var two = new Comparable {Thing = "b"};

            var result = Render.StringToString("{{#if_gt one compare=two}}greater{{/if_gt}}", new {one, two});

            result.Should().BeEmpty();
        }

        [Test, Category("if_gt")]
        public void IfGtHelper_renders_inverse_when_not_greater()
        {
            var one = new Comparable {Thing = "a"};
            var two = new Comparable {Thing = "b"};

            var result = Render.StringToString("{{#if_gt one compare=two}}greater{{else}}less{{/if_gt}}", new {one, two});

            result.Should().Be("less");
        }

        [Test, Category("if_gt")]
        public void IfGtHelper_throws_when_not_comparable()
        {
            var one = new Comparable {Thing = "a"};
            var two = new Incomparable {Thing = "b"};

            Action action =
                () => Render.StringToString("{{#if_gt one compare=two}}greater{{else}}less{{/if_gt}}", new {one, two});

            action.ShouldThrow<InvalidOperationException>().WithMessage(
                "The objects being compared must implement IComparable.");
        }

        [Test, Category("unless_gt")]
        public void UnlessGtHelper_renders_expected_result_when_greater()
        {
            var one = new Comparable {Thing = "b"};
            var two = new Comparable {Thing = "a"};

            var result = Render.StringToString("{{#unless_gt one compare=two}}less{{/unless_gt}}", new {one, two});

            result.Should().BeEmpty();
        }

        [Test, Category("unless_gt")]
        public void UnlessGtHelper_renders_expected_result_when_not_greater()
        {
            var one = new Comparable {Thing = "a"};
            var two = new Comparable {Thing = "b"};

            var result = Render.StringToString("{{#unless_gt one compare=two}}less{{/unless_gt}}", new {one, two});

            result.Should().Be("less");
        }

        [Test, Category("unless_gt")]
        public void UnlessGtHelper_renders_inverse_when_not_greater()
        {
            var one = new Comparable {Thing = "a"};
            var two = new Comparable {Thing = "b"};

            var result = Render.StringToString("{{#unless_gt one compare=two}}less{{else}}greater{{/unless_gt}}",
                                               new {one, two});

            result.Should().Be("less");
        }

        [Test, Category("unless_gt")]
        public void UnlessGtHelper_throws_when_not_comparable()
        {
            var one = new Comparable {Thing = "a"};
            var two = new Incomparable {Thing = "b"};

            Action action =
                () =>
                Render.StringToString("{{#unless_gt one compare=two}}less{{else}}greater{{/unless_gt}}", new {one, two});

            action.ShouldThrow<InvalidOperationException>().WithMessage(
                "The objects being compared must implement IComparable.");
        }

        [Test, Category("if_gteq")]
        public void IfGtEqHelper_renders_expected_result_when_greater()
        {
            var one = new Comparable {Thing = "b"};
            var two = new Comparable {Thing = "a"};

            var result = Render.StringToString("{{#if_gteq one compare=two}}greater{{/if_gteq}}", new {one, two});

            result.Should().Be("greater");
        }

        [Test, Category("if_gteq")]
        public void IfGtEqHelper_renders_expected_result_when_equal()
        {
            var one = new Comparable {Thing = "a"};
            var two = new Comparable {Thing = "a"};

            var result = Render.StringToString("{{#if_gteq one compare=two}}greater{{/if_gteq}}", new {one, two});

            result.Should().Be("greater");
        }

        [Test, Category("if_gteq")]
        public void IfGtEqHelper_renders_expected_result_when_not_greater()
        {
            var one = new Comparable {Thing = "a"};
            var two = new Comparable {Thing = "b"};

            var result = Render.StringToString("{{#if_gteq one compare=two}}greater{{/if_gteq}}", new {one, two});

            result.Should().BeEmpty();
        }

        [Test, Category("if_gteq")]
        public void IfGtEqHelper_renders_inverse_when_not_greater()
        {
            var one = new Comparable {Thing = "a"};
            var two = new Comparable {Thing = "b"};

            var result = Render.StringToString("{{#if_gteq one compare=two}}greater{{else}}less{{/if_gteq}}",
                                               new {one, two});

            result.Should().Be("less");
        }

        [Test, Category("if_gteq")]
        public void IfGtEqHelper_throws_when_not_comparable()
        {
            var one = new Comparable {Thing = "a"};
            var two = new Incomparable {Thing = "b"};

            Action action =
                () =>
                Render.StringToString("{{#if_gteq one compare=two}}greater{{else}}less{{/if_gteq}}", new {one, two});

            action.ShouldThrow<InvalidOperationException>().WithMessage(
                "The objects being compared must implement IComparable.");
        }

        [Test, Category("unless_gteq")]
        public void UnlessGtEqHelper_renders_expected_result_when_greater()
        {
            var one = new Comparable {Thing = "b"};
            var two = new Comparable {Thing = "a"};

            var result = Render.StringToString("{{#unless_gteq one compare=two}}less{{/unless_gteq}}", new {one, two});

            result.Should().BeEmpty();
        }

        [Test, Category("unless_gteq")]
        public void UnlessGtEqHelper_renders_expected_result_when_equal()
        {
            var one = new Comparable {Thing = "a"};
            var two = new Comparable {Thing = "a"};

            var result = Render.StringToString("{{#unless_gteq one compare=two}}less{{/unless_gteq}}", new {one, two});

            result.Should().BeEmpty();
        }

        [Test, Category("unless_gteq")]
        public void UnlessGtEqHelper_renders_expected_result_when_not_greater()
        {
            var one = new Comparable {Thing = "a"};
            var two = new Comparable {Thing = "b"};

            var result = Render.StringToString("{{#unless_gteq one compare=two}}less{{/unless_gteq}}", new {one, two});

            result.Should().Be("less");
        }

        [Test, Category("unless_gteq")]
        public void UnlessGtEqHelper_renders_inverse_when_not_greater()
        {
            var one = new Comparable {Thing = "a"};
            var two = new Comparable {Thing = "b"};

            var result = Render.StringToString("{{#unless_gteq one compare=two}}less{{else}}greater{{/unless_gteq}}",
                                               new {one, two});

            result.Should().Be("less");
        }

        [Test, Category("unless_gteq")]
        public void UnlessGtEqHelper_throws_when_not_comparable()
        {
            var one = new Comparable {Thing = "a"};
            var two = new Incomparable {Thing = "b"};

            Action action =
                () =>
                Render.StringToString("{{#unless_gteq one compare=two}}less{{else}}greater{{/unless_gteq}}",
                                      new {one, two});

            action.ShouldThrow<InvalidOperationException>().WithMessage(
                "The objects being compared must implement IComparable.");
        }
    }
}