namespace dg.adventofcode._2021.Days.Day2
{
    public class Dive
    {
        private int _horizontalPosition;
        private int _depth;
        private int _aim;

        public Dive()
        {
            _horizontalPosition = 0;
            _depth = 0;
            _aim = 0;
        }

        public int GetPosition(List<string> commands)
        {
            foreach (var command in commands)
            {
                var instruction = ParseCommand(command);
                ApplyInstruction(instruction);
            }

            return _horizontalPosition * _depth;
        }

        private static SubInstruction ParseCommand(string command)
        {
            var instruction = new SubInstruction();
            var commandParts = command.Split(' ');
            var distanceMultiplier = 1;

            switch (commandParts[0])
            {
                case "forward":
                    instruction.DirectionType = DirectionType.Horizontal;
                    distanceMultiplier = 1;
                    break;
                case "down":
                    instruction.DirectionType = DirectionType.Depth;
                    distanceMultiplier = 1;
                    break;
                case "up":
                    instruction.DirectionType = DirectionType.Depth;
                    distanceMultiplier = -1;
                    break;
            }

            var distance = int.Parse(commandParts[1]);
            instruction.Distance = distance * distanceMultiplier;

            return instruction;
        }

        private void ApplyInstruction(SubInstruction instruction)
        {
            if (instruction.DirectionType == DirectionType.Depth)
            {
                _aim += instruction.Distance;
            }
            else
            {
                _horizontalPosition += instruction.Distance;
                _depth += (_aim * instruction.Distance);
            }
        }

        internal class SubInstruction
        {
            public DirectionType DirectionType { get; set; }
            public int Distance { get; set; }
        }
    }

    internal enum DirectionType
    {
        Horizontal = 1,
        Depth = 2
    }
}
