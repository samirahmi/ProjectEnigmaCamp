using System;

namespace Project2_Robot
{
    internal class Robot
    {
        public Robot(Compass compass, int x, int y)
        {
            Compass = compass;
            X = x;
            Y = y;
        }

        public Compass Compass { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public void Movement(string move)
        {
            foreach (var m in move)
            {
                switch (char.ToUpper(m))
                {
                    case 'A':
                        Console.Write("A -> ");
                        GoAhead();
                        break;
                    case 'L':
                        Console.Write("L -> ");
                        TurnLeft();
                        break;
                    case 'R':
                        Console.Write("R -> ");
                        TurnRight();
                        break;
                }
            }
        }

        private void GoAhead()
        {
            switch (Compass)
            {
                case Compass.North:
                    Y++;
                    break;
                case Compass.East:
                    X++;
                    break;
                case Compass.South:
                    Y--;
                    break;
                case Compass.West:
                    X--;
                    break;
                default:
                    break;
            }

            Console.WriteLine($"{X} {Y}");
        }
        private void TurnLeft()
        {
            switch (Compass)
            {
                case Compass.North:
                    Compass = Compass.West;
                    break;
                case Compass.East:
                    Compass = Compass.North;
                    break;
                case Compass.South:
                    Compass = Compass.East;
                    break;
                case Compass.West:
                    Compass = Compass.South;
                    break;
            }

            Console.WriteLine($"{X} {Y}");
        }

        private void TurnRight()
        {
            switch (Compass)
            {
                case Compass.North:
                    Compass = Compass.East;
                    break;
                case Compass.East:
                    Compass = Compass.South;
                    break;
                case Compass.South:
                    Compass = Compass.West;
                    break;
                case Compass.West:
                    Compass = Compass.North;
                    break;
            }

            Console.WriteLine($"{X} {Y}");
        }
    }
}
