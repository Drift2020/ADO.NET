using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Milioners
{
    class XMLSerializer : ISerializer
    {
        FileStream stream = null;
        XmlSerializer serializer = null;
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