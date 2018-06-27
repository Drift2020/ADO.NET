﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace system.View_model
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

        private DelegateCommand _Command_search;

        public ICommand GetButton_search()
        {
            if (_Command_search == null)
            {
                _Command_search = new DelegateCommand(Execute_search, CanExecute_search);
            }
            return _Command_search;
        }
        private void Execute_search(object o)
        {
          

        }
        private bool CanExecute_search(object o)
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
    }
}
