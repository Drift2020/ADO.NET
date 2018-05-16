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
    public partial class Dell : Form , IDell
    {
        public Dell()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> Dells;
        public event EventHandler<EventArgs> Updete;

        public string Tex_Question
        {
            set { textBox1.Text = value; }
            get { return textBox1.Text; }
        }
        public int Value
        {
            set { NumberQuestion.Value = value; }
            get { return Int32.Parse(NumberQuestion.Value.ToString()); }
        }
        public int Max
        {
            set { NumberQuestion.Maximum = value; }
            get { return Int32.Parse(NumberQuestion.Maximum.ToString()); }
        }

        public void Acsept_Dell()
        {
            DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if( DialogResult.OK == MessageBox.Show("Хотите удалить этот вопрос?", "Удаление вопроса",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            Dells?.Invoke(this, EventArgs.Empty);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Updete?.Invoke(this, EventArgs.Empty);
        }

        
    }
}
//return MessageBox.Show("Хотите удалить этот вопрос?", "Удаление вопроса",
  //                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question);