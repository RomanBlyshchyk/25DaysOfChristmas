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
                Console.WriteLine(FindShortestDistance(sr.ReadToEnd()));
                Console.ReadKey();
            }
        }

        public static int FindShortestDistance(string input)
        {
            var north = 0;
            var south = 0;
            var east = 0;
            var west = 0;

            var steps = input.Split(',');

            foreach (var step in steps)
            {
                switch (step)
                {
                    case "n":
                        if (south != 0 && (east != 0 || west != 0))
                        {
                            south--;
                        }
                        else if (south != 0)
                        {
                            south--;
                        }
                        else
                        {
                            north++;
                        }
                        break;
                    case "ne":

                        if (south != 0 && west != 0)
                        {
                            south--;
                            west--;
                        }
                        else if (west != 0 && north != 0)
                        {
                            west--;
                        }
                        else if (west != 0)
                        {
                            north++;
                            west--;
                        }
                        else if (south != 0)
                        {
                            south--;
                            east++;
                        }
                        else
                        {
                            north++;
                            east++;
                        }

                        break;
                    case "nw":
                        if (south != 0 && east != 0)
                        {
                            south--;
                            east--;
                        }
                        else if (north != 0 && east != 0)
                        {
                            east--;
                        }
                        else if (east != 0)
                        {
                            north++;
                            east--;
                        }
                        else if (south != 0)
                        {
                            south--;
                            west++;
                        }
                        else
                        {
                            north++;
                            west++;
                        }
                        break;
                    case "s":
                        if (north != 0 && (east != 0 || west != 0))
                        {
                            north--;
                        }
                        else if (north != 0)
                        {
                            north--;
                        }
                        else
                        {
                            south++;
                        }
                        break;
                    case "se":
                        if (north != 0 && west != 0)
                        {
                            north--;
                            west--;
                        }
                        else if (south != 0 && west != 0)
                        {
                            west--;
                        }
                        else if (north != 0)
                        {
                            north--;
                            east++;
                        }
                        else if (west != 0)
                        {
                            west--;
                            south++;
                        }
                        else
                        {
                            south++;
                            east++;
                        }
                        break;
                    case "sw":
                        if (north != 0 && east != 0)
                        {
                            north--;
                            east--;
                        }
                        else if (south != 0 && east != 0)
                        {
                            east--;
                        }
                        else if (north != 0)
                        {
                            north--;
                            west++;
                        }
                        else if (east != 0)
                        {
                            east--;
                            south++;
                        }
                        else
                        {
                            south++;
                            west++;
                        }
                        break;
                    default:
                        Console.WriteLine("Something went wrong in switch statement");
                        break;
                }
            }

            return new List<int>() { north, south, east, west }.Max();
        }
    }
}
