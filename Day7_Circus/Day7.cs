using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7_Circus
{
    public class Day7
    {
        static void Main(string[] args)
        {
            using (var sr = new StreamReader("C:\\Development\\VS2015\\Projects\\25DaysOfChristmas\\Day7_Circus\\input.txt"))
            {
                Console.WriteLine(FindRoot(sr.ReadToEnd()));
                Console.ReadKey();
            }
        }

        public static string FindRoot(string input)
        {
            List<Program> nodes = GatherNodes(input);

            // find the node that doesn't have a parent
            if (nodes.FindAll(n => string.IsNullOrEmpty(n.Parent)).Count != 1)
                Console.WriteLine("ERROR: we didn't get a parent");

            var parent = nodes.Find(n => string.IsNullOrEmpty(n.Parent));
            return parent.Name;
        }

        public static int FindCorrectWeight(string input)
        {
            List<Program> nodes = GatherNodes(input);
            var correctWeight = 0;

            var parent = nodes.Find(n => string.IsNullOrEmpty(n.Parent));
            

            return correctWeight;
        }

        private static List<Program> GatherNodes(string input)
        {
            // split input by lines
            var lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            // read each line and store names in the list
            var nodes = new List<Program>();
            foreach (var line in lines)
            {
                var bits = line.Split(' ');
                if (bits.Length == 0)
                    Console.WriteLine($"ERROR: Something went wrong with line: {line}");

                var nodeName = bits[0];
                var nodeWeight = Convert.ToInt32(bits[1].Substring(1, bits[1].Length - 2).ToString());

                var node = new Program(nodeName, nodeWeight);
                if (line.Contains("->"))
                {
                    // we have children, get those names

                    for (int i = 3; i < bits.Length; i++)
                    {
                        if (bits[i].EndsWith(","))
                            node.ChildrenNames.Add(bits[i].Substring(0, bits[i].Length - 1));
                        else
                            node.ChildrenNames.Add(bits[i].Substring(0, bits[i].Length));
                    }

                }

                nodes.Add(node);
            }

            // make sure all nodes have Parent property set correctly
            foreach (var node in nodes.FindAll(n => n.ChildrenNames.Count > 0))
            {
                foreach (var child in node.ChildrenNames)
                {
                    var kid = nodes.Find(n => n.Name == child);
                    kid.Parent = node.Name;
                    node.Children.Add(new Program(kid.Name, kid.Weight));
                }
            }

            return nodes;
        }

        
        class Program
        {
            private string _name;
            private string _parent;
            private int _weight;
            public List<string> ChildrenNames;
            public List<Program> Children;

            public int Weight
            {
                get
                {
                    return _weight;
                }

                set
                {
                    _weight = value;
                }
            }

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

            public string Parent
            {
                get
                {
                    return _parent;
                }

                set
                {
                    _parent = value;
                }
            }

            public Program(string name, int weight)
            {
                Name = name;
                Weight = weight;
                ChildrenNames = new List<string>();
                Children = new List<Program>();
            }
        }
    }
}
