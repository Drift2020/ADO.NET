using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milioners.Model
{
    class SQL
    {
        void Save()
        {
            SqlConnection connect = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                connect.ConnectionString = (@"Initial Catalog=Milion;Data Source=(local)" + strServer + ";Integrated Security=SSPI"); // провайдер SQL;
                connect.Open();
                cmd = new SqlCommand("Save", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = cmd.Parameters.Add("q", SqlDbType.NVarChar);
                param.Direction = ParameterDirection.Input;
                param.Size = 255;
                param.Value = "hi";

                SqlParameter param1 = cmd.Parameters.Add("a1", SqlDbType.NVarChar);
                param1.Direction = ParameterDirection.Input;
                param1.Size = 255;
                param1.Value = "hi";

                SqlParameter param2 = cmd.Parameters.Add("a2", SqlDbType.NVarChar);
                param2.Direction = ParameterDirection.Input;
                param2.Size = 255;
                param2.Value = "hi";

                SqlParameter param3 = cmd.Parameters.Add("a3", SqlDbType.NVarChar);
                param3.Direction = ParameterDirection.Input;
                param3.Size = 255;
                param3.Value = "hi";

                SqlParameter param4 = cmd.Parameters.Add("a4", SqlDbType.NVarChar);
                param4.Direction = ParameterDirection.Input;
                param4.Size = 255;
                param4.Value = "hi";

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                cmd.Dispose();
                connect.Close();
            }
        }
    }
}
