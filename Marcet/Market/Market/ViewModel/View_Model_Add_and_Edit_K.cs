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
        public ICommand Button_edit_category
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


            if (Name_edit.Length > 0)
                return true;
            else
                return false;


        }
        #endregion Edit button

        #region Add button
        private DelegateCommand _Command_add_category;
        public ICommand Button_add_category
        {
            get
            {
                if (_Command_add_category == null)
                {
                    _Command_add_category = new DelegateCommand(Execute_add_category, CanExecute_add_category);
                }
                return _Command_add_category;
            }
        }
        private void Execute_add_category(object o)
        {
            Product_category temp = new Product_category();
            temp.Сategory = name;
            Name = "";

            myBD.Product_category.Add(temp);
            myBD.SaveChanges();


        }
        private bool CanExecute_add_category(object o)
        {


            if (Name.Length > 0)
                return true;
            else
                return false;


        }
        #endregion Add button


        #region Delete button
        private DelegateCommand _Command_delete_category;
        public ICommand Button_delete_category
        {
            get
            {
                if (_Command_delete_category == null)
                {
                    _Command_delete_category = new DelegateCommand(Execute_delete_category, CanExecute_delete_category);
                }
                return _Command_delete_category;
            }
        }
        private void Execute_delete_category(object o)
        {
            //_myDB.Products.Add().Product_category
            //  _myDB.SaveChanges();


        }
        private bool CanExecute_delete_category(object o)
        {


            if (Name.Length > 0)
                return true;
            else
                return false;


        }
        #endregion Delete button

        #region Cancel button
        private DelegateCommand _Command_cancel_category;
        public ICommand Button_cancel_category
        {
            get
            {
                if (_Command_cancel_category == null)
                {
                    _Command_cancel_category = new DelegateCommand(Execute_cancel_category, CanExecute_cancel_category);
                }
                return _Command_cancel_category;
            }
        }
        private void Execute_cancel_category(object o)
        {
            //_myDB.Products.Add().Product_category
            //  _myDB.SaveChanges();


        }
        private bool CanExecute_cancel_category(object o)
        {


          
                return true;
           


        }
        #endregion Cancel button
    }
}
