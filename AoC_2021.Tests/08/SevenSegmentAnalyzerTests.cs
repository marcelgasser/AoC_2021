using System.Collections.Generic;
using AoC_2021._08;
using NUnit.Framework;

namespace AoC_2021.Tests._08
{
    [TestFixture]
    public class SevenSegmentAnalyzerTests
    {
        private TestData _testData;

        private TestData TestData => _testData ?? (_testData = CreateTestData());

        private TestData CreateTestData()
        {
            return new TestData();
        }

        private List<string> bla = new List<string>
        {
            "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",
            "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",
            "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",
            "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",
            "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",
            "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb",
            "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe",
            "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef",
            "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb",
            "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce"
        };

        #region Part One

        [Test]
        public void Digit_occurance_SAMPLE()
        {
            // Arrange
            var sut = new SevenSegmentAnalyzer();

            // Act
            var result = sut.GetOccurrenceOfDigitsInOutputValues(bla, new []{2,3,4,7});

            // Assert
            Assert.That(result, Is.EqualTo(26));
        }

        [Test]
        public void Digit_occurance_CHALLANGE()
        {
            // Arrange
            var sut = new SevenSegmentAnalyzer();

            // Act
            var result = sut.GetOccurrenceOfDigitsInOutputValues(TestData.GetSevenSegmentInputData("08.input.txt"), new[] { 2, 3, 4, 7 });

            // Assert
            Assert.That(result, Is.EqualTo(352));
        }


        #endregion

        #region Part Two

        [Test]
        public void Sum_output_values_SAMPLE()
        {
            // Arrange
            var sut = new SevenSegmentAnalyzer();

            // Act
            var result = sut.PartTwo(bla);

            // Assert
            Assert.That(result, Is.EqualTo(61229));
        }

        [Test]
        public void Sum_output_values_CHALLANGE()
        {
            // Arrange
            var sut = new SevenSegmentAnalyzer();

            // Act
            var result = sut.PartTwo(TestData.GetSevenSegmentInputData("08.input.txt"));

            // Assert
            Assert.That(result, Is.EqualTo(936117));
        }

        #endregion
    }
}