using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyProcess
{
    [Serializable]
    public class My_Process
    {

        public My_Process(Process _my)
        {
            workingDirectory = _my.StartInfo.WorkingDirectory;
            fileName = _my.StartInfo.FileName;
        }
        public My_Process()
        {
            workingDirectory = null;
            fileName = null;
        }

        string workingDirectory;
        public string WorkingDirectory { get { return workingDirectory; } set { workingDirectory = value; } }

        string fileName;
        public string FileName { get { return fileName; } set { fileName = value; } }

       
      
    }
}
