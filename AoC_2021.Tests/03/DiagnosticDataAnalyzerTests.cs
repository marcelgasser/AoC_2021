using System.Collections.Generic;
using AoC_2021._03;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AoC_2021.Tests._03
{
    [TestFixture]
    public class DiagnosticDataAnalyzerTests
    {
        private TestData _testData;

        private TestData TestData => _testData ?? (_testData = CreateTestData());

        private TestData CreateTestData()
        {
            return new TestData();
        }

        private List<string> bla = new List<string>
        {
            "00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010"
        };

        #region Part One

        [Test]
        public void What_is_the_power_consumption_CHALLENGE()
        {
            // Arrange
            var sut = new DiagnosticDataAnalyzer(TestData.GetBinaryDiagnosticData("03.input.txt"));

            // Act
            var result = sut.GetPowerConsumption();

            // Assert
            Assert.That(result, Is.EqualTo(1997414));
        }


        #endregion

        #region Part Two

        [Test]
        public void What_is_the_life_support_rating_SAMPLE()
        {
            // Arrange
            var sut = new DiagnosticDataAnalyzer(bla);

            // Act
            var result = sut.GetLifeSupportRate();

            // Assert
            Assert.That(result, Is.EqualTo(230));
        }

        [Test]
        public void What_is_the_life_support_rating_CHALLENGE()
        {
            // Arrange
            var sut = new DiagnosticDataAnalyzer(TestData.GetBinaryDiagnosticData("03.input.txt"));

            // Act
            var result = sut.GetLifeSupportRate();

            // Assert
            Assert.That(result, Is.EqualTo(1032597));
        }

        #endregion
    }
}