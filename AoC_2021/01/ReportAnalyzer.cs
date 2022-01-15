using System.Collections.Generic;

namespace AoC_2021._01
{
    public class ReportAnalyzer
    {
        public int GetNumberOfMeasurementIncreases(IList<int> measurements)
        {
            var result = 0;
            var previousMeasurement = 0;

            foreach (var measurement in measurements)
            {
                if (previousMeasurement > 0 && measurement > previousMeasurement)
                {
                    result++;
                }

                previousMeasurement = measurement;
            }


            return result;
        }

        public int GetNumberOfSlidingWindowMeasurementIncreases(IList<int> measurements)
        {
            var sums = GetSlidingWindowSums(measurements);

            var result = GetNumberOfMeasurementIncreases(sums);

            return result;
        }

        private IList<int> GetSlidingWindowSums(IList<int> measurements)
        {
            var sums = new List<int>();
            var index = 0;

            while (index + 2 < measurements.Count)
            {
                sums.Add(measurements[index] + measurements[index + 1] + measurements[index + 2]);
                index++;
            }

            return sums;
        }
    }
}