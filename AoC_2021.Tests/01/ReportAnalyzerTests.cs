using AoC_2021._01;
using NUnit.Framework;

namespace AoC_2021.Tests._01
{
    [TestFixture]
    public class ReportAnalyzerTests
    {
        private TestData _testData;

        private TestData TestData => _testData ?? (_testData = CreateTestData());

        #region Part One

        [Test]
        public void Count_the_number_of_times_a_depth_measurement_increases_from_the_previous_measurement_sample()
        {
            // Arrange
            int[] input = {199, 200, 208, 210, 200, 207, 240, 269, 260, 263};
            var analyzer = new ReportAnalyzer();

            // Act
            var result = analyzer.GetNumberOfMeasurementIncreases(input);

            // Assert
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void Count_the_number_of_times_a_depth_measurement_increases_from_the_previous_measurement_challenge()
        {
            // Arrange
            var input = TestData.GetReportData("01.input.txt");
            var analyzer = new ReportAnalyzer();

            // Act
            var result = analyzer.GetNumberOfMeasurementIncreases(input);

            // Assert
            Assert.That(result, Is.EqualTo(1754));
        }

        #endregion

        #region Part Two

        [Test]
        public void Count_the_number_of_times_the_sum_of_measurements_in_a_sliding_window_of_three_measurements_increases_SAMPLE()
        {
            // Arrange
            int[] input = { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
            var analyzer = new ReportAnalyzer();

            // Act
            var result = analyzer.GetNumberOfSlidingWindowMeasurementIncreases(input);

            // Assert
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void Count_the_number_of_times_the_sum_of_measurements_in_a_sliding_window_of_three_measurements_increases_CHALLANGE()
        {
            // Arrange
            var input = TestData.GetReportData("01.input.txt");
            var analyzer = new ReportAnalyzer();

            // Act
            var result = analyzer.GetNumberOfSlidingWindowMeasurementIncreases(input);

            // Assert
            Assert.That(result, Is.EqualTo(1789));
        }

        #endregion

        private TestData CreateTestData()
        {
            return new TestData();
        }
    }
}