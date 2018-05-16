using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milioners
{
    public interface ISerializer
    {
        void Save(ICollection<Question> collection);
        ICollection<Question> Load();
    }
}
