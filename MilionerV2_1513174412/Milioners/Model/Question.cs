using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Milioners
{
    [Serializable(), XmlInclude(typeof(Question))]
    public class Question : ICloneable
    {
        public object Clone()
        {
            return new Question(question, answer_1, answer_2, answer_3, answer_4);
        }

        string question;
        string answer_1;
        string answer_2;
        string answer_3;
        string answer_4;



       
        public string Questio
        {
            get { return question; }
            set { question = value; }
        }
        public string Answer_1 {
            get { return answer_1; }
            set { answer_1 = value; }
        }
        public string Answer_2
        {
            get { return answer_2; }
            set { answer_2 = value; }
        }
        public string Answer_3
        {
            get { return answer_3; }
            set { answer_3 = value; }
        }
        public string Answer_4
        {
            get { return answer_4; }
            set { answer_4 = value; }
        }
        public Question(string  question, string answer_1, string answer_2, string answer_3, string answer_4)
        {
            this.question = question;
            this.answer_1 = answer_1;
            this.answer_2 = answer_2;
            this.answer_3 = answer_3;
            this.answer_4 = answer_4;
        }
        // для XML-сериализации необходим конструктор по умолчанию
        public Question()
        {
            this.question = "";
            this.answer_1 = "";
            this.answer_2 = "";
            this.answer_3 = "";
            this.answer_4 = "";
        }

        public bool IsCorect()
        {
            return question != "" && answer_1 != "" && answer_2 != "" && answer_3 != "" && answer_4 != "";
          
        }
    }
}
