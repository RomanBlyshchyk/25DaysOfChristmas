using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    public class Day12
    {
        private static List<string> _finalGroup = new List<string>();
        static void Main(string[] args)
        {
            //"C:\\Development\\VS2015\\Projects\\25DaysOfChristmas\\Day12\\input.txt"
            //@"c:\users\roman\source\repos\25daysofchristmas\day12\input.txt"
            using (var sr = new StreamReader("C:\\Development\\VS2015\\Projects\\25DaysOfChristmas\\Day12\\input.txt"))
            {
                Console.WriteLine(FindGroupCount(sr.ReadToEnd()));
                Console.ReadKey();
            }
        }

        public static int FindGroupCount(string input)
        {
            var groupFull = ParseInput(input);
            var groupCount = 0;
            while (groupFull.Count != 0)
            {
                CountGroupSize(groupFull, groupFull[0].Name, "");
                groupCount++;
            }
            return groupCount;
        }


        public static int FindGroupSize(string input)
        {
            var groupFull = ParseInput(input);

            CountGroupSize(groupFull, groupFull.First().Name, "");

            return _finalGroup.Count;
        }

        private static List<Person> ParseInput(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var groupFull = new List<Person>();
            foreach (var line in lines)
            {
                var lineParts = line.Trim().Split(' ');
                var name = lineParts[0].Trim();
                var friends = new List<string>();

                for (int i = 2; i < lineParts.Length; i++)
                {
                    var friendName = lineParts[i].Trim(',');
                    friends.Add(friendName);
                }

                groupFull.Add(new Person(name, friends));
            }

            return groupFull;
        }

        private static void CountGroupSize(List<Person> group, string startName, string parent)
        {
            var person = group.Find(p => p.Name == startName);
            if (!_finalGroup.Contains(startName))
            {
                _finalGroup.Add(startName);
                group.Remove(person);
                // can we even have zero friends? 
                if (person.Friends.Count == 1)
                {
                    if (person.Friends[0] == person.Name)
                        return;   // Do nothing because self containing group. e.g. "1 <-> 1"
                    else if (person.Friends[0] == parent)
                        return;   // Do nothing because link back to parent. e.g. "1 <-> 0", where "0" is the parent
                    else
                        CountGroupSize(group, person.Friends[0], person.Name);
                }
                else
                {
                    foreach (var friend in person.Friends)
                    {
                        if (friend != parent)
                        {
                            CountGroupSize(group, friend, person.Name);
                        }
                    }
                }
            }
        }


        public class Person
        {
            private string _name;
            private List<string> _friends;

            public string Name
            {
                get
                {
                    return _name;
                }

                set
                {
                    _name = value;
                }
            }

            public List<string> Friends
            {
                get
                {
                    return _friends;
                }

                set
                {
                    _friends = value;
                }
            }

            public Person(string name, List<string> friends)
            {
                Name = name;
                Friends = friends;
            }
        }
    }
}
