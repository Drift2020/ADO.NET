using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void Save(string q,string a1,string a2, string a3, string a4)
    {
        SqlCommand comm = new SqlCommand("use Milion insert into Questios(Questio,Answer_1,Answer_2,Answer_3,Answer_4) VALUES (\'" + q + "\',\'" + a1 + "\',\'" + a2 + "\',\'" + a3 + "\',\'" + a4 + "\')");
        SqlContext.Pipe.ExecuteAndSend(comm);

        // Put your code here
    }
}
