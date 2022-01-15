using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC_2021._08
{
    public class SevenSegmentAnalyzer
    {
        public int GetOccurrenceOfDigitsInOutputValues(List<string> input, int[] digitLengths)
        {
            var result = 0;

            foreach (var line in input)
            {
                var outputDigits = GetOutputPatterns(line);
                result += GetNumberOfOutputDigitsWithLengths(outputDigits, digitLengths);
            }

            return result;
        }

        private int GetNumberOfOutputDigitsWithLengths(string[] outputDigits, int[] lengths)
        {
            var result = 0;

            foreach (var digit in outputDigits)
            {
                if (lengths.Contains(digit.Length))
                {
                    result++;
                }
            }

            return result;
        }

        public int SumOutputDigitValues(List<string> input)
        {
            var result = 0;

            foreach (var line in input)
            {
                result += ReplacePatternsWithNumbers(line);
            }

            return result;
        }

        private int ReplacePatternsWithNumbers(string patternLine)
        {
            char[] OutputSeparator = { '|' };
            var bla = patternLine.Split(OutputSeparator)[1];
            IDictionary<string, string> map = new Dictionary<string, string>()
            {
                {@"\bcagedb\b", "0"},
                {@"\bab\b", "1"},
                {@"\bgcdfa\b", "2"},
                {@"\bfbcad\b", "3"},
                {@"\beafb\b", "4"},
                {@"\bcdfbe\b", "5"},
                {@"\bcdfgeb\b", "6"},
                {@"\bdab\b", "7"},
                {@"\bacedgfb\b", "8"},
                {@"\bcefabd\b", "9" }
            };

            var regex = new Regex(string.Join("|", map.Keys));
            var newStr = regex.Replace(bla, m => map[m.Value]);
            var numberStr = Regex.Replace(newStr, @"\s+", "");
            var result = int.Parse(numberStr);
            return result;
        }


        public int PartTwo(List<string> input)
        {
            var result = 0;

            foreach (var line in input)
            {
                var output = DecodeOutputValue(line);
                result += output;
            }

            return result;
        }

        private int DecodeOutputValue(string line)
        {
            var inputPatterns = GetInputPatterns(line);
            var outputPatterns = GetOutputPatterns(line);

            var patternDict = InferNumbersFromInputPatterns(inputPatterns);
            
            var result = ConvertOutputPatternsToValue(patternDict, outputPatterns);
            
            return result;
        }

        private int ConvertOutputPatternsToValue(Dictionary<string, int> patternDict, string[] outputPatterns)
        {
            for (int i = 0; i < 4; i++)
            {
                var key = outputPatterns[i];
                outputPatterns[i] = patternDict[key].ToString();
            }

            int.TryParse(string.Concat(outputPatterns), out var result);

            return result;
        }

        private Dictionary<string, int> InferNumbersFromInputPatterns(string[] inputPatterns)
        {
            char s0, s1, s2, s3, s4, s5, s6;

            string number2 = string.Empty;
            string number3 = string.Empty;
            string number5 = string.Empty;
            string number6 = string.Empty;
            string number9 = string.Empty;
            string number0 = string.Empty;

            var result = new Dictionary<string, int>();

            var number1 = inputPatterns.First(x => x.Length == 2);
            result.Add(number1, 1);

            var number4 = inputPatterns.First(x => x.Length == 4);
            result.Add(number4, 4);

            var number7 = inputPatterns.First(x => x.Length == 3);
            result.Add(number7, 7);

            var number8 = inputPatterns.First(x => x.Length == 7);
            result.Add(number8, 8);

            var numbers235 = inputPatterns.Where(x => x.Length == 5).ToList();

            foreach (var pattern in numbers235)
            {
                var bla = new HashSet<char>(pattern);
                if (bla.IsSupersetOf(new HashSet<char>(number1)))
                {
                    number3 = pattern;
                    result.Add(pattern, 3);
                }
                else
                {
                    bla.ExceptWith(new HashSet<char>(number4));
                    var tmp = bla.ToArray().Length;
                    result.Add(pattern, tmp == 2 ? 5 : 2);
                    if (tmp == 2)
                    {
                        number5 = pattern;
                    }
                }
            }

            var numbers690 = inputPatterns.Where(x => x.Length == 6).ToList();

            foreach (var pattern in numbers690)
            {
                var bla = new HashSet<char>(pattern);
                if (bla.IsSupersetOf(new HashSet<char>(number3)))
                {
                    result.Add(pattern, 9);
                }
                else if(bla.IsSupersetOf(new HashSet<char>(number5)))
                {
                    result.Add(pattern, 6);
                }
                else
                {
                    result.Add(pattern, 0);
                }
            }

            return result;
        }

        private string[] GetInputPatterns(string inputLine)
        {
            char[] outputSeparator = {'|'};
            string[] patternSeparator = {" "};

            var input = inputLine.Split(outputSeparator)[0];
            var inputPatterns = input.Split(patternSeparator, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < 10; i++)
            {
                var bla = SortStringCharacters(inputPatterns[i]);
                inputPatterns[i] = bla;
            }

            return inputPatterns;
        }

        private string[] GetOutputPatterns(string inputLine)
        {
            char[] outputSeparator = {'|'};
            string[] digitSeparator = {" "};

            var outputValues = inputLine.Split(outputSeparator)[1];
            var outputDigits = outputValues.Split(digitSeparator, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < 4; i++)
            {
                var bla = SortStringCharacters(outputDigits[i]);
                outputDigits[i] = bla;
            }

            return outputDigits;
        }


        static string SortStringCharacters(string input)
        {
            var characters = input.ToCharArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}