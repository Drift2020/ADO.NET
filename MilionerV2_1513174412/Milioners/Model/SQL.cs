
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milioners
{
   
   public class SQL
    {
        string strServer = "";
        public async void Delete_Questio(string Questio)
        {
            
            SqlCommand command = new SqlCommand();
            SqlConnection connect = new SqlConnection(@"Initial Catalog=Milion;Data Source=(local)" + strServer + ";Integrated Security=SSPI"); // провайдер SQL
            try
            {
                await connect.OpenAsync();

                command = new SqlCommand("Delete_Questio", connect);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param = command.Parameters.Add("Questio", SqlDbType.NVarChar);
                param.Direction = ParameterDirection.Input;
                param.Size = 255;
                param.Value = Questio;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (connect != null)
                    connect.Close();
                if (command != null)
                    command.Dispose();
            }
        }
        public async void Update_Questio(string Questio, string Answer_1, string Answer_2, string Answer_3, string Answer_4)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connect = new SqlConnection(@"Initial Catalog=Milion;Data Source=(local)" + strServer + ";Integrated Security=SSPI"); // провайдер SQL
            try
            {
                await connect.OpenAsync();
                //  Questio, Answer_1, Answer_2, Answer_3, Answer_4
                command = new SqlCommand("Update_Questio", connect);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param = command.Parameters.Add("Questio", SqlDbType.NVarChar);
                param.Direction = ParameterDirection.Input;
                param.Size = 255;
                param.Value = Questio;

                SqlParameter param1 = command.Parameters.Add("Answer_1", SqlDbType.NVarChar);
                param1.Direction = ParameterDirection.Input;
                param1.Size = 255;
                param1.Value = Answer_1;

                SqlParameter param2 = command.Parameters.Add("Answer_2", SqlDbType.NVarChar);
                param2.Direction = ParameterDirection.Input;
                param2.Size = 255;
                param2.Value = Answer_2;

                SqlParameter param3 = command.Parameters.Add("Answer_3", SqlDbType.NVarChar);
                param3.Direction = ParameterDirection.Input;
                param3.Size = 255;
                param3.Value = Answer_3;

                SqlParameter param4 = command.Parameters.Add("Answer_4", SqlDbType.NVarChar);
                param4.Direction = ParameterDirection.Input;
                param4.Size = 255;
                param4.Value = Answer_4;

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (connect != null)
                    connect.Close();
                if (command != null)
                    command.Dispose();
            }
        }
    }
}
