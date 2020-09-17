using System;
using System.Collections.Generic;
using System.Text;

namespace Mathml
{
    public class Operation
    {
        public string Operator { get; private set; }
        public string Description { get; private set; }
        public string Value1 { get; private set; }
        public string Value2 { get; private set; }

        public Operation (string operationType, string description, string value1, string value2)
        {
            Operator = operationType;
            Description = description;
            Value1 = value1;
            Value2 = value2;
        }      
    }
}
