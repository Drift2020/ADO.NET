using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milioners
{
    public interface ISerializerTask
    {
        void Save(ICollection<Question> collection);
        Task<Question> Load();
    }
}
