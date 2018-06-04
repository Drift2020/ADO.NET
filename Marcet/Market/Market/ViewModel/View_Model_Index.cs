using Market.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Market.ViewModel
{
    class View_Model_Index : View_Model_Base
    {

        #region Command_button


        #region
        private DelegateCommand _Command_Add_K;
        public ICommand Button_Add_K
        {
            get
            {
                if (_Command_Add_K == null)
                {
                    _Command_Add_K = new DelegateCommand(Execute_Add_K, CanExecute_Add_K);
                }
                return _Command_Add_K;
            }
        }
        private void Execute_Add_K(object o)
        {

            int n = 2;

        }
        private bool CanExecute_Add_K(object o)
        {

         
                    return true;
           

            return false;


        }
        #endregion

        #region
        private DelegateCommand _Command_Del_K;
        public ICommand Button_Del_K
        {
            get
            {
                if (_Command_Del_K == null)
                {
                    _Command_Del_K = new DelegateCommand(Execute_Del_K, CanExecute_Del_K);
                }
                return _Command_Del_K;
            }
        }
        private void Execute_Del_K(object o)
        {

            int n = 2;

        }
        private bool CanExecute_Del_K(object o)
        {


            return true;


            return false;


        }
        #endregion

        #region
        private DelegateCommand _Command_Edit_K;
        public ICommand Button_Edit_K
        {
            get
            {
                if (_Command_Edit_K == null)
                {
                    _Command_Edit_K = new DelegateCommand(Execute_Edit_K, CanExecute_Edit_K);
                }
                return _Command_Edit_K;
            }
        }
        private void Execute_Edit_K(object o)
        {

            int n = 2;

        }
        private bool CanExecute_Edit_K(object o)
        {


            return true;


            return false;


        }
        #endregion

        #region
        private DelegateCommand _Command_Add_P;
        public ICommand Button_Add_P
        {
            get
            {
                if (_Command_Add_P == null)
                {
                    _Command_Add_P = new DelegateCommand(Execute_Add_P, CanExecute_Add_P);
                }
                return _Command_Add_P;
            }
        }
        private void Execute_Add_P(object o)
        {

            int n = 2;

        }
        private bool CanExecute_Add_P(object o)
        {


            return true;


            return false;


        }
        #endregion

        #region
        private DelegateCommand _Command_Del_P;
        public ICommand Button_Del_P
        {
            get
            {
                if (_Command_Del_P == null)
                {
                    _Command_Del_P = new DelegateCommand(Execute_Del_P, CanExecute_Del_P);
                }
                return _Command_Del_P;
            }
        }
        private void Execute_Del_P(object o)
        {

            int n = 2;

        }
        private bool CanExecute_Del_P(object o)
        {


            return true;


            return false;


        }
        #endregion

        #region
        private DelegateCommand _Command_Edit_P;
        public ICommand Button_Edit_P
        {
            get
            {
                if (_Command_Edit_P == null)
                {
                    _Command_Edit_P = new DelegateCommand(Execute_Edit_P, CanExecute_Edit_P);
                }
                return _Command_Edit_P;
            }
        }
        private void Execute_Edit_P(object o)
        {

            int n = 2;

        }
        private bool CanExecute_Edit_P(object o)
        {


            return true;


            return false;


        }
        #endregion


        #region
        private DelegateCommand _Command_Add_F;
        public ICommand Button_Add_F
        {
            get
            {
                if (_Command_Add_F == null)
                {
                    _Command_Add_F = new DelegateCommand(Execute_Add_F, CanExecute_Add_F);
                }
                return _Command_Add_F;
            }
        }
        private void Execute_Add_F(object o)
        {

            int n = 2;

        }
        private bool CanExecute_Add_F(object o)
        {


            return true;


            return false;


        }
        #endregion

        #region
        private DelegateCommand _Command_Del_F;
        public ICommand Button_Del_F
        {
            get
            {
                if (_Command_Del_F == null)
                {
                    _Command_Del_F = new DelegateCommand(Execute_Del_F, CanExecute_Del_F);
                }
                return _Command_Del_F;
            }
        }
        private void Execute_Del_F(object o)
        {

            int n = 2;

        }
        private bool CanExecute_Del_F(object o)
        {


            return true;


            return false;


        }
        #endregion

        #region
        private DelegateCommand _Command_Edit_F;
        public ICommand Button_Edit_F
        {
            get
            {
                if (_Command_Edit_F == null)
                {
                    _Command_Edit_F = new DelegateCommand(Execute_Edit_F, CanExecute_Edit_F);
                }
                return _Command_Edit_F;
            }
        }
        private void Execute_Edit_F(object o)
        {

            int n = 2;

        }
        private bool CanExecute_Edit_F(object o)
        {


            return true;


            return false;


        }
        #endregion
        #endregion Command_button
    }
}
