using PathGDE.View_model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PathGDE.Code
{
   public class FileSearchThread : View_Model_Base
    {
        public void SearchFile(ObservableCollection<FileInfo> list_file,string name,string path,string str,bool recur)
        {
            if(list_file!=null)
           
            if(!recur)
            try
            {
                string[] path_file = Directory.GetFiles(name, path);
             

                
                foreach (var i in path_file)
                    list_file.Add(new FileInfo(i));

            }catch(Exception s)
            {
                        MessageBox.Show(s.Message);
                    }
            else
            {

                    try
                    {
                        string[] path_Directories = Directory.GetDirectories(name);


                    foreach(var y in path_Directories)
                    {
                        if(path_Directories!=null)
                        SearchFile(list_file, y, path, str, recur);
                        
                            string[] path_file = Directory.GetFiles(y, path);


                            foreach (var i in path_file)
                            list_file.Add(new FileInfo(i));
                       
                    }
                    }
                    catch (Exception s)
                    {
                        MessageBox.Show(s.Message);
                    }
                }
          
        }

        //public delegate void ConsolDelegate(object obj_snake);
        //List<ConsolDelegate> print_list = new List<ConsolDelegate>();
        //public event ConsolDelegate Print_list_deligete
        //{
        //    // Используем аксессоры событий
        //    add
        //    {
        //        print_list.Add(value);
        //    }

        //    remove
        //    {
        //        print_list.Remove(value);
        //    }
        //}

        //public void Print_list()
        //{
        //    if (print_list.Count != 0)
        //        foreach (ConsolDelegate i in print_list)
        //        {
        //            i(this);
        //        }
        //}
    }
}
