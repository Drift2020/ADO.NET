using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Milioners.Model
{
    //class SerializerDB : ISerializerTask
    //{
    //    async void CreateDB()
    //    {
    //        String str;
    //        SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

    //        str = "create database Milion";

    //        SqlCommand myCommand = new SqlCommand(str, myConn);
    //        try
    //        {
    //            await myConn.OpenAsync();
    //            await myCommand.ExecuteNonQueryAsync();

    //            myConn.Close();
    //            myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

    //            str = "CREATE TABLE dbo.Questios(Questio nvarchar(255), Answer_1 nvarchar(255), Answer_2 nvarchar(255), Answer_3 nvarchar(255), Answer_4 nvarchar(255))";

    //            myCommand = new SqlCommand(str, myConn);

    //            await myConn.OpenAsync();
    //            await myCommand.ExecuteNonQueryAsync();
    //        }
    //        catch (System.Exception ex)
    //        {
    //            throw ex;
    //        }
    //        finally
    //        {
    //            if (myConn.State == ConnectionState.Open)
    //            {
    //                myConn.Close();
    //            }
    //        }
    //    }
    //    public async void Save(ICollection<Question> collection)
    //    {
    //        SqlConnection connect = new SqlConnection(@"Initial Catalog=Milion;Data Source=(local);Integrated Security=SSPI");
    //        SqlCommand command = new SqlCommand();
    //        try
    //        {
    //            await connect.OpenAsync();
    //            command.Connection = connect;




    //        }
    //        catch (Exception ex)
    //        {
    //            CreateDB();
    //        }
    //        finally
    //        {
    //            command.Dispose();
    //            connect.Close();
    //        }


    //    }
    //    public async Task<Question> Load()
    //    {

    //        SqlConnection connect = new SqlConnection(@"Initial Catalog=Milion;Data Source=(local);Integrated Security=SSPI");
    //        SqlCommand command = new SqlCommand();

    //        List<Question> temp;

    //        try
    //        {
    //            await connect.OpenAsync();
    //            command.Connection = connect;




    //        }
    //        catch (Exception ex)
    //        {
    //            CreateDB();
    //        }
    //        finally
    //        {
    //            command.Dispose();
    //            connect.Close();
    //        }


    //        return tasktemp;
    //    }
    //}
}
