using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    public class Day11
    {
        static void Main(string[] args)
        {
            using (var sr = new StreamReader(@"C:\Users\Roman\Source\Repos\25DaysOfChristmas\Day11\input.txt"))
            {
                Console.WriteLine(FindFurthestShortestDistance(sr.ReadToEnd()));
                Console.ReadKey();
            }
        }
        public static int FindFurthestShortestDistance(string input)
        {
            var x = 0;
            var y = 0;
            var z = 0;
            var maxDistance = 0;
            var steps = input.Split(',');

            foreach (var step in steps)
            {
                switch (step)
                {
                    case "n":
                        y += 1;
                        z -= 1;
                        break;
                    case "ne":
                        x += 1;
                        z -= 1;
                        break;
                    case "nw":
                        x -= 1;
                        y += 1;
                        break;
                    case "s":
                        y -= 1;
                        z += 1;
                        break;
                    case "se":
                        x += 1;
                        y -= 1;
                        break;
                    case "sw":
                        x -= 1;
                        z += 1;
                        break;
                    default:
                        Console.WriteLine("Something went wrong in switch statement");
                        break;
                }
                var distance = (Math.Abs(x) + Math.Abs(y) + Math.Abs(z)) / 2;
                maxDistance = Math.Max(maxDistance, distance);
            }

            return maxDistance;
        }
        public static int FindShortestDistance(string input)
        {
            var x = 0;
            var y = 0;
            var z = 0;
            var steps = input.Split(',');

            foreach (var step in steps)
            {
                switch (step)
                {
                    case "n":
                        y += 1;
                        z -= 1;
                        break;
                    case "ne":
                        x += 1;
                        z -= 1;
                        break;
                    case "nw":
                        x -= 1;
                        y += 1;
                        break;
                    case "s":
                        y -= 1;
                        z += 1;
                        break;
                    case "se":
                        x += 1;
                        y -= 1;
                        break;
                    case "sw":
                        x -= 1;
                        z += 1;
                        break;
                    default:
                        Console.WriteLine("Something went wrong in switch statement");
                        break;
                }
            }

            var distance = (Math.Abs(x) + Math.Abs(y) + Math.Abs(z)) / 2;
            return distance;
        }
    }
}
