using NUnit.Framework;
using YYang.DocumentManagementSystem.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YYang.DocumentManagementSystem.Core.UnitTest
{
    [TestFixture()]
    public class Base64ConverterTests
    {
        [Test()]
        public void EncodeTest()
        {
            Byte[] bytes = File.ReadAllBytes(Path.Combine(TestContext.CurrentContext.TestDirectory, @"README.md"));

            IConverter converter = new Base64Converter(bytes);
            converter.Encode();
            
            Assert.IsTrue(Regex.IsMatch(((Base64Converter)converter).base64String, @"^[a-zA-Z0-9\+/]*={0,2}$"));
        }
    }
}