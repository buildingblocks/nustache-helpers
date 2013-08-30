using System;
using Blocks.NustacheHelpers.Tests.Models;
using FluentAssertions;
using NUnit.Framework;
using Nustache.Core;

namespace Blocks.NustacheHelpers.Tests
{
    [TestFixture]
    public class LessThanHelperTests
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            EqualityHelpers.Register();
        }

        [Test, Category("if_lt")]
        public void IfLtHelper_renders_expected_result_when_less()
        {
            var one = new Comparable { Thing = "a" };
            var two = new Comparable { Thing = "b" };

            var result = Render.StringToString("{{#if_lt one compare=two}}less{{/if_lt}}", new { one, two });

            result.Should().Be("less");
        }

        [Test, Category("if_lt")]
        public void IfLtHelper_renders_expected_result_when_not_less()
        {
            var one = new Comparable { Thing = "b" };
            var two = new Comparable { Thing = "a" };

            var result = Render.StringToString("{{#if_lt one compare=two}}less{{/if_lt}}", new { one, two });

            result.Should().BeEmpty();
        }

        [Test, Category("if_lt")]
        public void IfLtHelper_renders_inverse_when_not_less()
        {
            var one = new Comparable { Thing = "a" };
            var two = new Comparable { Thing = "b" };

            var result = Render.StringToString("{{#if_lt one compare=two}}less{{else}}less{{/if_lt}}", new { one, two });

            result.Should().Be("less");
        }

        [Test, Category("if_lt")]
        public void IfLtHelper_throws_when_not_comparable()
        {
            var one = new Comparable { Thing = "a" };
            var two = new Incomparable { Thing = "b" };

            Action action =
                () => Render.StringToString("{{#if_lt one compare=two}}less{{else}}less{{/if_lt}}", new { one, two });

            action.ShouldThrow<InvalidOperationException>().WithMessage(
                "The objects being compared must implement IComparable.");
        }

        [Test, Category("unless_lt")]
        public void UnlessLtHelper_renders_expected_result_when_less()
        {
            var one = new Comparable { Thing = "a" };
            var two = new Comparable { Thing = "b" };

            var result = Render.StringToString("{{#unless_lt one compare=two}}less{{/unless_lt}}", new { one, two });

            result.Should().BeEmpty();
        }

        [Test, Category("unless_lt")]
        public void UnlessLtHelper_renders_expected_result_when_not_less()
        {
            var one = new Comparable { Thing = "b" };
            var two = new Comparable { Thing = "a" };

            var result = Render.StringToString("{{#unless_lt one compare=two}}less{{/unless_lt}}", new { one, two });

            result.Should().Be("less");
        }

        [Test, Category("unless_lt")]
        public void UnlessLtHelper_renders_inverse_when_not_less()
        {
            var one = new Comparable { Thing = "a" };
            var two = new Comparable { Thing = "b" };

            var result = Render.StringToString("{{#unless_lt one compare=two}}less{{else}}less{{/unless_lt}}",
                                               new { one, two });

            result.Should().Be("less");
        }

        [Test, Category("unless_lt")]
        public void UnlessLtHelper_throws_when_not_comparable()
        {
            var one = new Comparable { Thing = "a" };
            var two = new Incomparable { Thing = "b" };

            Action action =
                () =>
                Render.StringToString("{{#unless_lt one compare=two}}less{{else}}less{{/unless_lt}}", new { one, two });

            action.ShouldThrow<InvalidOperationException>().WithMessage(
                "The objects being compared must implement IComparable.");
        }

        [Test, Category("if_lteq")]
        public void IfLtEqHelper_renders_expected_result_when_less()
        {
            var one = new Comparable { Thing = "a" };
            var two = new Comparable { Thing = "b" };

            var result = Render.StringToString("{{#if_lteq one compare=two}}less{{/if_lteq}}", new { one, two });

            result.Should().Be("less");
        }

        [Test, Category("if_lteq")]
        public void IfLtEqHelper_renders_expected_result_when_equal()
        {
            var one = new Comparable { Thing = "a" };
            var two = new Comparable { Thing = "a" };

            var result = Render.StringToString("{{#if_lteq one compare=two}}less{{/if_lteq}}", new { one, two });

            result.Should().Be("less");
        }

        [Test, Category("if_lteq")]
        public void IfLtEqHelper_renders_expected_result_when_not_less()
        {
            var one = new Comparable { Thing = "b" };
            var two = new Comparable { Thing = "a" };

            var result = Render.StringToString("{{#if_lteq one compare=two}}less{{/if_lteq}}", new { one, two });

            result.Should().BeEmpty();
        }

        [Test, Category("if_lteq")]
        public void IfLtEqHelper_renders_inverse_when_not_less()
        {
            var one = new Comparable { Thing = "a" };
            var two = new Comparable { Thing = "b" };

            var result = Render.StringToString("{{#if_lteq one compare=two}}less{{else}}less{{/if_lteq}}",
                                               new { one, two });

            result.Should().Be("less");
        }

        [Test, Category("if_lteq")]
        public void IfLtEqHelper_throws_when_not_comparable()
        {
            var one = new Comparable { Thing = "a" };
            var two = new Incomparable { Thing = "b" };

            Action action =
                () =>
                Render.StringToString("{{#if_lteq one compare=two}}less{{else}}less{{/if_lteq}}", new { one, two });

            action.ShouldThrow<InvalidOperationException>().WithMessage(
                "The objects being compared must implement IComparable.");
        }

        [Test, Category("unless_lteq")]
        public void UnlessLtEqHelper_renders_expected_result_when_less()
        {
            var one = new Comparable { Thing = "a" };
            var two = new Comparable { Thing = "b" };

            var result = Render.StringToString("{{#unless_lteq one compare=two}}less{{/unless_lteq}}", new { one, two });

            result.Should().BeEmpty();
        }

        [Test, Category("unless_lteq")]
        public void UnlessLtEqHelper_renders_expected_result_when_equal()
        {
            var one = new Comparable { Thing = "a" };
            var two = new Comparable { Thing = "a" };

            var result = Render.StringToString("{{#unless_lteq one compare=two}}less{{/unless_lteq}}", new { one, two });

            result.Should().BeEmpty();
        }

        [Test, Category("unless_lteq")]
        public void UnlessLtEqHelper_renders_expected_result_when_not_less()
        {
            var one = new Comparable { Thing = "b" };
            var two = new Comparable { Thing = "a" };

            var result = Render.StringToString("{{#unless_lteq one compare=two}}less{{/unless_lteq}}", new { one, two });

            result.Should().Be("less");
        }

        [Test, Category("unless_lteq")]
        public void UnlessLtEqHelper_renders_inverse_when_not_less()
        {
            var one = new Comparable { Thing = "a" };
            var two = new Comparable { Thing = "b" };

            var result = Render.StringToString("{{#unless_lteq one compare=two}}less{{else}}less{{/unless_lteq}}",
                                               new { one, two });

            result.Should().Be("less");
        }

        [Test, Category("unless_lteq")]
        public void UnlessLtEqHelper_throws_when_not_comparable()
        {
            var one = new Comparable { Thing = "a" };
            var two = new Incomparable { Thing = "b" };

            Action action =
                () =>
                Render.StringToString("{{#unless_lteq one compare=two}}less{{else}}less{{/unless_lteq}}",
                                      new { one, two });

            action.ShouldThrow<InvalidOperationException>().WithMessage(
                "The objects being compared must implement IComparable.");
        }
    }
}