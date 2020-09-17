using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Mathml
{
    public class XmlParser : IParser
    {
        public List<Operation> Parse(string data)
        {
            List<Operation> operations = new List<Operation>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(data);

            // add a new Operation to the list for each node inside of the root XmlElement
            foreach (XmlNode node in xDoc.DocumentElement)
            {
                var operation = node.Name;
                string description = node["Description"].InnerText;
                string value1 = node["Value1"].InnerText;
                string value2 = node["Value2"].InnerText;

                operations.Add(new Operation(operation, description, value1, value2));
            }
            return operations;
        }


        

    }
}
