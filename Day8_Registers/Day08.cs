using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8_Registers
{
    public class Day08
    {
        static void Main(string[] args)
        {
            using (var sr = new StreamReader("C:\\Development\\VS2015\\Projects\\25DaysOfChristmas\\Day8_Registers\\input.txt"))
            {
                Console.WriteLine(FindLargestValue(sr.ReadToEnd()));
                Console.ReadKey();
            }

        }

        public static int FindLargestValue(string input)
        {

            // create a list of Registers and their values. 
            var registers = new List<Register>();

            // split the input into a list of commands
            var lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var maxValue = 0;
            // split each command into chunks 
            //      {register} {operation} {value} {condition}
            //      {condition} ==> {register} {operator} {value}
            foreach (var line in lines)
            {
                var components = line.Split(new char[] { ' ' });    // should always be 7 components
                if (components.Length != 7)
                    Console.WriteLine($"# of components is wrong: {components.Length} instead of 7. Line: {line}");

                var regName = components[0];
                var operation = components[1];  // inc or dec.  don't need to validate right now 
                var regValueChange = Convert.ToInt32(components[2].ToString());
                // component[3] is always "if". Ideally would check for it, but don't need it right now
                var conditionRegister = components[4];
                var condition = components[5];
                var conditionValue = Convert.ToInt32(components[6].ToString());

                if (registers.Find(r => r.Name == regName) == null)
                    registers.Add(new Register(regName));

                if (registers.Find(r => r.Name == conditionRegister) == null)
                    registers.Add(new Register(conditionRegister));

                var conditionResult = false;
                
                if(condition == ">")
                {
                    var value = registers.Find(r => r.Name == conditionRegister).Value;
                    if (value > conditionValue)
                        conditionResult = true;
                }
                else if( condition == "<")
                {
                    var value = registers.Find(r => r.Name == conditionRegister).Value;
                    if (value < conditionValue)
                        conditionResult = true;
                }
                else if (condition == "==")
                {
                    var value = registers.Find(r => r.Name == conditionRegister).Value;
                    if (value == conditionValue)
                        conditionResult = true;
                }
                else if (condition == "!=")
                {
                    var value = registers.Find(r => r.Name == conditionRegister).Value;
                    if (value != conditionValue)
                        conditionResult = true;
                }
                else if (condition == ">=")
                {
                    var value = registers.Find(r => r.Name == conditionRegister).Value;
                    if (value >= conditionValue)
                        conditionResult = true;
                }
                else if (condition == "<=")
                {
                    var value = registers.Find(r => r.Name == conditionRegister).Value;
                    if (value <= conditionValue)
                        conditionResult = true;
                }
                else
                {
                    Console.WriteLine($"Encountered an unknown condition operator: {condition} in line: {line}");
                }
                // test
                if(conditionResult)
                {
                    var register = registers.Find(r => r.Name == regName);

                    if(operation == "inc")
                    {
                        register.Value += regValueChange;
                    }
                    else if(operation == "dec")
                    {
                        register.Value -= regValueChange;
                    }
                    else
                    {
                        Console.WriteLine($"Unknown operation encountered: {operation} on line: {line}");
                    }

                    if (register.Value > maxValue)
                        maxValue = register.Value;
                }
            }


            int largestValue = registers.First().Value; // find largest value;
            foreach (var register in registers)
            {
                if (register.Value > largestValue)
                    largestValue = register.Value;
            }
            return maxValue;
        }

        class Register
        {
            public string Name;
            public int Value;

            public Register(string name, int value = 0)
            {
                Name = name;
                Value = value;
            }
        }
    }
}
