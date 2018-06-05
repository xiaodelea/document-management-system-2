using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYang.DocumentManagementSystem.Core
{
    public interface IConverter
    {
        void Encode();
        void Decode();
    }
}
