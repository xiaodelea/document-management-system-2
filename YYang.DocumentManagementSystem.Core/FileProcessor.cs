using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = System.Console;

namespace YYang.DocumentManagementSystem.Core
{
    static class FileProcessor
    {
        public static void Process(FileInfo file)
        {
            using (var writer = new StreamWriter(string.Format(@"{0}\log.txt", Constants.RootPath)))
            {
                writer.WriteLine(file.Name);
                
            }
        }
    }
}
