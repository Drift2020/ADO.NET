using Market.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Market.ViewModel
{
    class View_Model_Add_and_Edit_K : View_Model_Base
    {
        Model1 myBD;

        public View_Model_Add_and_Edit_K()
        {
            myBD = new Model1();
            list_category = myBD.Product_category.ToList();

        }

        List<Product_category> list_category;


        #region Pole

        string name="";
        public string Name
        {
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
            get
            {
                return name;
            }
        }

        string name_edit = "";
        public string Name_edit
        {
            set
            {
                name_edit = value;
                OnPropertyChanged(nameof(Name_edit));
            }
            get
            {
                return name_edit;
            }
        }
        #endregion Pole


        #region Edit button
        private DelegateCommand _Command_Edit_category;
        public ICommand Button_Edit_category
        {
            get
            {
                if (_Command_Edit_category == null)
                {
                    _Command_Edit_category = new DelegateCommand(Execute_Edit_category, CanExecute_Edit_category);
                }
                return _Command_Edit_category;
            }
        }
        private void Execute_Edit_category(object o)
        {
            //_myDB.Products.Add().Product_category
            //  _myDB.SaveChanges();


        }
        private bool CanExecute_Edit_category(object o)
        {


            if (Name.Length > 0)
                return true;
            else
                return false;


        }
        #endregion Edit button
    }
}
