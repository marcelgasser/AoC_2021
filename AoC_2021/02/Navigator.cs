using System.Collections.Generic;
using System.Linq;

namespace AoC_2021._02
{
    public struct Command
    {
        public Direction Direction { get; }
        public int Value { get; }

        public Command(Direction direction, int value)
        {
            Direction = direction;
            Value = value;
        }
    }

    public enum Direction
    {
        Unknown,
        Forward,
        Down,
        Up
    }
    
    public class Navigator
    {
        private int HorizontalPosition { get; set; }
        private int Depth { get; set; }
        private int Aim { get; set; }

        public int CalculateFinalHorizontalPosition(IList<Command> plannedCourse)
        {
            var forwardCommands = plannedCourse.Where(x => x.Direction == Direction.Forward);

            foreach (var command in forwardCommands)
            {
                HorizontalPosition += command.Value;
            }

            return HorizontalPosition;
        }

        public int CalculateFinalDepth(IList<Command> plannedCourse)
        {
            var depthCommands = plannedCourse.Where(x => x.Direction == Direction.Down || x.Direction == Direction.Up);

            foreach (var command in depthCommands)
            {
                if (command.Direction == Direction.Down)
                {
                    Depth += command.Value;
                }
                else
                {
                    Depth -= command.Value;
                }
            }

            return Depth;
        }

        public int CalculateResult(IList<Command> plannedCourse)
        {

            return CalculateFinalHorizontalPosition(plannedCourse) * CalculateFinalDepth(plannedCourse);
        }

        public int CalculateAimResult(IList<Command> plannedCourse)
        {
            foreach (var command in plannedCourse)
            {
                switch (command.Direction)
                {
                    case Direction.Forward:
                    {
                        HorizontalPosition += command.Value;
                        Depth += command.Value * Aim;
                        break;
                    }

                    case Direction.Down:
                    {
                        Aim += command.Value;
                        break;
                    }

                    case Direction.Up:
                    {
                        Aim -= command.Value;
                        break;
                    }
                }
            }

            return HorizontalPosition * Depth;
        }
    }
}