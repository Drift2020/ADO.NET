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
            time_str = "Я родился";
            temp = null;
        }
        public My_thread(ThreadStart _temp)
        {
            temp = new Thread(_temp);
            time = 0;
            time_str = "Я родился";
        }

        int time = 0;
        public int Time{
            set
            {
                time = value;
                OnPropertyChanged(nameof(Time));
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

        string time_str="";
        public string Time_str
        {
            set
            {
                time_str = value;
                OnPropertyChanged(nameof(Time_str));
            }
            get
            {
                return "Поток: "+(temp!=null?temp.ManagedThreadId:0) + " "+time_str;
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
    }
}
