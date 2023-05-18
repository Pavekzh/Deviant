using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTools
{
    public interface IValidationRule<T>
    {
        T DefaultValidValue { get; }
        bool UseDefaultValue { get; }

        bool ValidateValue(T value);
    }
}
