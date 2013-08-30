using System;
using FluentAssertions;
using NUnit.Framework;
using Nustache.Core;

namespace Blocks.NustacheHelpers.Tests
{
    [TestFixture]
    public class Nl2BrHelperTests
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            DisplayHelpers.Register();
        }

        [Test]
        public void Nl2BrHelper_should_remove_newlines_and_replace_with_brs()
        {
            var test = "Test" + Environment.NewLine + "String";

            var result = Render.StringToString("{{nl2br test}}", new {test});

            result.Should().Be("Test<br>" + Environment.NewLine + "String");
        }
    }
}