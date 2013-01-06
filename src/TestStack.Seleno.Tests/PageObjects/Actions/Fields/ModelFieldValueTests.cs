﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using TestStack.BDDfy.Core;
using TestStack.Seleno.PageObjects.Actions.Fields;
using TestStack.BDDfy;
using TestStack.BDDfy.Scanners.StepScanners.Fluent;

namespace TestStack.Seleno.Tests.PageObjects.Actions.Fields
{
    class ModelFieldValueTests
    {
        [Story(Title = "ModelFieldValue - Single value")]
        public class SingleValueModelFieldValueSpec
        {
            private ModelFieldValue SUT;

            public void Given_a_ModelFieldValue_of(object modelValue)
            {
                SUT = new ModelFieldValue(modelValue);
            }

            public void Then_IsTrue_should_be(bool expected)
            {
                Assert.That(SUT.IsTrue, Is.EqualTo(expected));
            }

            public void And_Value_should_be(string expected)
            {
                Assert.That(SUT.Value, Is.EqualTo(expected));
            }

            public void And_HasMultipleValues_should_be_false()
            {
                Assert.That(SUT.HasMultipleValues, Is.False);
            }

            public void And_Values_should_throw_exception()
            {
                #pragma warning disable 219
                IEnumerable<string> x;
                #pragma warning restore 219
                Assert.Throws<InvalidOperationException>(() => x = SUT.Values);
            }
        }

        private void TestSpec(string testTitle, object modelValue, bool expectedIsTrueValue, string expectedValue)
        {
            new SingleValueModelFieldValueSpec()
                .Given(s => s.Given_a_ModelFieldValue_of(modelValue))
                .Then(s => s.Then_IsTrue_should_be(expectedIsTrueValue))
                .And(s => s.And_Value_should_be(expectedValue))
                .And(s => s.And_HasMultipleValues_should_be_false())
                .And(s => s.And_Values_should_throw_exception())
                .BDDfy<SingleValueModelFieldValueSpec>(string.Format("{0} - {1}", testTitle, modelValue ?? "(null)"));
        }

        [TestCase(true, true, "true")]
        [TestCase(false, false, "false")]
        [TestCase(null, false, "")]
        public void BooleanTests(bool? modelValue, bool expectedIsTrueValue, string expectedValue)
        {
            TestSpec("Boolean", modelValue, expectedIsTrueValue, expectedValue);
        }

        [TestCase(1, false, "1")]
        [TestCase(2.3, false, "2.3")]
        [TestCase(2.333f, false, "2.333")]
        [TestCase(2.3355551111111, false, "2.3355551111111")]
        [TestCase((short)5, false, "5")]
        public void NumericTests(object modelValue, bool expectedIsTrueValue, string expectedValue)
        {
            TestSpec("Numeric", modelValue, expectedIsTrueValue, expectedValue);
        }
    }
}
