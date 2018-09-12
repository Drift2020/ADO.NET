using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work4.CODES
{
    class Class1
    {
        using System;
using System.Threading;
using System.Windows.Forms;
 
namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }

            private void Form1_Load(object sender, EventArgs e)
            {
                for (int i = 0; i < _ThreadHive.Length; i++)
                {
                    _ThreadHive[i] = new Thread(DoStuff);
                    listBox1.Items.Add(_ThreadHive[i]);
                }
            }
            protected override void OnFormClosing(FormClosingEventArgs e)
            {
                for (int i = 0; i < _ThreadHive.Length; i++)
                    _ThreadHive[i].Abort();
                base.OnFormClosing(e);
            }

            private Thread[] _ThreadHive = new Thread[10];
            private Semaphore _Semaphore = new Semaphore(3, 3);

            private void DoStuff()
            {
                _Semaphore.WaitOne();
                Thread.Sleep(5000);
                _Semaphore.Release();
                CallBack(Thread.CurrentThread);
            }

            private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                Thread thread = (Thread)listBox1.SelectedItem;
                if (thread != null)
                {
                    listBox1.Items.Remove(thread);
                    listBox2.Items.Add(thread);
                    thread.Start();
                }
            }

            private void CallBack(Thread thread)
            {
                this.Invoke(new MethodInvoker(() => {
                    listBox2.Items.Remove(thread);
                    listBox3.Items.Add(thread);
                }));
            }

            private System.ComponentModel.IContainer components = null;

            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            private void InitializeComponent()
            {
                this.listBox1 = new System.Windows.Forms.ListBox();
                this.listBox2 = new System.Windows.Forms.ListBox();
                this.listBox3 = new System.Windows.Forms.ListBox();
                this.SuspendLayout();

                this.listBox1.FormattingEnabled = true;
                this.listBox1.Location = new System.Drawing.Point(12, 12);
                this.listBox1.Name = "listBox1";
                this.listBox1.Size = new System.Drawing.Size(120, 238);
                this.listBox1.TabIndex = 0;
                this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);

                this.listBox2.FormattingEnabled = true;
                this.listBox2.Location = new System.Drawing.Point(138, 12);
                this.listBox2.Name = "listBox2";
                this.listBox2.Size = new System.Drawing.Size(120, 238);
                this.listBox2.TabIndex = 0;

                this.listBox3.FormattingEnabled = true;
                this.listBox3.Location = new System.Drawing.Point(264, 12);
                this.listBox3.Name = "listBox3";
                this.listBox3.Size = new System.Drawing.Size(120, 238);
                this.listBox3.TabIndex = 0;

                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(398, 262);
                this.Controls.Add(this.listBox3);
                this.Controls.Add(this.listBox2);
                this.Controls.Add(this.listBox1);
                this.Name = "Form1";
                this.Text = "Form1";
                this.Load += new System.EventHandler(this.Form1_Load);
                this.ResumeLayout(false);

            }

            private System.Windows.Forms.ListBox listBox1;
            private System.Windows.Forms.ListBox listBox2;
            private System.Windows.Forms.ListBox listBox3;

        }
    }
}
}
