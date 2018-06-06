using Market.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Market.ViewModel
{
    public class View_Model_Index : View_Model_Base
    {

        public Model1 _myDB;
        

        public View_Model_Index()
        {
            _myDB = new Model1();
            
        }

        #region Command_button




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
        private DelegateCommand _Command_Editor_K;
        public ICommand Button_Editor_K
        {
            get
            {
                if (_Command_Editor_K == null)
                {
                    _Command_Editor_K = new DelegateCommand(Execute_Editor_K, CanExecute_Editor_K);
                }
                return _Command_Editor_K;
            }
        }
        private void Execute_Editor_K(object o)
        {

            View_Model_Add_and_Edit_K view_Model = new View_Model_Add_and_Edit_K();
            Add_K view = new Add_K();
            view.DataContext = view_Model;
            view.ShowDialog();
        }
        private bool CanExecute_Editor_K(object o)
        {

            return true;
       

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
        private DelegateCommand _Command_Editor_P;
        public ICommand Button_Editor_P
        {
            get
            {
                if (_Command_Editor_P == null)
                {
                    _Command_Editor_P = new DelegateCommand(Execute_Editor_P, CanExecute_Editor_P);
                }
                return _Command_Editor_P;
            }
        }
        private void Execute_Editor_P(object o)
        {
            View_Model_Add_and_Edit_T view_Model = new View_Model_Add_and_Edit_T();
            Add_T view = new Add_T();
            view.DataContext = view_Model;
            view.ShowDialog();

        }
        private bool CanExecute_Editor_P(object o)
        {


            return true;

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
        private DelegateCommand _Command_Editor_F;
        public ICommand Button_Editor_F
        {
            get
            {
                if (_Command_Editor_F == null)
                {
                    _Command_Editor_F = new DelegateCommand(Execute_Editor_F, CanExecute_Editor_F);
                }
                return _Command_Editor_F;
            }
        }
        private void Execute_Editor_F(object o)
        {

            View_Model_Add_and_Edit_Firm view_Model = new View_Model_Add_and_Edit_Firm();
            Add_and_Edit_Firm view = new Add_and_Edit_Firm();
            view.DataContext = view_Model;
            view.ShowDialog();

        }
        private bool CanExecute_Editor_F(object o)
        {

            return true;

        }
        #endregion
        #endregion Command_button


        #region

       

        public ICollection<Product> product
        {
            
            get => _myDB.Products.ToList();
        }
        public ICollection<Date_of_receipt> data_of_receipt
        {

            get => _myDB.Date_of_receipt.ToList();
        }
        
        public ICollection<FIO_Person> fio_Person
        {

            get => _myDB.FIO_Person.ToList();
        }
        public ICollection<Product_category> product_category
        {

            get => _myDB.Product_category.ToList();
        }
        public ICollection<Product_life> product_life
        {

            get => _myDB.Product_life.ToList();
        }
        public ICollection<Count> count
        {

            get => _myDB.Counts.ToList();
        }
        public ICollection<Mark_up> mark_up
        {

            get => _myDB.Mark_up.ToList();
        }


        #endregion
    }
}
