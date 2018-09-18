using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace My_TeamViewer
{
    class View_model_translete : View_Model_Base
    {

        #region pole

        Image image_my;
        public Image Image_my
        {
            get
            {
                return image_my;
            }
            set
            {
                image_my = value;
                OnPropertyChanged(nameof(Image_my));
            }
        }


        #endregion pole 

        #region Command

        #region Button disconnect

        private DelegateCommand _Command_button_disconnect;
        public ICommand Button_disconnect
        {
            get
            {
                if (_Command_button_disconnect == null)
                {
                    _Command_button_disconnect = new DelegateCommand(Execute_button_disconnect, CanExecute_button_disconnect);
                }
                return _Command_button_disconnect;
            }
        }
        private void Execute_button_disconnect(object o)
        {

        }
        private bool CanExecute_button_disconnect(object o)
        {

            return false;
        }

        #endregion Button disconnect

        #endregion Command
    }
}
