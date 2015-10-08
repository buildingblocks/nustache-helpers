using System;
using FluentAssertions;
using NUnit.Framework;
using Nustache.Core;

namespace Blocks.NustacheHelpers.Tests
{
    [TestFixture]
    public class EqualsHelperTests
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            EqualityHelpers.Register();
        }

        [Test, Category("if_eq")]
        public void IfEqHelper_renders_expected_result_with_equal_objects()
        {
            var one = new {thing = "thing"};
            var two = new {thing = "thing"};

            var result = Render.StringToString("{{#if_eq one compare=two}}equal{{/if_eq}}", new {one, two});

            result.Should().Be("equal");
        }

        [Test, Category("if_eq")]
        public void IfEqHelper_renders_expected_result_with_unequal_objects()
        {
            var one = new {thing = "thing"};
            var two = new {thing = "other"};

            var result = Render.StringToString("{{#if_eq one compare=two}}equal{{/if_eq}}", new {one, two});

            result.Should().BeEmpty();
        }

        [Test, Category("if_eq")]
        public void IfEqHelper_renders_inverse_with_unequal_objects()
        {
            var one = new {thing = "thing"};
            var two = new {thing = "other"};

            var result = Render.StringToString("{{#if_eq one compare=two}}equal{{else}}not equal{{/if_eq}}",
                                               new {one, two});

            result.Should().Be("not equal");
        }

        [Test, Category("if_eq")]
        public void IfEqHelper_renders_expected_result_with_equal_structs()
        {
            var one = 1;
            var two = 1;

            var result = Render.StringToString("{{#if_eq one compare=two}}equal{{/if_eq}}",
                                               new {one, two});

            result.Should().Be("equal");
        }

        [Test, Category("if_eq")]
        public void IfEqHelper_renders_expected_result_with_unequal_structs()
        {
            var one = 1;
            var two = 2;

            var result = Render.StringToString("{{#if_eq one compare=two}}equal{{/if_eq}}",
                                               new {one, two});

            result.Should().BeEmpty();
        }

        [Test, Category("if_eq")]
        public void IfEqHelper_renders_inverse_with_unequal_structs()
        {
            var one = 1;
            var two = 2;

            var result = Render.StringToString("{{#if_eq one compare=two}}equal{{else}}not equal{{/if_eq}}",
                                               new {one, two});

            result.Should().Be("not equal");
        }

        [Test, Category("if_eq")]
        public void IfEqHelper_renders_expected_result_with_different_types()
        {
            var one = 1;
            var two = DateTime.Now;

            var result = Render.StringToString("{{#if_eq one compare=two}}equal{{/if_eq}}",
                                               new {one, two});

            result.Should().BeEmpty();
        }

        [Test, Category("if_eq")]
        public void IfEqHelper_renders_inverse_with_different_types()
        {
            var one = 1;
            var two = DateTime.Now;

            var result = Render.StringToString("{{#if_eq one compare=two}}equal{{else}}not equal{{/if_eq}}",
                                               new {one, two});

            result.Should().Be("not equal");
        }

        [Test, Category("if_eq")]
        public void IfEqHelper_renders_expected_result_with_null_comparand()
        {
            object one = new {thing = "thing"};
            object two = null;

            var result = Render.StringToString("{{#if_eq one compare=two}}equal{{/if_eq}}", new {one, two});

            result.Should().BeEmpty();
        }

        [Test, Category("if_eq")]
        public void IfEqHelper_renders_inverse_with_null_comparand()
        {
            object one = new {thing = "thing"};
            object two = null;

            var result = Render.StringToString("{{#if_eq one compare=two}}equal{{else}}not equal{{/if_eq}}",
                                               new {one, two});

            result.Should().Be("not equal");
        }

        [Test, Category("if_eq")]
        public void IfEqHelper_renders_inverse_with_null_target()
        {
            object one = null;            
            object two = new { thing = "thing" };

            var result = Render.StringToString("{{#if_eq one compare=two}}equal{{else}}not equal{{/if_eq}}",
                                               new { one, two });

            result.Should().Be("not equal");
        }

        [Test, Category("unless_eq")]
        public void UnlessEqHelper_renders_expected_result_with_equal_objects()
        {
            var one = new { thing = "thing" };
            var two = new { thing = "thing" };

            var result = Render.StringToString("{{#unless_eq one compare=two}}not equal{{/unless_eq}}", new { one, two });

            result.Should().BeEmpty();
        }

        [Test, Category("unless_eq")]
        public void UnlessEqHelper_renders_expected_result_with_unequal_objects()
        {
            var one = new { thing = "thing" };
            var two = new { thing = "other" };

            var result = Render.StringToString("{{#unless_eq one compare=two}}not equal{{/unless_eq}}", new { one, two });

            result.Should().Be("not equal");
        }

        [Test, Category("unless_eq")]
        public void UnlessEqHelper_renders_inverse_with_unequal_objects()
        {
            var one = new { thing = "thing" };
            var two = new { thing = "other" };

            var result = Render.StringToString("{{#unless_eq one compare=two}}not equal{{else}}equal{{/unless_eq}}",
                                               new { one, two });

            result.Should().Be("not equal");
        }

        [Test, Category("unless_eq")]
        public void UnlessEqHelper_renders_expected_result_with_equal_structs()
        {
            var one = 1;
            var two = 1;

            var result = Render.StringToString("{{#unless_eq one compare=two}}not equal{{/unless_eq}}",
                                               new { one, two });

            result.Should().BeEmpty();
        }

        [Test, Category("unless_eq")]
        public void UnlessEqHelper_renders_expected_result_with_unequal_structs()
        {
            var one = 1;
            var two = 2;

            var result = Render.StringToString("{{#unless_eq one compare=two}}not equal{{/unless_eq}}",
                                               new { one, two });

            result.Should().Be("not equal");
        }

        [Test, Category("unless_eq")]
        public void UnlessEqHelper_renders_inverse_with_unequal_structs()
        {
            var one = 1;
            var two = 2;

            var result = Render.StringToString("{{#unless_eq one compare=two}}not equal{{else}}equal{{/unless_eq}}",
                                               new { one, two });

            result.Should().Be("not equal");
        }

        [Test, Category("unless_eq")]
        public void UnlessEqHelper_renders_expected_result_with_different_types()
        {
            var one = 1;
            var two = DateTime.Now;

            var result = Render.StringToString("{{#unless_eq one compare=two}}not equal{{/unless_eq}}",
                                               new { one, two });

            result.Should().Be("not equal");
        }

        [Test, Category("unless_eq")]
        public void UnlessEqHelper_renders_inverse_with_different_types()
        {
            var one = 1;
            var two = DateTime.Now;

            var result = Render.StringToString("{{#unless_eq one compare=two}}not equal{{else}}equal{{/unless_eq}}",
                                               new { one, two });

            result.Should().Be("not equal");
        }

        [Test, Category("unless_eq")]
        public void UnlessEqHelper_renders_expected_result_with_null_comparand()
        {
            object one = new { thing = "thing" };
            object two = null;

            var result = Render.StringToString("{{#unless_eq one compare=two}}not equal{{/unless_eq}}", new { one, two });

            result.Should().Be("not equal");
        }

        [Test, Category("unless_eq")]
        public void UnlessEqHelper_renders_expected_result_with_null_target()
        {
            object one = null;
            object two = new { thing = "thing" };            

            var result = Render.StringToString("{{#unless_eq one compare=two}}not equal{{/unless_eq}}", new { one, two });

            result.Should().Be("not equal");
        }

        [Test, Category("unless_eq")]
        public void UnlessEqHelper_renders_inverse_with_null_comparand()
        {
            object one = new { thing = "thing" };
            object two = null;

            var result = Render.StringToString("{{#unless_eq one compare=two}}not equal{{else}}equal{{/unless_eq}}",
                                               new { one, two });

            result.Should().Be("not equal");
        }

        [Test, Category("unless_eq")]
        public void UnlessEqHelper_renders_inverse_with_null_target()
        {
            object one = null;
            object two = new { thing = "thing" };

            var result = Render.StringToString("{{#unless_eq one compare=two}}not equal{{else}}equal{{/unless_eq}}",
                                               new { one, two });

            result.Should().Be("not equal");
        }
    }
}