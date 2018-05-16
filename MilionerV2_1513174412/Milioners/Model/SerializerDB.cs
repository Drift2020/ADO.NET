using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Milioners.Model
{
    class SerializerDB : ISerializerTask
    {

        public async void Save(ICollection<Question> collection)
        {
            SqlConnection connect = new SqlConnection(@"Initial Catalog=Milion;Data Source=(local);Integrated Security=SSPI");
            SqlCommand command = new SqlCommand();
            try
            {
                await connect.OpenAsync();
                command.Connection = connect;




            }
            catch (Exception ex) {
            };

        }
        public async Task<Question> Load()
        {




            return new List<Question>();
        }
    }
}
