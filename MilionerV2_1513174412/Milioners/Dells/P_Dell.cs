using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milioners
{
    class P_Dell 
    {
        Сontainer c = new Сontainer();
        private readonly IDell _view;

        public P_Dell(IDell view)
        {
            c.SetSerializer(new XMLSerializer());
            c.Load();
          
            _view = view;
            _view.Max = c.Count();
            // Презентер подписывается на уведомления о событиях Представления
            _view.Dells += new EventHandler<EventArgs>(OnDell);
            _view.Updete += new EventHandler<EventArgs>(UpdateQuestion);
         
            UpdateView();
        }
        private void UpdateQuestion(object sender, EventArgs e)
        {
            _view.Tex_Question = c.Element(_view.Value - 1).Questio;
        }
        private void OnDell(object sender, EventArgs e)
        {
            // В ответ на изменения в Представлении необходимо изменить Модель         
         

            
            c.Remove(_view.Value-1);
            _view.Max = c.Count();
            c.Save();

            // В данной форме этот вызов не нужен, однако в общем
            // случае изменение части Модели может привести к изменениям
            // в других ее частях. Поэтому необходимо синхронизировать
            // Представление с новым текущим состоянием Модели.
            UpdateView();
        }
        private void UpdateView()
        {
            try {
            _view.Tex_Question = c.Element(_view.Value-1).Questio;
            }
            catch (Exception ex) { _view.Tex_Question = "У вас нет вопросов."; }
        }
      
    }
}
