using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milioners
{


    public interface I_Add_Edit
    {     
        event EventHandler<EventArgs> Quest;
        event EventHandler<EventArgs> NumderQuest;


        string Questio { set; get; }
        string Answer_1 { set; get; }
        string Answer_2 { set; get; }
        string Answer_3 { set; get; }
        string Answer_4 { set; get; }

        int Value { set; get; }
        int Max { set; get; }

        void Acsept_Add();
        void Dont_Add();
        void QuestionEmty_Edit();

        void Acsept_Edit();
        void Dont_Edit();
    }
}
