using System;
using System.Collections.Generic;
using System.Text;

namespace Mathml.Operations
{
    public class MultiplicationOperator : Operator
    {
        int operationStringLength = 8;
        string correctOperationName = "MULTIPLY";

        public override string FindOperation(string text, int stringLength = 0, string startAt = ";")
        {
            return base.FindOperation(text, operationStringLength, startAt);
        }

        public override string CalculateOperation(int value1, int value2, string operatorText)
        {
            string text = String.Empty;
            if (operatorText == correctOperationName)
            {
                int answer = value1 * value2;
                text = String.Format("{0} * {1} = {2}", value1, value2, answer);
            }
            return text;
        }
    }
}
