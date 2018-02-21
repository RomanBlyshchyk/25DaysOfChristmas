﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13
{
    public class Day13
    {
        static void Main(string[] args)
        {
            //"C:\\Development\\VS2015\\Projects\\25DaysOfChristmas\\Day13\\input.txt"
            //@"c:\users\roman\source\repos\25daysofchristmas\day13\input.txt"
            using (var sr = new StreamReader("C:\\Development\\VS2015\\Projects\\25DaysOfChristmas\\Day13\\input.txt"))
            {
                Console.WriteLine(FindSeverity(sr.ReadToEnd()));
                Console.ReadKey();
            }
        }

        public static int FindSeverity(string input)
        {
            var severity = 0;
            var firewall = ParseInput(input);
            var packetPosition = 0;
            while(packetPosition < firewall.Count)
            {
                if(firewall[packetPosition].Position == 0)
                {
                    // We are caught. Add to severity
                    severity += firewall[packetPosition].Depth * firewall[packetPosition].Range;
                }

                foreach (var securityLevel in firewall)
                    securityLevel.TimeStamp();

                packetPosition++;
            }

            return severity;
        }

        private static List<SecurityLevel> ParseInput(string input)
        {
            var firewall = new List<SecurityLevel>();
            var lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                var lineParts = line.Trim().Split(':');
                var depth = Convert.ToInt32(lineParts[0].Trim().ToString());
                var range = Convert.ToInt32(lineParts[1].Trim().ToString());

                if (depth == firewall.Count)
                {
                    // we are at the correct location. add the Security Level
                    firewall.Add(new SecurityLevel(depth, range));
                }
                else
                {
                    var currentDepth = firewall.Count;
                    for (int i = currentDepth; i < depth; i++)
                    {
                        firewall.Add(new SecurityLevel(i, 0));
                    }
                    firewall.Add(new SecurityLevel(depth, range));
                }

            }
            return firewall;
        }

        public class SecurityLevel
        {
            private int _depth;
            private int _range;
            private int _position;
            private Direction _scannerDirection;
            private enum Direction
            {
                Up,
                Down
            }

            public int Depth
            {
                get
                {
                    return _depth;
                }

                set
                {
                    _depth = value;
                }
            }
            public int Range
            {
                get
                {
                    return _range;
                }

                set
                {
                    _range = value;
                }
            }

            public int Position
            {
                get
                {
                    return _position;
                }

                set
                {
                    _position = value;
                }
            }

            public SecurityLevel(int depth, int range)
            {
                Depth = depth;
                Range = range;
                Position = 0;
                _scannerDirection = Direction.Down;
            }

            /// <summary>
            /// Would be good to test this
            /// </summary>
            public void TimeStamp()
            {
                if (_scannerDirection == Direction.Down)
                {
                    if (Position == Range - 1)
                    {
                        Position--;
                        _scannerDirection = Direction.Up;
                    }
                    else
                    {
                        Position++;
                    }
                }
                else if (_scannerDirection == Direction.Up)
                {
                    if (Position == 0)
                    {
                        Position++;
                        _scannerDirection = Direction.Down;
                    }
                    else
                    {
                        Position--;
                    }
                }
            }
        }
    }
}
