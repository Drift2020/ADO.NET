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
using System.Windows;
using System.Windows.Threading;

namespace PathGDE.View_model
{
    class View_Model_Index : View_Model_Base
    {
        #region Code

        public View_Model_Index()
        {
            list_disc = Directory.GetLogicalDrives();
            _dispatcher = Dispatcher.CurrentDispatcher;

          
        }

        public static void ThreadParam(object obj)
        {
            View_Model_Index temp = ((View_Model_Index)obj);
          
            SearchFile(temp.list_file2, temp.select_item_disc,
                temp.name_file, temp.str_in_file, temp.Chec_box, temp);
            temp.End();

            //   ((View_Model_Index)obj).sets(((View_Model_Index)obj).list_file2);

            temp.OnPropertyChanged(nameof(List_file));
        }

        private static void Sets(object obj)
        {
            View_Model_Index temp = ((View_Model_Index)obj);
            temp.list_file = temp.list_file2;
            temp.OnPropertyChanged(nameof(List_file));
        }


        public static void SearchFile(ObservableCollection<FileInfo> list_file, string name, string path, string str, bool recur, View_Model_Index t)
        {
            string[] path_file=null;
            if (list_file != null)

                if (!recur)
                {
                    try
                    {
                        path_file = Directory.GetFiles(name, path);


                    }
                    catch (Exception s)
                    {

                    }
                    foreach (var i in path_file)
                    {
                        list_file.Add(new FileInfo(i));
                       
                    }
                }

                else
                {

                    try
                    {
                        string[] path_Directories = Directory.GetDirectories(name);


                        foreach (var y in path_Directories)
                        {
                            if (path_Directories != null)
                                SearchFile(list_file, y, path, str, recur, t);

                                 path_file = Directory.GetFiles(y, path);


                            foreach (var i in path_file)
                            {
                                list_file.Add(new FileInfo(i));
                              
                            }

                        }
                    }
                    catch (Exception s)
                    {
                        MessageBox.Show(s.Message);
                    }
                }

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
        Thread th1;
        readonly Dispatcher _dispatcher;
        #endregion Pole

        #region action

        public Action End { get; set; }
        public Action Stop { get; set; }
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

            if (th1 == null || !th1.IsAlive)
                th1 = new Thread(new ParameterizedThreadStart(ThreadParam));
            else
            {
                th1.Abort();
                th1 = new Thread(new ParameterizedThreadStart(ThreadParam));
            }

         
        
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
            if (th1.IsAlive)
            {
                th1.Abort();
                Stop();
            }
          


        }
        private bool CanExecute_stop(object o)
        {

            return true;

        }



        #endregion stop

        #endregion command


        #region list

        #region list file
        ObservableCollection<FileInfo> list_file2 = new ObservableCollection<FileInfo>();


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
               // return new ObservableCollection<FileInfo>();
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








        public delegate void UpdateTextCallback(string message);

        private void TestThread()
        {
            for (int i = 0; i <= 1000000000; i++)
            {
                Thread.Sleep(1000);
                richTextBox1.Dispatcher.Invoke(
                    new UpdateTextCallback(this.UpdateText),
                    new object[] { i.ToString() }
                );
            }
        }
        private void UpdateText(string message)
        {
            richTextBox1.AppendText(message + "\n");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Thread test = new Thread(new ThreadStart(TestThread));
            test.Start();
        }

    }
}
