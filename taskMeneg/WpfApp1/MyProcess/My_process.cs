using System;
using System.Diagnostics;

namespace MyProcess
{
    public class My_Process
    {
        public My_Process(Process _my)
        {
            my = _my;
        }
        public My_Process()
        {
            my = null;
        }
        public Process my;
    }
}
