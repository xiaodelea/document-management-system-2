using System;
using System.IO;
using System.Linq;
using System.Threading;
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

            string[] filePaths = Directory.GetFiles(Constants.RootPath);
            foreach (string filePath in filePaths)
            {
                try
                {
                    File.Delete(filePath);
                }
                catch (Exception)
                {
                    // empty
                }
            }
                
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

        [TestMethod]
        public void RecognizesFile()
        {
            string[] validFileExtensions = {"jpeg", "jpg", "pdf", "png"};

            var watcher = new Watcher(Constants.RootPath);

            foreach (var fileExtension in validFileExtensions)
            {
                using (var writer = new StreamWriter(string.Format(@"{0}\{1}{2}", Constants.RootPath, fileExtension, "." + fileExtension)))
                {
                    Console.WriteLine("Write " + fileExtension);
                    writer.WriteLine(fileExtension.ToUpper());
                }

                Thread.Sleep(20); // give the file system time to create the file

                var lastLine = File.ReadLines(Constants.RootPath + @"\log.txt").Last();

                Console.WriteLine("Assert");
                Assert.AreEqual(fileExtension + "." + fileExtension, lastLine);
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            Initialize();
        }
    }
}
