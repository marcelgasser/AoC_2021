using AoC_2021._01;
using NUnit.Framework;

namespace AoC_2021.Tests._01
{
    [TestFixture]
    public class SonarSweepReportAnalyzerTests
    {
        [Test]
        public void Count_the_number_of_times_a_depth_measurement_increases_from_the_previous_measurement()
        {
            // Arrange
            int[] input = {199, 200, 208, 210, 200, 207, 240, 269, 260, 263};
            SonarSweepReportAnalyzer analyzer = new SonarSweepReportAnalyzer(input);

            // Act
            var result = analyzer.GetNumberOfDepthMeasurementIncreases();

            // Assert
            Assert.That(result, Is.EqualTo(7));
        }
    }
}