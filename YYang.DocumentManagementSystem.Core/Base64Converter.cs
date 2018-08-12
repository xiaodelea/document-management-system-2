using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYang.DocumentManagementSystem.Core
{
    public class Base64Converter : IConverter
    {
        public Byte[] Bytes { get; private set; }
        public String Base64String { get; private set; }

        

        public Base64Converter(Byte[] bytes)
        {
            this.Bytes = bytes;
        }

        public Base64Converter(string base64String)
        {
            this.Base64String = base64String;
        }

        public void Encode()
        {
            if (Bytes == null)
            {
                throw new InputException();
            }

            Base64String = Convert.ToBase64String(Bytes);
        }

        public void Decode()
        {
            if (string.IsNullOrEmpty(Base64String))
            {
                throw new InputException();
            }

            Bytes = Convert.FromBase64String(Base64String);
        }
    }
}
