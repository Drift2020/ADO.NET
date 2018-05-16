using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Media;

namespace Milioners
{
    public delegate void MyDelegate();
    public partial class Form1 : Form, I_Global
    {
        bool win = false;
        bool trueAnsver = false;
        bool lose = false;
        bool secondMenu = false;
        bool isVisibleCall = false;

        bool isFandF = false;

        bool[] isButtonV = { true, true, true, true };

       
        float nowTimeTrueAnsverLose = 0;
        float endTimeTrueAnsverLose = 40;

        float nowTimeWin = 0;
        float endTimeWin = 10;

        float nowTimeCall = 0;
        float endTimeCall = 40;

        float nowTime = 0;
        float EndTime = 40;

        float nowTimeGAME = 0;
        float endTimeGAME = 60;

        float nowTimeHelpRoom = 0;
        float endTimeHelpRoom = 140;
        Color butColor = Color.Red;
        Button ClicNow;
        Button ClicNow2;
        SoundPlayer player = new SoundPlayer("../../Resurses/sound/begin.wav");
      
        int numberQuestion = 0;
        string[] money = new string[]{"100", "200",
            "300", "500", "1000",
            "2000","4000","8000","16000","32000","64000","125000","250000","500000","1000000"};
        public Form1()
        {
            InitializeComponent();

            // public event ElapsedEventHandler Elapsed - это событие происходит по истечении интервала времени
            TimeWindow.Tick += new EventHandler(OnTick);
            TimeColor.Tick += new EventHandler(OnTickColor);
            TimeTrueAnsver.Tick += new EventHandler(OnTickTrue);
            TimeCallHelp.Tick += new EventHandler(OnTickCallHelp);
            TimeHelpRoom.Tick+= new EventHandler(OnTickHelpRoom);
            TimeAnsver.Tick+= new EventHandler(OnTickAnsver);
            TimeAnsver.Interval = 1000;
            TimeWin.Tick += new EventHandler(OnTickWin);
            TimeTrueAnsverLose.Tick += new EventHandler(OnTickTrueAnsverLose);
            // Начинает вызывать событие Elapsed

            if (secondMenu)
            {

            }
            else
            {
                LableWin.Visible = false;
                TimerAnsver.Visible = false;
                Flag.Visible = false;
                Exit.Visible = false;
                Stop.Visible = false;
                CallPictureBox.Visible = false;
                CallLabel.Visible = false;
                HelpBar.Visible = false;
                HelpVariant.Visible = false;
                NumberlistView.Visible = false;
                AnsverPictureBox.Visible = false;
                AnsverLabel.Visible = false;
                QuestTable.Visible = false;
                Ansver_A.Visible = false;
                Ansver_B.Visible = false;
                Ansver_C.Visible = false;
                Ansver_D.Visible = false;
            }

        }

        public event EventHandler<EventArgs> StartGame;
        public event EventHandler<EventArgs> LoseGameE;
        public event EventHandler<EventArgs> ExitGame;
        public event EventHandler<EventArgs> StopGame;
        public event EventHandler<EventArgs> CallHelp;
        public event EventHandler<EventArgs> FiftyOnFifty;
        public event EventHandler<EventArgs> AnsverClick;
        public event EventHandler<EventArgs> UpdateViewQuestion;
        public event EventHandler<EventArgs> ZalHelp;
        ////////////////////////////////////////////////////////////////
        #region pole
        public int FerstFonF { set; get; }
        public int SecondFonF { set; get; }
        public string ShowDialog {set; get;}
        public float NowTime { set { nowTime = value; } get { return nowTime; } }
        public int NumberQuestion { set { numberQuestion = value; } get { return numberQuestion; } }
        public string Ansver_AS { set { Ansver_A.Text = value; } get { return Ansver_A.Text; } }
        public string Ansver_BS { set { Ansver_B.Text = value; } get { return Ansver_B.Text; } }
        public string Ansver_CS { set { Ansver_C.Text = value; } get { return Ansver_C.Text; } }
        public string Ansver_DS { set { Ansver_D.Text = value; } get { return Ansver_D.Text; } }

        public int Ansver_AP { set; get; }
        public int Ansver_BP { set; get; }
        public int Ansver_CP { set; get; }
        public int Ansver_DP { set; get; }

        public string Ansver { set; get; }
        public string Question { set { QuestTable.Text = value; } get { return QuestTable.Text; } }
        public bool Win { set { win = value; } get { return lose; } }
        public bool Lose { set { lose = value; } get { return lose; } }
        public bool AnsverTrue { set { trueAnsver = value; } get { return trueAnsver; } }
        public bool IsFandF { set { isFandF = value; } get { return isFandF; } }   
        public bool StartGameQ { set { secondMenu = value; } get { return secondMenu; } }
        public bool IsCall { set; get; }
        public bool IsStop { set; get; }
        public bool IsHelpRoom { set; get; }
        #endregion pole
        ////////////////////////////////////////////////////////////////
        public void OnTickColor(object sender, EventArgs e)
        {

            if (NowTime >= EndTime)
            {
                NowTime = 0;

                ClicNow.BackColor = Color.Black;
                TimeColor.Stop();
            }
            else if (ClicNow.BackColor == Color.Black)
            {
                ClicNow.BackColor = butColor;
            }
            else
            {
                ClicNow.BackColor = Color.Black;
            }
            
        }
        public void OnTick(object sender, EventArgs e)
        {
            NowTime += 1;

            if (NowTime >= EndTime)
            {
                GroupRoomHelp(false);
                SecondWindow(false);
                AnsverBoxPicture(false, "");
                Start_Window(true);


                TimeWindow.Stop();
            }
        }
        public void OnTickTrue(object sender, EventArgs e)
        {
            NowTime += 1;

            if (NowTime >= EndTime)
            {

                
                AnsverBoxPicture(false, "");

                UpdateViewQuestion?.Invoke(this, EventArgs.Empty);

                SetColorNewElement(numberQuestion);
                AnsverTrue = false;

                nowTimeGAME = 0;
                TimeAnsver.Start();

                TimeTrueAnsver.Stop();
                
            }
        }
        public void OnTickTrueAnsverLose(object sender, EventArgs e)
        {
            nowTimeTrueAnsverLose += 1;
            if(Ansver_A.Text.Contains(Ansver))
            {
                ClicNow2 = Ansver_A;
                if (Ansver_A.BackColor == Color.Black)
                {
                    Ansver_A.BackColor = Color.Green;
                }
                else
                {
                    Ansver_A.BackColor = Color.Black;
                }
            }
            else if (Ansver_B.Text.Contains(Ansver))
            {
                ClicNow2 = Ansver_B;
                if (Ansver_B.BackColor == Color.Black)
                {
                    Ansver_B.BackColor = Color.Green;
                }
                else
                {
                    Ansver_B.BackColor = Color.Black;
                }
            }
            else if (Ansver_D.Text.Contains(Ansver))
            {
                ClicNow2 = Ansver_D;
                if (Ansver_D.BackColor == Color.Black)
                {
                    Ansver_D.BackColor = Color.Green;
                }
                else
                {
                    Ansver_D.BackColor = Color.Black;
                }
            }
            else if (Ansver_C.Text.Contains(Ansver))
            {
                ClicNow2 = Ansver_C;
                if (Ansver_C.BackColor == Color.Black)
                {
                    Ansver_C.BackColor = Color.Green;
                }
                else
                {
                    Ansver_C.BackColor = Color.Black;
                }
            }

            if (nowTimeTrueAnsverLose >= endTimeTrueAnsverLose)
            {
                ClicNow2.BackColor = Color.Black;
                TimeTrueAnsverLose.Stop();
            }
        }

        ////////////////////////////////////////////////////////////////
        public void SetColorNewElement(int number)
        {
            if (number == 14)
            {
                NumberlistView.Items[number].BackColor = Color.Gold;
            }
            else
            {
                NumberlistView.Items[number].BackColor = Color.Gold;
                NumberlistView.Items[number + 1].BackColor = Color.Black;
            }
        }    
        public void Error(string z, string s)
        {
            MessageBox.Show(s, z, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }      
        private void SecondWindow(bool t)
        {
            StartGameQ = t;
            Ansver_A.Visible = t;
            Ansver_B.Visible = t;
            Ansver_C.Visible = t;
            Ansver_D.Visible = t;
            Flag.Visible = t;
            Exit.Visible = t;
            Stop.Visible = t;
            QuestTable.Visible = t;
            FandF.Visible = t;
            HelpCall.Visible = t;
            HelpRoom.Visible = t;
            HelpVariant.Visible = t;
            NumberlistView.Visible = t;
            TimerAnsver.Visible = t;

        }
        ////////////////////////////////////////////////////////////////
        private void LoseGame()
        {
            AnsverBoxPicture(true, "Ответ не верен!");
            butColor = Color.Red;
            TimeWindow.Start();
            TimeColor.Start();

        
            LoseGameE?.Invoke(this, EventArgs.Empty);
            TimeTrueAnsverLose.Start();

            player = new SoundPlayer("../../Resurses/sound/false.wav");
            // player.SoundLocation = "../../sound.wav";
            player.Play();

        }
        private void WinGroup(bool isTrue,string s)
        {
            if(isTrue)
            {
                LableWin.Visible = isTrue;
                LableWin.Text = s;
                pictureBox1.Image= Image.FromFile("../../Resurses/Image/vig.jpg");
            }
            else
            {
                LableWin.Visible = isTrue;
                LableWin.Text = s;
                pictureBox1.Image = Image.FromFile("../../Resurses/Image/mil.jpg");
            }
            
        }
        private void WinGame()
        {
            TimeAnsver.Stop();
            TimeWin.Start();
            WinGroup(true, ("Победа!!! Вы выйграли " + (money[14]) + " белорусских рублей!!!"));
            SecondWindow(false);

        }
        public void OnTickWin(object sender, EventArgs e)
        {
            nowTimeWin += 1;

            if(nowTimeWin>= endTimeWin)
            {
                WinGroup(false,"");
                Start_Window(true);
                nowTimeWin = 0;
                TimeWin.Stop();
            }
        }
        private void TrueAnsver()
        {
            AnsverBoxPicture(true, "Ответ верен!");

            butColor = Color.Green;

            TimeColor.Start();
            TimeTrueAnsver.Start();
            SoundPlayer player = new SoundPlayer("../../Resurses/sound/true.wav");        
            player.Play();

           

        }
        private void AnsverBoxPicture(bool isTrue, string text)
        {
            AnsverPictureBox.Visible = isTrue;
            AnsverLabel.Visible = isTrue;
            AnsverLabel.Text = text;
        }
        ////////////////////////////////////////////////////////////////
        private void Start_Window(bool t)
        {

            Start.Visible = t;
            ExitG.Visible = t;
        }
        private void StartGames(object sender, EventArgs e)
        {
            StartGame?.Invoke(this, EventArgs.Empty);
            if (StartGameQ)
            {
                for (int i = 0; i < 4; i++)
                    isButtonV[0] = false;

                nowTimeTrueAnsverLose = 0;

                Ansver_AP = 0;
                Ansver_BP = 0;
                Ansver_CP = 0;
                Ansver_DP = 0;

                nowTimeCall = 0;
                NowTime = 0;
                nowTimeGAME = 0;
                nowTimeHelpRoom = 0;
               


                player = new SoundPlayer("../../Resurses/sound/gong.wav");
                player.Play();
                nowTimeGAME = 0;

                isFandF = true;
                IsCall = true;
                IsHelpRoom = true;

                win = false;
                lose = false;

                Start_Window(false);
                ZeroProgressBar();
                GroupRoomHelp(false);              
                SecondWindow(true);

                FiftyOnFiftyImage(true);
                HelpRoomImage(true);
                CAllHelpImage(true);
                

                NumberlistView.Clear();
                NumberlistView.View = View.Details;

                ColumnHeader columnHeader1 = new ColumnHeader();
                columnHeader1.TextAlign = HorizontalAlignment.Left;
                columnHeader1.Width = 70;
                ColumnHeader columnHeader2 = new ColumnHeader();
                columnHeader2.TextAlign = HorizontalAlignment.Right;
                columnHeader2.Width = 100;
                NumberlistView.FullRowSelect = true;
                NumberlistView.Columns.Clear();
                NumberlistView.Columns.Add(columnHeader1);
                NumberlistView.Columns.Add(columnHeader2);

                for (int count = 0; count < money.Length; count++)
                {
                    ListViewItem listItem = new ListViewItem((14 - count + 1).ToString());
                    if ((15 - count) % 5 == 0)
                        listItem.ForeColor = Color.Goldenrod;
                    else
                        listItem.ForeColor = Color.Yellow;

                    listItem.SubItems.Add(money[14 - count]);

                    NumberlistView.Items.Add(listItem);
                }
                NumberQuestion = 14;
                SetColorNewElement(NumberQuestion);
             
                TimeAnsver.Start();
            }

        }
        //////////////////////////////////////////////////////////////
        #region ModalDialog
        private void CreatQvest_Click(object sender, EventArgs e)
        {
            Add_Edit Add_Edit_form = new Add_Edit(true);
            P_Add loginPresenter = new P_Add(Add_Edit_form);

            if (Add_Edit_form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Вопрос создан.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Edit_Quest_Click(object sender, EventArgs e)
        {
            Add_Edit Add_Edit_form = new Add_Edit(false);
            P_Edit loginPresenter = new P_Edit(Add_Edit_form);

            DialogResult resalt = Add_Edit_form.ShowDialog();
            if (resalt == DialogResult.OK)
            {
                MessageBox.Show("Вопрос создан.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void Dell_Question_Click(object sender, EventArgs e)
        {
            Dell Dell_form = new Dell();
            P_Dell loginPresenter = new P_Dell(Dell_form);

            if (Dell_form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Вопрос удалён", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion ModalDialog
        //////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////
        #region Exit
        private void Exit_tolbar_Click(object sender, EventArgs e)
        {

        }
        private void Exit_Click(object sender, EventArgs e)
        {
            if (!win && !lose)
            {            
                    Close();
            }

        }
        new void Close()
        {
            DialogResult resalt = MessageBox.Show("Точно хотите выйти?", "Выход", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (resalt == DialogResult.OK)
            {
                base.Close();
            }
        }
        private void Exit_tolbar_Click(object sender, FormClosingEventArgs e)
        {
         
                TimeWindow.Stop();
                TimeColor.Stop();
                TimeHelpRoom.Stop();

                TimeTrueAnsver.Stop();
                TimeCallHelp.Stop();


                ExitGame?.Invoke(this, EventArgs.Empty);
                  
        }
        private void button2_Click(object sender, EventArgs e)
        {
           Close();
        }
        #endregion Exit
        //////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////
        private void AnsverClic(object sender, EventArgs e)
        {
            if (!win && !lose && !trueAnsver)
            {
                TimeAnsver.Stop();

                Button temp = ClicNow = sender as Button;
                Ansver = temp.Text;

                AnsverClick?.Invoke(this, EventArgs.Empty);

                if (win)
                {
                    WinGame();
                }
                else if (lose)
                {                
                    LoseGame();                
                }
                else if (trueAnsver)
                {
                    TrueAnsver();
                    VisibleButtonAnsver(true);
                }
              
            }
        }      

        //////////////////////////////////////////////////////////////
        private void Stop_Click(object sender, EventArgs e)
        {
            if (!win && !lose && !trueAnsver && !IsStop && StartGameQ)
            {
                IsStop = true;
                TimeAnsver.Stop();
              
               

                if(!IsCall)
                {
                    TimeCallHelp.Stop();
                    if(CallPictureBox.Visible == true)
                    {
                        isVisibleCall = true;
                        CallPictureBox.Visible = false;
                        CallLabel.Visible = false;
                    }
                }
                if (!IsFandF)
                {
                  
                }
                if (!IsHelpRoom)
                {                  
                    GroupRoomHelp(false);
                    TimeHelpRoom.Stop();
                }
                player.Stop();
                StopVisible(false);
            }
            else if(!win && !lose && !trueAnsver && IsStop && StartGameQ)
            {
                IsStop = false;
                TimeAnsver.Start();
                StopVisible(true);

                if (!IsCall)
                {
                    TimeCallHelp.Start();
                    if (isVisibleCall == true)
                    {                        
                        CallPictureBox.Visible = false;
                        CallLabel.Visible = false;
                    }
                }
                if (!IsFandF)
                {                                    
                    Ansver_A.Visible=isButtonV[0];
                    Ansver_B.Visible=isButtonV[1];
                    Ansver_C.Visible=isButtonV[2];
                    Ansver_D.Visible=isButtonV[3];
                }
                if(!IsHelpRoom)
                {                 
                    GroupRoomHelp(true);
                    TimeHelpRoom.Start();
                }
            }
        }
        private void StopVisible(bool t)
        {
           
            Ansver_A.Visible = t;
            Ansver_B.Visible = t;
            Ansver_C.Visible = t;
            Ansver_D.Visible = t;
            Flag.Visible = t;
                    
            QuestTable.Visible = t;
            FandF.Visible = t;
            HelpCall.Visible = t;
            HelpRoom.Visible = t;
            HelpVariant.Visible = t;
            NumberlistView.Visible = t;
            TimerAnsver.Visible = t;
        }
        private void Flag_Click(object sender, EventArgs e)
        {
            if (!win && !lose && !trueAnsver)
            {

            }
        }
        //////////////////////////////////////////////////////////////           
        private void VisibleButtonAnsver(bool isTrue)
        {
           
          Ansver_A.Visible = isTrue;            
          Ansver_B.Visible = isTrue;          
          Ansver_C.Visible = isTrue;           
          Ansver_D.Visible = isTrue;
        }
        //////////////////////////////////////////////////////////////
        private void FandF_Click(object sender, EventArgs e)
        {
            if(isFandF)
            {
                FiftyOnFifty?.Invoke(this, EventArgs.Empty);
                switch(FerstFonF)
                {
                    case 0:
                        Ansver_A.Visible = false;
                        break;
                    case 1:
                       Ansver_B.Visible = false;
                        break;
                    case 2:
                        Ansver_C.Visible = false;
                        break;
                    case 3:
                        Ansver_D.Visible = false;
                        break;
                }
                switch (SecondFonF)
                {
                    case 0:
                        Ansver_A.Visible = false;
                        break;
                    case 1:
                        Ansver_B.Visible = false;
                        break;
                    case 2:
                        Ansver_C.Visible = false;
                        break;
                    case 3:
                        Ansver_D.Visible = false;
                        break;
                }
                isButtonV[0] = Ansver_A.Visible;
                isButtonV[1] = Ansver_B.Visible;
                isButtonV[2] = Ansver_C.Visible;
                isButtonV[3] = Ansver_D.Visible;

                FiftyOnFiftyImage(false);
            }           
        }
        private void FiftyOnFiftyImage(bool isTrue)
        {
            if (isTrue)
            {
                FandF.Image = Image.FromFile("../../Resurses/Image/1.jpg");
                isFandF = isTrue;
            }
            else
            {
                FandF.Image = Image.FromFile("../../Resurses/Image/4.jpg");
                isFandF = isTrue;
            }
            SecondFonF = FerstFonF = 5;
        }
        //////////////////////////////////////////////////////////////
        #region Call
        private void HelpCall_Click(object sender, EventArgs e)
        {
            if(IsCall)
            {
                TimeAnsver.Stop();
                CallHelp?.Invoke(this, EventArgs.Empty);

                player = new SoundPlayer("../../Resurses/sound/zvonok.wav");
                player.Play();

                CAllHelpImage(false);
                TimeCallHelp.Start();
                IsCall = false;
            }
        }
        private void CallLableGroup(bool isTrue, string text)
        {
            CallPictureBox.Visible = isTrue;
            CallLabel.Visible = isTrue;
            CallLabel.Text = ("Я думаю это " + text + ".");
        }
        private void CAllHelpImage(bool isTrue)
        {
            if (isTrue)
            {
                HelpCall.Image = Image.FromFile("../../Resurses/Image/2.jpg");

            }
            else
            {
                HelpCall.Image = Image.FromFile("../../Resurses/Image/5.jpg");

            }

        }
        public void OnTickCallHelp(object sender, EventArgs e)
        {
            nowTimeCall += 1;
            if (nowTimeCall >= endTimeCall / 2 && CallPictureBox.Visible == false)
            {
                CallLableGroup(true, Ansver);
            }
            if (nowTimeCall >= endTimeCall)
            {
                TimeAnsver.Start();
                CallLableGroup(false, "");
                TimeCallHelp.Stop();
                
            }
        }
        #endregion Call
        //////////////////////////////////////////////////////////////
        #region HelpRoom
        private void HelpRoomImage(bool isTrue)
        {
            if (isTrue)
            {
                HelpRoom.Image = Image.FromFile("../../Resurses/Image/3.jpg");

            }
            else
            {
                HelpRoom.Image = Image.FromFile("../../Resurses/Image/6.jpg");

            }

        }
        private void HelpRoom_Click(object sender, EventArgs e)
        {
            if(IsHelpRoom)
            {
                HelpRoomImage(false);
                IsHelpRoom = false;
                ZalHelp?.Invoke(this, EventArgs.Empty);

                TimeAnsver.Stop();
                
                GroupRoomHelp(true);
                TimeHelpRoom.Start();
                player = new SoundPlayer("../../Resurses/sound/begin.wav");
                player.Play();
            }
        }
        private void GroupRoomHelp(bool isTrue)
        {
            HelpBar.Visible = isTrue;
        }
        public void OnTickHelpRoom(object sender, EventArgs e)
        {
            nowTimeHelpRoom += 1;

            if(nowTimeHelpRoom<=Ansver_AP)
            {
                progressBar1.Value += 1;
                label1.Text = "A:" + progressBar1.Value + "%";
            }
            if (nowTimeHelpRoom <= Ansver_BP)
            {
                progressBar2.Value += 1;
                label2.Text = "B:" + progressBar2.Value + "%";
            }
            if (nowTimeHelpRoom <= Ansver_CP)
            {
                progressBar3.Value += 1;
                label3.Text = "C:" + progressBar3.Value + "%";
            }
            if (nowTimeHelpRoom <= Ansver_DP)
            {
                progressBar4.Value += 1;
                label4.Text = "D:" + progressBar4.Value + "%";
            }


            if (nowTimeHelpRoom >=  endTimeHelpRoom)
            {
                TimeAnsver.Start();
                player.Stop();
                GroupRoomHelp(false);
                TimeHelpRoom.Stop();
              
            }
           
        }
        private void ZeroProgressBar()
        {
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            progressBar3.Value = 0;
            progressBar4.Value = 0;
        }
        #endregion HelpRoom
        //////////////////////////////////////////////////////////////
        #region TimeGame
        private void OnTickAnsver(object sender, EventArgs e)
        {
            nowTimeGAME += 1;
            TimerAnsver.Text = (60f - nowTimeGAME).ToString();

            if ( nowTimeGAME>= endTimeGAME)
            {
                EndTimeGame();
                TimeAnsver.Stop();
            }
        }
        private void EndTimeGame()
        {
            lose = true;
         
            AnsverBoxPicture(true, "Время закончилось!");
            TimeWindow.Start();
        }
        #endregion TimeGame

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }



}
