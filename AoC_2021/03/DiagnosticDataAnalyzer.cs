using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC_2021._03
{
    public class DiagnosticDataAnalyzer
    {
        private const int InputDataBits = 12;
        private readonly int[] _bitCounterArray = new int[InputDataBits];
        private int _binaryNumberStringCount;

        private List<string> DiagnosticData { get; }

        private int GammaRate { get; set; }
        private int EpsilonRate { get; set; }
        private int OxygenGeneratorRating { get; set; }
        private int Co2ScrubberRating { get; set; }

        public DiagnosticDataAnalyzer(List<string> diagnosticData)
        {
            DiagnosticData = diagnosticData;
        }

        #region Part One

        public int GetPowerConsumption()
        {
            CalculateGammaRate();
            CalculateEpsilonRate();

            return GammaRate * EpsilonRate;
        }

        private void CalculateGammaRate()
        {
            GetMostCommonBitCount();

            // ConvertToBinaryGammaRate
            int[] gammaRateArray = new int[InputDataBits];

            for (var i = 0; i < InputDataBits; i++)
            {
                if (_bitCounterArray[i] > _binaryNumberStringCount / 2)
                {
                    gammaRateArray[i] = 1;
                }
                else
                {
                    gammaRateArray[i] = 0;
                }
            }

            var gammaRateString = string.Join(string.Empty, gammaRateArray);

            // ConvertToDecimalGammaRate
            GammaRate = Convert.ToInt32(gammaRateString, 2);
        }

        private void GetMostCommonBitCount()
        {
            foreach (var binaryNumberString in DiagnosticData)
            {
                for (var i = 0; i < binaryNumberString.Length; i++)
                {
                    if (binaryNumberString[i] == '1')
                    {
                        _bitCounterArray[i]++;
                    }
                }

                _binaryNumberStringCount++;
            }
        }

        private void CalculateEpsilonRate()
        {
            // ConvertToBinaryEpsilonRate
            int[] epsilonRateArray = new int[InputDataBits];

            for (var i = 0; i < InputDataBits; i++)
            {
                if (_bitCounterArray[i] > _binaryNumberStringCount / 2)
                {
                    epsilonRateArray[i] = 0;
                }
                else
                {
                    epsilonRateArray[i] = 1;
                }
            }

            var epsilonRateString = string.Join(string.Empty, epsilonRateArray);

            // ConvertToDecimalGammaRate
            EpsilonRate = Convert.ToInt32(epsilonRateString, 2);
        }

        #endregion

        #region Part Two

        public int GetLifeSupportRate()
        {
            CalculateOxygenGeneratorRating();
            CalculateCo2ScrubberRating();

            return OxygenGeneratorRating * Co2ScrubberRating;
        }

        private void CalculateOxygenGeneratorRating()
        {
            List<string> filteredDiagnosticData = DiagnosticData;

            for (int i = 0; i < filteredDiagnosticData[0].Length; i++)
            {
                var filterValue = GetMostCommonBitAtIndex(i, filteredDiagnosticData);

                filteredDiagnosticData = filteredDiagnosticData.Where(x => x[i] == filterValue).ToList();

                if (filteredDiagnosticData.Count == 1)
                {
                    break;
                }
            }

            OxygenGeneratorRating = Convert.ToInt32(filteredDiagnosticData[0], 2);
        }

        private char GetMostCommonBitAtIndex(int i, List<string> diagnosticData)
        {
            var result = '0';
            var oneCounter = 0;
            var zeroCounter = 0;

            foreach (var binaryNumberString in diagnosticData)
            {
                if (binaryNumberString[i] == '1')
                {
                    oneCounter++;
                }
                else
                {
                    zeroCounter++;
                }
            }

            if (oneCounter >= zeroCounter)
            {
                result = '1';
            }

            return result;
        }

        private void CalculateCo2ScrubberRating()
        {
            List<string> filteredDiagnosticData = DiagnosticData;

            for (int i = 0; i < filteredDiagnosticData[0].Length; i++)
            {
                var filterValue = GetLeastCommonBitAtIndex(i, filteredDiagnosticData);

                filteredDiagnosticData = filteredDiagnosticData.Where(x => x[i] == filterValue).ToList();

                if (filteredDiagnosticData.Count == 1)
                {
                    break;
                }
            }

            Co2ScrubberRating = Convert.ToInt32(filteredDiagnosticData[0], 2);
        }

        private char GetLeastCommonBitAtIndex(int i, List<string> diagnosticData)
        {
            var result = '1';
            var oneCounter = 0;
            var zeroCounter = 0;

            foreach (var binaryNumberString in diagnosticData)
            {
                if (binaryNumberString[i] == '1')
                {
                    oneCounter++;
                }
                else
                {
                    zeroCounter++;
                }
            }

            if (oneCounter >= zeroCounter)
            {
                result = '0';
            }

            return result;
        }

        #endregion
    }
}