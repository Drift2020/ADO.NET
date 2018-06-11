using Market.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Market.ViewModel
{
    class View_Model_Add_and_Edit_Firm : View_Model_Base
    {
        public View_Model_Add_and_Edit_Firm()
        {

        }

        #region Command button 

        #region Base
        #region 
        private DelegateCommand _Command_New_Phone;
        public ICommand Button_New_Phone
        {
            get
            {
                if (_Command_New_Phone == null)
                {
                    _Command_New_Phone = new DelegateCommand(Execute_New_Phone, CanExecute_New_Phone);
                }
                return _Command_New_Phone;
            }
        }
        private void Execute_New_Phone(object o)
        {

            Phone temp = new Phone();
            temp.Number = Convert.ToString(phone);
            list_phone.Add(temp);
            OnPropertyChanged(nameof(List_phone));

        }
        private bool CanExecute_New_Phone(object o)
        {


            if (phone != null && phone.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_Phone;
        public ICommand Button_Delete_Phone
        {
            get
            {
                if (_Command_Delete_Phone == null)
                {
                    _Command_Delete_Phone = new DelegateCommand(Execute_Delete_Phone, CanExecute_Delete_Phone);
                }
                return _Command_Delete_Phone;
            }
        }
        private void Execute_Delete_Phone(object o)
        {

            list_phone.Remove(select_item_phone);

            OnPropertyChanged(nameof(List_phone));
            Select_item_phone = null;
            Phone = null;


        }
        private bool CanExecute_Delete_Phone(object o)
        {


            if (select_item_phone != null)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_phone;
        public ICommand Button_Edit_Phone
        {
            get
            {
                if (_Command_Edit_phone == null)
                {
                    _Command_Edit_phone = new DelegateCommand(Execute_Edit_phone, CanExecute_Edit_phone);
                }
                return _Command_Edit_phone;
            }
        }
        private void Execute_Edit_phone(object o)
        {

            Select_item_phone.Number = Phone;
            OnPropertyChanged(nameof(List_phone));


        }

        private bool CanExecute_Edit_phone(object o)
        {

            if (select_item_phone != null && Phone.Length>0)
                return true;
            else
                return false;


        }
        #endregion
        #endregion Base

        #region City
        #region 
        private DelegateCommand _Command_New_Phone;
        public ICommand Button_New_Phone
        {
            get
            {
                if (_Command_New_Phone == null)
                {
                    _Command_New_Phone = new DelegateCommand(Execute_New_Phone, CanExecute_New_Phone);
                }
                return _Command_New_Phone;
            }
        }
        private void Execute_New_Phone(object o)
        {

            Phone temp = new Phone();
            temp.Number = Convert.ToString(phone);
            list_phone.Add(temp);
            OnPropertyChanged(nameof(List_phone));

        }
        private bool CanExecute_New_Phone(object o)
        {


            if (phone != null && phone.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_Phone;
        public ICommand Button_Delete_Phone
        {
            get
            {
                if (_Command_Delete_Phone == null)
                {
                    _Command_Delete_Phone = new DelegateCommand(Execute_Delete_Phone, CanExecute_Delete_Phone);
                }
                return _Command_Delete_Phone;
            }
        }
        private void Execute_Delete_Phone(object o)
        {

            list_phone.Remove(select_item_phone);

            OnPropertyChanged(nameof(List_phone));
            Select_item_phone = null;
            Phone = null;


        }
        private bool CanExecute_Delete_Phone(object o)
        {


            if (select_item_phone != null)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_phone;
        public ICommand Button_Edit_Phone
        {
            get
            {
                if (_Command_Edit_phone == null)
                {
                    _Command_Edit_phone = new DelegateCommand(Execute_Edit_phone, CanExecute_Edit_phone);
                }
                return _Command_Edit_phone;
            }
        }
        private void Execute_Edit_phone(object o)
        {

            Select_item_phone.Number = Phone;
            OnPropertyChanged(nameof(List_phone));


        }

        private bool CanExecute_Edit_phone(object o)
        {

            if (select_item_phone != null && Phone.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #endregion City

        #endregion Command button




        #region Pole


        #region Phone

        string phone;
        public string Phone {
            set
            {
                phone = value;
                OnPropertyChanged(nameof(Phone));
            }
            get
            {
                return phone;
            }
        }

        string name_firm;
        public string Name_firm
        {
            set
            {
                name_firm = value;
                OnPropertyChanged(nameof(Name_firm));
            }
            get
            {
                return name_firm;
            }
        }


        #endregion Phone 


        #endregion Pole



        #region List and select


        #region Phone
        List<Phone> list_phone= new List<Market.Phone>();
        public ICollection<Phone> List_phone
        {
            set
            {
                list_phone = value.ToList();
                OnPropertyChanged(nameof(List_phone));
            }
            get
            {
                return list_phone.ToList();
            }
        }


        Phone select_item_phone= new Phone();
        public Phone Select_item_phone
        {
            set
            {
                select_item_phone = value;
                OnPropertyChanged(nameof(Select_item_phone));
                Set_phone();
            }
            get
            {
                return select_item_phone;
            }
        }


        void Set_phone()
        {
            if (select_item_phone != null)
                Phone = select_item_phone.Number.ToString();
        }
        #endregion Phone

        #endregion List and select

    }
}
