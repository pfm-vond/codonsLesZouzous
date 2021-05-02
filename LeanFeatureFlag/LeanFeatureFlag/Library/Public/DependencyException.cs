using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeanFeatureFlag.Library
{
    public class DependencyException : Exception
    {
        public DependencyException(
            string message,
            Type type)
            : base(message)
        {
            Data.Add("RequestedType", type);
        }
    }
}
