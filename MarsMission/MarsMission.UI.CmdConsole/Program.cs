using System;
using System.Linq;
using MarsMission.Core;

namespace MarsMission.UI.CmdConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var answer = 'N';
            do
            {
                try
                {
                    var spaceCenter = new SpaceCenter();

                    SetPlateau(spaceCenter);
                    SetRovers(spaceCenter);

                    foreach (var position in spaceCenter.Launch())
                    {
                        Console.WriteLine(position);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Message : {ex.Message}");
                }

                Console.WriteLine("\nDo you want to continue ? (Yes : Y)/(No : N)");
                answer = Convert.ToChar(Console.ReadLine().ToUpper());

                Console.WriteLine("\n");
            } while (answer == 'Y');


            Console.WriteLine("Press [Enter] to Exit...");
            Console.ReadLine();
        }

        private static void SetPlateau(SpaceCenter spaceCenter)
        {
            Console.WriteLine("\n================== PLATEAU =========================\n");

            Console.WriteLine("Weight : ");
            var weight = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Height : ");
            var height = Convert.ToInt32(Console.ReadLine());

            spaceCenter.SetPlateau(weight, height);
        }

        private static void SetRovers(SpaceCenter spaceCenter)
        {
            Console.WriteLine("\n================== ROVERS =========================\n");

            var answer = 'N';

            do
            {
                Console.WriteLine("X Coordinate : ");
                var xCoordinate = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Y Coordinate : ");
                var yCoordinate = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Heading Route : (East : E, West : W, North : N, South : S)");
                var head = Convert.ToChar(Console.ReadLine());

                Console.WriteLine("Command Set (Left : L, Right : R, Move : M) : ");
                var commandSet = Console.ReadLine();

                spaceCenter.AddRover(xCoordinate, yCoordinate, head, commandSet);

                Console.WriteLine("\nDo you want to add another rover ? (Yes : Y)/(No : N)");
                answer = Convert.ToChar(Console.ReadLine().ToUpper());
            } while (answer == 'Y');
        }
    }
}