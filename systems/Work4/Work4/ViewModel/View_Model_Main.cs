using Market.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Work4.ViewModel
{
    class View_Model_Main : View_Model_Base
    {
        public View_Model_Main()
        {
          
            s = new Semaphore(1, 30, "My_SEMAPHORE");

            for (int i = 0; i < _ThreadHive.Length; i++)
            {
                _ThreadHive[i] = new Thread(My_Thread);
                List1.Add(_ThreadHive[i]);
            }

        }
        #region list
        #region 1
        List<Thread> list1 = new List<Thread>();
        public ICollection<Thread> List1
        {
            set
            {
                list1 = value.ToList();
                OnPropertyChanged(nameof(List1));
            }
            get
            {


                if (list1 != null)
                    return list1;
                else
                    return null;
            }

        }

        private Thread list1_SelectedIndex;
      public  Thread List1_SelectedIndex
        {
            get { return list1_SelectedIndex; }
            set { list1_SelectedIndex = value; }
        }

       
     
        #endregion 1

        #region 2
        List<Thread> list2 = new List<Thread>();
        public ICollection<Thread> List2
        {
            set
            {
                list2 = value.ToList();
                OnPropertyChanged(nameof(List2));
            }
            get
            {


                if (list2 != null)
                    return list2;
                else
                    return null;
            }

        }

        private Thread list2_SelectedIndex;
        Thread List2_SelectedIndex
        {
            get { return list2_SelectedIndex; }
            set { list2_SelectedIndex = value; }
        }
        #endregion 2

        #region 3
        List<Thread> list3 = new List<Thread>();
        public ICollection<Thread> List3
        {
            set
            {
                list3 = value.ToList();
                OnPropertyChanged(nameof(List3));
            }
            get
            {


                if (list3 != null)
                    return list3;
                else
                    return null;
            }

        }

        private Thread list3_SelectedIndex;
        Thread List3_SelectedIndex
        {
            get { return list1_SelectedIndex; }
            set { list1_SelectedIndex = value; }
        }
        #endregion 3

        #endregion

        #region CODE

        private Semaphore s ;
        private Thread[] _ThreadHive = new Thread[1];

        void SetSemafor(int value)
        {
            
            Semaphore temp = s;
            s = new Semaphore(_numValue, _numValue, "My_SEMAPHORE");
           
        }


        private void My_Thread()
        {
            
            s.WaitOne();
            Thread.Sleep(200);
            s.Release();
            CallBack(Thread.CurrentThread);
        }


        private void CallBack(Thread thread)
        {
            List2.Remove(thread);
            OnPropertyChanged(nameof(List2));
            List3.Add(thread);
            OnPropertyChanged(nameof(List3));

        }


        #endregion


        #region UpDown


        private int _numValue = 1;

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
            OnPropertyChanged(nameof(NumValue));
        }
        private bool CanExecute_up_product(object o)
        {
           
                return true;
          

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
            OnPropertyChanged(nameof(NumValue));
        }
        private bool CanExecute_down_product(object o)
        {
            if (_numValue > 1)
                return true;
            else
                return false;

        }

        #endregion

        #region text

        //void Set_seting()
        //{
           

        //    if (list_product_edit.Count == 0)
        //    {
        //        _numValue = 0;

        //        NumValue = _numValue.ToString();
        //    }
        //    else if (_numValue > list_product_edit.Count - 1)
        //    {

        //        _numValue -= 1;

        //        NumValue = _numValue.ToString();
        //    }
        //    else
        //    {

        //        NumValue = _numValue.ToString();
        //    }
          
        //}

     
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
                    _Command_button_creature = new DelegateCommand(Execute_button_creature, CanExecute_button_creature);
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

        #region doubleclik

        private DelegateCommand _Command_List1_SelectedIndexChanged;
        public ICommand List1_SelectedIndexChanged
        {
            get
            {
                if (_Command_List1_SelectedIndexChanged == null)
                {
                    _Command_List1_SelectedIndexChanged = new DelegateCommand(Execute_List1_SelectedIndexChanged, CanExecute_List1_SelectedIndexChanged);
                }
                return _Command_List1_SelectedIndexChanged;
            }
        }
        private void Execute_List1_SelectedIndexChanged(object o)
        {

            Thread thread = list1_SelectedIndex;
            list1_SelectedIndex = null;
            if (thread != null)
            {
                List1.Remove(thread);
                OnPropertyChanged(nameof(List1));
                List2.Add(thread);
                OnPropertyChanged(nameof(List2));
                thread.Start();
            }
        }
        private bool CanExecute_List1_SelectedIndexChanged(object o)
        {
            
            return list1_SelectedIndex != null? true: false;
            
        }


        #endregion

    }
}

