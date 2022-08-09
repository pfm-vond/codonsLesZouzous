using MeasurementUnit.InternationalSystem.Lengths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasurementUnit.InternationalSystem.Factors
{
    internal class Base<T> : Factor<T>
    {
        private UnitOfLength measurement;

        public Base(UnitOfLength measurement)
        {
            this.measurement = measurement;
        }
    }
}
