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
            var stepsNorth = 0;
            var stepsSouth = 0;
            var stepsEast = 0;
            var stepsWest = 0;

            var steps = input.Split(',');

            foreach (var step in steps)
            {
                switch (step)
                {
                    case "n":
                        if (stepsSouth != 0 && (stepsEast != 0 || stepsWest != 0))
                        {
                            stepsSouth--;
                        }
                        else if (stepsSouth != 0)
                        {
                            stepsSouth--;
                        }
                        else
                        {
                            stepsNorth++;
                        }
                        break;
                    case "ne":

                        if (stepsWest != 0 && stepsSouth != 0)
                        {
                            stepsWest--;
                            stepsSouth--;
                        }
                        else if (stepsWest != 0)
                        {
                            stepsWest--;
                            stepsNorth++;
                        }
                        else if (stepsSouth != 0)
                        {
                            stepsSouth--;
                            stepsEast++;
                        }
                        else
                        {
                            stepsNorth++;
                            stepsEast++;
                        }

                        break;
                    case "nw":
                        if (stepsEast != 0 && stepsSouth != 0)
                        {
                            stepsEast--;
                            stepsSouth--;
                        }
                        else if (stepsEast != 0)
                        {
                            stepsEast--;
                            stepsNorth++;
                        }
                        else if (stepsSouth != 0)
                        {
                            stepsSouth--;
                            stepsWest++;
                        }
                        else
                        {
                            stepsNorth++;
                            stepsWest++;
                        }
                        break;
                    case "s":
                        if (stepsNorth != 0 && (stepsEast != 0 || stepsWest != 0))
                        {
                            stepsNorth--;
                        }
                        else if (stepsNorth != 0)
                        {
                            stepsNorth--;
                        }
                        else
                        {
                            stepsSouth++;
                        }
                        break;
                    case "se":
                        if (stepsNorth != 0 && stepsWest != 0)
                        {
                            stepsNorth--;
                            stepsWest--;
                        }
                        else if (stepsNorth != 0)
                        {
                            stepsNorth--;
                            stepsEast++;
                        }
                        else if (stepsWest != 0)
                        {
                            stepsWest--;
                            stepsSouth++;
                        }
                        else
                        {
                            stepsSouth++;
                            stepsEast++;
                        }
                        break;
                    case "sw":
                        if (stepsNorth != 0 && stepsEast != 0)
                        {
                            stepsNorth--;
                            stepsEast--;
                        }
                        else if (stepsNorth != 0)
                        {
                            stepsNorth--;
                            stepsWest++;
                        }
                        else if (stepsEast != 0)
                        {
                            stepsEast--;
                            stepsSouth++;
                        }
                        else
                        {
                            stepsSouth++;
                            stepsWest++;
                        }
                        break;
                    default:
                        Console.WriteLine("Something went wrong in switch statement");
                        break;
                }
            }
            
            return new List<int>() { stepsNorth, stepsSouth, stepsEast, stepsWest }.Max();
        }
    }
}
