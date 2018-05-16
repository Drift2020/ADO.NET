using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Milioners
{


    [Serializable(), XmlInclude(typeof(Question))]
    public class Сontainer
    {
      
        List<Question> ques = new List<Question>();

        ISerializer serialize;
        public Сontainer() { }
        public void SetSerializer(ISerializer serialize)
        {
            this.serialize = serialize;
           
        }
      
        public void Add(Question question)
        {
            this.ques.Add(question);
          //  log.Write("Данные успешно добавлены!");
        }
        public void Remove(int index)
        {
            if (index < 0 || index >= ques.Count)
                return;
            ques.RemoveAt(index);
           // log.Write("Удаление успешно выполнено!");
        }

        public void RemoveAll()
        {
            ques.RemoveRange(0, ques.Count);
           // log.Write("Все данные успешно удалены!");
        }
        public void Save()
        {
            serialize.Save(ques);
          //  log.Write("Сериализация успешно выполнена!");
        }
        public void Load()
        {
            ques = serialize.Load() as List<Question>;
          //  log.Write("Десериализация успешно выполнена!");
        }
       public Question Element (int index)
       {
                return ques[index];       
       }
        public int Count()
        {
            return ques.Count;
        }
        //public void Print()
        //{
        //    foreach (Question j in ques)
        //    {
        //      //  log.Write( );
        //    }
        //}

    }
}

