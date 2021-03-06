﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day18
{
    public class Day18
    {
        static void Main(string[] args)
        {
            using (var sr = new StreamReader(@"input.txt"))
            {
                var input = sr.ReadToEnd();
                var finalFrequency = FindFinalFrequency(input);
                Console.WriteLine(finalFrequency);

                Console.ReadKey();
            }
        }

        //Assume there is no bad data. Hence no significant error checking for the input
        public static long FindFinalFrequency(string input)
        {
            long finalFrequency = 0;
            var commands = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var isRecoveryReached = false;
            var currentCommandIndex = 0;
            long lastPlayedSound = 0;
            var registry = new Dictionary<string, long>();

            while (!isRecoveryReached)
            {
                var currentCommand = commands[currentCommandIndex].Trim();
                //process current command
                var commandParts = currentCommand.Split(' ');
                var operation = commandParts[0];

                switch (operation)
                {
                    case "snd": // snd X : play sound value of Register X
                        var register = currentCommand.Split(' ')[1];
                        lastPlayedSound = registry[register];
                        break;
                    case "set":
                        var registerName = commandParts[1];
                        long registerValue = 0;
                        try
                        {
                            registerValue = Convert.ToInt32(commandParts[2]);
                        }
                        catch
                        {
                            registerValue = registry[commandParts[2]];
                        }

                        if (registry.ContainsKey(registerName))
                        {
                            registry[registerName] = registerValue;
                        }
                        else
                        {
                            registry.Add(registerName, registerValue);
                        }
                        break;
                    case "add":
                        long value = 0;
                        try
                        {
                            value = Convert.ToInt32(commandParts[2]);
                        }
                        catch
                        {
                            value = registry[commandParts[2]];
                        }
                        if (registry.ContainsKey(commandParts[1]))
                        {
                            registry[commandParts[1]] += value;
                        }
                        else
                        {
                            registry.Add(commandParts[1], value);
                        }
                        break;
                    case "mul":
                        if (registry.ContainsKey(commandParts[1]))
                        {
                            try
                            {
                                registry[commandParts[1]] *= Convert.ToInt32(commandParts[2]);
                            }
                            catch
                            {
                                registry[commandParts[1]] *= registry[commandParts[2]];
                            }
                        }
                        else
                        {
                            registry.Add(commandParts[1], 0);
                        }
                        break;
                    case "mod":
                        if (registry.ContainsKey(commandParts[1]))
                        {
                            try
                            {
                                registry[commandParts[1]] %= Convert.ToInt32(commandParts[2]);
                            }
                            catch
                            {
                                registry[commandParts[1]] %= registry[commandParts[2]];
                            }
                        }
                        else
                        {
                            registry.Add(commandParts[1], 0);
                        }
                        break;
                    case "rcv":
                        if (registry[commandParts[1]] != 0)
                        {
                            isRecoveryReached = true;
                            finalFrequency = lastPlayedSound;
                        }
                        break;
                    case "jgz":
                        if (registry[commandParts[1]] > 0)
                        {
                            currentCommandIndex += Convert.ToInt32(commandParts[2]);
                        }
                        else
                        {
                            operation = "noj";  // no jump; advance the index  
                        }
                        break;
                }

                if (operation != "jgz")
                    currentCommandIndex++;
            }

            return finalFrequency;
        }
    }
}
