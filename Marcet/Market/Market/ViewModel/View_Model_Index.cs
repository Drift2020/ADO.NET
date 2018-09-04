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
        List<View_Index_List> List_product;
        List<View_Firm_List> new_list_firm;

        public View_Model_Index()
        {
            _myDB = new Model1();

            List_product = new List<View_Index_List>();
            foreach (var i in _myDB.Products)
                List_product.Add(new View_Index_List(i));


            new_list_firm = new List<View_Firm_List>();
            //foreach (var i in _myDB.Firms)
            //    if (select_Item_Index != null && select_Item_Index._product.Firm.ID == i.ID)
            //        new_list_firm.Add(new View_Firm_List(i));

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


            List_product = new List<View_Index_List>();
            foreach (var i in _myDB.Products)
                List_product.Add(new View_Index_List(i));

            OnPropertyChanged(nameof(product));

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



        public ICollection<View_Firm_List> firm
        {
            set
            {
                new_list_firm = value.ToList();
                OnPropertyChanged(nameof(firm));
            }
            get
            {


                if (new_list_firm != null)
                    return new_list_firm;
                else
                    return (new List<View_Firm_List>());
            }

        }
        public ICollection<View_Index_List> product
        {
            set
            {
                List_product = value.ToList();
                OnPropertyChanged(nameof(product));
            }
            get
            {



                if (List_product != null)
                    return List_product;
                else
                    return (new List<View_Index_List>());
                
            }
          
        }

        /// <summary>
        /// refreh
        /// </summary>
        View_Index_List select_Item_Index;
        public View_Index_List Select_Item_Index
        {
            set
            {


                select_Item_Index = value;         
                OnPropertyChanged(nameof(Select_Item_Index));

                new_list_firm.Clear();
                foreach (var i in _myDB.Firms)
                    if (select_Item_Index != null && select_Item_Index._product.Firm.ID == i.ID)
                        new_list_firm.Add(new View_Firm_List(i));
                OnPropertyChanged(nameof(firm));
            }
            get
            {
              
                return select_Item_Index;
            }

        }



        public ICollection<Date_of_receipt> data_of_receipt
        {
             get { return _myDB.Date_of_receipt.ToList(); }
        }



        #region
        public ICollection<FIO_Person> fio_Person
        {

            get
            {
                return _myDB.FIO_Person.ToList();
            }
        }
        public ICollection<Product_category> product_category
        {

            get
            {
                return _myDB.Product_category.ToList();
            }
        }
        public ICollection<Product_life> product_life
        {

            get
            {
                return _myDB.Product_life.ToList();
            }
        }
        public ICollection<Count> count
        {

            get
            {
                return _myDB.Counts.ToList();
            }
        }
        public ICollection<Mark_up> mark_up
        {

            get
            {
                return _myDB.Mark_up.ToList();
            }
        }
        #endregion

        #endregion




    }
}
