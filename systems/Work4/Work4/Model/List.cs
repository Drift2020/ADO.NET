using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Work4
{
    class My_thread:ViewModel.View_Model_Base
    {
        public My_thread()
        {
            time = 0;
          
            temp = null;
        }
        public My_thread(ThreadStart _temp)
        {
            temp = new Thread(_temp);
            time = 0;
           
        }

        int time = 0;
        public int Time{
            set
            {
                time = value;
                OnPropertyChanged(nameof(Time));
                OnPropertyChanged(nameof(Time_str));
            }
            get
            {
                return time;
            }
        }

        public bool isWork
        {
            get;set;
        }
        public bool isWeit
        {
            get; set;
        }


        string time_str;
        public string Time_str
        {
            set
            {
                time_str = value;
                  OnPropertyChanged(nameof(Time_str));
            }
            get
            {
              
                if (isWork)
                    return "Поток: " + temp.ManagedThreadId + " " + "Я работаю уже: " + time +" сек." ;
                else if (!isWeit)
                    return "Поток: " + temp.ManagedThreadId+ " "+ "Я родился";
                else if (isWeit)
                    return "Поток: " + temp.ManagedThreadId + " " + "Я жду";
                return "7 дней...";
                
            }
        }

        public Thread temp;
        public Thread Temp
        {
            set
            {
                temp = value;
                OnPropertyChanged(nameof(Temp));
            }
            get
            {
                return temp;
            }
        }

        public CancellationTokenSource tokenSource = new CancellationTokenSource();
    }
}
