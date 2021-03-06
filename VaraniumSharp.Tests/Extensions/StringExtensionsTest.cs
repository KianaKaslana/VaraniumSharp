﻿using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using VaraniumSharp.Extensions;

namespace VaraniumSharp.Tests.Extensions
{
    public class StringExtensionsTest
    {
        #region Public Methods

        [Test]
        public void RetrieveEmptyKeyFromConfiguration()
        {
            // arrange
            const string key = "Empty";

            // act
            var result = key.GetConfigurationValue<DateTime>();

            // assert
            result.Should().Be(default(DateTime));
        }

        /// <summary>
        /// #Issue-9 - Cannot retrieve Enum from configuration
        /// </summary>
        [Test]
        public void RetrieveEnumerationValueFromConfiguration()
        {
            // arrange
            const string key = "EnumValue";

            // act
            var result = key.GetConfigurationValue<TestEnum>();

            // assert
            result.Should().Be(TestEnum.EnumResult);
        }

        [Test]
        public void RetrieveIntegerKeyFromConfiguration()
        {
            // arrange
            const string key = "IntValue";
            const int expectedValue = 20787;

            // act
            var result = key.GetConfigurationValue<int>();

            // assert
            result.GetType().Should().Be<int>();
            result.Should().Be(expectedValue);
        }

        [Test]
        public void RetrieveKeyThatDoesNotExistFromConfiguration()
        {
            // arrange
            const string key = "InvalidKey";
            var action = new Action(() => key.GetConfigurationValue<string>());

            // act
            // assert
            action.ShouldThrow<KeyNotFoundException>();
        }

        [Test]
        public void RetrieveStringKeyFromConfiguration()
        {
            // arrange
            const string key = "StringValue";
            const string expectedValue = "TestValue";

            // act
            var result = key.GetConfigurationValue<string>();

            // assert
            result.GetType().Should().Be<string>();
            result.Should().Be(expectedValue);
        }

        #endregion

        private enum TestEnum
        {
            EnumResult
        }
    }
}