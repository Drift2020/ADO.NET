using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    [Serializable]
    class User:View_Model_Base, IUser
    {
        string name;
        public string Name { set { name = value; OnPropertyChanged(nameof(Name)); } get { return name; } }
    }
}
