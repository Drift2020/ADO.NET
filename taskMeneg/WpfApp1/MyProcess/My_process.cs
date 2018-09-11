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

        public My_Process(string _fileName,int _id )
        {
            id = _id;
            fileName = _fileName;
        }
        public My_Process()
        {
          //  workingDirectory = null;
            fileName = null;
        }

        int id;
        public int ID { get { return id; } set { id = value; } }
        string fileName;
        public string FileName { get { return fileName; } set { fileName = value; } }

       
      
    }
}
