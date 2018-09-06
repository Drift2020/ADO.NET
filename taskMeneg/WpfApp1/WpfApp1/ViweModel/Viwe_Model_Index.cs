using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1.ViweModel
{
    class Viwe_Model_Index: View_Model_Base
    {


        #region Text

        string connect;
        public string Connect
        {
            get{ return connect;  }
            set { connect = value; }
        }
        #endregion Text



        #region Button Connect

        private DelegateCommand _Command_button_Connect;
        public ICommand Button_connect
        {
            get
            {
                if (_Command_button_Connect == null)
                {
                    _Command_button_Connect = new DelegateCommand(Execute_button_Connect, CanExecute_button_Connect);
                }
                return _Command_button_Connect;
            }
        }
        private void Execute_button_Connect(object o)
        {
           
        }
        private bool CanExecute_button_Connect(object o)
        {
            
            return true;
        }

        #endregion Button Connect

        #region Button disconnect

        private DelegateCommand _Command_button_disconnect;
        public ICommand Button_disconnect
        {
            get
            {
                if (_Command_button_disconnect == null)
                {
                    _Command_button_disconnect = new DelegateCommand(Execute_button_disconnect, CanExecute_button_disconnect);
                }
                return _Command_button_disconnect;
            }
        }
        private void Execute_button_disconnect(object o)
        {

        }
        private bool CanExecute_button_disconnect(object o)
        {
            return true;
        }

        #endregion Button disconnect

        #region Button update

        private DelegateCommand _Command_button_update;
        public ICommand Button_update
        {
            get
            {
                if (_Command_button_update == null)
                {
                    _Command_button_update = new DelegateCommand(Execute_button_update, CanExecute_button_update);
                }
                return _Command_button_update;
            }
        }
        private void Execute_button_update(object o)
        {

        }
        private bool CanExecute_button_update(object o)
        {
            return true;
        }

        #endregion Button update

        #region Button create_task

        private DelegateCommand _Command_button_create_task;
        public ICommand Button_create_task
        {
            get
            {
                if (_Command_button_create_task == null)
                {
                    _Command_button_create_task = new DelegateCommand(Execute_button_create_task, CanExecute_button_create_task);
                }
                return _Command_button_create_task;
            }
        }
        private void Execute_button_create_task(object o)
        {

        }
        private bool CanExecute_button_create_task(object o)
        {
            return true;
        }

        #endregion Button create_task

        #region Button close_task

        private DelegateCommand _Command_button_close_task;
        public ICommand Button_close_task
        {
            get
            {
                if (_Command_button_close_task == null)
                {
                    _Command_button_close_task = new DelegateCommand(Execute_button_close_task, CanExecute_button_close_task);
                }
                return _Command_button_close_task;
            }
        }
        private void Execute_button_close_task(object o)
        {

        }
        private bool CanExecute_button_close_task(object o)
        {
            return true;
        }

        #endregion Button create_task

    }
}
