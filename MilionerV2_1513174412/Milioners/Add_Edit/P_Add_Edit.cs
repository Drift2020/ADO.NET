using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milioners
{
    class P_Add
    {
        private readonly Question _model = new Question();
        private readonly I_Add_Edit _view;
        private readonly Сontainer _c = new Сontainer();
        public P_Add(I_Add_Edit view, Сontainer c)
        {
            _c = c;
            _view = view;
            // Презентер подписывается на уведомления о событиях Представления
            _view.Quest += new EventHandler<EventArgs>(OnOkey);
            UpdateView();
        }
        public P_Add(I_Add_Edit view)
        {
          
            _c.SetSerializer(new XMLSerializer());
            _c.Load();

            _view = view;
            // Презентер подписывается на уведомления о событиях Представления
            _view.Quest += new EventHandler<EventArgs>(OnOkey);
            UpdateView();
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
                                           
                _c.Add(new Question(_model.Questio, _model.Answer_1, _model.Answer_2, _model.Answer_3, _model.Answer_4));
                _c.Save();

                _view.Acsept_Add();
            }
            else
            {
                _view.Dont_Add();
            }

            // В данной форме этот вызов не нужен, однако в общем
            // случае изменение части Модели может привести к изменениям
            // в других ее частях. Поэтому необходимо синхронизировать
            // Представление с новым текущим состоянием Модели.
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
