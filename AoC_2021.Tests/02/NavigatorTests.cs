using System.Collections.Generic;
using AoC_2021._01;
using AoC_2021._02;
using NUnit.Framework;

namespace AoC_2021.Tests._02
{
    [TestFixture]
    public class NavigatorTests
    {
        private TestData _testData;

        private TestData TestData => _testData ?? (_testData = CreateTestData());

        #region Part One

        [Test]
        public void multiply_final_horizontal_position_by_final_depth_SAMPLE()
        {
            // Arrange
            List<Command>input = new List<Command>()
            {
                new Command(Direction.Forward, 5),
                new Command(Direction.Down, 5),
                new Command(Direction.Forward, 8),
                new Command(Direction.Up, 3),
                new Command(Direction.Down, 8),
                new Command(Direction.Forward, 2)
            };
            var navigator = new Navigator();

            // Act
            var result = navigator.CalculateResult(input);

            // Assert
            Assert.That(result, Is.EqualTo(150));
        }

        [Test]
        public void multiply_final_horizontal_position_by_final_depth_CHALLENGE()
        {
            // Arrange
            var input = TestData.GetCourseCommands("02.input.txt");
            var navigator = new Navigator();

            // Act
            var result = navigator.CalculateResult(input);

            // Assert
            Assert.That(result, Is.EqualTo(1692075));
        }

        #endregion

        #region Part Two

        [Test]
        public void multiply_final_horizontal_position_by_final_depth_SAMPLE_aim()
        {
            // Arrange
            List<Command> input = new List<Command>()
            {
                new Command(Direction.Forward, 5),
                new Command(Direction.Down, 5),
                new Command(Direction.Forward, 8),
                new Command(Direction.Up, 3),
                new Command(Direction.Down, 8),
                new Command(Direction.Forward, 2)
            };
            var navigator = new Navigator();

            // Act
            var result = navigator.CalculateAimResult(input);

            // Assert
            Assert.That(result, Is.EqualTo(900));
        }

        [Test]
        public void multiply_final_horizontal_position_by_final_depth_CHALLENGE_aim()
        {
            // Arrange
            var input = TestData.GetCourseCommands("02.input.txt");
            var navigator = new Navigator();

            // Act
            var result = navigator.CalculateAimResult(input);

            // Assert
            Assert.That(result, Is.EqualTo(1749524700));
        }

        #endregion

        private TestData CreateTestData()
        {
            return new TestData();
        }
    }
}