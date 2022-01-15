using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AoC_2021._02;

namespace AoC_2021.Tests
{
    public class TestData
    {
        #region 01

        public IList<int> GetReportData(string resourceName)
        {
            var measurements = new List<int>();
            var assembly = Assembly.GetExecutingAssembly();
            var resourcePath = assembly.GetManifestResourceNames().Single(str => str.EndsWith(resourceName));


            using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
            using (StreamReader reader = new StreamReader(stream))
            {
                while (reader.Peek() >= 0)
                {
                    var measurement = reader.ReadLine();
                    if (measurement != null)
                    {
                        measurements.Add(int.Parse(measurement));
                    }
                }
            }

            return measurements;
        }

        #endregion

        #region 02

        public IList<Command> GetCourseCommands(string resourceName)
        {
            var commandList = new List<Command>();
            var assembly = Assembly.GetExecutingAssembly();
            var resourcePath = assembly.GetManifestResourceNames().Single(str => str.EndsWith(resourceName));


            using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
            using (StreamReader reader = new StreamReader(stream))
            {
                while (reader.Peek() >= 0)
                {
                    var commandString = reader.ReadLine();
                    if (commandString != null)
                    {
                        commandList.Add(ParseCommand(commandString));
                    }
                }
            }

            return commandList;
        }

        public Command ParseCommand(string commandString)
        {
            Command result = new Command(Direction.Unknown, 0);

            if (!string.IsNullOrEmpty(commandString))
            {
                var command = commandString.Split(' ');
                var commandDirectionString = command[0];
                var commandValueString = command[1];


                result = new Command(ConvertDirectionString(commandDirectionString), int.Parse(command[1]));
            }

            return result;
        }

        public Direction ConvertDirectionString(string direction)
        {
            if (!string.IsNullOrEmpty(direction))
            {
                switch (direction)
                {
                    case "forward":
                        return Direction.Forward;
                    case "up":
                        return Direction.Up;
                    case "down":
                        return Direction.Down;
                }
            }

            return Direction.Unknown;
        }

        #endregion

        #region 03

        public List<string> GetBinaryDiagnosticData(string resourceName)
        {
            var stringDiagnosticData = new List<string>();
            var assembly = Assembly.GetExecutingAssembly();
            var resourcePath = assembly.GetManifestResourceNames().Single(str => str.EndsWith(resourceName));


            using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
            using (StreamReader reader = new StreamReader(stream))
            {
                while (reader.Peek() >= 0)
                {
                    var binaryString = reader.ReadLine();
                    if (binaryString != null)
                    {
                        stringDiagnosticData.Add(binaryString);
                    }
                }
            }

            return stringDiagnosticData;
        }

        #endregion

        #region 08

        public List<string> GetSevenSegmentInputData(string resourceName)
        {
            var lineList = new List<string>();
            var assembly = Assembly.GetExecutingAssembly();
            var resourcePath = assembly.GetManifestResourceNames().Single(str => str.EndsWith(resourceName));


            using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
            using (StreamReader reader = new StreamReader(stream))
            {
                while (reader.Peek() >= 0)
                {
                    var inputLine = reader.ReadLine();
                    if (inputLine != null)
                    {
                        lineList.Add(inputLine);
                    }
                }
            }

            return lineList;
        }

        #endregion
    }
}