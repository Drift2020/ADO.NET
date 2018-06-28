using PathGDE.View_model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathGDE.Code
{
   public class FileSearchThread : View_Model_Base
    {
        static ObservableCollection<FileInfo> SearchFile(string name,string path)
        {


             string[] path_file =  Directory.GetFiles(path, name);


            return new ObservableCollection<FileInfo>();
        }
    }
}
