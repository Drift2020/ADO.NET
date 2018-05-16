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

            

                myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=Milion");

                str = "CREATE TABLE dbo.Questios(Questio nvarchar(255), Answer_1 nvarchar(255), Answer_2 nvarchar(255), Answer_3 nvarchar(255), Answer_4 nvarchar(255))";

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


          
            stream = new FileStream("../../list.xml", FileMode.Create);
            serializer = new XmlSerializer(typeof(List<Question>));
            serializer.Serialize(stream, collection);
            stream.Close();
            Console.WriteLine("Сериализация успешно выполнена!");
        }

        public ICollection<Question> Load()
        {
            SqlConnection connect = new SqlConnection(@"Initial Catalog=Milion;Data Source=(local);Integrated Security=SSPI");
            SqlCommand command = new SqlCommand();

         
            try
            {
                connect.Open();
                command.Connection = connect;





            }
            catch (Exception ex)
            {
                CreateDB();
            }
            finally
            {
                command.Dispose();
                connect.Close();
            }


            List<Question> temp;
            try
            {
                stream = new FileStream("../../list.xml", FileMode.Open);
                serializer = new XmlSerializer(typeof(List<Question>));
                temp = (List<Question>)serializer.Deserialize(stream);
                stream.Close();

                return temp;
            }
            catch (Exception ex) { };
            stream.Close();
            return new List<Question>();
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