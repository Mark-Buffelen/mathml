using System;
using System.Collections.Generic;
using System.Text;

namespace Mathml.Operations
{
    public abstract class Operator
    {
        public abstract string CalculateOperation(int value1, int value2, string operatorText);

        public string BuildString(Operation data)
        {
            string finalPrint = string.Empty;
            string userName = FindUserName(data.Description);
            string operationText = FindOperation(data.Description);

            int value1;
            int value2;

            try 
            { 
                value1 = int.Parse(data.Value1); 
            } 
            catch 
            {
                Console.WriteLine(string.Format("\"{0}\" could not be parsed into an integer.", data.Value1));
                return finalPrint;
            }

            try
            {
                value2 = int.Parse(data.Value2);
            }
            catch
            {
                Console.WriteLine(string.Format("\"{0}\" could not be parsed into an integer.", data.Value2));
                return finalPrint;
            }

            string operation = CalculateOperation(value1, value2, operationText);
            if (operation == string.Empty)
            {
                Console.WriteLine("Either operator is not handled or your Operator text is incorrect.");
                return finalPrint;
            }
            finalPrint = userName + "--" + operationText + "--" + operation;

            return finalPrint;
        }

        private string FindUserName(string text, string stopAt = ";")
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    return text.Substring(0, charLocation);
                }
            }
            return string.Empty;
        }

        public virtual string FindOperation(string text, int stringLength = 0, string startAt = ";")
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                int startLocation = text.IndexOf(startAt, StringComparison.Ordinal);
                // used to verify that the length of the substring is at least the needed length for operation name
                int stringLengthVerification = startLocation + 1 + stringLength;
                if (startLocation >= 0 && stringLength > 0 && stringLengthVerification <= text.Length)
                {
                    // add one to not include the startAt character in the substring
                    return text.Substring(startLocation + 1, stringLength);
                }
            }
            return string.Empty;
        }
    }
}
