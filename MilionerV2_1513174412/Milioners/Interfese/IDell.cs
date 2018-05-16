using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milioners
{
    public interface IDell
    {
        event EventHandler<EventArgs> Dells;
        event EventHandler<EventArgs> Updete;
        string Tex_Question { set; get; }
        int Value { set; get; }
        int Max { set; get; }
        void Acsept_Dell();
    }
}
