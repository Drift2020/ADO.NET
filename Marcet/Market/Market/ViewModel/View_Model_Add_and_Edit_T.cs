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
            _myDB = new Model1();

            List_Price = _myDB.Prices.ToList();
            List_Count = _myDB.Counts.ToList();
            List_Mark_up = _myDB.Mark_up.ToList();
            List_date_of_receipt = _myDB.Date_of_receipt.ToList();
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

            Price new_price = new Price();
            new_price.Price1 = Convert.ToDecimal(price);
            list_price.Add(new_price);
            OnPropertyChanged(nameof(List_Price));

        }
        private bool CanExecute_New_Price(object o)
        {


            if (price != null && price.Length>0)
                return true;
            else
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

            list_price.Remove(select_item_price);

            OnPropertyChanged(nameof(List_Price));
            Select_item_price = null;
            Price = null;


        }
        private bool CanExecute_Delete_Price(object o)
        {


            if (select_item_price != null)
                return true;
            else
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

            Select_item_price.Price1 = Convert.ToDecimal(Price);
            OnPropertyChanged(nameof(List_Price));
          

        }

        private bool CanExecute_Edit_price(object o)
        {

            if(select_item_price!=null&& (Price!="" && Price!=null && !Price.Contains(" ")))
            return true;
            else
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

            Count new_count = new Count();
            new_count.Count1 = Convert.ToInt32(count);
            List_Count.Add(new_count);
            OnPropertyChanged(nameof(List_Count));

        }
        private bool CanExecute_New_Count(object o)
        {



            if (count != null && count.Length>0 && !count.Contains(" "))
                return true;
            else
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


            list_count.Remove(select_item_count);

            OnPropertyChanged(nameof(List_Count));
            Select_item_count = null;
            Count = null;


        }
        private bool CanExecute_Delete_Count(object o)
        {



            if (select_item_count != null)
                return true;
            else
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

            Select_item_count.Count1 = Convert.ToInt32(Count);
            OnPropertyChanged(nameof(List_Count));

        }
        private bool CanExecute_Edit_Count(object o)
        {



            if (select_item_count != null && (Count != "" && Count != null && !Count.Contains(" ")))
                return true;
            else
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


            Mark_up new_mark_up = new Mark_up();
            new_mark_up.Count = Convert.ToInt32(mark_up);
            List_Mark_up.Add(new_mark_up);
            OnPropertyChanged(nameof(List_Mark_up));

        }
        private bool CanExecute_New_Mark_up(object o)
        {


            if (Mark_up != null && Mark_up.Length > 0 && !Mark_up.Contains(" "))
                return true;
            else
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


            list_mark_up.Remove(select_item_mark_up);

            OnPropertyChanged(nameof(List_Mark_up));
            Select_item_mark_up = null;
            Mark_up = null;


        }
        private bool CanExecute_Delete_Mark_up(object o)
        {



            if (select_item_mark_up != null)
                return true;
            else
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

            Select_item_mark_up.Count = Convert.ToInt32(Mark_up);
            OnPropertyChanged(nameof(List_Mark_up));

        }
        private bool CanExecute_Edit_Mark_up(object o)
        {



            if (select_item_mark_up != null && (mark_up != "" && mark_up != null && !mark_up.Contains(" ")))
                return true;
            else
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


            Date_of_receipt new_date_of_receipt = new Date_of_receipt();
            new_date_of_receipt.Date = Convert.ToDateTime(date_of_receipt);
            List_date_of_receipt.Add(new_date_of_receipt);
            OnPropertyChanged(nameof(List_date_of_receipt));

        }
        private bool CanExecute_New_Date_of_receipt(object o)
        {


            if (Date_of_receipt != null && Date_of_receipt.Length > 0 && !Date_of_receipt.Contains(" "))
                return true;
            else
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

            list_date_of_receipt.Remove(select_item_date_of_receipt);

            OnPropertyChanged(nameof(List_date_of_receipt));
            Select_item_date_of_receipt = null;
            date_of_receipt = null;


        }
        private bool CanExecute_Delete_Date_of_receipt(object o)
        {


            if (select_item_date_of_receipt != null)
                return true;
            else
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
        #region Name
        string name_t;
        public string Name_t
        {
            get
            {
                return name_t;
            }
            set
            {
                name_t = value;
                OnPropertyChanged(nameof(Name_t));
            }
        }
        #endregion Accrptor
        #region price
        string price;
        public string Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        #endregion price
        #region Product life
        string product_life;
        public string Product_life
        {
            get
            {
                return product_life;
            }
            set
            {
                product_life = value;
                OnPropertyChanged(nameof(Product_life));
            }
        }
        #endregion product_life

        #endregion pole

        #region List
        #region Price list

        List<Price> list_price=new List<Market.Price>();
        public ICollection<Price> List_Price
        {
            set
            {
                list_price = value.ToList();
                OnPropertyChanged(nameof(List_Price));
            }
            get
            {


                if (list_price != null)
                    return list_price;
                else
                    return (new List<Price>());
            }

        }

        Price select_item_price;
        public Price Select_item_price
        {
            set
            {
                select_item_price = value;
                OnPropertyChanged(nameof(Select_item_price));
                Set_price();
            }
            get
            {


                if (select_item_price != null)
                    return select_item_price;
                else
                    return (new Price());
            }

        }

        void Set_price()
        {
            if(select_item_price!=null)
            Price = select_item_price.Price1.ToString();
        }

        #endregion Price list
        #region Count list

        List<Count> list_count = new List<Count>();
        public ICollection<Count> List_Count
        {
            set
            {
                list_count = value.ToList();
                OnPropertyChanged(nameof(List_Count));
            }
            get
            {


                if (list_count != null)
                    return list_count;
                else
                    return (new List<Count>());
            }

        }

        Count select_item_count;
        public Count Select_item_count
        {
            set
            {
                select_item_count = value;
                OnPropertyChanged(nameof(Select_item_count));
                Set_count();
            }
            get
            {


                if (select_item_count != null)
                    return select_item_count;
                else
                    return (new Count());
            }

        }

        void Set_count()
        {
            if (select_item_count != null)
                Count = select_item_count.Count1.ToString();
        }

        #endregion Count list
        #region Mark_up list

        List<Mark_up> list_mark_up = new List<Mark_up>();
        public ICollection<Mark_up> List_Mark_up
        {
            set
            {
                list_mark_up = value.ToList();
                OnPropertyChanged(nameof(List_Mark_up));
            }
            get
            {


                if (list_mark_up != null)
                    return list_mark_up;
                else
                    return (new List<Mark_up>());
            }

        }

        Mark_up select_item_mark_up;
        public Mark_up Select_item_mark_up
        {
            set
            {
                select_item_mark_up = value;
                OnPropertyChanged(nameof(Select_item_mark_up));
                Set_mark_up();
            }
            get
            {


                if (select_item_mark_up != null)
                    return select_item_mark_up;
                else
                    return (new Mark_up());
            }

        }

        void Set_mark_up()
        {
            if (select_item_mark_up != null)
                Mark_up = select_item_mark_up.Count.ToString();
        }

        #endregion Count list
        #region Date of receipt list

        List<Date_of_receipt> list_date_of_receipt = new List<Date_of_receipt>();
        public ICollection<Date_of_receipt> List_date_of_receipt
        {
            set
            {
                list_date_of_receipt = value.ToList();
                OnPropertyChanged(nameof(List_date_of_receipt));
            }
            get
            {


                if (list_date_of_receipt != null)
                    return list_date_of_receipt;
                else
                    return (new List<Date_of_receipt>());
            }

        }

        Date_of_receipt select_item_date_of_receipt;
        public Date_of_receipt Select_item_date_of_receipt
        {
            set
            {
                select_item_date_of_receipt = value;
                OnPropertyChanged(nameof(Select_item_date_of_receipt));
                Set_date_of_receipt();
            }
            get
            {


                if (select_item_date_of_receipt != null)
                    return select_item_date_of_receipt;
                else
                    return (new Date_of_receipt());
            }

        }

        void Set_date_of_receipt()
        {
            if (select_item_date_of_receipt != null)
                Date_of_receipt = select_item_date_of_receipt.Date.ToString();
        }

        #endregion Date of receipt list

        #endregion List
    }
}
