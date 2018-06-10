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
            List_acceptor = _myDB.FIO_Person.ToList();
            List_product_life = _myDB.Product_life.ToList();
            List_firm = _myDB.Firms.ToList();
        }

        #region Add
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


            if (Date_of_receipt != null && Date_of_receipt.Length > 0)
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
            Date_of_receipt = null;


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

            Select_item_date_of_receipt.Date = Convert.ToDateTime(Date_of_receipt);
            OnPropertyChanged(nameof(List_date_of_receipt));

        }
        private bool CanExecute_Edit_Date_of_receipt(object o)
        {


            if (Select_item_date_of_receipt != null && (Date_of_receipt != "" && Date_of_receipt != null))
                return true;
            else
                return false;


        }
        #endregion
        #endregion Date_of_receipt

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

            FIO_Person new_fio_person = new FIO_Person();
            new_fio_person.Name = Convert.ToString(name);
            new_fio_person.Surname = Convert.ToString(surname);

            List_acceptor.Add(new_fio_person);
            OnPropertyChanged(nameof(List_acceptor));

        }
        private bool CanExecute_New_Acceptor(object o)
        {



            if (Name != null && Name.Length > 0 &&
                Surname != null && Surname.Length > 0)
                return true;
            else
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

            list_acceptor.Remove(select_item_acceptor);

            OnPropertyChanged(nameof(List_acceptor));
            Select_item_acceptor = null;
            Name = null;
            Surname = null;

        }
        private bool CanExecute_Delete_Acceptor(object o)
        {

            if (select_item_acceptor != null)
                return true;
            else
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
                    _Command_Edit_Acceptor = new DelegateCommand(Execute_Edit_Acceptor, CanExecute_Edit_Acceptor);
                }
                return _Command_Edit_Acceptor;
            }
        }
        private void Execute_Edit_Acceptor(object o)
        {
            Select_item_acceptor.Name = Convert.ToString(Name);
            Select_item_acceptor.Surname = Convert.ToString(Surname);
            OnPropertyChanged(nameof(List_acceptor));

        }
        private bool CanExecute_Edit_Acceptor(object o)
        {

            if (select_item_acceptor != null && Name != "" && Name != null
                && Surname != "" && Surname != null)
                return true;
            else
                return false;
        }
        #endregion
        #endregion Acceptor

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
            Product_life new_product_life = new Product_life();
            new_product_life.Date = Convert.ToDateTime(product_life);


            List_product_life.Add(new_product_life);
            OnPropertyChanged(nameof(List_product_life));
        }
        private bool CanExecute_New_Product_life(object o)
        {


            if (Product_life != null && Product_life.Length > 0)
                return true;
            else
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

            list_product_life.Remove(select_item_product_life);
            OnPropertyChanged(nameof(List_product_life));
            Select_item_product_life = null;
            product_life = null;
          
        }
        private bool CanExecute_Delete_Product_life(object o)
        {
            if (select_item_product_life != null)
                return true;
            else
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
                    _Command_Edit_Product_life = new DelegateCommand(Execute_Edit_Product_life, CanExecute_Edit_Product_life);
                }
                return _Command_Edit_Product_life;
            }
        }
        private void Execute_Edit_Product_life(object o)
        {

            Select_item_product_life.Date = Convert.ToDateTime(product_life);
            OnPropertyChanged(nameof(List_product_life));

        }
        private bool CanExecute_Edit_Product_life(object o)
        {
            if (select_item_product_life != null && Product_life != "" && Product_life != null)
                return true;
            else
                return false;
        }
        #endregion
        #endregion Product_life
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
        #region Name Firm
        string firm;
        public string Firm
        {
            get
            {
                return firm;
            }
            set
            {
                firm = value;
                OnPropertyChanged(nameof(Firm));
            }
        }
        #endregion Name Firm

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
        #region Acceptor list

        List<FIO_Person> list_acceptor = new List<FIO_Person>();
        public ICollection<FIO_Person> List_acceptor
        {
            set
            {
                list_acceptor = value.ToList();
                OnPropertyChanged(nameof(List_acceptor));
            }
            get
            {


                if (list_acceptor != null)
                    return list_acceptor;
                else
                    return (new List<FIO_Person>());
            }

        }

        FIO_Person select_item_acceptor;
        public FIO_Person Select_item_acceptor
        {
            set
            {
                select_item_acceptor = value;
                OnPropertyChanged(nameof(Select_item_acceptor));
                Set_acceptor();
            }
            get
            {


                if (select_item_acceptor != null)
                    return select_item_acceptor;
                else
                    return (new FIO_Person());
            }

        }

        void Set_acceptor()
        {
            if (select_item_acceptor != null)
            {
                Name = select_item_acceptor.Name.ToString();
                Surname = select_item_acceptor.Surname.ToString();
            }
        }

        #endregion Product life list
        #region Product life list

        List<Product_life> list_product_life = new List<Product_life>();
        public ICollection<Product_life> List_product_life
        {
            set
            {
                list_product_life = value.ToList();
                OnPropertyChanged(nameof(List_product_life));
            }
            get
            {


                if (list_product_life != null)
                    return list_product_life;
                else
                    return (new List<Product_life>());
            }

        }

        Product_life select_item_product_life;
        public Product_life Select_item_product_life
        {
            set
            {
                select_item_product_life = value;
                OnPropertyChanged(nameof(Select_item_product_life));
                Set_product_life();
            }
            get
            {


                if (select_item_product_life != null)
                    return select_item_product_life;
                else
                    return (new Product_life());
            }

        }

        void Set_product_life()
        {
            if (select_item_product_life != null)
            {
                Product_life = select_item_product_life.Date.ToString();
              
            }
        }

        #endregion Product life list
        #region Firm list

        List<Firm> list_firm = new List<Firm>();
        public ICollection<Firm> List_firm
        {
            set
            {
                list_firm = value.ToList();
                OnPropertyChanged(nameof(List_firm));
            }
            get
            {


                if (list_firm != null)
                    return list_firm;
                else
                    return (new List<Firm>());
            }

        }

        Firm select_item_firm;
        public Firm Select_item_firm
        {
            set
            {
                select_item_firm = value;
                OnPropertyChanged(nameof(Select_item_firm));
                Set_firm();
            }
            get
            {


                if (select_item_firm != null)
                    return select_item_firm;
                else
                    return (new Firm());
            }

        }

        void Set_firm()
        {
            if (select_item_firm != null)
            {
                Firm = select_item_firm.Name.ToString();

            }
        }

        #endregion Firm list
        #endregion List
        #endregion Add

        #region Edit
        #region Command button

        #region Price
        #region 
        private DelegateCommand _Command_New_Price_edit;
        public ICommand Button_New_Price_edit
        {
            get
            {
                if (_Command_New_Price_edit == null)
                {
                    _Command_New_Price_edit = new DelegateCommand(Execute_New_Price_edit, CanExecute_New_Price_edit);
                }
                return _Command_New_Price_edit;
            }
        }
        private void Execute_New_Price_edit(object o)
        {

            Price new_price = new Price();
            new_price.Price1 = Convert.ToDecimal(price_edit);
            list_price_edit.Add(new_price);
            OnPropertyChanged(nameof(List_Price_edit));

        }
        private bool CanExecute_New_Price_edit(object o)
        {


            if (price_edit != null && price_edit.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_Price_edit;
        public ICommand Button_Delete_Price_edit
        {
            get
            {
                if (_Command_Delete_Price_edit == null)
                {
                    _Command_Delete_Price_edit = new DelegateCommand(Execute_Delete_Price_edit, CanExecute_Delete_Price_edit);
                }
                return _Command_Delete_Price_edit;
            }
        }
        private void Execute_Delete_Price_edit(object o)
        {

            list_price_edit.Remove(select_item_price_edit);

            OnPropertyChanged(nameof(List_Price_edit));
            Select_item_price_edit = null;
            Price_edit = null;


        }
        private bool CanExecute_Delete_Price_edit(object o)
        {


            if (select_item_price_edit != null)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_price_edit;
        public ICommand Button_Edit_price_edit
        {
            get
            {
                if (_Command_Edit_price_edit == null)
                {
                    _Command_Edit_price_edit = new DelegateCommand(Execute_Edit_price_edit, CanExecute_Edit_price_edit);
                }
                return _Command_Edit_price_edit;
            }
        }
        private void Execute_Edit_price_edit(object o)
        {

            Select_item_price_edit.Price1 = Convert.ToDecimal(Price_edit);
            OnPropertyChanged(nameof(List_Price_edit));


        }

        private bool CanExecute_Edit_price_edit(object o)
        {

            if (select_item_price_edit != null && (Price_edit != "" && Price_edit != null && !Price_edit.Contains(" ")))
                return true;
            else
                return false;


        }
        #endregion
        #endregion Price

        #region Count
        #region 
        private DelegateCommand _Command_New_Count_edit;
        public ICommand Button_New_Count_edit
        {
            get
            {
                if (_Command_New_Count_edit == null)
                {
                    _Command_New_Count_edit = new DelegateCommand(Execute_New_Count_edit, CanExecute_New_Count_edit);
                }
                return _Command_New_Count_edit;
            }
        }
        private void Execute_New_Count_edit(object o)
        {

            Count new_count = new Count();
            new_count.Count1 = Convert.ToInt32(count_edit);
            List_Count_edit.Add(new_count);
            OnPropertyChanged(nameof(List_Count_edit));

        }
        private bool CanExecute_New_Count_edit(object o)
        {



            if (count_edit != null && count_edit.Length > 0 && !count_edit.Contains(" "))
                return true;
            else
                return false;

        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_Count_edit;
        public ICommand Button_Delete_Count_edit
        {
            get
            {
                if (_Command_Delete_Count_edit == null)
                {
                    _Command_Delete_Count_edit = new DelegateCommand(Execute_Delete_Count_edit, CanExecute_Delete_Count_edit);
                }
                return _Command_Delete_Count_edit;
            }
        }
        private void Execute_Delete_Count_edit(object o)
        {


            list_count_edit.Remove(select_item_count_edit);

            OnPropertyChanged(nameof(List_Count_edit));
            Select_item_count_edit = null;
            Count_edit = null;


        }
        private bool CanExecute_Delete_Count_edit(object o)
        {



            if (select_item_count_edit != null)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_Count_edit;
        public ICommand Button_Edit_Count_edit
        {
            get
            {
                if (_Command_Edit_Count_edit == null)
                {
                    _Command_Edit_Count_edit = new DelegateCommand(Execute_Edit_Count_edit, CanExecute_Edit_Count_edit);
                }
                return _Command_Edit_Count_edit;
            }
        }
        private void Execute_Edit_Count_edit(object o)
        {

            Select_item_count_edit.Count1 = Convert.ToInt32(Count_edit);
            OnPropertyChanged(nameof(List_Count_edit));

        }
        private bool CanExecute_Edit_Count_edit(object o)
        {

            if (select_item_count_edit != null && (Count_edit != "" && Count_edit != null && !Count_edit.Contains(" ")))
                return true;
            else
                return false;

        }
        #endregion
        #endregion Count

        #region Mark_up
        #region 
        private DelegateCommand _Command_New_Mark_up_edit;
        public ICommand Button_New_Mark_up_edit
        {
            get
            {
                if (_Command_New_Mark_up_edit == null)
                {
                    _Command_New_Mark_up_edit = new DelegateCommand(Execute_New_Mark_up_edit, CanExecute_New_Mark_up_edit);
                }
                return _Command_New_Mark_up_edit;
            }
        }
        private void Execute_New_Mark_up_edit(object o)
        {


            Mark_up new_mark_up = new Mark_up();
            new_mark_up.Count = Convert.ToInt32(mark_up_edit);
            List_Mark_up_edit.Add(new_mark_up);
            OnPropertyChanged(nameof(List_Mark_up_edit));

        }
        private bool CanExecute_New_Mark_up_edit(object o)
        {


            if (Mark_up_edit != null && Mark_up_edit.Length > 0 && !Mark_up_edit.Contains(" "))
                return true;
            else
                return false;

        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_Mark_up_edit;
        public ICommand Button_Delete_Mark_up_edit
        {
            get
            {
                if (_Command_Delete_Mark_up_edit == null)
                {
                    _Command_Delete_Mark_up_edit = new DelegateCommand(Execute_Delete_Mark_up_edit, CanExecute_Delete_Mark_up_edit);
                }
                return _Command_Delete_Mark_up_edit;
            }
        }
        private void Execute_Delete_Mark_up_edit(object o)
        {


            list_mark_up_edit.Remove(select_item_mark_up_edit);

            OnPropertyChanged(nameof(List_Mark_up_edit));
            Select_item_mark_up_edit = null;
            Mark_up_edit = null;


        }
        private bool CanExecute_Delete_Mark_up_edit(object o)
        {



            if (select_item_mark_up_edit != null)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_Mark_up_edit;
        public ICommand Button_Edit_Mark_up_edit
        {
            get
            {
                if (_Command_Edit_Mark_up_edit == null)
                {
                    _Command_Edit_Mark_up_edit = new DelegateCommand(Execute_Edit_Mark_up_edit, CanExecute_Edit_Mark_up_edit);
                }
                return _Command_Edit_Mark_up_edit;
            }
        }
        private void Execute_Edit_Mark_up_edit(object o)
        {

            Select_item_mark_up_edit.Count = Convert.ToInt32(Mark_up_edit);
            OnPropertyChanged(nameof(List_Mark_up_edit));

        }
        private bool CanExecute_Edit_Mark_up_edit(object o)
        {



            if (select_item_mark_up_edit != null && (mark_up_edit != "" && mark_up_edit != null && !mark_up_edit.Contains(" ")))
                return true;
            else
                return false;


        }
        #endregion
        #endregion Mark_up

        #region Date_of_receipt
        #region 
        private DelegateCommand _Command_New_Date_of_receipt_edit;
        public ICommand Button_New_Date_of_receipt_edit
        {
            get
            {
                if (_Command_New_Date_of_receipt_edit == null)
                {
                    _Command_New_Date_of_receipt_edit = new DelegateCommand(Execute_New_Date_of_receipt_edit, CanExecute_New_Date_of_receipt_edit);
                }
                return _Command_New_Date_of_receipt_edit;
            }
        }
        private void Execute_New_Date_of_receipt_edit(object o)
        {


            Date_of_receipt new_date_of_receipt = new Date_of_receipt();
            new_date_of_receipt.Date = Convert.ToDateTime(date_of_receipt_edit);
            List_date_of_receipt_edit.Add(new_date_of_receipt);
            OnPropertyChanged(nameof(List_date_of_receipt_edit));

        }
        private bool CanExecute_New_Date_of_receipt_edit(object o)
        {


            if (Date_of_receipt_edit != null && Date_of_receipt_edit.Length > 0)
                return true;
            else
                return false;



        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_Date_of_receipt_edit;
        public ICommand Button_Delete_Date_of_receipt_edit
        {
            get
            {
                if (_Command_Delete_Date_of_receipt_edit == null)
                {
                    _Command_Delete_Date_of_receipt_edit = new DelegateCommand(Execute_Delete_Date_of_receipt_edit, CanExecute_Delete_Date_of_receipt_edit);
                }
                return _Command_Delete_Date_of_receipt_edit;
            }
        }
        private void Execute_Delete_Date_of_receipt_edit(object o)
        {

            list_date_of_receipt_edit.Remove(select_item_date_of_receipt_edit);

            OnPropertyChanged(nameof(List_date_of_receipt_edit));
            Select_item_date_of_receipt_edit = null;
            Date_of_receipt_edit = null;


        }
        private bool CanExecute_Delete_Date_of_receipt_edit(object o)
        {


            if (select_item_date_of_receipt_edit != null)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_Date_of_receipt_edit;
        public ICommand Button_Edit_Date_of_receipt_edit
        {
            get
            {
                if (_Command_Edit_Date_of_receipt_edit == null)
                {
                    _Command_Edit_Date_of_receipt_edit = new DelegateCommand(Execute_Edit_Date_of_receipt_edit, CanExecute_Edit_Date_of_receipt_edit);
                }
                return _Command_Edit_Date_of_receipt_edit;
            }
        }
        private void Execute_Edit_Date_of_receipt_edit(object o)
        {

            Select_item_date_of_receipt_edit.Date = Convert.ToDateTime(Date_of_receipt_edit);
            OnPropertyChanged(nameof(List_date_of_receipt_edit));

        }
        private bool CanExecute_Edit_Date_of_receipt_edit(object o)
        {


            if (Select_item_date_of_receipt_edit != null && (Date_of_receipt_edit != "" && Date_of_receipt_edit != null))
                return true;
            else
                return false;


        }
        #endregion
        #endregion Date_of_receipt

        #region Acceptor
        #region 
        private DelegateCommand _Command_New_Acceptor_edit;
        public ICommand Button_New_Acceptor_edit
        {
            get
            {
                if (_Command_New_Acceptor_edit == null)
                {
                    _Command_New_Acceptor_edit = new DelegateCommand(Execute_New_Acceptor_edit, CanExecute_New_Acceptor_edit);
                }
                return _Command_New_Acceptor_edit;
            }
        }
        private void Execute_New_Acceptor_edit(object o)
        {

            FIO_Person new_fio_person = new FIO_Person();
            new_fio_person.Name = Convert.ToString(name_edit);
            new_fio_person.Surname = Convert.ToString(surname_edit);

            List_acceptor_edit.Add(new_fio_person);
            OnPropertyChanged(nameof(List_acceptor_edit));

        }
        private bool CanExecute_New_Acceptor_edit(object o)
        {



            if (Name_edit != null && Name_edit.Length > 0 &&
                Surname_edit != null && Surname_edit.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_Acceptor_edit;
        public ICommand Button_Delete_Acceptor_edit
        {
            get
            {
                if (_Command_Delete_Acceptor_edit == null)
                {
                    _Command_Delete_Acceptor_edit = new DelegateCommand(Execute_Delete_Acceptor_edit, CanExecute_Delete_Acceptor_edit);
                }
                return _Command_Delete_Acceptor_edit;
            }
        }
        private void Execute_Delete_Acceptor_edit(object o)
        {

            list_acceptor_edit.Remove(select_item_acceptor_edit);

            OnPropertyChanged(nameof(List_acceptor_edit));
            Select_item_acceptor_edit = null;
            Name_edit = null;
            Surname_edit = null;

        }
        private bool CanExecute_Delete_Acceptor_edit(object o)
        {

            if (select_item_acceptor_edit != null)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_Acceptor_edit;
        public ICommand Button_Edit_Acceptor_edit
        {
            get
            {
                if (_Command_Edit_Acceptor_edit == null)
                {
                    _Command_Edit_Acceptor_edit = new DelegateCommand(Execute_Edit_Acceptor_edit, CanExecute_Edit_Acceptor_edit);
                }
                return _Command_Edit_Acceptor_edit;
            }
        }
        private void Execute_Edit_Acceptor_edit(object o)
        {
            Select_item_acceptor_edit.Name = Convert.ToString(Name_edit);
            Select_item_acceptor_edit.Surname = Convert.ToString(Surname_edit);
            OnPropertyChanged(nameof(List_acceptor_edit));

        }
        private bool CanExecute_Edit_Acceptor_edit(object o)
        {

            if (select_item_acceptor_edit != null && Name_edit != "" && Name_edit != null
                && Surname_edit != "" && Surname_edit != null)
                return true;
            else
                return false;
        }
        #endregion
        #endregion Acceptor

        #region Product_life
        #region 
        private DelegateCommand _Command_New_Product_life_edit;
        public ICommand Button_New_Product_life_edit
        {
            get
            {
                if (_Command_New_Product_life_edit == null)
                {
                    _Command_New_Product_life_edit = new DelegateCommand(Execute_New_Product_life_edit, CanExecute_New_Product_life_edit);
                }
                return _Command_New_Product_life_edit;
            }
        }
        private void Execute_New_Product_life_edit(object o)
        {
            Product_life new_product_life_edit = new Product_life();
            new_product_life_edit.Date = Convert.ToDateTime(product_life_edit);


            List_product_life_edit.Add(new_product_life_edit);
            OnPropertyChanged(nameof(List_product_life_edit));
        }
        private bool CanExecute_New_Product_life_edit(object o)
        {


            if (Product_life_edit != null && Product_life_edit.Length > 0)
                return true;
            else
                return false;

        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_Product_life_edit;
        public ICommand Button_Delete_Product_life_edit
        {
            get
            {
                if (_Command_Delete_Product_life_edit == null)
                {
                    _Command_Delete_Product_life_edit = new DelegateCommand(Execute_Delete_Product_life_edit, CanExecute_Delete_Product_life_edit);
                }
                return _Command_Delete_Product_life_edit;
            }
        }
        private void Execute_Delete_Product_life_edit(object o)
        {

            list_product_life.Remove(select_item_product_life_edit);
            OnPropertyChanged(nameof(List_product_life_edit));
            Select_item_product_life_edit = null;
            product_life_edit = null;

        }
        private bool CanExecute_Delete_Product_life_edit(object o)
        {
            if (select_item_product_life_edit != null)
                return true;
            else
                return false;

        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_Product_life_edit;
        public ICommand Button_Edit_Product_life_edit
        {
            get
            {
                if (_Command_Edit_Product_life_edit == null)
                {
                    _Command_Edit_Product_life_edit = new DelegateCommand(Execute_Edit_Product_life_edit, CanExecute_Edit_Product_life_edit);
                }
                return _Command_Edit_Product_life_edit;
            }
        }
        private void Execute_Edit_Product_life_edit(object o)
        {

            Select_item_product_life_edit.Date = Convert.ToDateTime(product_life_edit);
            OnPropertyChanged(nameof(List_product_life_edit));

        }
        private bool CanExecute_Edit_Product_life_edit(object o)
        {
            if (select_item_product_life_edit != null && Product_life_edit != "" && Product_life_edit != null)
                return true;
            else
                return false;
        }
        #endregion
        #endregion Product_life
        #endregion Command button


        #region pole

        #region mark_up
        string mark_up_edit;
        public string Mark_up_edit
        {
            get
            {
                return mark_up_edit;
            }
            set
            {
                mark_up_edit = value;
                OnPropertyChanged(nameof(Mark_up_edit));
            }
        }
        #endregion mark_up
        #region date_of_receipt
        string date_of_receipt_edit;
        public string Date_of_receipt_edit
        {
            get
            {
                return date_of_receipt_edit;
            }
            set
            {
                date_of_receipt_edit = value;
                OnPropertyChanged(nameof(Date_of_receipt_edit));
            }
        }
        #endregion date_of_receipt
        #region count
        string count_edit;
        public string Count_edit
        {
            get
            {
                return count_edit;
            }
            set
            {
                count_edit = value;
                OnPropertyChanged(nameof(Count_edit));
            }
        }
        #endregion count
        #region Accrptor
        string name_edit;
        public string Name_edit
        {
            get
            {
                return name_edit;
            }
            set
            {
                name_edit = value;
                OnPropertyChanged(nameof(Name_edit));
            }
        }

        string surname_edit;
        public string Surname_edit
        {
            get
            {
                return surname_edit;
            }
            set
            {
                surname_edit = value;
                OnPropertyChanged(nameof(Surname_edit));
            }
        }
        #endregion Accrptor
        #region Name
        string name_t_edit;
        public string Name_t_edit
        {
            get
            {
                return name_t_edit;
            }
            set
            {
                name_t_edit = value;
                OnPropertyChanged(nameof(Name_t_edit));
            }
        }
        #endregion Accrptor
        #region price
        string price_edit;
        public string Price_edit
        {
            get
            {
                return price_edit;
            }
            set
            {
                price_edit = value;
                OnPropertyChanged(nameof(Price_edit));
            }
        }
        #endregion price
        #region Product life
        string product_life_edit;
        public string Product_life_edit
        {
            get
            {
                return product_life_edit;
            }
            set
            {
                product_life_edit = value;
                OnPropertyChanged(nameof(Product_life_edit));
            }
        }
        #endregion product_life
        #region Name Firm
        string firm_edit;
        public string Firm_edit
        {
            get
            {
                return firm_edit;
            }
            set
            {
                firm_edit = value;
                OnPropertyChanged(nameof(Firm_edit));
            }
        }
        #endregion Name Firm

        #endregion pole

        #region List
        #region Price list

        List<Price> list_price_edit = new List<Market.Price>();
        public ICollection<Price> List_Price_edit
        {
            set
            {
                list_price_edit = value.ToList();
                OnPropertyChanged(nameof(List_Price_edit));
            }
            get
            {


                if (list_price_edit != null)
                    return list_price_edit;
                else
                    return (new List<Price>());
            }

        }

        Price select_item_price_edit;
        public Price Select_item_price_edit
        {
            set
            {
                select_item_price_edit = value;
                OnPropertyChanged(nameof(Select_item_price_edit));
                Set_price_edit();
            }
            get
            {


                if (select_item_price_edit != null)
                    return select_item_price_edit;
                else
                    return (new Price());
            }

        }

        void Set_price_edit()
        {
            if (select_item_price_edit != null)
                Price_edit = select_item_price_edit.Price1.ToString();
        }

        #endregion Price list
        #region Count list

        List<Count> list_count_edit = new List<Count>();
        public ICollection<Count> List_Count_edit
        {
            set
            {
                list_count_edit = value.ToList();
                OnPropertyChanged(nameof(List_Count_edit));
            }
            get
            {


                if (list_count_edit != null)
                    return list_count_edit;
                else
                    return (new List<Count>());
            }

        }

        Count select_item_count_edit;
        public Count Select_item_count_edit
        {
            set
            {
                select_item_count_edit = value;
                OnPropertyChanged(nameof(Select_item_count_edit));
                Set_count_edit();
            }
            get
            {


                if (select_item_count_edit != null)
                    return select_item_count_edit;
                else
                    return (new Count());
            }

        }

        void Set_count_edit()
        {
            if (select_item_count_edit != null)
                Count_edit = select_item_count_edit.Count1.ToString();
        }

        #endregion Count list
        #region Mark_up list

        List<Mark_up> list_mark_up_edit = new List<Mark_up>();
        public ICollection<Mark_up> List_Mark_up_edit
        {
            set
            {
                list_mark_up_edit = value.ToList();
                OnPropertyChanged(nameof(List_Mark_up_edit));
            }
            get
            {


                if (list_mark_up_edit != null)
                    return list_mark_up_edit;
                else
                    return (new List<Mark_up>());
            }

        }

        Mark_up select_item_mark_up_edit;
        public Mark_up Select_item_mark_up_edit
        {
            set
            {
                select_item_mark_up_edit = value;
                OnPropertyChanged(nameof(Select_item_mark_up_edit));
                Set_mark_up_edit();
            }
            get
            {


                if (select_item_mark_up_edit != null)
                    return select_item_mark_up_edit;
                else
                    return (new Mark_up());
            }

        }

        void Set_mark_up_edit()
        {
            if (select_item_mark_up_edit != null)
                Mark_up_edit = select_item_mark_up_edit.Count.ToString();
        }

        #endregion Count list
        #region Date of receipt list

        List<Date_of_receipt> list_date_of_receipt_edit = new List<Date_of_receipt>();
        public ICollection<Date_of_receipt> List_date_of_receipt_edit
        {
            set
            {
                list_date_of_receipt_edit = value.ToList();
                OnPropertyChanged(nameof(List_date_of_receipt_edit));
            }
            get
            {


                if (list_date_of_receipt_edit != null)
                    return list_date_of_receipt_edit;
                else
                    return (new List<Date_of_receipt>());
            }

        }

        Date_of_receipt select_item_date_of_receipt_edit;
        public Date_of_receipt Select_item_date_of_receipt_edit
        {
            set
            {
                select_item_date_of_receipt_edit = value;
                OnPropertyChanged(nameof(Select_item_date_of_receipt_edit));
                Set_date_of_receipt_edit();
            }
            get
            {


                if (select_item_date_of_receipt_edit != null)
                    return select_item_date_of_receipt_edit;
                else
                    return (new Date_of_receipt());
            }

        }

        void Set_date_of_receipt_edit()
        {
            if (select_item_date_of_receipt_edit != null)
                Date_of_receipt_edit = select_item_date_of_receipt_edit.Date.ToString();
        }

        #endregion Date of receipt list
        #region Acceptor list

        List<FIO_Person> list_acceptor_edit = new List<FIO_Person>();
        public ICollection<FIO_Person> List_acceptor_edit
        {
            set
            {
                list_acceptor_edit = value.ToList();
                OnPropertyChanged(nameof(List_acceptor_edit));
            }
            get
            {


                if (list_acceptor_edit != null)
                    return list_acceptor_edit;
                else
                    return (new List<FIO_Person>());
            }

        }

        FIO_Person select_item_acceptor_edit;
        public FIO_Person Select_item_acceptor_edit
        {
            set
            {
                select_item_acceptor_edit = value;
                OnPropertyChanged(nameof(Select_item_acceptor_edit));
                Set_acceptor_edit();
            }
            get
            {


                if (select_item_acceptor_edit != null)
                    return select_item_acceptor_edit;
                else
                    return (new FIO_Person());
            }

        }

        void Set_acceptor_edit()
        {
            if (select_item_acceptor_edit != null)
            {
                Name_edit = select_item_acceptor_edit.Name.ToString();
                Surname_edit = select_item_acceptor_edit.Surname.ToString();
            }
        }

        #endregion Product life list
        #region Product life list

        List<Product_life> list_product_life_edit = new List<Product_life>();
        public ICollection<Product_life> List_product_life_edit
        {
            set
            {
                list_product_life_edit = value.ToList();
                OnPropertyChanged(nameof(List_product_life_edit));
            }
            get
            {


                if (list_product_life_edit != null)
                    return list_product_life_edit;
                else
                    return (new List<Product_life>());
            }

        }

        Product_life select_item_product_life_edit;
        public Product_life Select_item_product_life_edit
        {
            set
            {
                select_item_product_life_edit = value;
                OnPropertyChanged(nameof(Select_item_product_life_edit));
                Set_product_life_edit();
            }
            get
            {


                if (select_item_product_life_edit != null)
                    return select_item_product_life_edit;
                else
                    return (new Product_life());
            }

        }

        void Set_product_life_edit()
        {
            if (select_item_product_life_edit != null)
            {
                Product_life_edit = select_item_product_life_edit.Date.ToString();

            }
        }

        #endregion Product life list
        #region Firm list

        List<Firm> list_firm_edit = new List<Firm>();
        public ICollection<Firm> List_firm_edit
        {
            set
            {
                list_firm_edit = value.ToList();
                OnPropertyChanged(nameof(List_firm_edit));
            }
            get
            {


                if (list_firm_edit != null)
                    return list_firm_edit;
                else
                    return (new List<Firm>());
            }

        }

        Firm select_item_firm_edit;
        public Firm Select_item_firm_edit
        {
            set
            {
                select_item_firm_edit = value;
                OnPropertyChanged(nameof(Select_item_firm_edit));
                Set_firm_edit();
            }
            get
            {


                if (select_item_firm_edit != null)
                    return select_item_firm_edit;
                else
                    return (new Firm());
            }

        }

        void Set_firm_edit()
        {
            if (select_item_firm_edit != null)
            {
                Firm_edit = select_item_firm_edit.Name.ToString();

            }
        }

        #endregion Firm list
        #endregion List
        #endregion Edit

    }
}
