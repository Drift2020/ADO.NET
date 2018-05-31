
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
        string strServer = "";//"\\SQLVNEXT";
        DataSet dataset = new DataSet();
        
        SqlDataAdapter adapter1 = null, adapter2 = null, adapter3 = null;
        SqlCommandBuilder build1 = null, build2 = null, build3 = null;

       
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
        public async void Update_Questio(string Questio_old,string Questio, string Answer_1, string Answer_2, string Answer_3, string Answer_4)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connect = new SqlConnection(@"Initial Catalog=Milion;Data Source=(local)" + strServer + ";Integrated Security=SSPI"); // провайдер SQL
            try
            {
                await connect.OpenAsync();
                //  Questio, Answer_1, Answer_2, Answer_3, Answer_4
                command = new SqlCommand("Update_Questio", connect);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter param = command.Parameters.Add("Questio_old", SqlDbType.NVarChar);
                param.Direction = ParameterDirection.Input;
                param.Size = 255;
                param.Value = Questio;

                SqlParameter param1 = command.Parameters.Add("Questio", SqlDbType.NVarChar);
                param1.Direction = ParameterDirection.Input;
                param1.Size = 255;
                param1.Value = Questio;

                SqlParameter param2 = command.Parameters.Add("Answer_1", SqlDbType.NVarChar);
                param2.Direction = ParameterDirection.Input;
                param2.Size = 255;
                param2.Value = Answer_1;

                SqlParameter param3 = command.Parameters.Add("Answer_2", SqlDbType.NVarChar);
                param3.Direction = ParameterDirection.Input;
                param3.Size = 255;
                param3.Value = Answer_2;

                SqlParameter param4 = command.Parameters.Add("Answer_3", SqlDbType.NVarChar);
                param4.Direction = ParameterDirection.Input;
                param4.Size = 255;
                param4.Value = Answer_3;

                SqlParameter param5 = command.Parameters.Add("Answer_4", SqlDbType.NVarChar);
                param5.Direction = ParameterDirection.Input;
                param5.Size = 255;
                param5.Value = Answer_4;

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


        public void Delete_Questio_out(string Questio)
        {

            SqlConnection connect = new SqlConnection(@"Initial Catalog=Milion;Data Source=(local)" + strServer + ";Integrated Security=SSPI"); // провайдер SQL
            adapter1 = new SqlDataAdapter("select * from Questios", connect);
            // SqlCommandBuilder автоматически генерирует однотабличные команды, которые позволяют согласовать изменения, вносимые в объект DataSet, с базой данных
            build1 = new SqlCommandBuilder(adapter1); // команды INSERT, UPDATE, DELETE будут сгенерированы автоматически


            DataTable customers = dataset.Tables.Add("Questios");
            //Добавляем столбцы в таблицу
            customers.Columns.Add("ID", typeof(Int32));
            customers.Columns.Add("Questio", typeof(String));
            customers.Columns.Add("Answer_1", typeof(String));
            customers.Columns.Add("Answer_2", typeof(String));
            customers.Columns.Add("Answer_3", typeof(String));
            customers.Columns.Add("Answer_4", typeof(String));

            customers.Constraints.Add("PK_Questios", customers.Columns["ID"], true);
            customers.Columns["ID"].AllowDBNull = false;
            customers.Columns["Questio"].AllowDBNull = true;
            customers.Columns["Answer_1"].AllowDBNull = true;
            customers.Columns["Answer_2"].AllowDBNull = true;
            customers.Columns["Answer_3"].AllowDBNull = true;
            customers.Columns["Answer_4"].AllowDBNull = true;

            adapter1.Fill(dataset, "Questios");
            // Удалим из таблицы запись с указанным номером

            for (int i = 0, len = dataset.Tables["Questios"].Rows[i].ToString().Length; i < len; i++)
            {
                string s = dataset.Tables["Questios"].Rows[i].ItemArray[1].ToString();
                if (String.Compare(dataset.Tables["Questios"].Rows[i].ItemArray[1].ToString(), Questio) == 0)
                {
                    dataset.Tables["Questios"].Rows[i].Delete();
                }
            }

            // Внесем изменения в источник данных
            adapter1.Update(dataset, "Questios");
        }
        public void Update_Questio_out(string Questio_old, string Questio, string Answer_1, string Answer_2, string Answer_3, string Answer_4)
        {
            SqlConnection connect = new SqlConnection(@"Initial Catalog=Milion;Data Source=(local)" + strServer + ";Integrated Security=SSPI"); // провайдер SQL
            adapter1 = new SqlDataAdapter("select * from Questios", connect);
            // SqlCommandBuilder автоматически генерирует однотабличные команды, которые позволяют согласовать изменения, вносимые в объект DataSet, с базой данных
            build1 = new SqlCommandBuilder(adapter1); // команды INSERT, UPDATE, DELETE будут сгенерированы автоматически


            DataTable customers = dataset.Tables.Add("Questios");
            //Добавляем столбцы в таблицу
            customers.Columns.Add("ID", typeof(Int32));
            customers.Columns.Add("Questio", typeof(String));
            customers.Columns.Add("Answer_1", typeof(String));
            customers.Columns.Add("Answer_2", typeof(String));
            customers.Columns.Add("Answer_3", typeof(String));
            customers.Columns.Add("Answer_4", typeof(String));

            customers.Constraints.Add("PK_Questios", customers.Columns["ID"], true);
            customers.Columns["ID"].AllowDBNull = false;
            customers.Columns["Questio"].AllowDBNull = true;
            customers.Columns["Answer_1"].AllowDBNull = true;
            customers.Columns["Answer_2"].AllowDBNull = true;
            customers.Columns["Answer_3"].AllowDBNull = true;
            customers.Columns["Answer_4"].AllowDBNull = true;

            adapter1.Fill(dataset, "Questios");
            // Удалим из таблицы запись с указанным номером

            for (int i = 0, len = dataset.Tables["Questios"].Rows[i].ToString().Length; i < len; i++)
            {
               
                if (String.Compare(dataset.Tables["Questios"].Rows[i].ItemArray[1].ToString(), Questio_old) == 0)
                {
                    dataset.Tables["Questios"].Rows[i].ItemArray[1]=Questio;
                    dataset.Tables["Questios"].Rows[i].ItemArray[2] = Answer_1;
                    dataset.Tables["Questios"].Rows[i].ItemArray[3] = Answer_2;
                    dataset.Tables["Questios"].Rows[i].ItemArray[4] = Answer_3;
                    dataset.Tables["Questios"].Rows[i].ItemArray[5] = Answer_4;
                }
            }

            // Внесем изменения в источник данных
            adapter1.Update(dataset, "Questios");
        }
        public void Add_Questio_out(string Questio, string Answer_1, string Answer_2, string Answer_3, string Answer_4)
        {

        }
    }
}
