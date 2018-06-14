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


            list_firm_edit = myBD.Firms.ToList();

            List_adressa_edit = myBD.Adressas.ToList();
            List_boss_edit = myBD.Bosses.ToList();
            List_city_edit = myBD.Cities.ToList();
            List_country_edit = myBD.Countries.ToList();

            if (list_firm_edit.ToList().Count > 0)
            {
                List_phone_edit = list_firm_edit.ToList()[_numValue].Phones.ToList();
                Name_firm_edit = list_firm_edit[_numValue].Name;
            }
        }
        void Set_list()
        {
            List_adressa = myBD.Adressas.ToList();
            List_boss = myBD.Bosses.ToList();
            List_city = myBD.Cities.ToList();
            List_country = myBD.Countries.ToList();


            list_firm_edit = myBD.Firms.ToList();

            List_adressa_edit = myBD.Adressas.ToList();
            List_boss_edit = myBD.Bosses.ToList();
            List_city_edit = myBD.Cities.ToList();
            List_country_edit = myBD.Countries.ToList();

            if (list_firm_edit.ToList().Count > 0)
            {
                List_phone_edit = list_firm_edit.ToList()[_numValue].Phones.ToList();
                Name_firm_edit = list_firm_edit[_numValue].Name;
            }
        }

        #region Add

        #region Command button 

        #region Base
        //#region 
        //private DelegateCommand _Command_New_Phone;
        //public ICommand Button_New_Phone
        //{
        //    get
        //    {
        //        if (_Command_New_Phone == null)
        //        {
        //            _Command_New_Phone = new DelegateCommand(Execute_New_Phone, CanExecute_New_Phone);
        //        }
        //        return _Command_New_Phone;
        //    }
        //}
        //private void Execute_New_Phone(object o)
        //{

        //    Phone temp = new Phone();
        //    temp.Number = Convert.ToString(phone);
        //    list_phone.Add(temp);
        //    myBD.Phones.Add(temp);

        //    myBD.SaveChanges();

        //    OnPropertyChanged(nameof(List_phone));

        //}
        //private bool CanExecute_New_Phone(object o)
        //{


        //    if (phone != null && phone.Length > 0)
        //        return true;
        //    else
        //        return false;


        //}
        //#endregion
        //#region 
        //private DelegateCommand _Command_Delete_Phone;
        //public ICommand Button_Delete_Phone
        //{
        //    get
        //    {
        //        if (_Command_Delete_Phone == null)
        //        {
        //            _Command_Delete_Phone = new DelegateCommand(Execute_Delete_Phone, CanExecute_Delete_Phone);
        //        }
        //        return _Command_Delete_Phone;
        //    }
        //}
        //private void Execute_Delete_Phone(object o)
        //{

        //    list_phone.Remove(select_item_phone);
        //    myBD.Phones.Remove(select_item_phone);
        //    myBD.SaveChanges();

        //    OnPropertyChanged(nameof(List_phone));
        //    Select_item_phone = null;
        //    Phone = null;


        //}
        //private bool CanExecute_Delete_Phone(object o)
        //{


        //    if (select_item_phone != null)
        //        return true;
        //    else
        //        return false;


        //}
        //#endregion
        //#region 
        //private DelegateCommand _Command_Edit_phone;
        //public ICommand Button_Edit_Phone
        //{
        //    get
        //    {
        //        if (_Command_Edit_phone == null)
        //        {
        //            _Command_Edit_phone = new DelegateCommand(Execute_Edit_phone, CanExecute_Edit_phone);
        //        }
        //        return _Command_Edit_phone;
        //    }
        //}
        //private void Execute_Edit_phone(object o)
        //{



        //    var mySTR = Select_item_phone.ID;
        //    var query = (from b in myBD.Phones
        //                 where b.ID == mySTR
        //                 select b).Single();
        //    query.Number = phone;
        //    myBD.SaveChanges();
        //    Select_item_phone.Number = phone;

        //    OnPropertyChanged(nameof (List_phone));


        //}

        //private bool CanExecute_Edit_phone(object o)
        //{

        //    if (select_item_phone != null && Phone.Length>0)
        //        return true;
        //    else
        //        return false;


        //}
        //#endregion
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
            myBD.Cities.Add(temp);
            myBD.SaveChanges();

            Set_list();
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

            myBD.Cities.Remove(select_item_city);
            myBD.SaveChanges();

            OnPropertyChanged(nameof(List_city));
            Select_item_city = null;
            Phone = null;
            Set_list();

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

            var mySTR = Select_item_city.ID;

            var query = (from b in myBD.Cities
                         where b.ID == mySTR
                         select b).Single();
            query.Name = city;
            myBD.SaveChanges();

            Select_item_city.Name = city;
            OnPropertyChanged(nameof(List_city));
            Set_list();

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

            myBD.Countries.Add(temp);
            myBD.SaveChanges();

            Set_list();
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

            myBD.Countries.Remove(select_item_country);
            myBD.SaveChanges();

            Set_list();
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

            var mySTR = Select_item_country.ID;

            var query = (from b in myBD.Countries
                         where b.ID == mySTR
                         select b).Single();
            query.Name = country;
            myBD.SaveChanges();

            Select_item_country.Name = country;
            Set_list();
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
            myBD.Adressas.Add(temp);
            myBD.SaveChanges();
            Set_list();
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
            myBD.Adressas.Remove(select_item_adressa);
            myBD.SaveChanges();
            Set_list();
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

            var mySTR = select_item_adressa.ID;

            var query = (from b in myBD.Adressas
                         where b.ID == mySTR
                         select b).Single();
            query.Name = adressa;
            myBD.SaveChanges();


            Set_list();
            Select_item_adressa.Name = adressa;
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

            myBD.Bosses.Add(temp);
            myBD.SaveChanges();

            list_boss.Add(temp);
            Set_list();
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
            myBD.Bosses.Remove(select_item_boss);
            myBD.SaveChanges();

            Set_list();
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
            var mySTR = Select_item_boss.ID;

            var query = (from b in myBD.Bosses
                         where b.ID == mySTR
                         select b).Single();
            query.Name = name_boss;
            query.Surname = surname_boss;

            myBD.SaveChanges();


            Select_item_boss.Name = Name_boss;
            Select_item_boss.Surname = Surname_boss;
            Set_list();
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

        string phone = "";
        public string Phone
        {
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


        //#region Phone
        //List<Phone> list_phone= new List<Market.Phone>();
        //public ICollection<Phone> List_phone
        //{
        //    set
        //    {
        //        list_phone = value.ToList();
        //        OnPropertyChanged(nameof(List_phone));
        //    }
        //    get
        //    {

        //        return list_phone.ToList();
        //    }
        //}


        //Phone select_item_phone= new Phone();
        //public Phone Select_item_phone
        //{
        //    set
        //    {
        //        select_item_phone = value;
        //        OnPropertyChanged(nameof(Select_item_phone));
        //        Set_phone();
        //    }
        //    get
        //    {
        //        return select_item_phone;
        //    }
        //}


        //void Set_phone()
        //{
        //    if (select_item_phone != null)
        //        Phone = select_item_phone.Number.ToString();
        //    else
        //        Phone = "";
        //}
        //#endregion Phone


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
        public City Select_item_city
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
            else
                City = "";
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
            else
                Country = "";
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
                if (select_item_adressa != null)
                    return select_item_adressa;
                else
                    return new Adressa();
            }
        }


        void Set_adressa()
        {
            if (select_item_adressa != null)
                Adressa = select_item_adressa.Name.ToString();
            else
                Adressa = "";
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
            else
                Name_boss = "";
            Surname_boss = "";
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
            temp.FirmID = list_firm_edit.ToList()[_numValue].ID;

            list_phone_edit.Add(temp);


            myBD.Phones.Add(temp);
            myBD.SaveChanges();
            Set_list();
            OnPropertyChanged(nameof(List_phone_edit));

        }
        private bool CanExecute_New_Phone_edit(object o)
        {


            if (Phone_edit != null && Phone_edit.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_Phone_edit;
        public ICommand Button_Delete_Phone_edit
        {
            get
            {
                if (_Command_Delete_Phone_edit == null)
                {
                    _Command_Delete_Phone_edit = new DelegateCommand(Execute_Delete_Phone_edit, CanExecute_Delete_Phone_edit);
                }
                return _Command_Delete_Phone_edit;
            }
        }
        private void Execute_Delete_Phone_edit(object o)
        {

            list_phone_edit.Remove(select_item_phone_edit);
            list_firm_edit.ToList()[_numValue].Phones.Remove(select_item_phone_edit);

            myBD.Phones.Remove(select_item_phone_edit);
            myBD.SaveChanges();

            Set_list();
            OnPropertyChanged(nameof(List_phone_edit));
            Select_item_phone_edit = null;
            Phone_edit = null;


        }
        private bool CanExecute_Delete_Phone_edit(object o)
        {


            if (select_item_phone_edit != null)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_phone_edit;
        public ICommand Button_Edit_Phone_edit
        {
            get
            {
                if (_Command_Edit_phone_edit == null)
                {
                    _Command_Edit_phone_edit = new DelegateCommand(Execute_Edit_phone_edit, CanExecute_Edit_phone_edit);
                }
                return _Command_Edit_phone_edit;
            }
        }
        private void Execute_Edit_phone_edit(object o)
        {


            var mySTR = Select_item_phone_edit.ID;
            var query = (from b in myBD.Phones
                         where b.ID == mySTR
                         select b).Single();
            query.Number = phone_edit;



            myBD.SaveChanges();

            Select_item_phone_edit.Number = phone_edit;
            Set_list();
            OnPropertyChanged(nameof(List_phone_edit));


        }
        private bool CanExecute_Edit_phone_edit(object o)
        {

            if (select_item_phone_edit != null && Phone_edit!=null && Phone_edit.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #endregion Base

        #region City
        #region 
        private DelegateCommand _Command_New_City_edit;
        public ICommand Button_New_City_edit
        {
            get
            {
                if (_Command_New_City_edit == null)
                {
                    _Command_New_City_edit = new DelegateCommand(Execute_New_City_edit, CanExecute_New_City_edit);
                }
                return _Command_New_City_edit;
            }
        }
        private void Execute_New_City_edit(object o)
        {

            City temp = new City();
            temp.Name = Convert.ToString(city_edit);

            myBD.Cities.Add(temp);
            myBD.SaveChanges();

            list_city_edit.Add(temp);
            Set_list();
            OnPropertyChanged(nameof(List_city_edit));

        }
        private bool CanExecute_New_City_edit(object o)
        {


            if (city_edit != null && city_edit.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_City_edit;
        public ICommand Button_Delete_City_edit
        {
            get
            {
                if (_Command_Delete_City_edit == null)
                {
                    _Command_Delete_City_edit = new DelegateCommand(Execute_Delete_City_edit, CanExecute_Delete_City_edit);
                }
                return _Command_Delete_City_edit;
            }
        }
        private void Execute_Delete_City_edit(object o)
        {

           

            myBD.Cities.Remove(select_item_city_edit);
            list_city_edit.Remove(select_item_city_edit);
            myBD.SaveChanges();
            Set_list();
            OnPropertyChanged(nameof(List_city_edit));
            Select_item_city_edit = null;
            Phone_edit = null;


        }
        private bool CanExecute_Delete_City_edit(object o)
        {


            if (select_item_city_edit != null)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_city_edit;
        public ICommand Button_Edit_City_edit
        {
            get
            {
                if (_Command_Edit_city_edit == null)
                {
                    _Command_Edit_city_edit = new DelegateCommand(Execute_Edit_city_edit, CanExecute_Edit_city_edit);
                }
                return _Command_Edit_city_edit;
            }
        }
        private void Execute_Edit_city_edit(object o)
        {

            var mySTR = Select_item_city_edit.ID;
            var query = (from b in myBD.Cities
                         where b.ID == mySTR
                         select b).Single();
            query.Name = city_edit;
            myBD.SaveChanges();

            Select_item_city_edit.Name = city_edit;
            Set_list();
            OnPropertyChanged(nameof(List_city_edit));


        }
        private bool CanExecute_Edit_city_edit(object o)
        {

            if (select_item_city_edit != null && City_edit.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #endregion City

        #region Country
        #region 
        private DelegateCommand _Command_New_country_edit;
        public ICommand Button_New_country_edit
        {
            get
            {
                if (_Command_New_country_edit == null)
                {
                    _Command_New_country_edit = new DelegateCommand(Execute_New_country_edit, CanExecute_New_country_edit);
                }
                return _Command_New_country_edit;
            }
        }
        private void Execute_New_country_edit(object o)
        {

            Country temp = new Country();
            temp.Name = Convert.ToString(country_edit);
            list_country_edit.Add(temp);

            myBD.Countries.Add(temp);
            myBD.SaveChanges();
            Set_list();
            OnPropertyChanged(nameof(List_country_edit));

        }
        private bool CanExecute_New_country_edit(object o)
        {


            if (country_edit != null && country_edit.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_country_edit;
        public ICommand Button_Delete_country_edit
        {
            get
            {
                if (_Command_Delete_country_edit == null)
                {
                    _Command_Delete_country_edit = new DelegateCommand(Execute_Delete_country_edit, CanExecute_Delete_country_edit);
                }
                return _Command_Delete_country_edit;
            }
        }
        private void Execute_Delete_country_edit(object o)
        {

            list_country_edit.Remove(select_item_country_edit);
            myBD.Countries.Remove(select_item_country_edit);
            myBD.SaveChanges();
            Set_list();
            OnPropertyChanged(nameof(List_country_edit));
            Select_item_country_edit = null;
            Country_edit = null;


        }
        private bool CanExecute_Delete_country_edit(object o)
        {


            if (select_item_country_edit != null)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_country_edit;
        public ICommand Button_Edit_country_edit
        {
            get
            {
                if (_Command_Edit_country_edit == null)
                {
                    _Command_Edit_country_edit = new DelegateCommand(Execute_Edit_country_edit, CanExecute_Edit_country_edit);
                }
                return _Command_Edit_country_edit;
            }
        }
        private void Execute_Edit_country_edit(object o)
        {

            var mySTR = select_item_country_edit.ID;
            var query = (from b in myBD.Countries
                         where b.ID == mySTR
                         select b).Single();
            query.Name = country_edit;
            myBD.SaveChanges();

            Select_item_country_edit.Name = country_edit;
            Set_list();
            OnPropertyChanged(nameof(List_country_edit));


        }
        private bool CanExecute_Edit_country_edit(object o)
        {

            if (select_item_country_edit != null && country_edit.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #endregion Country

        #region Adressa
        #region 
        private DelegateCommand _Command_New_adressa_edit;
        public ICommand Button_New_adressa_edit
        {
            get
            {
                if (_Command_New_adressa_edit == null)
                {
                    _Command_New_adressa_edit = new DelegateCommand(Execute_New_adressa_edit, CanExecute_New_adressa_edit);
                }
                return _Command_New_adressa_edit;
            }
        }
        private void Execute_New_adressa_edit(object o)
        {

            Adressa temp = new Market.Adressa();
            temp.Name = Convert.ToString(adressa_edit);

            list_adressa_edit.Add(temp);
            myBD.Adressas.Add(temp);
            myBD.SaveChanges();
            Set_list();
            OnPropertyChanged(nameof(List_adressa_edit));

        }
        private bool CanExecute_New_adressa_edit(object o)
        {


            if (adressa_edit != null && adressa_edit.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_adressa_edit;
        public ICommand Button_Delete_adressa_edit
        {
            get
            {
                if (_Command_Delete_adressa_edit == null)
                {
                    _Command_Delete_adressa_edit = new DelegateCommand(Execute_Delete_adressa_edit, CanExecute_Delete_adressa_edit);
                }
                return _Command_Delete_adressa_edit;
            }
        }
        private void Execute_Delete_adressa_edit(object o)
        {

            list_adressa_edit.Remove(select_item_adressa_edit);

            myBD.Adressas.Remove(select_item_adressa_edit);
            myBD.SaveChanges();
            Set_list();
            OnPropertyChanged(nameof(List_adressa_edit));
            Select_item_adressa_edit = null;
            Adressa_edit = null;


        }
        private bool CanExecute_Delete_adressa_edit(object o)
        {


            if (select_item_adressa_edit != null)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_adressa_edit;
        public ICommand Button_Edit_adressa_edit
        {
            get
            {
                if (_Command_Edit_adressa_edit == null)
                {
                    _Command_Edit_adressa_edit = new DelegateCommand(Execute_Edit_adressa_edit, CanExecute_Edit_adressa_edit);
                }
                return _Command_Edit_adressa_edit;
            }
        }
        private void Execute_Edit_adressa_edit(object o)
        {
            var mySTR = select_item_adressa_edit.ID;
            var query = (from b in myBD.Adressas
                         where b.ID == mySTR
                         select b).Single();
            query.Name = adressa_edit;
            myBD.SaveChanges();

            Select_item_adressa_edit.Name = adressa_edit;
            Set_list();
            OnPropertyChanged(nameof(List_adressa_edit));


        }
        private bool CanExecute_Edit_adressa_edit(object o)
        {

            if (select_item_adressa_edit != null && adressa_edit.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #endregion Adressa

        #region boss
        #region 
        private DelegateCommand _Command_New_boss_edit;
        public ICommand Button_New_boss_edit
        {
            get
            {
                if (_Command_New_boss_edit == null)
                {
                    _Command_New_boss_edit = new DelegateCommand(Execute_New_boss_edit, CanExecute_New_boss_edit);
                }
                return _Command_New_boss_edit;
            }
        }
        private void Execute_New_boss_edit(object o)
        {

            Boss temp = new Market.Boss();
            temp.Name = Convert.ToString(name_boss_edit);
            temp.Surname = Convert.ToString(surname_boss_edit);
            list_boss_edit.Add(temp);
            myBD.Bosses.Add(temp);
            myBD.SaveChanges();
            Set_list();
            OnPropertyChanged(nameof(List_boss_edit));

        }
        private bool CanExecute_New_boss_edit(object o)
        {


            if (name_boss_edit != null && name_boss_edit.Length > 0
                && surname_boss_edit != null && surname_boss_edit.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Delete_boss_edit;
        public ICommand Button_Delete_boss_edit
        {
            get
            {
                if (_Command_Delete_boss_edit == null)
                {
                    _Command_Delete_boss_edit = new DelegateCommand(Execute_Delete_boss_edit, CanExecute_Delete_boss_edit);
                }
                return _Command_Delete_boss_edit;
            }
        }
        private void Execute_Delete_boss_edit(object o)
        {

            list_boss_edit.Remove(select_item_boss_edit);
            myBD.Bosses.Remove(select_item_boss_edit);
            myBD.SaveChanges();
            Set_list();
            OnPropertyChanged(nameof(List_boss_edit));
            Select_item_boss_edit = null;
            Name_boss_edit = null;
            Surname_boss_edit = null;


        }
        private bool CanExecute_Delete_boss_edit(object o)
        {


            if (select_item_boss_edit != null)
                return true;
            else
                return false;


        }
        #endregion
        #region 
        private DelegateCommand _Command_Edit_boss_edit;
        public ICommand Button_Edit_boss_edit
        {
            get
            {
                if (_Command_Edit_boss_edit == null)
                {
                    _Command_Edit_boss_edit = new DelegateCommand(Execute_Edit_boss_edit, CanExecute_Edit_boss_edit);
                }
                return _Command_Edit_boss_edit;
            }
        }
        private void Execute_Edit_boss_edit(object o)
        {

            var mySTR = select_item_boss_edit.ID;
            var query = (from b in myBD.Bosses
                         where b.ID == mySTR
                         select b).Single();
            query.Name = name_boss_edit;
            query.Surname = surname_boss_edit;
            myBD.SaveChanges();


            Select_item_boss_edit.Name = name_boss_edit;
            Select_item_boss_edit.Surname = surname_boss_edit;
            Set_list();
            OnPropertyChanged(nameof(List_boss_edit));


        }
        private bool CanExecute_Edit_boss_edit(object o)
        {

            if (select_item_boss_edit != null && name_boss_edit.Length > 0 && surname_boss_edit.Length > 0)
                return true;
            else
                return false;


        }
        #endregion
        #endregion Adressa


        #region UpDown
        private int _numValue = 0;

        public string NumValue
        {
            get { return _numValue.ToString(); }
            set
            {


                _numValue = Convert.ToInt32(value);
                OnPropertyChanged(nameof(NumValue));

            }
        }


        #region UP

        private DelegateCommand _Command_up_firm;
        public ICommand Button_up_firm
        {
            get
            {
                if (_Command_up_firm == null)
                {
                    _Command_up_firm = new DelegateCommand(Execute_up_firm, CanExecute_up_firm);
                }
                return _Command_up_firm;
            }
        }
        private void Execute_up_firm(object o)
        {
            _numValue += 1;
            Set_seting();
        }
        private bool CanExecute_up_firm(object o)
        {
            if (_numValue < list_firm_edit.Count - 1)
                return true;
            else
                return false;

        }

        #endregion

        #region DOWN

        private DelegateCommand _Command_down_firm;
        public ICommand Button_down_firm
        {
            get
            {
                if (_Command_down_firm == null)
                {
                    _Command_down_firm = new DelegateCommand(Execute_down_firm, CanExecute_down_firm);
                }
                return _Command_down_firm;
            }
        }
        private void Execute_down_firm(object o)
        {
            _numValue -= 1;
            Set_seting();
        }
        private bool CanExecute_down_firm(object o)
        {
            if (_numValue > 0)
                return true;
            else
                return false;

        }

        #endregion

        #region text

        void Set_seting()
        {
            list_firm_edit = myBD.Firms.ToList();

            if (list_firm_edit.Count == 0)
            {
                _numValue = 0;

                NumValue = _numValue.ToString();
            }
            else if (_numValue > list_firm_edit.Count - 1)
            {

                _numValue -= 1;

                NumValue = _numValue.ToString();
            }
            else
            {

                NumValue = _numValue.ToString();
            }
            Set_select();
        }

        void Set_select()
        {
            if (list_firm_edit[_numValue].Adressas.ToList().Count > 0)
                foreach (var i in list_adressa_edit)
                {
                    if (i.ID == list_firm_edit[_numValue].Adressas.ToList()[0].ID)
                    {
                        Select_item_adressa_edit = i;
                    }
                }


            List_phone_edit = list_firm_edit[_numValue].Phones.ToList();

            if (list_firm_edit[_numValue].Cities.ToList().Count > 0)
                foreach (var i in list_city_edit)
                {
                    if (i.ID == list_firm_edit[_numValue].Cities.ToList()[0].ID)
                    {
                        Select_item_city_edit = i;
                    }
                }

            if (list_firm_edit[_numValue].Countries.ToList().Count > 0)
                foreach (var i in list_country_edit)
                {
                    if (i.ID == list_firm_edit[_numValue].Countries.ToList()[0].ID)
                    {
                        Select_item_country_edit = i;
                    }
                }

            if (list_firm_edit[_numValue].Bosses.ToList().Count > 0)
                foreach (var i in list_boss_edit)
                {
                    if (i.ID == list_firm_edit[_numValue].Bosses.ToList()[0].ID)
                    {
                        Select_item_boss_edit = i;
                    }
                }

            Name_firm_edit = list_firm_edit[_numValue].Name;

        }


        #endregion text 


        #endregion

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
            else
                Phone_edit = "";
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
            else
                City_edit = "";
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
            else
                Country_edit = "";
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
            else
                Adressa_edit = "";
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
            else
            {
                Name_boss_edit = "";
                Surname_boss_edit = "";
            }
        }
        #endregion Boss

        #region Firm list

        List<Firm> list_firm_edit = new List<Market.Firm>();
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
                    return null;
            }

        }




        #endregion Price list

        #endregion List and select

        #endregion Edit



        #region Edit button
        private DelegateCommand _Command_Edit_firm;
        public ICommand Button_edit_firm
        {
            get
            {
                if (_Command_Edit_firm == null)
                {
                    _Command_Edit_firm = new DelegateCommand(Execute_Edit_firm, CanExecute_Edit_firm);
                }
                return _Command_Edit_firm;
            }
        }
        private void Execute_Edit_firm(object o)
        {
            Firm temp = new Firm();
            temp.Name = name_firm_edit;



            foreach (var i in myBD.Phones)
            {
                foreach (var y in list_phone_edit)
                {
                    if (i.FirmID == y.FirmID)
                    {
                        temp.Phones.Add(i);
                        break;
                    }
                }
            }


            temp.Adressas.Add(select_item_adressa_edit);
            //    Select_item_adressa = null;

            temp.Bosses.Add(select_item_boss_edit);
            // Select_item_boss = null;

            temp.Cities.Add(select_item_city_edit);
            //  Select_item_city = null;

            temp.Countries.Add(select_item_country_edit);
            //  Select_item_country = null;

            temp.Name = name_firm_edit;

            var mySTR = myBD.Firms.ToList()[_numValue].ID;
            var query = (from b in myBD.Firms
                         where b.ID == mySTR
                         select b).Single();
            query.Adressas = temp.Adressas;
            query.Bosses = temp.Bosses;
            query.Cities = temp.Cities;
            query.Countries = temp.Countries;
            query.Name = temp.Name;
            query.Phones = temp.Phones;

            myBD.SaveChanges();
            Set_seting();
        }
        private bool CanExecute_Edit_firm(object o)
        {


            if (select_item_adressa_edit != null &&
                select_item_boss_edit != null &&
                select_item_city_edit != null &&
                select_item_country_edit != null &&
                //select_item_phone!= null&&

                name_firm_edit.Length > 0)
                return true;
            else
                return false;


        }
        #endregion Edit button

        #region Add button
        private DelegateCommand _Command_add_firm;
        public ICommand Button_add_firm
        {
            get
            {
                if (_Command_add_firm == null)
                {
                    _Command_add_firm = new DelegateCommand(Execute_add_firm, CanExecute_add_firm);
                }
                return _Command_add_firm;
            }
        }
        private void Execute_add_firm(object o)
        {
            Firm temp = new Firm();
            temp.Name = name_firm;
            Name_firm = "";


            Phone temp_p = new Phone();
            temp_p.Number = Convert.ToString(phone);
            temp_p.Firm = temp;
            temp_p.FirmID = temp.ID;

            myBD.Phones.Add(temp_p);

            temp.Adressas.Add(select_item_adressa);
            Select_item_adressa = null;

            temp.Bosses.Add(select_item_boss);
            Select_item_boss = null;

            temp.Cities.Add(select_item_city);
            Select_item_city = null;

            temp.Countries.Add(select_item_country);
            Select_item_country = null;

            //temp.Phones.Add(select_item_phone);
            //Select_item_phone = null;




            myBD.Firms.Add(temp);
            myBD.SaveChanges();


        }
        private bool CanExecute_add_firm(object o)
        {


            if (select_item_adressa != null &&
                select_item_boss != null &&
                select_item_city != null &&
                select_item_country != null &&
                //select_item_phone!= null&&
                phone.Length > 0 &&
                name_firm.Length > 0)
                return true;
            else
                return false;


        }
        #endregion Add button


        #region Delete button
        private DelegateCommand _Command_delete_firm;
        public ICommand Button_delete_firm
        {
            get
            {
                if (_Command_delete_firm == null)
                {
                    _Command_delete_firm = new DelegateCommand(Execute_delete_firm, CanExecute_delete_firm);
                }
                return _Command_delete_firm;
            }
        }
        private void Execute_delete_firm(object o)
        {
            list_firm_edit.Remove(myBD.Firms.ToList()[_numValue]);


            myBD.Firms.Remove(myBD.Firms.ToList()[_numValue]);

            myBD.SaveChanges();
            Set_seting();

        }
        private bool CanExecute_delete_firm(object o)
        {


            if (myBD.Firms.ToList().Count > 0)
                return true;
            else
                return false;


        }
        #endregion Delete button
    }
    
}
