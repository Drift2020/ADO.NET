using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milioners
{
    public partial class Add_Edit : Form, I_Add_Edit
    {
     

       
        public Add_Edit()
        {
            InitializeComponent();
        }

        public Add_Edit(bool add)
        {
            InitializeComponent();
            if (add)
            {
                NameQuest.Visible = false;
                numericUpDown1.Visible = false;
                this.Text = "Создание вопрос";
                Ok.Text = "Добавить";

            }
            else
            {
                NameQuest.Visible = true;
                numericUpDown1.Visible = true;
                this.Text = "Изменение вопроса";
                Ok.Text = "Изменить";

            }
           
        }


        
        public event EventHandler<EventArgs> Quest;

        public event EventHandler<EventArgs> NumderQuest;

        public string Questio {
            set { textBoxQuestion.Text = value; }
            get { return textBoxQuestion.Text.Trim(); }
        }
        public string Answer_1
        {
            set { textBoxAnswer_1.Text = value; }
            get { return textBoxAnswer_1.Text.Trim(); }
        }
        public string Answer_2
        {
            set { textBoxAnswer_2.Text = value; }
            get { return textBoxAnswer_2.Text.Trim(); }
        }
        public string Answer_3
        {
            set { textBoxAnswer_3.Text = value; }
            get { return textBoxAnswer_3.Text.Trim(); }
        }
        public string Answer_4
        {
            set { textBoxAnswer_4.Text = value; }
            get { return textBoxAnswer_4.Text.Trim(); }
        }

        public int Value
        {
            set { numericUpDown1.Value = value; }
            get { return Int32.Parse(numericUpDown1.Value.ToString()); }
        }
        public int Max {
            set { numericUpDown1.Maximum = value; }
            get { return Int32.Parse(numericUpDown1.Maximum.ToString()); }
        }

        public void Acsept_Add()
        {       
            DialogResult = DialogResult.OK;
        }
        public void Dont_Add()
        {
            MessageBox.Show("Ошибка при заполнении поля.", "Добавление вопроса",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void Acsept_Edit()
        {
            DialogResult = DialogResult.OK;
        }
        public void Dont_Edit()
        {
            MessageBox.Show("Ошибка при заполнении поля.", "Изменение вопроса",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void QuestionEmty_Edit()
        {
            DialogResult = DialogResult.Cancel;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Quest?.Invoke(this, EventArgs.Empty);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            NumderQuest?.Invoke(this, EventArgs.Empty);          
        }

        private void Cansel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
