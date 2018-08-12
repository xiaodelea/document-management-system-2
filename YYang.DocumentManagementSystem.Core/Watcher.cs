using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace YYang.DocumentManagementSystem.Core
{
    public class Watcher
    {
        public static List<FileSystemWatcher> FileSystemWatchers { get; private set; } = new List<FileSystemWatcher>();
        private readonly string[] _extensions = {".jpg", ".jpeg", ".png", ".pdf"};

        public Watcher(string rootPath)
        {
            var watcher = new FileSystemWatcher(rootPath)
            {
                Filter = "*.*",
                EnableRaisingEvents = true
            };
            watcher.Created += OnCreated;

            FileSystemWatchers.Add(watcher);
        }

        private void OnCreated(object sender, FileSystemEventArgs eventArgs)
        {
            var ext = (Path.GetExtension(eventArgs.FullPath) ?? string.Empty).ToLower();

            if (_extensions.Any(ext.Equals))
            {
                FileProcessor.Process(new FileInfo(eventArgs.FullPath));
            }
        }
    }
}