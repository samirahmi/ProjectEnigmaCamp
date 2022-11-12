using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Robot
{
    internal class RobotMenu
    {
        public void MainMenu()
        {
            var run = true;
            while(run)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("    Robot's Starting Position    ");
                Console.WriteLine("=================================");
                Console.WriteLine("N = North, X, Y");
                Console.WriteLine("S = South, X, Y");
                Console.WriteLine("W = West, X, Y");
                Console.WriteLine("E = East, X, Y");
                Console.WriteLine("=================================");
                Console.Write("Input Start Position : ");
                char position = Convert.ToChar(Console.ReadLine());
                switch (char.ToUpper(position))
                {
                    case 'N':
                        position = (char)Compass.North;
                        Console.WriteLine("North");
                        break;
                    case 'S':
                        position = (char)Compass.South;
                        Console.WriteLine("South");
                        break;
                    case 'W':
                        position = (char)Compass.West;
                        Console.WriteLine("West");
                        break;
                    case 'E':
                        position = (char)Compass.East;
                        Console.WriteLine("East");
                        break;
                    default:
                        Console.WriteLine("Try Again");
                        Console.ReadKey();
                        run = false;
                        MainMenu();
                        return;
                }

                Console.Write("X : ");
                int X = Convert.ToInt32(Console.ReadLine());
                Console.Write("Y : ");
                int Y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("=================================");
                Console.WriteLine("Description of Robot Movement");
                Console.WriteLine("A = Go Ahead");
                Console.WriteLine("R = Turn Right");
                Console.WriteLine("L = Turn Left");
                Console.WriteLine("=================================");
                Console.Write("Input Robot's Movement : ");
                string instruction = Console.ReadLine();
                //char a = 'a';
                //char r = 'r';
                //char l = 'l';
                //if (!instruction.Contains(a, r, l))
                //{

                //}

                Robot robot = new Robot((Compass)position, X, Y);
                Console.WriteLine("=================================");
                Console.WriteLine("Robot's Step Position");
                robot.Movement(instruction);
                Console.ReadKey();
            }

        }
    }
}
