using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void Save(SqlString q, SqlString a1, SqlString a2, SqlString a3, SqlString a4)
    {
        SqlCommand comm = new SqlCommand("use Milion insert into Questios(Questio,Answer_1,Answer_2,Answer_3,Answer_4) VALUES (\'" + q.ToString() + "\',\'" + a1.ToString() + "\',\'" + a2.ToString() + "\',\'" + a3.ToString() + "\',\'" + a4.ToString() + "\')");
        SqlContext.Pipe.ExecuteAndSend(comm);

        // Put your code here
    }

    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void Delete_Questio(SqlString Questio)
    {
        SqlCommand comm = new SqlCommand("use Milion DELETE FROM Questios where Questio like \'%"+ Questio.ToString()+"%\' ");
        SqlContext.Pipe.ExecuteAndSend(comm);

        // Put your code here
    }

    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void Update_Questio(SqlString Questio_old,SqlString Questio, SqlString Answer_1, SqlString Answer_2, SqlString Answer_3, SqlString Answer_4)
    {
        SqlCommand comm = new SqlCommand("update Questios set Questio = \'" + Questio.ToString() + "\'"+
            ", Answer_1 = \'" + Answer_1.ToString() + "\'"+
            ", Answer_2 = \'" + Answer_2.ToString() + "\'" +
            ", Answer_3 = \'" + Answer_3.ToString() + "\'" +
            ", Answer_4 = \'" + Answer_4.ToString() + "\'" +
            " where Questio like \'" + Questio_old.ToString() + "\' ");
        SqlContext.Pipe.ExecuteAndSend(comm);

        // Put your code here
    }
}
