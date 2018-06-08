using Market.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market
{

    public class View_Index_List : View_Model_Base//, ICloneable
    {
        

        public View_Index_List(Model1 _my)
        {

        }

        public Product _product { get; set; }
       



        public View_Index_List( Product product)
        {
           
            _product = product;
        }


        #region FIRM
        public Firm Firm
        {
            get { return _product.Firm; }
            set
            {
                _product.Firm = value;
                OnPropertyChanged(nameof(Firm));
            }
        }



     
        #endregion FIRM


        #region Product
        public string Name
        {
            get { return _product.Name; }
            set
            {
                _product.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public decimal Price
        {
            get {  
                    foreach(var i in _product.Prices)                       
                    return i.Price1;

                return 0;
                }
            
        }
        public string fio_Person
        {
            get
            {
                foreach (var i in _product.FIO_Person)
                    return i.Surname +" "+ i.Name;

                return "none";
            }

        }
        public DateTime Date
        {
            get
            {
                foreach (var i in _product.Date_of_receipt)
                    return i.Date;

                return new DateTime();
            }

        }
        public string Product_category
        {
            get
            {
                foreach (var i in _product.Product_category)
                    return i.Сategory;

                return "none";
            }

        }
        public DateTime Product_life
        {
            get
            {
                foreach (var i in _product.Product_life)
                    return i.Date;

                return new DateTime();
            }

        }
        public int Сount
        {
            get
            {
                foreach (var i in _product.Counts)
                    return i.Count1;

                return 0;
            }

        }
        public decimal Mark_up
        {
            get
            {
                foreach (var i in _product.Mark_up)
                    return i.Count;

                return 0;
            }

        }
        #endregion Product


    }

}
