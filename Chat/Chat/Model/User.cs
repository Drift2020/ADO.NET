﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    [Serializable]
    class User: IUser
    {
        string name;
        public string Name { set { name = value; } get { return name; } }
      
    }
}