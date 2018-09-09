using Market.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Work4.ViewModel
{
    class View_Model_Main : View_Model_Base
    {
        public View_Model_Main()
        {
            list_product_edit.Add("non");
            list_product_edit.Add("non");
            list_product_edit.Add("non");
        }
        #region
        List<string> list_product_edit = new List<string>();
        public ICollection<string> List_product_edit
        {
            set
            {
                list_product_edit = value.ToList();
                OnPropertyChanged(nameof(List_product_edit));
            }
            get
            {


                if (list_product_edit != null)
                    return list_product_edit;
                else
                    return null;
            }

        }
        #endregion

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

        private DelegateCommand _Command_up_product;
        public ICommand Button_up_product
        {
            get
            {
                if (_Command_up_product == null)
                {
                    _Command_up_product = new DelegateCommand(Execute_up_product, CanExecute_up_product);
                }
                return _Command_up_product;
            }
        }
        private void Execute_up_product(object o)
        {
            _numValue += 1;
            
        }
        private bool CanExecute_up_product(object o)
        {
            if (_numValue < list_product_edit.Count - 1)
                return true;
            else
                return false;

        }

        #endregion

        #region DOWN

        private DelegateCommand _Command_down_product;
        public ICommand Button_down_product
        {
            get
            {
                if (_Command_down_product == null)
                {
                    _Command_down_product = new DelegateCommand(Execute_down_product, CanExecute_down_product);
                }
                return _Command_down_product;
            }
        }
        private void Execute_down_product(object o)
        {
            _numValue -= 1;
          
        }
        private bool CanExecute_down_product(object o)
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
           

            if (list_product_edit.Count == 0)
            {
                _numValue = 0;

                NumValue = _numValue.ToString();
            }
            else if (_numValue > list_product_edit.Count - 1)
            {

                _numValue -= 1;

                NumValue = _numValue.ToString();
            }
            else
            {

                NumValue = _numValue.ToString();
            }
          
        }

     
        #endregion text 

        #endregion


        #region Button

        private DelegateCommand _Command_button_creature;
        public ICommand Button_creature
        {
            get
            {
                if (_Command_button_creature == null)
                {
                    _Command_button_creature = new DelegateCommand(Execute_up_product, CanExecute_up_product);
                }
                return _Command_button_creature;
            }
        }
        private void Execute_button_creature(object o)
        {
           
        }
        private bool CanExecute_button_creature(object o)
        {          
                return true;       
        }

        #endregion


    }
}
