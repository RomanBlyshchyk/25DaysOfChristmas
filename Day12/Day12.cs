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
        static void Main(string[] args)
        {
            //"C:\\Development\\VS2015\\Projects\\25DaysOfChristmas\\Day12\\input.txt"
            using (var sr = new StreamReader(@"c:\users\roman\source\repos\25daysofchristmas\day12\input.txt"))
            {
                Console.WriteLine(FindGroupSize(sr.ReadToEnd()));
                Console.ReadKey();
            }
        }

        public static int FindGroupSize(string input)
        {
            var lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var groupSize = 0;
            var group = new List<Person>();
            foreach (var line in lines)
            {
                var lineParts = line.Split(' ');
                var name = lineParts[0];
                var friends = new List<string>();

                for (int i = 2; i < lineParts.Length; i++)
                {
                    var friendName = lineParts[i];
                    if (lineParts[i].EndsWith(","))
                        friendName = lineParts[i].Substring(0, lineParts[i].Length - 1);

                    friends.Add(friendName);
                }

                group.Add(new Person(name, friends));
            }

            groupSize = CountGroupSize(group, group.First().Name, "");

            return groupSize;
        }

        private static int CountGroupSize(List<Person> group, string startName, string parent)
        {
            var person = group.Find(p => p.Name == startName);
            // can we even have zero friends? 
            if (person.Friends.Count == 1)
            {
                if (person.Friends[0] == person.Name)
                    return 1;
                else if (person.Friends[0] == parent)
                    return 1;
                else
                    return CountGroupSize(group, person.Friends[0], person.Name);
            }
            var size = 0;
            foreach (var friend in person.Friends)
            {
                if (friend != parent)
                    size += CountGroupSize(group, friend, person.Name);
            }
            return size;
        }

        public class Person
        {
            private string _name;
            private List<string> _friends;

            public Person(string name, List<string> friends)
            {
                Name = name;
                Friends = friends;
            }

            public List<string> Friends { get => _friends; set => _friends = value; }
            public string Name { get => _name; set => _name = value; }
        }
    }
}
