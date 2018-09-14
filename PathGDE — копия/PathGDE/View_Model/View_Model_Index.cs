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
    public delegate void MyThreadDelegate(string name, string path, string str, bool recur);
    class View_Model_Index : View_Model_Base
    {
        #region Code

        public View_Model_Index()
        {
            list_disc = Directory.GetLogicalDrives();
            _dispatcher = Dispatcher.CurrentDispatcher;

            
            


            ser = new FileSearchThread();
            //ser.Print_list_deligete += (new FileSearchThread.ConsolDelegate(Sets));
           
        }
      
      

        #region task

        public void SearchFile2(CancellationToken cancellationToken,string name, string path, List<string> str)
        {
            cancellationToken.ThrowIfCancellationRequested();
            string[] path_file = null;
            if (list_file != null)

             

            

                    try
                    {
                        string[] path_Directories = Directory.GetDirectories(name);


                        foreach (var y in path_Directories)
                        {
                            cancellationToken.ThrowIfCancellationRequested();
                            if (path_Directories != null)
                                SearchFile2(cancellationToken, y, path, str);

                            path_file = Directory.GetFiles(y, path);


                            foreach (var i in path_file)
                            {
                                cancellationToken.ThrowIfCancellationRequested();
                                DispatchService.Invoke(() =>
                                {
                                    if (str != null)
                                    {
                                        if (i.Contains(".txt"))
                                        {
                                            using (StreamReader objReader = new StreamReader(i))
                                            {
                                                string sLine = "";
                                                while (sLine != null)
                                                {
                                                    cancellationToken.ThrowIfCancellationRequested();
                                                    sLine = objReader.ReadLine();
                                                    //if (sLine != null && sLine.Contains(str))
                                                    //{
                                                    //    this.list_file.Add(new FileInfo(i));
                                                    //    this.OnPropertyChanged(nameof(List_file));
                                                    //    break;
                                                    //}

                                                }
                                            }

                                        }
                                    }
                                    else
                                    {
                                        cancellationToken.ThrowIfCancellationRequested();
                                        this.list_file.Add(new FileInfo(i));
                                        this.OnPropertyChanged(nameof(List_file));
                                    }
                                });

                            }

                        }
                    }
                    catch (Exception s)
                    {
                        MessageBox.Show(s.Message);
                    }
                

        }

        #endregion task

      

        #endregion Code




        #region Pole

        #region Name file

        string path;
        public string Path
        {
            set
            {
                path = value;
                OnPropertyChanged(nameof(Path));
            }
            get
            {
                return path;
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

  
        CancellationTokenSource cts;
        FileSearchThread ser ;
        Thread th1;
        readonly Dispatcher _dispatcher;
        #endregion Pole

        #region action

        public Action End { get; set; }
        public Action Stop { get; set; }
        #endregion action


        #region command

        #region search

        Task tsk2;
    



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
            cts = new CancellationTokenSource();
          

            #region task


        //    var task = Task.Run(() => SearchFile2(cts.Token, select_item_disc, "*.txt", str_in_file), cts.Token);


            #endregion task

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

            #region Thread
            //try
            //{
            //    if (th1.IsAlive)
            //    {

            //        th1.Abort();
            //       // Stop();
            //    }
            //}
            //catch(Exception e)
            //{
            //    MessageBox.Show(e.Message);
            //}
            #endregion Thread

            #region ansi
            //if (d1 != null && ar1 != null && !ar1.IsCompleted)
            //{
            //    d1.EndInvoke(ar1);

            //}
            #endregion ansi


            #region task
            cts.Cancel();
            #endregion task 
        }
        private bool CanExecute_stop(object o)
        {

            return true;

        }



        #endregion stop

        #region OpenFolder

        
 private DelegateCommand _Command_open_folder;

        public ICommand Button_open_folder
        {
            get
            {
                if (_Command_open_folder == null)
                {
                    _Command_open_folder = new DelegateCommand(Execute_open_folder, CanExecute_open_folder);
                }
                return _Command_open_folder;
            }
        }
        private void Execute_open_folder(object o)
        {

        }
        private bool CanExecute_open_folder(object o)
        {

            return true;

        }
        #endregion

        #region Pause


        private DelegateCommand _Command_pause;

        public ICommand Button_clik_pause
        {
            get
            {
                if (_Command_pause == null)
                {
                    _Command_pause = new DelegateCommand(Execute_pause, CanExecute_pause);
                }
                return _Command_pause;
            }
        }
        private void Execute_pause(object o)
        {

        }
        private bool CanExecute_pause(object o)
        {

            return true;

        }
        #endregion

        #region resume


        private DelegateCommand _Command_resume;

        public ICommand Button_clik_resume
        {
            
            get
            {
                if (_Command_resume == null)
                {
                    _Command_resume = new DelegateCommand(Execute_resume, CanExecute_resume);
                }
                return _Command_resume;
            }
        }
        private void Execute_resume(object o)
        {

        }
        private bool CanExecute_resume(object o)
        {

            return true;

        }
        #endregion

        #region edit


        private DelegateCommand _Command_edit;

        public ICommand Button_clik_edit
        {

            get
            {
                if (_Command_edit == null)
                {
                    _Command_edit = new DelegateCommand(Execute_edit, CanExecute_edit);
                }
                return _Command_edit;
            }
        }
        private void Execute_edit(object o)
        {

        }
        private bool CanExecute_edit(object o)
        {

            return true;

        }
        #endregion


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

    }
}
