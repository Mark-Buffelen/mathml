using System;
using System.Collections.Generic;
using System.Text;

namespace Mathml
{
    public interface IParser
    {
        List<Operation> Parse(string data);
    }
}
