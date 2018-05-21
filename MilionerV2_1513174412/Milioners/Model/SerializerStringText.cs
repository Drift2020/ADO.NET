using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Data.SqlClient;
using System.Data;

namespace Milioners
{
    class XMLSerializer : ISerializer
    {



        static string strServer = " ";//"\\SQLVNEXT";
        FileStream stream = null;
        XmlSerializer serializer = null;

        async void CreateDB()
        {
            String str;
            SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

            str = "create database Milion";

            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                await myConn.OpenAsync();
                await myCommand.ExecuteNonQueryAsync();
                myConn.Close();



                myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=milion");
                str = "create table dbo.Questios(Questio nvarchar(255),Answer_1 nvarchar(255),Answer_2 nvarchar(255),Answer_3 nvarchar(255),Answer_4 nvarchar(255))";
                myCommand = new SqlCommand(str, myConn);
                await myConn.OpenAsync();
                await myCommand.ExecuteNonQueryAsync();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }

        public void Save(ICollection<Question> collection)
        {

            SqlConnection connect = new SqlConnection(@"Initial Catalog=Milion;Data Source=(local)"+ strServer + ";Integrated Security=SSPI"); // провайдер SQL
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;

                List<string> listBox1 = new List<string>();
                try
                {
                  
                 
                   
                    command.CommandText = "select  Questio, Answer_1, Answer_2, Answer_3, Answer_4 from Questios";
                    SqlDataReader reader =  command.ExecuteReader();
                    int count = reader.FieldCount;
                    while ( reader.Read())
                    {
                        string res = "", temp = "";
                        for (int i = 0; i < count; i++)
                        {
                            temp = reader[i].ToString();
                            res += temp + "  ";
                        }
                        listBox1.Add(res);
                        res = "";
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    command.Dispose();
                }
                finally
                {
                    command.Dispose();                  
                }

                for (int i = 0; i < collection.Count; i++)
                try
                {
                      

                        bool worc = true;

                        for (int i1 = 0; i1 < listBox1.Count; i1++)
                            if (listBox1[i1].Contains(collection.ToList()[i].Questio))
                            {
                                worc = false;
                               
                            }
                        if(worc)
                        {
                            //command.CommandText = "INSERT INTO Questios ( Questio, Answer_1, Answer_2, Answer_3, Answer_4)VALUES (\'" + collection.ToList()[i].Questio +
                            //   "\',\'" + collection.ToList()[i].Answer_1 +
                            //   "\',\'" + collection.ToList()[i].Answer_2 +
                            //   "\',\'" + collection.ToList()[i].Answer_3 +
                            //   "\',\'" + collection.ToList()[i].Answer_4 + "\')";

                           
                            command = new SqlCommand("Save", connect);
                            command.CommandType = CommandType.StoredProcedure;
                            SqlParameter param = command.Parameters.Add("q", SqlDbType.NVarChar);
                            param.Direction = ParameterDirection.Input;
                            param.Size = 255;
                            param.Value = collection.ToList()[i].Questio;

                            SqlParameter param1 = command.Parameters.Add("a1", SqlDbType.NVarChar);
                            param1.Direction = ParameterDirection.Input;
                            param1.Size = 255;
                            param1.Value = collection.ToList()[i].Answer_1;

                            SqlParameter param2 = command.Parameters.Add("a2", SqlDbType.NVarChar);
                            param2.Direction = ParameterDirection.Input;
                            param2.Size = 255;
                            param2.Value = collection.ToList()[i].Answer_2;

                            SqlParameter param3 = command.Parameters.Add("a3", SqlDbType.NVarChar);
                            param3.Direction = ParameterDirection.Input;
                            param3.Size = 255;
                            param3.Value = collection.ToList()[i].Answer_3;

                            SqlParameter param4 = command.Parameters.Add("a4", SqlDbType.NVarChar);
                            param4.Direction = ParameterDirection.Input;
                            param4.Size = 255;
                            param4.Value = collection.ToList()[i].Answer_4;

                            command.ExecuteNonQuery();
                          
                        }
                }
                catch (Exception ex)
                {
                        command.Dispose();
                        connect.Close();
                }
                finally
                {
                    command.Dispose();
                }
            }
            catch (Exception ex)
            {
                connect.Close();
                command.Dispose();
            }
            finally
            {
                connect.Close();
                command.Dispose();
            }

            //stream = new FileStream("../../list.xml", FileMode.Create);
            //serializer = new XmlSerializer(typeof(List<Question>));
            //serializer.Serialize(stream, collection);
            //stream.Close();
            //Console.WriteLine("Сериализация успешно выполнена!");
        }

        public ICollection<Question> Load()
        {

            #region outputDate
            SqlConnection connect = new SqlConnection(@"Initial Catalog=Milion;Data Source=(local)" + strServer + ";Integrated Security=SSPI"); // провайдер SQL
            SqlCommand command = new SqlCommand();

            List<Question> temp = new List<Question>();
            try
            {
                connect.Open();


                command.Connection = connect;
                command.CommandText = "select  Questio, Answer_1, Answer_2, Answer_3, Answer_4 from Questios";
                SqlDataReader reader = command.ExecuteReader();
                int count = reader.FieldCount;
                while (reader.Read())
                {


                    temp.Add(new Question(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString()));

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                connect.Close();
                command.Dispose();
                return new List<Question>();

            }
            finally
            {
                command.Dispose();
                connect.Close();
            }

           

            return temp;
            #endregion outputDate

            //List<Question> temp;
            //try
            //{
            //    stream = new FileStream("../../list.xml", FileMode.Open);
            //    serializer = new XmlSerializer(typeof(List<Question>));
            //    temp = (List<Question>)serializer.Deserialize(stream);
            //    stream.Close();
            //    return temp;
            //}
            //catch (Exception ex) { };
            //stream.Close();
            //return new List<Question>();
        }


       

    }
}
//bool ferst = true;
//bool truh = false;
//float size = 0f;

//StreamReader sr = new StreamReader("../../Resurses/question.txt", Encoding.Default);
//string line;

//List<Question> tempL = new List<Question>();
//Question tempT = new Question();

//            while ((line = sr.ReadLine()) != null)
//            {
//                if (line.IndexOf("?") == line.Length-1 && ferst)
//                {
//                    ferst = false;
//                    truh = true;
//                    tempT.Questio += line;
//                }
//                else if (!truh)
//                {
//                    tempT.Questio += line;
//                }
//                else if (truh && size == 0f)
//                {
//                    tempT.Answer_1 = line;
//                    size++;
//                }
//                else if (truh && size == 1f)
//                {
//                    tempT.Answer_2 = line;
//                    size++;
//                }
//                else if (truh && size == 2f)
//                {
//                    tempT.Answer_3 = line;
//                    size++;
//                }
//                else if (truh && size == 3f)
//                {
//                    tempT.Answer_4 = line;
//                    tempL.Add(tempT);
//                    tempT = new Question();

//size = 0;
//                    ferst = true;
//                    truh = false;
//                }
//            }
//            sr.Close();
        
//            return tempL;