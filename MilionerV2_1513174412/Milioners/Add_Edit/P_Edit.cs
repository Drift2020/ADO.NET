using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milioners
{
    class P_Edit
    {
        private readonly Question _model = new Question();
        private readonly I_Add_Edit _view;
        private readonly Сontainer _c= new Сontainer();
        
        public P_Edit(I_Add_Edit view, Сontainer c)
        {
            _c = c;
           
            
            _view = view;
            // Презентер подписывается на уведомления о событиях Представления
            _view.Quest += new EventHandler<EventArgs>(OnOkey);
            _view.NumderQuest += new EventHandler<EventArgs>(UpdateNumberQuest);

            _model = c.Element(0).Clone() as Question;
            _view.Max = c.Count();
            UpdateView();
        }
        public P_Edit(I_Add_Edit view)
        {
            _c.SetSerializer(new XMLSerializer());
            _c.Load();

            _view = view;
            // Презентер подписывается на уведомления о событиях Представления
            _view.Quest += new EventHandler<EventArgs>(OnOkey);
            _view.NumderQuest += new EventHandler<EventArgs>(UpdateNumberQuest);

            if (_c.Count() > 0)
            {
                _model = _c.Element(0).Clone() as Question;
                _view.Max = _c.Count();
                UpdateView();
            }             
            else
                _view.QuestionEmty_Edit();

        
        }

        private void OnOkey(object sender, EventArgs e)
        {
            // В ответ на изменения в Представлении необходимо изменить Модель
            _model.Questio = _view.Questio;
            _model.Answer_1 = _view.Answer_1;
            _model.Answer_2 = _view.Answer_2;
            _model.Answer_3 = _view.Answer_3;
            _model.Answer_4 = _view.Answer_4;

            if (_model.IsCorect())
            {
                _c.Element(_view.Value - 1).Questio = _model.Questio;
                _c.Element(_view.Value - 1).Answer_1 = _model.Answer_1 ;
                _c.Element(_view.Value - 1).Answer_2 = _model.Answer_2 ;
                _c.Element(_view.Value - 1).Answer_3 = _model.Answer_3;
                _c.Element(_view.Value - 1).Answer_4 = _model.Answer_4;
              
                _c.Save();
                _view.Acsept_Edit();
            }
            else
            {
                _view.Dont_Edit();
            }

            // В данной форме этот вызов не нужен, однако в общем
            // случае изменение части Модели может привести к изменениям
            // в других ее частях. Поэтому необходимо синхронизировать
            // Представление с новым текущим состоянием Модели.
            UpdateView();
        }
        private void UpdateNumberQuest(object sender, EventArgs e)
        {                    
            Question t = (_c.Element(_view.Value-1).Clone() as Question);
           

            _model.Questio = t.Questio;
            _model.Answer_1 = t.Answer_1;
            _model.Answer_2 = t.Answer_2;
            _model.Answer_3 = t.Answer_3;
            _model.Answer_4 = t.Answer_4;

            UpdateView();
        }
        private void UpdateView()
        {
            _view.Questio = _model.Questio;
            _view.Answer_1 = _model.Answer_1;
            _view.Answer_2 = _model.Answer_2;
            _view.Answer_3 = _model.Answer_3;
            _view.Answer_4 = _model.Answer_4;
        }
    }
}
