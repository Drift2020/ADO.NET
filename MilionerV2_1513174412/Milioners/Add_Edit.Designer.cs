namespace Milioners
{
    partial class Add_Edit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxQuestion = new System.Windows.Forms.TextBox();
            this.textBoxAnswer_1 = new System.Windows.Forms.TextBox();
            this.textBoxAnswer_2 = new System.Windows.Forms.TextBox();
            this.textBoxAnswer_3 = new System.Windows.Forms.TextBox();
            this.textBoxAnswer_4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Ok = new System.Windows.Forms.Button();
            this.Cansel = new System.Windows.Forms.Button();
            this.NameQuest = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxQuestion
            // 
            this.textBoxQuestion.Location = new System.Drawing.Point(26, 43);
            this.textBoxQuestion.Name = "textBoxQuestion";
            this.textBoxQuestion.Size = new System.Drawing.Size(231, 20);
            this.textBoxQuestion.TabIndex = 0;
            // 
            // textBoxAnswer_1
            // 
            this.textBoxAnswer_1.Location = new System.Drawing.Point(26, 108);
            this.textBoxAnswer_1.Name = "textBoxAnswer_1";
            this.textBoxAnswer_1.Size = new System.Drawing.Size(231, 20);
            this.textBoxAnswer_1.TabIndex = 1;
            // 
            // textBoxAnswer_2
            // 
            this.textBoxAnswer_2.Location = new System.Drawing.Point(26, 170);
            this.textBoxAnswer_2.Name = "textBoxAnswer_2";
            this.textBoxAnswer_2.Size = new System.Drawing.Size(231, 20);
            this.textBoxAnswer_2.TabIndex = 2;
            // 
            // textBoxAnswer_3
            // 
            this.textBoxAnswer_3.Location = new System.Drawing.Point(26, 230);
            this.textBoxAnswer_3.Name = "textBoxAnswer_3";
            this.textBoxAnswer_3.Size = new System.Drawing.Size(231, 20);
            this.textBoxAnswer_3.TabIndex = 3;
            // 
            // textBoxAnswer_4
            // 
            this.textBoxAnswer_4.Location = new System.Drawing.Point(26, 287);
            this.textBoxAnswer_4.Name = "textBoxAnswer_4";
            this.textBoxAnswer_4.Size = new System.Drawing.Size(231, 20);
            this.textBoxAnswer_4.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Введите вопрос:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Введите первый вариант ответа(правильный):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Введите второй вариант ответа:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Введите третий вариант ответа:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Введите четвёртый вариант ответа";
            // 
            // Ok
            // 
            this.Ok.Location = new System.Drawing.Point(26, 337);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(89, 40);
            this.Ok.TabIndex = 10;
            this.Ok.Text = "Добавить";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.button1_Click);
            // 
            // Cansel
            // 
            this.Cansel.Location = new System.Drawing.Point(168, 337);
            this.Cansel.Name = "Cansel";
            this.Cansel.Size = new System.Drawing.Size(89, 40);
            this.Cansel.TabIndex = 11;
            this.Cansel.Text = "Отмена";
            this.Cansel.UseVisualStyleBackColor = true;
            this.Cansel.Click += new System.EventHandler(this.Cansel_Click);
            // 
            // NameQuest
            // 
            this.NameQuest.AutoSize = true;
            this.NameQuest.Location = new System.Drawing.Point(69, 4);
            this.NameQuest.Name = "NameQuest";
            this.NameQuest.Size = new System.Drawing.Size(89, 13);
            this.NameQuest.TabIndex = 13;
            this.NameQuest.Text = "Номер вопроса:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(154, 2);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(74, 20);
            this.numericUpDown1.TabIndex = 14;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // Add_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(286, 430);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.NameQuest);
            this.Controls.Add(this.Cansel);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxAnswer_4);
            this.Controls.Add(this.textBoxAnswer_3);
            this.Controls.Add(this.textBoxAnswer_2);
            this.Controls.Add(this.textBoxAnswer_1);
            this.Controls.Add(this.textBoxQuestion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Add_Edit";
            this.Text = "Add_Edit";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxQuestion;
        private System.Windows.Forms.TextBox textBoxAnswer_1;
        private System.Windows.Forms.TextBox textBoxAnswer_2;
        private System.Windows.Forms.TextBox textBoxAnswer_3;
        private System.Windows.Forms.TextBox textBoxAnswer_4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.Button Cansel;
        private System.Windows.Forms.Label NameQuest;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}