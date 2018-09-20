using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    class Date_massege: My_Date

    {
        string name;
        public string Name { get { return name; } set { name = value;  } }
        string time;
        public string Time { get { return time; } set { time = value;  } }
        string message;
        public string Messege
        {
            get { return message; }
            set { message = value;}
        }
    }
}
