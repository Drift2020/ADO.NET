using Market.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Market.ViewModel
{
    class View_Model_Add_and_Edit_T : View_Model_Base
    {
        public Model1 _myDB;


        public View_Model_Add_and_Edit_T()
        {

        }


        #region Command button

        #region Price
        #region 
        private DelegateCommand _Command_New_Price;
        public ICommand Button_New_Price
        {
            get
            {
                if (_Command_New_Price == null)
                {
                    _Command_New_Price = new DelegateCommand(Execute_New_Price, CanExecute_New_Price);
                }
                return _Command_New_Price;
            }
        }
        private void Execute_New_Price(object o)
        {

            int n = 2;

        }
        private bool CanExecute_New_Price(object o)
        {


            return true;


            return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_Price;
        public ICommand Button_Delete_Price
        {
            get
            {
                if (_Command_Delete_Price == null)
                {
                    _Command_Delete_Price = new DelegateCommand(Execute_Delete_Price, CanExecute_Delete_Price);
                }
                return _Command_Delete_Price;
            }
        }
        private void Execute_Delete_Price(object o)
        {

            int n = 2;

        }
        private bool CanExecute_Delete_Price(object o)
        {


            return true;


            return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_price;
        public ICommand Button_Edit_price
        {
            get
            {
                if (_Command_Edit_price == null)
                {
                    _Command_Edit_price = new DelegateCommand(Execute_Edit_price, CanExecute_Edit_price);
                }
                return _Command_Edit_price;
            }
        }
        private void Execute_Edit_price(object o)
        {

            int n = 2;

        }
        private bool CanExecute_Edit_price(object o)
        {


            return true;


            return false;


        }
        #endregion
        #endregion Price

        #region Count
        #region 
        private DelegateCommand _Command_New_Count;
        public ICommand Button_New_Count
        {
            get
            {
                if (_Command_New_Count == null)
                {
                    _Command_New_Count = new DelegateCommand(Execute_New_Count, CanExecute_New_Count);
                }
                return _Command_New_Count;
            }
        }
        private void Execute_New_Count(object o)
        {

            int n = 2;

        }
        private bool CanExecute_New_Count(object o)
        {


            return true;


            return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_Count;
        public ICommand Button_Delete_Count
        {
            get
            {
                if (_Command_Delete_Count == null)
                {
                    _Command_Delete_Count = new DelegateCommand(Execute_Delete_Count, CanExecute_Delete_Count);
                }
                return _Command_Delete_Count;
            }
        }
        private void Execute_Delete_Count(object o)
        {

            int n = 2;

        }
        private bool CanExecute_Delete_Count(object o)
        {


            return true;


            return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_Count;
        public ICommand Button_Edit_Count
        {
            get
            {
                if (_Command_Edit_Count == null)
                {
                    _Command_Edit_Count = new DelegateCommand(Execute_Edit_Count, CanExecute_Edit_Count);
                }
                return _Command_Edit_Count;
            }
        }
        private void Execute_Edit_Count(object o)
        {

            int n = 2;

        }
        private bool CanExecute_Edit_Count(object o)
        {


            return true;


            return false;


        }
        #endregion
        #endregion Count

        #region Mark_up
        #region 
        private DelegateCommand _Command_New_Mark_up;
        public ICommand Button_New_Mark_up
        {
            get
            {
                if (_Command_New_Mark_up == null)
                {
                    _Command_New_Mark_up = new DelegateCommand(Execute_New_Mark_up, CanExecute_New_Mark_up);
                }
                return _Command_New_Mark_up;
            }
        }
        private void Execute_New_Mark_up(object o)
        {

            int n = 2;

        }
        private bool CanExecute_New_Mark_up(object o)
        {


            return true;


            return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_Mark_up;
        public ICommand Button_Delete_Mark_up
        {
            get
            {
                if (_Command_Delete_Mark_up == null)
                {
                    _Command_Delete_Mark_up = new DelegateCommand(Execute_Delete_Mark_up, CanExecute_Delete_Mark_up);
                }
                return _Command_Delete_Mark_up;
            }
        }
        private void Execute_Delete_Mark_up(object o)
        {

            int n = 2;

        }
        private bool CanExecute_Delete_Mark_up(object o)
        {


            return true;


            return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_Mark_up;
        public ICommand Button_Edit_Mark_up
        {
            get
            {
                if (_Command_Edit_Mark_up == null)
                {
                    _Command_Edit_Mark_up = new DelegateCommand(Execute_Edit_Mark_up, CanExecute_Edit_Mark_up);
                }
                return _Command_Edit_Mark_up;
            }
        }
        private void Execute_Edit_Mark_up(object o)
        {

            int n = 2;

        }
        private bool CanExecute_Edit_Mark_up(object o)
        {


            return true;


            return false;


        }
        #endregion
        #endregion Mark_up

        #region Date_of_receipt
        #region 
        private DelegateCommand _Command_New_Date_of_receipt;
        public ICommand Button_New_Date_of_receipt
        {
            get
            {
                if (_Command_New_Date_of_receipt == null)
                {
                    _Command_New_Date_of_receipt = new DelegateCommand(Execute_New_Date_of_receipt, CanExecute_New_Date_of_receipt);
                }
                return _Command_New_Date_of_receipt;
            }
        }
        private void Execute_New_Date_of_receipt(object o)
        {

            int n = 2;

        }
        private bool CanExecute_New_Date_of_receipt(object o)
        {


            return true;


            return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_Date_of_receipt;
        public ICommand Button_Delete_Date_of_receipt
        {
            get
            {
                if (_Command_Delete_Date_of_receipt == null)
                {
                    _Command_Delete_Date_of_receipt = new DelegateCommand(Execute_Delete_Date_of_receipt, CanExecute_Delete_Date_of_receipt);
                }
                return _Command_Delete_Date_of_receipt;
            }
        }
        private void Execute_Delete_Date_of_receipt(object o)
        {

            int n = 2;

        }
        private bool CanExecute_Delete_Date_of_receipt(object o)
        {


            return true;


            return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_Date_of_receipt;
        public ICommand Button_Edit_Date_of_receipt
        {
            get
            {
                if (_Command_Edit_Date_of_receipt == null)
                {
                    _Command_Edit_Date_of_receipt = new DelegateCommand(Execute_Edit_Date_of_receipt, CanExecute_Edit_Date_of_receipt);
                }
                return _Command_Edit_Date_of_receipt;
            }
        }
        private void Execute_Edit_Date_of_receipt(object o)
        {

            int n = 2;

        }
        private bool CanExecute_Edit_Date_of_receipt(object o)
        {


            return true;


            return false;


        }
        #endregion
        #endregion Date_of_receipt


        #region Firm
        #region 
        private DelegateCommand _Command_New_Firm;
        public ICommand Button_New_Firm
        {
            get
            {
                if (_Command_New_Firm == null)
                {
                    _Command_New_Firm = new DelegateCommand(Execute_New_Firm, CanExecute_New_Firm);
                }
                return _Command_New_Firm;
            }
        }
        private void Execute_New_Firm(object o)
        {

            int n = 2;

        }
        private bool CanExecute_New_Firm(object o)
        {


            return true;


            return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_Firm;
        public ICommand Button_Delete_Firm
        {
            get
            {
                if (_Command_Delete_Firm == null)
                {
                    _Command_Delete_Firm = new DelegateCommand(Execute_Delete_Firm, CanExecute_Delete_Firm);
                }
                return _Command_Delete_Firm;
            }
        }
        private void Execute_Delete_Firm(object o)
        {

            int n = 2;

        }
        private bool CanExecute_Delete_Firm(object o)
        {


            return true;


            return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_Firm;
        public ICommand Button_Edit_Firm
        {
            get
            {
                if (_Command_Edit_Firm == null)
                {
                    _Command_Edit_Firm = new DelegateCommand(Execute_Edit_Firm, CanExecute_Edit_Firm);
                }
                return _Command_Edit_Firm;
            }
        }
        private void Execute_Edit_Firm(object o)
        {

            int n = 2;

        }
        private bool CanExecute_Edit_Firm(object o)
        {


            return true;


            return false;


        }
        #endregion
        #endregion Firm

        #region Acceptor
        #region 
        private DelegateCommand _Command_New_Acceptor;
        public ICommand Button_New_Acceptor
        {
            get
            {
                if (_Command_New_Acceptor == null)
                {
                    _Command_New_Acceptor = new DelegateCommand(Execute_New_Acceptor, CanExecute_New_Acceptor);
                }
                return _Command_New_Acceptor;
            }
        }
        private void Execute_New_Acceptor(object o)
        {

            int n = 2;

        }
        private bool CanExecute_New_Acceptor(object o)
        {


            return true;


            return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_Acceptor;
        public ICommand Button_Delete_Acceptor
        {
            get
            {
                if (_Command_Delete_Acceptor == null)
                {
                    _Command_Delete_Acceptor = new DelegateCommand(Execute_Delete_Acceptor, CanExecute_Delete_Acceptor);
                }
                return _Command_Delete_Acceptor;
            }
        }
        private void Execute_Delete_Acceptor(object o)
        {

            int n = 2;

        }
        private bool CanExecute_Delete_Acceptor(object o)
        {


            return true;


            return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_Acceptor;
        public ICommand Button_Edit_Acceptor
        {
            get
            {
                if (_Command_Edit_Acceptor == null)
                {
                    _Command_Edit_Acceptor = new DelegateCommand(Execute_Edit_Firm, CanExecute_Edit_Firm);
                }
                return _Command_Edit_Acceptor;
            }
        }
        private void Execute_Edit_Acceptor(object o)
        {

            int n = 2;

        }
        private bool CanExecute_Edit_Acceptor(object o)
        {


            return true;


            return false;


        }
        #endregion
        #endregion Firm

        #region Product_life
        #region 
        private DelegateCommand _Command_New_Product_life;
        public ICommand Button_New_Product_life
        {
            get
            {
                if (_Command_New_Product_life == null)
                {
                    _Command_New_Product_life = new DelegateCommand(Execute_New_Product_life, CanExecute_New_Product_life);
                }
                return _Command_New_Product_life;
            }
        }
        private void Execute_New_Product_life(object o)
        {

            int n = 2;

        }
        private bool CanExecute_New_Product_life(object o)
        {


            return true;


            return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_Product_life;
        public ICommand Button_Delete_Product_life
        {
            get
            {
                if (_Command_Delete_Product_life == null)
                {
                    _Command_Delete_Product_life = new DelegateCommand(Execute_Delete_Product_life, CanExecute_Delete_Product_life);
                }
                return _Command_Delete_Product_life;
            }
        }
        private void Execute_Delete_Product_life(object o)
        {

            int n = 2;

        }
        private bool CanExecute_Delete_Product_life(object o)
        {


            return true;


            return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_Product_life;
        public ICommand Button_Edit_Product_life
        {
            get
            {
                if (_Command_Edit_Product_life == null)
                {
                    _Command_Edit_Product_life = new DelegateCommand(Execute_Edit_Firm, CanExecute_Edit_Firm);
                }
                return _Command_Edit_Product_life;
            }
        }
        private void Execute_Edit_Product_life(object o)
        {

            int n = 2;

        }
        private bool CanExecute_Edit_Product_life(object o)
        {


            return true;


            return false;


        }
        #endregion
        #endregion Firm
        #endregion Command button


        #region pole

        #region mark_up
        string mark_up;
        public string Mark_up
        {
            get
            {
                return mark_up;
            }
            set
            {
                mark_up = value;
                OnPropertyChanged(nameof(Mark_up));
            }
        }
        #endregion mark_up
        #region date_of_receipt
        string date_of_receipt;
        public string Date_of_receipt
        {
            get
            {
                return date_of_receipt;
            }
            set
            {
                date_of_receipt = value;
                OnPropertyChanged(nameof(Date_of_receipt));
            }
        }
        #endregion date_of_receipt
        #region count
        string count;
        public string Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
                OnPropertyChanged(nameof(Count));
            }
        }
        #endregion count
        #region Accrptor
        string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        string surname;
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
        #endregion Accrptor

        #endregion pole

    }
}
