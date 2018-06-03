using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YYang.DocumentManagementSystem.Core;

namespace YYang.DocumentManagementSystem.Core.UnitTest
{
    [TestClass]
    public class WatcherTests
    {
        [TestInitialize]
        public void Initialize()
        {
            Watcher.FileSystemWatchers.Clear();
        }

        [TestMethod]
        public void WatcherObjectAdded()
        {
            var watcher = new Watcher(Constants.RootPath);

            Assert.AreEqual(1, Watcher.FileSystemWatchers.Count);
        }

        [TestMethod]
        public void MultipleWatcherObjectsAdded()
        {
            var watcher_1 = new Watcher(Constants.RootPath);
            var watcher_2 = new Watcher(Constants.RootPath);
            var watcher_3 = new Watcher(Constants.RootPath);

            Assert.AreEqual(3, Watcher.FileSystemWatchers.Count);
            Assert.AreNotSame(Watcher.FileSystemWatchers[0], Watcher.FileSystemWatchers[1]);
            Assert.AreNotSame(Watcher.FileSystemWatchers[0], Watcher.FileSystemWatchers[2]);
            Assert.AreNotSame(Watcher.FileSystemWatchers[1], Watcher.FileSystemWatchers[2]);
        }

        [TestCleanup]
        public void Cleanup()
        {
            Watcher.FileSystemWatchers.Clear();
        }
    }
}
