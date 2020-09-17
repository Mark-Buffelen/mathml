using System;
using System.Collections.Generic;
using System.Text;

namespace Mathml.Operations
{
    public class DivisionOperator : Operator
    {
        int operationStringLength = 6;
        string correctOperationName = "DIVIDE";

        public override string FindOperation(string text, int stringLength = 0, string startAt = ";")
        {
            return base.FindOperation(text, operationStringLength, startAt);
        }

        public override string CalculateOperation(int value1, int value2, string operatorText)
        {
            string text = String.Empty;
            if (operatorText == correctOperationName)
            {
                decimal answer = value1 / value2;
                text = String.Format("{0} / {1} = {2}", value1, value2, answer);
            }
            return text;
        }
    }
}
