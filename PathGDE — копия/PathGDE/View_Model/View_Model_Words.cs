using PathGDE.View_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PathGDE
{
    class View_Model_Words: View_Model_Base
    {
        public View_Model_Words()
        {

        }

        #region Pole
        string word;
        public string Word { get { return word; } set { word = value; } }
        #endregion Pole

        #region Command
        #region Add


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

        }
        private bool CanExecute_add(object o)
        {

            return true;

        }
        #endregion Add

        #region Del


        private DelegateCommand _Command_del;

        public ICommand Button_clik_del
        {

            get
            {
                if (_Command_del == null)
                {
                    _Command_del = new DelegateCommand(Execute_del, CanExecute_del);
                }
                return _Command_del;
            }
        }
        private void Execute_del(object o)
        {

        }
        private bool CanExecute_del(object o)
        {

            return true;

        }
        #endregion Dell

        #region Clear


        private DelegateCommand _Command_clear;

        public ICommand Button_clik_clear
        {

            get
            {
                if (_Command_clear == null)
                {
                    _Command_clear = new DelegateCommand(Execute_clear, CanExecute_clear);
                }
                return _Command_clear;
            }
        }
        private void Execute_clear(object o)
        {

        }
        private bool CanExecute_clear(object o)
        {

            return true;

        }
        #endregion Clear



        #endregion Command

        #region List

        #endregion List

    }
}
