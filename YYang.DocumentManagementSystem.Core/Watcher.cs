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
            var watcher = new FileSystemWatcher(rootPath);
            watcher.Filter = "*.*";
            watcher.EnableRaisingEvents = true;
            watcher.Created += OnChanged;

            FileSystemWatchers.Add(watcher);
        }

        private void OnChanged(object sender, FileSystemEventArgs eventArgs)
        {
            var ext = (Path.GetExtension(eventArgs.FullPath) ?? string.Empty).ToLower();

            if (_extensions.Any(ext.Equals))
            {
                // TODO: found valid file. Do something with it.
            }
        }
    }
}