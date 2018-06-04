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
        #endregion Command_button
    }
}
