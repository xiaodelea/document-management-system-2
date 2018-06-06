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
    [TestFixture]
    public class Base64ConverterTests
    {
        [Test]
        public void EncodeToBase64Test()
        {
            Byte[] bytes = File.ReadAllBytes(Path.Combine(TestContext.CurrentContext.TestDirectory, @"README.md"));

            IConverter converter = new Base64Converter(bytes);
            converter.Encode();
            
            Assert.IsTrue(Regex.IsMatch(((Base64Converter)converter).base64String, @"^[a-zA-Z0-9\+/]*={0,2}$"));
        }

        [Test]
        public void DecodeFromBase64Test()
        {
            var base64String = "IyBEb2N1bWVudCBNYW5hZ2VtZW50IFN5c3RlbQ0KDQpUaGlzIGxpdHRsZSBhcHBsaWNhdGlvbiBpcyBzdXBwb3NlZCB0byB3YXRjaCBhIGRpcmVjdG9yeSB3aGVyZSBzY2FubmVkIGRvY3VtZW50cyAoanBnLCBwbmcgYW5kIHBkZikgYXJlIHNhdmVkIHRvLg0KDQpVcG9uIGRldGVjdGlvbiBvZiBzdWNoIGFuIGFjdGlvbiB0aGUgZG9jdW1lbnQncyBtZXRhIGRhdGEgYXJlIHJlYWQgYW5kIHNhdmVkIHRvIGEgZGF0YWJhc2UuDQoNCkVhY2ggZG9jdW1lbnQgaXMgZmxhZ2dlZCBbSU5JVElBTCwgRU5SSUNITUVOVCwgU0FWRUQsIEFSQ0hJVkVEXS4NCg0KIyMgRG9jdW1lbnQgc3RhZ2UNCg0KVGhpcyBzZWN0aW9uIGRlc2NyaWJlZCB0aGUgZGlmZmVyZW50IGRvY3VtZW50IHN0YWdlcy4gQSBkb2N1bWVudCBzdGFnZSB3b3JrZmxvdyBpcyB1c3VhbGx5IElOSVRJQUwgLT4gRU5SSUNITUVOVCAtPiBTQVZFRCAtPiBBUkNISVZFRC4NCg0KIyMjIElOSVRJQUwNCiMjIyBFTlJJQ0hNRU5UDQojIyMgU0FWRUQNCiMjIyBBUkNISVZFRA0KDQojIyBEb2N1bWVudCBzdGF0dXMNCg0KVGhpcyBzZWN0aW9uIGRlc2NyaWJlZCB0aGUgZGlmZmVyZW50IGRvY3VtZW50IHN0YXR1cy4gQSBkb2N1bWVudCBzdGF0dXMgaXMgb25lIG9mIFtPUEVOLCBJTi1QUk9HUkVTUywgUkVWSUVXLCBSRVNPTFZFLCBDTE9TRV0uDQoNCiMjIyBPUEVODQojIyMgSU4tUFJPR1JFU1MNCiMjIyBSRVZJRVcNCiMjIyBSRVNPTFZFDQojIyMgQ0xPU0UNCg==";
            Byte[] bytes = File.ReadAllBytes(Path.Combine(TestContext.CurrentContext.TestDirectory, @"README.md"));

            IConverter converter = new Base64Converter(base64String);
            converter.Decode();

            Assert.AreEqual(bytes, ((Base64Converter)converter).bytes);
        }
    }
}