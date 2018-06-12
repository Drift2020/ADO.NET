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

        Model1 myBD;

        public View_Model_Add_and_Edit_Firm()
        {
            myBD = new Model1();
            List_adressa = myBD.Adressas.ToList();
            List_boss = myBD.Bosses.ToList();
            List_city = myBD.Cities.ToList();
            List_country = myBD.Countries.ToList();
            List_phone = myBD.Phones.ToList();
        }

        #region Add

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
        private DelegateCommand _Command_New_City;
        public ICommand Button_New_City
        {
            get
            {
                if (_Command_New_City == null)
                {
                    _Command_New_City = new DelegateCommand(Execute_New_City, CanExecute_New_City);
                }
                return _Command_New_City;
            }
        }
        private void Execute_New_City(object o)
        {

            City temp = new City();
            temp.Name = Convert.ToString(city);
            list_city.Add(temp);
            OnPropertyChanged(nameof(List_city));

        }
        private bool CanExecute_New_City(object o)
        {


            if (city != null && city.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_City;
        public ICommand Button_Delete_City
        {
            get
            {
                if (_Command_Delete_City == null)
                {
                    _Command_Delete_City = new DelegateCommand(Execute_Delete_City, CanExecute_Delete_City);
                }
                return _Command_Delete_City;
            }
        }
        private void Execute_Delete_City(object o)
        {

            list_city.Remove(select_item_city);

            OnPropertyChanged(nameof(List_city));
            Select_item_city = null;
            Phone = null;


        }
        private bool CanExecute_Delete_City(object o)
        {


            if (select_item_city != null)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_city;
        public ICommand Button_Edit_City
        {
            get
            {
                if (_Command_Edit_city == null)
                {
                    _Command_Edit_city = new DelegateCommand(Execute_Edit_city, CanExecute_Edit_city);
                }
                return _Command_Edit_city;
            }
        }
        private void Execute_Edit_city(object o)
        {

            Select_item_city.Name = City;
            OnPropertyChanged(nameof(List_city));


        }
        private bool CanExecute_Edit_city(object o)
        {

            if (select_item_city != null && City.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #endregion City

        #region Country
        #region 
        private DelegateCommand _Command_New_country;
        public ICommand Button_New_country
        {
            get
            {
                if (_Command_New_country == null)
                {
                    _Command_New_country = new DelegateCommand(Execute_New_country, CanExecute_New_country);
                }
                return _Command_New_country;
            }
        }
        private void Execute_New_country(object o)
        {

            Country temp = new Country();
            temp.Name = Convert.ToString(country);
            list_country.Add(temp);
            OnPropertyChanged(nameof(List_country));

        }
        private bool CanExecute_New_country(object o)
        {


            if (country != null && country.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_country;
        public ICommand Button_Delete_country
        {
            get
            {
                if (_Command_Delete_country == null)
                {
                    _Command_Delete_country = new DelegateCommand(Execute_Delete_country, CanExecute_Delete_country);
                }
                return _Command_Delete_country;
            }
        }
        private void Execute_Delete_country(object o)
        {

            list_country.Remove(select_item_country);

            OnPropertyChanged(nameof(List_country));
            Select_item_country = null;
            Country = null;


        }
        private bool CanExecute_Delete_country(object o)
        {


            if (select_item_country != null)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_country;
        public ICommand Button_Edit_country
        {
            get
            {
                if (_Command_Edit_country == null)
                {
                    _Command_Edit_country = new DelegateCommand(Execute_Edit_country, CanExecute_Edit_country);
                }
                return _Command_Edit_country;
            }
        }
        private void Execute_Edit_country(object o)
        {

            Select_item_country.Name = City;
            OnPropertyChanged(nameof(List_country));


        }
        private bool CanExecute_Edit_country(object o)
        {

            if (select_item_country != null && country.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #endregion Country

        #region Adressa
        #region 
        private DelegateCommand _Command_New_adressa;
        public ICommand Button_New_adressa
        {
            get
            {
                if (_Command_New_adressa == null)
                {
                    _Command_New_adressa = new DelegateCommand(Execute_New_adressa, CanExecute_New_adressa);
                }
                return _Command_New_adressa;
            }
        }
        private void Execute_New_adressa(object o)
        {

            Adressa temp = new Market.Adressa();
            temp.Name = Convert.ToString(adressa);
            list_adressa.Add(temp);
            OnPropertyChanged(nameof(List_adressa));

        }
        private bool CanExecute_New_adressa(object o)
        {


            if (adressa != null && adressa.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_adressa;
        public ICommand Button_Delete_adressa
        {
            get
            {
                if (_Command_Delete_adressa == null)
                {
                    _Command_Delete_adressa = new DelegateCommand(Execute_Delete_adressa, CanExecute_Delete_adressa);
                }
                return _Command_Delete_adressa;
            }
        }
        private void Execute_Delete_adressa(object o)
        {

            list_adressa.Remove(select_item_adressa);

            OnPropertyChanged(nameof(List_adressa));
            Select_item_adressa = null;
            Adressa = null;


        }
        private bool CanExecute_Delete_adressa(object o)
        {


            if (select_item_adressa != null)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_adressa;
        public ICommand Button_Edit_adressa
        {
            get
            {
                if (_Command_Edit_adressa == null)
                {
                    _Command_Edit_adressa = new DelegateCommand(Execute_Edit_adressa, CanExecute_Edit_adressa);
                }
                return _Command_Edit_adressa;
            }
        }
        private void Execute_Edit_adressa(object o)
        {

            Select_item_adressa.Name = Adressa;
            OnPropertyChanged(nameof(List_adressa));


        }
        private bool CanExecute_Edit_adressa(object o)
        {

            if (select_item_adressa != null && adressa.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #endregion Adressa

        #region boss
        #region 
        private DelegateCommand _Command_New_boss;
        public ICommand Button_New_boss
        {
            get
            {
                if (_Command_New_boss == null)
                {
                    _Command_New_boss = new DelegateCommand(Execute_New_boss, CanExecute_New_boss);
                }
                return _Command_New_boss;
            }
        }
        private void Execute_New_boss(object o)
        {

            Boss temp = new Market.Boss();
            temp.Name = Convert.ToString(name_boss);
            temp.Surname = Convert.ToString(surname_boss);
            list_boss.Add(temp);
            OnPropertyChanged(nameof(List_boss));

        }
        private bool CanExecute_New_boss(object o)
        {


            if (name_boss != null && name_boss.Length > 0
                && surname_boss != null && surname_boss.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_boss;
        public ICommand Button_Delete_boss
        {
            get
            {
                if (_Command_Delete_boss == null)
                {
                    _Command_Delete_boss = new DelegateCommand(Execute_Delete_boss, CanExecute_Delete_boss);
                }
                return _Command_Delete_boss;
            }
        }
        private void Execute_Delete_boss(object o)
        {

            list_boss.Remove(select_item_boss);

            OnPropertyChanged(nameof(List_boss));
            Select_item_boss = null;
            Name_boss = null;
            Surname_boss = null;


        }
        private bool CanExecute_Delete_boss(object o)
        {


            if (select_item_boss != null)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_boss;
        public ICommand Button_Edit_boss
        {
            get
            {
                if (_Command_Edit_boss == null)
                {
                    _Command_Edit_boss = new DelegateCommand(Execute_Edit_boss, CanExecute_Edit_boss);
                }
                return _Command_Edit_boss;
            }
        }
        private void Execute_Edit_boss(object o)
        {

            Select_item_boss.Name = Name_boss;
            Select_item_boss.Surname = Surname_boss;
            OnPropertyChanged(nameof(List_boss));


        }
        private bool CanExecute_Edit_boss(object o)
        {

            if (select_item_boss != null && name_boss.Length > 0 && surname_boss.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #endregion Adressa

        #endregion Command button




        #region Pole


        #region Phone

        string phone="";
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

        string name_firm = "";
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

        #region City

        string city = "";
        public string City
        {
            set
            {
                city = value;
                OnPropertyChanged(nameof(City));
            }
            get
            {
                return city;
            }
        }

        #endregion City


        #region Country

        string country = "";
        public string Country
        {
            set
            {
                country = value;
                OnPropertyChanged(nameof(Country));
            }
            get
            {
                return country;
            }
        }

        #endregion Country

        #region Adressa

        string adressa = "";
        public string Adressa
        {
            set
            {
                adressa = value;
                OnPropertyChanged(nameof(Adressa));
            }
            get
            {
                return adressa;
            }
        }

        #endregion Adressa

        #region Boss

        string name_boss = "";
        public string Name_boss
        {
            set
            {
                name_boss = value;
                OnPropertyChanged(nameof(Name_boss));
            }
            get
            {
                return name_boss;
            }
        }


        string surname_boss;
        public string Surname_boss
        {
            set
            {
                surname_boss = value;
                OnPropertyChanged(nameof(Surname_boss));
            }
            get
            {
                return surname_boss;
            }
        }

        #endregion Boss

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


        #region City
        List<City> list_city = new List<Market.City>();
        public ICollection<City> List_city
        {
            set
            {
                list_city = value.ToList();
                OnPropertyChanged(nameof(List_city));
            }
            get
            {
                return list_city.ToList();
            }
        }


        City select_item_city = new City();
        public City  Select_item_city
        {
            set
            {
                select_item_city = value;
                OnPropertyChanged(nameof(Select_item_city));
                Set_city();
            }
            get
            {
                return select_item_city;
            }
        }


        void Set_city()
        {
            if (select_item_city != null)
                City = select_item_city.Name.ToString();
        }
        #endregion Phone


        #region Country
        List<Country> list_country = new List<Market.Country>();
        public ICollection<Country> List_country
        {
            set
            {
                list_country = value.ToList();
                OnPropertyChanged(nameof(List_country));
            }
            get
            {
                return list_country.ToList();
            }
        }


        Country select_item_country = new Country();
        public Country Select_item_country
        {
            set
            {
                select_item_country = value;
                OnPropertyChanged(nameof(Select_item_country));
                Set_country();
            }
            get
            {
                return select_item_country;
            }
        }


        void Set_country()
        {
            if (select_item_country != null)
                Country = select_item_country.Name.ToString();
        }
        #endregion Country


        #region Adressa
        List<Adressa> list_adressa = new List<Market.Adressa>();
        public ICollection<Adressa> List_adressa
        {
            set
            {
                list_adressa = value.ToList();
                OnPropertyChanged(nameof(List_adressa));
            }
            get
            {
                return list_adressa.ToList();
            }
        }


        Adressa select_item_adressa = new Adressa();
        public Adressa Select_item_adressa
        {
            set
            {
                select_item_adressa = value;
                OnPropertyChanged(nameof(Select_item_adressa));
                Set_adressa();
            }
            get
            {
                return select_item_adressa;
            }
        }


        void Set_adressa()
        {
            if (select_item_adressa != null)
                Adressa = select_item_adressa.Name.ToString();
        }
        #endregion Adressa

        #region Boss
        List<Boss> list_boss = new List<Market.Boss>();
        public ICollection<Boss> List_boss
        {
            set
            {
                list_boss = value.ToList();
                OnPropertyChanged(nameof(List_boss));
            }
            get
            {
                return list_boss.ToList();
            }
        }


        Boss select_item_boss = new Boss();
        public Boss Select_item_boss
        {
            set
            {
                select_item_boss = value;
                OnPropertyChanged(nameof(Select_item_boss));
                Set_boss();
            }
            get
            {
                return select_item_boss;
            }
        }


        void Set_boss()
        {
            if (select_item_boss != null)
            {
                Name_boss = select_item_boss.Name.ToString();
                Surname_boss = select_item_boss.Surname.ToString();
            }
        }
        #endregion Boss

        #endregion List and select

        #endregion Add



        #region Edit

        #region Command button 

        #region Base
        #region 
        private DelegateCommand _Command_New_Phone_edit;
        public ICommand Button_New_Phone_edit
        {
            get
            {
                if (_Command_New_Phone_edit == null)
                {
                    _Command_New_Phone_edit = new DelegateCommand(Execute_New_Phone_edit, CanExecute_New_Phone_edit);
                }
                return _Command_New_Phone_edit;
            }
        }
        private void Execute_New_Phone_edit(object o)
        {

            Phone temp = new Phone();
            temp.Number = Convert.ToString(phone_edit);
            list_phone_edit.Add(temp);
            OnPropertyChanged(nameof(List_phone_edit));

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
        #endregion Base

        #region City
        #region 
        private DelegateCommand _Command_New_City;
        public ICommand Button_New_City
        {
            get
            {
                if (_Command_New_City == null)
                {
                    _Command_New_City = new DelegateCommand(Execute_New_City, CanExecute_New_City);
                }
                return _Command_New_City;
            }
        }
        private void Execute_New_City(object o)
        {

            City temp = new City();
            temp.Name = Convert.ToString(city);
            list_city.Add(temp);
            OnPropertyChanged(nameof(List_city));

        }
        private bool CanExecute_New_City(object o)
        {


            if (city != null && city.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_City;
        public ICommand Button_Delete_City
        {
            get
            {
                if (_Command_Delete_City == null)
                {
                    _Command_Delete_City = new DelegateCommand(Execute_Delete_City, CanExecute_Delete_City);
                }
                return _Command_Delete_City;
            }
        }
        private void Execute_Delete_City(object o)
        {

            list_city.Remove(select_item_city);

            OnPropertyChanged(nameof(List_city));
            Select_item_city = null;
            Phone = null;


        }
        private bool CanExecute_Delete_City(object o)
        {


            if (select_item_city != null)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_city;
        public ICommand Button_Edit_City
        {
            get
            {
                if (_Command_Edit_city == null)
                {
                    _Command_Edit_city = new DelegateCommand(Execute_Edit_city, CanExecute_Edit_city);
                }
                return _Command_Edit_city;
            }
        }
        private void Execute_Edit_city(object o)
        {

            Select_item_city.Name = City;
            OnPropertyChanged(nameof(List_city));


        }
        private bool CanExecute_Edit_city(object o)
        {

            if (select_item_city != null && City.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #endregion City

        #region Country
        #region 
        private DelegateCommand _Command_New_country;
        public ICommand Button_New_country
        {
            get
            {
                if (_Command_New_country == null)
                {
                    _Command_New_country = new DelegateCommand(Execute_New_country, CanExecute_New_country);
                }
                return _Command_New_country;
            }
        }
        private void Execute_New_country(object o)
        {

            Country temp = new Country();
            temp.Name = Convert.ToString(country);
            list_country.Add(temp);
            OnPropertyChanged(nameof(List_country));

        }
        private bool CanExecute_New_country(object o)
        {


            if (country != null && country.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_country;
        public ICommand Button_Delete_country
        {
            get
            {
                if (_Command_Delete_country == null)
                {
                    _Command_Delete_country = new DelegateCommand(Execute_Delete_country, CanExecute_Delete_country);
                }
                return _Command_Delete_country;
            }
        }
        private void Execute_Delete_country(object o)
        {

            list_country.Remove(select_item_country);

            OnPropertyChanged(nameof(List_country));
            Select_item_country = null;
            Country = null;


        }
        private bool CanExecute_Delete_country(object o)
        {


            if (select_item_country != null)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_country;
        public ICommand Button_Edit_country
        {
            get
            {
                if (_Command_Edit_country == null)
                {
                    _Command_Edit_country = new DelegateCommand(Execute_Edit_country, CanExecute_Edit_country);
                }
                return _Command_Edit_country;
            }
        }
        private void Execute_Edit_country(object o)
        {

            Select_item_country.Name = City;
            OnPropertyChanged(nameof(List_country));


        }
        private bool CanExecute_Edit_country(object o)
        {

            if (select_item_country != null && country.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #endregion Country

        #region Adressa
        #region 
        private DelegateCommand _Command_New_adressa;
        public ICommand Button_New_adressa
        {
            get
            {
                if (_Command_New_adressa == null)
                {
                    _Command_New_adressa = new DelegateCommand(Execute_New_adressa, CanExecute_New_adressa);
                }
                return _Command_New_adressa;
            }
        }
        private void Execute_New_adressa(object o)
        {

            Adressa temp = new Market.Adressa();
            temp.Name = Convert.ToString(adressa);
            list_adressa.Add(temp);
            OnPropertyChanged(nameof(List_adressa));

        }
        private bool CanExecute_New_adressa(object o)
        {


            if (adressa != null && adressa.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_adressa;
        public ICommand Button_Delete_adressa
        {
            get
            {
                if (_Command_Delete_adressa == null)
                {
                    _Command_Delete_adressa = new DelegateCommand(Execute_Delete_adressa, CanExecute_Delete_adressa);
                }
                return _Command_Delete_adressa;
            }
        }
        private void Execute_Delete_adressa(object o)
        {

            list_adressa.Remove(select_item_adressa);

            OnPropertyChanged(nameof(List_adressa));
            Select_item_adressa = null;
            Adressa = null;


        }
        private bool CanExecute_Delete_adressa(object o)
        {


            if (select_item_adressa != null)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_adressa;
        public ICommand Button_Edit_adressa
        {
            get
            {
                if (_Command_Edit_adressa == null)
                {
                    _Command_Edit_adressa = new DelegateCommand(Execute_Edit_adressa, CanExecute_Edit_adressa);
                }
                return _Command_Edit_adressa;
            }
        }
        private void Execute_Edit_adressa(object o)
        {

            Select_item_adressa.Name = Adressa;
            OnPropertyChanged(nameof(List_adressa));


        }
        private bool CanExecute_Edit_adressa(object o)
        {

            if (select_item_adressa != null && adressa.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #endregion Adressa

        #region boss
        #region 
        private DelegateCommand _Command_New_boss;
        public ICommand Button_New_boss
        {
            get
            {
                if (_Command_New_boss == null)
                {
                    _Command_New_boss = new DelegateCommand(Execute_New_boss, CanExecute_New_boss);
                }
                return _Command_New_boss;
            }
        }
        private void Execute_New_boss(object o)
        {

            Boss temp = new Market.Boss();
            temp.Name = Convert.ToString(name_boss);
            temp.Surname = Convert.ToString(surname_boss);
            list_boss.Add(temp);
            OnPropertyChanged(nameof(List_boss));

        }
        private bool CanExecute_New_boss(object o)
        {


            if (name_boss != null && name_boss.Length > 0
                && surname_boss != null && surname_boss.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_boss;
        public ICommand Button_Delete_boss
        {
            get
            {
                if (_Command_Delete_boss == null)
                {
                    _Command_Delete_boss = new DelegateCommand(Execute_Delete_boss, CanExecute_Delete_boss);
                }
                return _Command_Delete_boss;
            }
        }
        private void Execute_Delete_boss(object o)
        {

            list_boss.Remove(select_item_boss);

            OnPropertyChanged(nameof(List_boss));
            Select_item_boss = null;
            Name_boss = null;
            Surname_boss = null;


        }
        private bool CanExecute_Delete_boss(object o)
        {


            if (select_item_boss != null)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_boss;
        public ICommand Button_Edit_boss
        {
            get
            {
                if (_Command_Edit_boss == null)
                {
                    _Command_Edit_boss = new DelegateCommand(Execute_Edit_boss, CanExecute_Edit_boss);
                }
                return _Command_Edit_boss;
            }
        }
        private void Execute_Edit_boss(object o)
        {

            Select_item_boss.Name = Name_boss;
            Select_item_boss.Surname = Surname_boss;
            OnPropertyChanged(nameof(List_boss));


        }
        private bool CanExecute_Edit_boss(object o)
        {

            if (select_item_boss != null && name_boss.Length > 0 && surname_boss.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #endregion Adressa

        #endregion Command button




        #region Pole


        #region Phone

        string phone_edit = "";
        public string Phone_edit
        {
            set
            {
                phone_edit = value;
                OnPropertyChanged(nameof(Phone_edit));
            }
            get
            {
                return phone_edit;
            }
        }

        string name_firm_edit = "";
        public string Name_firm_edit
        {
            set
            {
                name_firm_edit = value;
                OnPropertyChanged(nameof(Name_firm_edit));
            }
            get
            {
                return name_firm_edit;
            }
        }


        #endregion Phone 

        #region City

        string city_edit = "";
        public string City_edit
        {
            set
            {
                city_edit = value;
                OnPropertyChanged(nameof(City_edit));
            }
            get
            {
                return city_edit;
            }
        }

        #endregion City


        #region Country

        string country_edit = "";
        public string Country_edit
        {
            set
            {
                country_edit = value;
                OnPropertyChanged(nameof(Country_edit));
            }
            get
            {
                return country_edit;
            }
        }

        #endregion Country

        #region Adressa

        string adressa_edit = "";
        public string Adressa_edit
        {
            set
            {
                adressa_edit = value;
                OnPropertyChanged(nameof(Adressa_edit));
            }
            get
            {
                return adressa_edit;
            }
        }

        #endregion Adressa

        #region Boss

        string name_boss_edit = "";
        public string Name_boss_edit
        {
            set
            {
                name_boss_edit = value;
                OnPropertyChanged(nameof(Name_boss_edit));
            }
            get
            {
                return name_boss_edit;
            }
        }


        string surname_boss_edit;
        public string Surname_boss_edit
        {
            set
            {
                surname_boss_edit = value;
                OnPropertyChanged(nameof(Surname_boss_edit));
            }
            get
            {
                return surname_boss_edit;
            }
        }

        #endregion Boss

        #endregion Pole



        #region List and select


        #region Phone
        List<Phone> list_phone_edit = new List<Market.Phone>();
        public ICollection<Phone> List_phone_edit
        {
            set
            {
                list_phone_edit = value.ToList();
                OnPropertyChanged(nameof(List_phone_edit));
            }
            get
            {
                return list_phone_edit.ToList();
            }
        }


        Phone select_item_phone_edit = new Phone();
        public Phone Select_item_phone_edit
        {
            set
            {
                select_item_phone_edit = value;
                OnPropertyChanged(nameof(Select_item_phone_edit));
                Set_phone_edit();
            }
            get
            {
                return select_item_phone_edit;
            }
        }


        void Set_phone_edit()
        {
            if (select_item_phone_edit != null)
                Phone_edit = select_item_phone_edit.Number.ToString();
        }
        #endregion Phone


        #region City
        List<City> list_city_edit = new List<Market.City>();
        public ICollection<City> List_city_edit
        {
            set
            {
                list_city_edit = value.ToList();
                OnPropertyChanged(nameof(List_city_edit));
            }
            get
            {
                return list_city_edit.ToList();
            }
        }


        City select_item_city_edit = new City();
        public City Select_item_city_edit
        {
            set
            {
                select_item_city_edit = value;
                OnPropertyChanged(nameof(Select_item_city_edit));
                Set_city_edit();
            }
            get
            {
                return select_item_city_edit;
            }
        }


        void Set_city_edit()
        {
            if (select_item_city_edit != null)
                City_edit = select_item_city_edit.Name.ToString();
        }
        #endregion Phone


        #region Country
        List<Country> list_country_edit = new List<Market.Country>();
        public ICollection<Country> List_country_edit
        {
            set
            {
                list_country_edit = value.ToList();
                OnPropertyChanged(nameof(List_country_edit));
            }
            get
            {
                return list_country_edit.ToList();
            }
        }


        Country select_item_country_edit = new Country();
        public Country Select_item_country_edit
        {
            set
            {
                select_item_country_edit = value;
                OnPropertyChanged(nameof(Select_item_country_edit));
                Set_country_edit();
            }
            get
            {
                return select_item_country_edit;
            }
        }


        void Set_country_edit()
        {
            if (select_item_country_edit != null)
                Country_edit = select_item_country_edit.Name.ToString();
        }
        #endregion Country


        #region Adressa
        List<Adressa> list_adressa_edit = new List<Market.Adressa>();
        public ICollection<Adressa> List_adressa_edit
        {
            set
            {
                list_adressa_edit = value.ToList();
                OnPropertyChanged(nameof(List_adressa_edit));
            }
            get
            {
                return list_adressa_edit.ToList();
            }
        }


        Adressa select_item_adressa_edit = new Adressa();
        public Adressa Select_item_adressa_edit
        {
            set
            {
                select_item_adressa_edit = value;
                OnPropertyChanged(nameof(Select_item_adressa_edit));
                Set_adressa_edit();
            }
            get
            {
                return select_item_adressa_edit;
            }
        }


        void Set_adressa_edit()
        {
            if (select_item_adressa_edit != null)
                Adressa_edit = select_item_adressa_edit.Name.ToString();
        }
        #endregion Adressa

        #region Boss
        List<Boss> list_boss_edit = new List<Market.Boss>();
        public ICollection<Boss> List_boss_edit
        {
            set
            {
                list_boss_edit = value.ToList();
                OnPropertyChanged(nameof(List_boss_edit));
            }
            get
            {
                return list_boss_edit.ToList();
            }
        }


        Boss select_item_boss_edit = new Boss();
        public Boss Select_item_boss_edit
        {
            set
            {
                select_item_boss_edit = value;
                OnPropertyChanged(nameof(Select_item_boss_edit));
                Set_boss_edit();
            }
            get
            {
                return select_item_boss_edit;
            }
        }


        void Set_boss_edit()
        {
            if (select_item_boss_edit != null)
            {
                Name_boss_edit = select_item_boss_edit.Name.ToString();
                Surname_boss_edit = select_item_boss_edit.Surname.ToString();
            }
        }
        #endregion Boss

        #endregion List and select

        #endregion Add

    }
}
