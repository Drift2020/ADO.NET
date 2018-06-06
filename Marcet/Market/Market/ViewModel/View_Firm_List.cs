using Market.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market
{
    public class View_Firm_List : View_Model_Base
    {

        public Firm _firm;
     

        public View_Firm_List(Firm firm)
        {

            _firm = firm;
        }

        public string Name
        {
            get { return _firm.Name; }
            set
            {
                _firm.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Country
        {
            get {
                
                    foreach (var i in _firm.Countries)
                        return i.Name;

                    return "none";
                
            }
           
        }
        public string City
        {
            get
            {

                foreach (var i in _firm.Cities)
                    return i.Name;

                return "none";

            }

        }
        public string Adress
        {
            get
            {

                foreach (var i in _firm.Adressas)
                    return i.Name;

                return "none";

            }

        }

        public string Phone
        {
            get
            {

                foreach (var i in _firm.Phones)
                    return i.Number;

                return "none";

            }

        }

        public string Boss
        {
            get
            {

                foreach (var i in _firm.Bosses)
                    return i.Surname+" "+i.Name;

                return "none";

            }

        }
    }
}
