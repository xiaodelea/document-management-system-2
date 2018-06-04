using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYang.DocumentManagementSystem.Core
{
    class Document
    {
        public Guid Guid { get; private set; }
        public FileInfo FileInfo { get; private set; }
        public HashSet<string> Tags { get; set; }
        public DocumentStage DocumentStage { get; private set; }
        public DocumentStatus DocumentStatus { get; private set; }

        public Document(FileInfo file)
        {
            Guid = System.Guid.NewGuid();
            FileInfo = file;
            DocumentStage = DocumentStage.Initial;
            DocumentStatus = DocumentStatus.Open;
        }
    }
}
