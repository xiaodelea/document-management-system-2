using System;
using System.IO;
using YYang.DocumentManagementSystem.NAPS2Wrapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YYang.DocumentManagementSystem.NAPS2Wrapper.UnitTests
{
    [TestClass]
    public class WrapperTests
    {
        [TestMethod]
        public void InstallPathNotEmptyString()
        {
            Assert.IsNotNull(Wrapper.GetInstallationPath());
        }

        [TestMethod]
        public void NAPS2FullPathIsValid()
        {
            try
            {
                // Will fail implicitly if exception is thrown but this is clearer
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                Path.GetFullPath(Wrapper.GetNAPS2FullPath());
            }
            catch (Exception e)
            {
                Assert.Fail("Expected no exception, but got: " + e.Message);
            }
        }

        [TestMethod]
        public void ScanSuccessful()
        {
            Assert.IsTrue(Wrapper.Scan() == 0);
        }
    }
}