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

    
}
