using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
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



        #region command

        #region search

        private DelegateCommand _Command_add;
        public ICommand Button_clik_add
        {
            get
            {
                if (_Command_add == null)
                {
                    _Command_add = new DelegateCommand(Execute_add, CanExecute_add);
                }
                return _Command_add;
            }
        }
        private void Execute_add(object o)
        {

            Add_Article my_add = new Add_Article();

            View_Model_Add_Article my_model_add = new View_Model_Add_Article(my_profile);
            my_model_add.Button_ok = "Add";

            if (my_model_add.Add == null)
                my_model_add.Add = new Action(my_add.Close);

            my_add.DataContext = my_model_add;



            my_add.ShowDialog();
            Set_new_items();

        }
        private bool CanExecute_add(object o)
        {
            return true;
        }


        #endregion search

        #region stop

        private DelegateCommand _Command_stop;

        public ICommand GetButton_stop()
        {
            if (_Command_stop == null)
            {
                _Command_stop = new DelegateCommand(Execute_stop, CanExecute_stop);
            }
            return _Command_stop;
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

        ObservableCollection<FileInfo> list_file;
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

      

        #endregion list
    }
}
