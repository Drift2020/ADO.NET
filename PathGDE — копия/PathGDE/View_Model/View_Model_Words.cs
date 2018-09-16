using PathGDE.View_model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PathGDE
{
    class View_Model_Words: View_Model_Base
    {
        Words model;
        public View_Model_Words(Words model)
        {
            this.model = model;
            List_file = model.Prohibited_words.ToList();
        }

        #region Pole
        string word;
        public string Word { get { return word; } set { word = value; } }
        #endregion Pole

        #region Command
        #region Add


        private DelegateCommand _Command_add;

        public ICommand Button_clik_add
        {

            get
            {
                if (_Command_add == null)
                {
                    _Command_add = new DelegateCommand(Execute_add, CanExecute_add);
                }
                return _Command_add;
            }
        }
        private void Execute_add(object o)
        {
            var temp = new Prohibited_words();
            temp.word = word;
            List_file.Add(temp);
            model.Prohibited_words.Add(temp);
            model.SaveChanges();
        }
        private bool CanExecute_add(object o)
        {
            if(word!=null&& word.Length>0)
            return true;
            return false;

        }
        #endregion Add

        #region Del


        private DelegateCommand _Command_del;

        public ICommand Button_clik_del
        {

            get
            {
                if (_Command_del == null)
                {
                    _Command_del = new DelegateCommand(Execute_del, CanExecute_del);
                }
                return _Command_del;
            }
        }
        private void Execute_del(object o)
        {

        }
        private bool CanExecute_del(object o)
        {

            return true;

        }
        #endregion Dell

        #region Clear


        private DelegateCommand _Command_clear;

        public ICommand Button_clik_clear
        {

            get
            {
                if (_Command_clear == null)
                {
                    _Command_clear = new DelegateCommand(Execute_clear, CanExecute_clear);
                }
                return _Command_clear;
            }
        }
        private void Execute_clear(object o)
        {

        }
        private bool CanExecute_clear(object o)
        {

            return true;

        }
        #endregion Clear



        #endregion Command

        #region List
        


        List<Prohibited_words> list_file = new List<Prohibited_words>();
        public ICollection<Prohibited_words> List_file
        {
            set
            {
                list_file = value.ToList();
                OnPropertyChanged(nameof(List_file));
            }
            get
            {
                return list_file;
                // return new ObservableCollection<FileInfo>();
            }
        }
        #endregion List

    }
}
