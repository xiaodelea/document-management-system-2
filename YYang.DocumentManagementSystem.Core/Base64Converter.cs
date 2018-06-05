using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYang.DocumentManagementSystem.Core
{
    public class Base64Converter : IConverter
    {
        public Byte[] bytes { get; private set; }
        public String base64String { get; private set; }

        

        public Base64Converter(Byte[] bytes)
        {
            this.bytes = bytes;
        }

        public Base64Converter(string base64String)
        {
            this.base64String = base64String;
        }

        public void Encode()
        {
            if (bytes == null)
            {
                throw new InputException();
            }

            base64String = Convert.ToBase64String(bytes);
        }

        public void Decode()
        {
            if (string.IsNullOrEmpty(base64String))
            {
                throw new InputException();
            }

            bytes = Convert.FromBase64String(base64String);
        }
    }
}
