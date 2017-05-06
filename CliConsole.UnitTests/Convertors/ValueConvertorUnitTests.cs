﻿using System;
using CliConsole.Convertors;
using CliConsole.Interfaces.Convertors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CliConsole.UnitTests.Convertors
{
    [TestClass]
    public class ValueConvertorUnitTests
    {
        private IValueConvertor _target;

        [TestInitialize]
        public void TestInitialize()
        {
            _target = new ValueConvertor();
        }

        [TestMethod]
        public void WhenIConvertAStringToAnIntItIsConverted()
        {
            const int expectedValue = 12345;
            var inputValue = $"{expectedValue}";

            var result = _target.TryConvert(typeof(int), inputValue, out object convertedValue);

            Assert.IsTrue(result);
            Assert.AreEqual(expectedValue, convertedValue);
        }

        [TestMethod]
        public void WhenIConvertAStringThatCannotBeToAnIntItIsNotConverted()
        {
            const int expectedValue = new int();
            var inputValue = $"{Guid.NewGuid()}";

            var result = _target.TryConvert(typeof(int), inputValue, out object convertedValue);

            Assert.IsFalse(result);
            Assert.AreEqual(expectedValue, convertedValue);
        }

        [TestMethod]
        public void WhenIConvertAStringToAnDoubleItIsConverted()
        {
            const double expectedValue = 12345;
            var inputValue = $"{expectedValue}";

            var result = _target.TryConvert(typeof(double), inputValue, out object convertedValue);

            Assert.IsTrue(result);
            Assert.AreEqual(expectedValue, convertedValue);
        }

        [TestMethod]
        public void WhenIConvertAStringThatCannotBeToAnDoubleItIsNotConverted()
        {
            const double expectedValue = new double();
            var inputValue = $"{Guid.NewGuid()}";

            var result = _target.TryConvert(typeof(double), inputValue, out object convertedValue);

            Assert.IsFalse(result);
            Assert.AreEqual(expectedValue, convertedValue);
        }

        [TestMethod]
        public void WhenIConvertAStringToAnFloatItIsConverted()
        {
            const float expectedValue = 12345;
            var inputValue = $"{expectedValue}";

            var result = _target.TryConvert(typeof(float), inputValue, out object convertedValue);

            Assert.IsTrue(result);
            Assert.AreEqual(expectedValue, convertedValue);
        }

        [TestMethod]
        public void WhenIConvertAStringThatCannotBeToAnFloatItIsNotConverted()
        {
            const float expectedValue = new float();
            var inputValue = $"{Guid.NewGuid()}";

            var result = _target.TryConvert(typeof(float), inputValue, out object convertedValue);

            Assert.IsFalse(result);
            Assert.AreEqual(expectedValue, convertedValue);
        }

        [TestMethod]
        public void WhenIConvertAStringToAnByteItIsConverted()
        {
            const byte expectedValue = 255;
            var inputValue = $"{expectedValue}";

            var result = _target.TryConvert(typeof(byte), inputValue, out object convertedValue);

            Assert.IsTrue(result);
            Assert.AreEqual(expectedValue, convertedValue);
        }

        [TestMethod]
        public void WhenIConvertAStringThatCannotBeToAnByteItIsNotConverted()
        {
            const byte expectedValue = new byte();
            var inputValue = $"{Guid.NewGuid()}";

            var result = _target.TryConvert(typeof(byte), inputValue, out object convertedValue);

            Assert.IsFalse(result);
            Assert.AreEqual(expectedValue, convertedValue);
        }

        [TestMethod]
        public void WhenIConvertAStringToAnLongItIsConverted()
        {
            const long expectedValue = 255;
            var inputValue = $"{expectedValue}";

            var result = _target.TryConvert(typeof(long), inputValue, out object convertedValue);

            Assert.IsTrue(result);
            Assert.AreEqual(expectedValue, convertedValue);
        }

        [TestMethod]
        public void WhenIConvertAStringThatCannotBeToAnLongItIsNotConverted()
        {
            const long expectedValue = new long();
            var inputValue = $"{Guid.NewGuid()}";

            var result = _target.TryConvert(typeof(long), inputValue, out object convertedValue);

            Assert.IsFalse(result);
            Assert.AreEqual(expectedValue, convertedValue);
        }

        [TestMethod]
        public void WhenIConvertAStringToAnDecimalItIsConverted()
        {
            const decimal expectedValue = 255;
            var inputValue = $"{expectedValue}";

            var result = _target.TryConvert(typeof(decimal), inputValue, out object convertedValue);

            Assert.IsTrue(result);
            Assert.AreEqual(expectedValue, convertedValue);
        }

        [TestMethod]
        public void WhenIConvertAStringThatCannotBeToAnDecimaltIsNotConverted()
        {
            const decimal expectedValue = new decimal();
            var inputValue = $"{Guid.NewGuid()}";

            var result = _target.TryConvert(typeof(decimal), inputValue, out object convertedValue);

            Assert.IsFalse(result);
            Assert.AreEqual(expectedValue, convertedValue);
        }

        [TestMethod]
        public void WhenIConvertAStringToAnDateItIsConverted()
        {
            var expectedValue = new DateTime(2004, 2, 23, 14, 40, 23);
            var inputValue = $"2004-02-23 14:40:23";

            var result = _target.TryConvert(typeof(DateTime), inputValue, out object convertedValue);

            Assert.IsTrue(result);
            Assert.AreEqual(expectedValue, convertedValue);
        }

        [TestMethod]
        public void WhenIConvertAStringToAnDateUkFormatItIsConverted()
        {
            var expectedValue = new DateTime(2004, 2, 23, 14, 40, 23);
            var inputValue = $"23/02/2004 14:40:23";

            var result = _target.TryConvert(typeof(DateTime), inputValue, out object convertedValue);

            Assert.IsTrue(result);
            Assert.AreEqual(expectedValue, convertedValue);
        }

        [TestMethod]
        public void WhenIConvertAStringToAnDateUkFormatWithoutTimeItIsConverted()
        {
            var expectedValue = new DateTime(2004, 2, 23);
            var inputValue = $"23/02/2004";

            var result = _target.TryConvert(typeof(DateTime), inputValue, out object convertedValue);

            Assert.IsTrue(result);
            Assert.AreEqual(expectedValue, convertedValue);
        }

        [TestMethod]
        public void WhenIConvertAStringThatCannotBeToAnDatetIsNotConverted()
        {
            var expectedValue = new DateTime();
            var inputValue = $"{Guid.NewGuid()}";

            var result = _target.TryConvert(typeof(DateTime), inputValue, out object convertedValue);

            Assert.IsFalse(result);
            Assert.AreEqual(expectedValue, convertedValue);
        }

        [TestMethod]
        public void WhenIConvertAStringToAnTimeSpanItIsConverted()
        {
            var expectedValue = new TimeSpan(1, 4, 5, 6);
            var inputValue = $"01:04:05:06";

            var result = _target.TryConvert(typeof(TimeSpan), inputValue, out object convertedValue);

            Assert.IsTrue(result);
            Assert.AreEqual(expectedValue, convertedValue);
        }

        [TestMethod]
        public void WhenIConvertAStringToAnTimeSpanWithoutDaysItIsConverted()
        {
            var expectedValue = new TimeSpan(0, 1, 4, 5);
            var inputValue = $"01:04:05";

            var result = _target.TryConvert(typeof(TimeSpan), inputValue, out object convertedValue);

            Assert.IsTrue(result);
            Assert.AreEqual(expectedValue, convertedValue);
        }

        [TestMethod]
        public void WhenIConvertAStringThatCannotBeToATimeSpantIsNotConverted()
        {
            var expectedValue = new TimeSpan();
            var inputValue = $"{Guid.NewGuid()}";

            var result = _target.TryConvert(typeof(TimeSpan), inputValue, out object convertedValue);

            Assert.IsFalse(result);
            Assert.AreEqual(expectedValue, convertedValue);
        }
    }
}
