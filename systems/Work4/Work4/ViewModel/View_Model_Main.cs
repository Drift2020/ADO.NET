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
          
            s = new Semaphore(1, 0xFFFFF, "My_SEMAPHORE");
            
            My_thread temp = new My_thread(My_Thread);
            _ThreadHive.Add(temp);
            List1.Add(temp);

        
        }
        #region list
        #region 1
        List<My_thread> list1 = new List<My_thread>();
        public ICollection<My_thread> List1
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

        private My_thread list1_SelectedIndex;
      public My_thread List1_SelectedIndex
        {
            get { return list1_SelectedIndex; }
            set { list1_SelectedIndex = value; }
        }

       
     
        #endregion 1

        #region 2
        List<My_thread> list2 = new List<My_thread>();
        public ICollection<My_thread> List2
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

        private My_thread list2_SelectedIndex;
        My_thread List2_SelectedIndex
        {
            get { return list2_SelectedIndex; }
            set { list2_SelectedIndex = value; }
        }
        #endregion 2

        #region 3
        List<My_thread> list3 = new List<My_thread>();
        public ICollection<My_thread> List3
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

        private My_thread list3_SelectedIndex;
        My_thread List3_SelectedIndex
        {
            get { return list1_SelectedIndex; }
            set { list1_SelectedIndex = value; }
        }
        #endregion 3
        bool isDell;
        #endregion

        #region CODE

        private Semaphore s ;
        private List<My_thread> _ThreadHive=new List<My_thread>();

        void SetSemafor(int value)
        {
            
            Semaphore temp = s;
            s = new Semaphore(_numValue, _numValue, "My_SEMAPHORE");
           
        }


        private void My_Thread()
        {
            do
            {
                if (s.WaitOne() && !isDell)
                {
                    CallBack(Thread.CurrentThread);
                    break;
                }
                else
                    s.Release();
            } while (true);
        }


        private void CallBack(Thread thread)
        {
         
            foreach (var i in _ThreadHive)
            {
                if (i.temp.ManagedThreadId == thread.ManagedThreadId)
                {
                    i.isWork = true;
                    List2.Remove(i);
                    OnPropertyChanged(nameof(List2));
                    List3.Add(i);
                    OnPropertyChanged(nameof(List3));              
                    while (i.isWork)
                    {
                        Thread.Sleep(1000);
                        i.Time++;

                    }
                    s.Release();
                   
                    break;
                }
            }
        }

        public void DellThread()
        {

            isDell = true;
            My_thread temp =_ThreadHive.Where(u => u.Time == _ThreadHive.Max(i => i.Time)).Single();
            temp.isWork = false;
         
            temp.temp.Join();
            s.WaitOne();
            List3.Remove(temp);
            _ThreadHive.Remove(temp);
            OnPropertyChanged(nameof(List3));
            
            isDell = false;
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
            if (_numValue < 30)
            {
                s.Release();
                _numValue += 1;
                OnPropertyChanged(nameof(NumValue));
            }
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

           
            DellThread();
           

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
            My_thread temp = new My_thread(My_Thread);
            _ThreadHive.Add(temp);
            List1.Add(temp);
            OnPropertyChanged(nameof(List1));
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

            My_thread thread = list1_SelectedIndex;
            list1_SelectedIndex = null;
            if (thread != null)
            {
                List1.Remove(thread);
                OnPropertyChanged(nameof(List1));
                List2.Add(thread);
                OnPropertyChanged(nameof(List2));
                thread.isWeit = true;


                thread.temp.Start();
                
            }
        }
        private bool CanExecute_List1_SelectedIndexChanged(object o)
        {
            
            return list1_SelectedIndex != null? true: false;
            
        }


        #endregion


        #region Close

        private DelegateCommand _Command_Close;
        public ICommand Window_close
        {
            get
            {
                if (_Command_Close == null)
                {
                    _Command_Close = new DelegateCommand(Execute_window, CanExecute_window);
                }
                return _Command_Close;
            }
        }
        private void Execute_window(object o)
        {
            foreach(var i in _ThreadHive)
            {
                i.temp.Abort();
            }
            s.Close();
            
        }
        private bool CanExecute_window(object o)
        {

            return true;

        }


        #endregion
    }
}

