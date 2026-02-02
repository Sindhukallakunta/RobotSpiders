using RobotSpiders.Application.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpiders.Tests.UnitTests.Application.Input
{
    public class InputValueParserTests
    {
        [Test]
        public void ParseRequiredInt_ValidNumber_ReturnsValue()
        {
            var result = InputValueParser.ParseRequiredInt("42", "X");
            Assert.That(result, Is.EqualTo(42));
        }

        [Test]
        public void ParseRequiredInt_Null_Throws()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                InputValueParser.ParseRequiredInt(null, "X"));

            Assert.That(ex!.Message, Is.EqualTo("X is required"));
        }

        [Test]
        public void ParseRequiredInt_Whitespace_Throws()
        {
            Assert.Throws<ArgumentException>(() =>
                InputValueParser.ParseRequiredInt(" ", "Y"));
        }

        [Test]
        public void ParseRequiredInt_InvalidNumber_Throws()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                InputValueParser.ParseRequiredInt("abc", "X"));

            Assert.That(ex!.Message,
                Does.Contain("Invalid numeric value for X"));
        }
    }
}
