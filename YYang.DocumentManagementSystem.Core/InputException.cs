using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYang.DocumentManagementSystem.Core
{
    [Serializable]
    public class InputException : Exception
    {
        public InputException()
        { }

        public InputException(string message) : base(message)
        { }

        public InputException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
