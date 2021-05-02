using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeanFeatureFlag.Library
{
    public interface IFeatureBuilder<T>
    {
        ICapabilityBuilder<TCapability> Need<TCapability>();
    }
}
