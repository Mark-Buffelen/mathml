using Mathml.Operations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Xml;

namespace Mathml
{
    public class Program
    {
        // Used to choose which type of parser based on file extension
        private static Dictionary<string, IParser> _parsers = new Dictionary<string, IParser>()
        {
            {".xml", new XmlParser() },
        };

        // Chooses which operator class based on Node name
        private static Dictionary<string, Operator> _operator = new Dictionary<string, Operator>()
        {
            {"Add", new AdditionOperator() },
            {"Subtract", new SubtractionOperator() },
            {"Multiply", new MultiplicationOperator() },
            {"Divide", new DivisionOperator() },
        };

        static void Main(string[] args)
        {
            var filePath = "math.xml";
            var data = File.ReadAllText(filePath);
            var extension = Path.GetExtension(filePath);
            var parser = _parsers[extension];
            var results = parser.Parse(data);

            PrintAllStrings(results);

            // Used so Console will not automatically close when ran
            Console.WriteLine("\nPress any button to exit.");
            Console.ReadKey(true);

        }

        private static void PrintAllStrings(List<Operation> results)
        {
            if (results != null)
            {
                foreach (Operation node in results)
                {
                    string operatorString;
                    var nodeToPrint = _operator[node.Operator];
                    operatorString = nodeToPrint.BuildString(node);
                    PrintString(operatorString);
                }
            }
        }

        private static void PrintString(string operatorString)
        {
            if (operatorString.Length > 0)
            {
                Console.WriteLine(operatorString);
            }
        }
    }
}
