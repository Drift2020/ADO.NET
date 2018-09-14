using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathGDE.Model
{
//    Также нужно создать файл отчета.Он должен содержать
//информацию обо всех найденных файлах с запрещенными словами, пути
//к этим файлам, размер файлов, информацию о количестве замен и так
//далее.В файле отчета нужно также отобразить топ-10 самых популярных
//запрещенных слов.
    class Reports
    {
        string name;
        public string Name
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }

        string path;
        public string Path
        {
            set
            {
                path = value;
            }
            get
            {
                return path;
            }
        }

        int size;
        public int Size
        {
            set
            {
                size = value;
            }
            get
            {
                return size;
            }
        }

        List<string> words;
      public List<string> Words {
            get
            {
                return words;
            }
            set
            {
                words = value;
            }
        }

    }
}
