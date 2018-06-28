using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using PathGDE.Code;

namespace PathGDE.View_model
{   
    class View_Model_Index: View_Model_Base
    {
        #region Code

        public View_Model_Index()
        {
            list_disc = Directory.GetLogicalDrives();
        }

        public static void ThreadParam(object obj)
        {
           // View_Model_Index delay = (View_Model_Index)obj;
            FileSearchThread.SearchFile(((View_Model_Index)obj).list_file, ((View_Model_Index)obj).select_item_disc, 
                ((View_Model_Index)obj).name_file, ((View_Model_Index)obj).str_in_file, ((View_Model_Index)obj).Chec_box);
            ((View_Model_Index)obj).End();

            ((View_Model_Index)obj).OnPropertyChanged(nameof(List_file));
        }
        #endregion Code

        #region Pole

        #region Name file

        string name_file;
        public string Name_file
        {
            set
            {
                name_file = value;
                OnPropertyChanged(nameof(name_file));
            }
            get
            {
                return name_file;
            }
        }


        #endregion Name file

        #region str_in_file

        string str_in_file;
        public string Str_in_file
        {
            set
            {
                str_in_file = value;
                OnPropertyChanged(nameof(Str_in_file));
            }
            get
            {
                return str_in_file;
            }
        }


        #endregion str_in_file

        #region chec box

        bool chec_box;
        public bool Chec_box
        {
            set
            {
                chec_box = value;
                OnPropertyChanged(nameof(chec_box));
            }
            get
            {
                return chec_box;
            }
        }

        #endregion chec box

        #endregion Pole

        #region action

       public Action End { get; set; }

        #endregion action



        #region command

        #region search



        private DelegateCommand _Command_search;
        public ICommand Button_clik_search
        {
            get
            {
                if (_Command_search == null)
                {
                    _Command_search = new DelegateCommand(Execute_search, CanExecute_search);
                }
                return _Command_search;
            }
        }
        private void Execute_search(object o)
        {
            list_file.Clear();

            Thread th1 = new Thread(new ParameterizedThreadStart(ThreadParam));
            th1.IsBackground = true;
            th1.Name = "второй";
            th1.Start(this);
            


        }
        private bool CanExecute_search(object o)
        {
            return true;
        }


        #endregion search

        #region stop

        private DelegateCommand _Command_stop;

        public ICommand Button_clik_stop
        {
            get
            {
                if (_Command_stop == null)
                {
                    _Command_stop = new DelegateCommand(Execute_stop, CanExecute_stop);
                }
                return _Command_stop;
            }
        }
        private void Execute_stop(object o)
        {


        }
        private bool CanExecute_stop(object o)
        {

            return true;

        }



        #endregion stop

        #endregion command


        #region list

        #region list file
        ObservableCollection<FileInfo> list_file=new ObservableCollection<FileInfo>();
        public ObservableCollection<FileInfo> List_file
        {
            set
            {
                list_file = value;
                OnPropertyChanged(nameof(List_file));
            }
            get
            {
                return list_file;
            }
        }
        #endregion list file

        #region list disc
        string [] list_disc;
        public List<string> List_disc
        {
            set
            {
              
                OnPropertyChanged(nameof(List_disc));
            }
            get
            {
                return list_disc.ToList();
            }
        }
        public string select_item_disc=null;
        public string Select_item_disc
        {
            set
            {
                select_item_disc = value;
                OnPropertyChanged(nameof(Select_item_disc));
            }
            get
            {
                return select_item_disc;
            }
        }
        #endregion list disc



        #endregion list
    }
}
