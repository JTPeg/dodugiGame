using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Drawing.Text;
using static System.Windows.Forms.AxHost;
using System.Xml.Linq;
using System.Reflection;
using System.Diagnostics;

namespace basicUI
{

    public partial class GameWindow : Form
    {
        //@leader board만들때 쓸것
        event EventHandler e;
        private readonly object _lockObject = new object();
        private int score = 0;
        private bool isGameStarted = false;     // 게임 시작했는지 확인
        Image emptyHole, dodugiHole, heart, brokenheart, hammer;    // 이미지 선언을 여기서
        bool[] clickedFlags = new bool[9]; // 버튼이 망치인지 두더지인지 구분하기 위한 변수

        List<Button> buttons;
        List<PictureBox> Hearts;
        List<System.Windows.Forms.Timer> timers;

        const int INITNHEARTS = 3;
        private int nHearts;

        public int Score
        {
            get { return score; }
            set {  }
        }


        // timer 객체와 각 버튼 활성화 스레드 공유 랜덤 객체를 global하게 생성
        Random rand = new Random();

        public GameWindow()
        {
            InitializeComponent();
            InitializeImages();
            InitializeButtons();
            InitializeHearts();
            InitializeTimers();
            InitializeClickedFlags();
        }
        private void InitializeImages()     // resource 폴더 안의 이미지 가져옴
        {
            string basePath = Path.Combine(Application.StartupPath, @"..\..\resource");

            emptyHole = new Bitmap(Image.FromFile(Path.Combine(basePath, "emptyHole.png")), 150, 135);
            dodugiHole = new Bitmap(Image.FromFile(Path.Combine(basePath, "dodugiHole.png")), 150, 135);
            hammer = new Bitmap(Image.FromFile(Path.Combine(basePath, "hammer.png")), 150, 135);
            heart = new Bitmap(Image.FromFile(Path.Combine(basePath, "heart.png")), 100, 100);
            brokenheart = new Bitmap(Image.FromFile(Path.Combine(basePath, "brokenheart.png")), 100, 100);
        }

        //value를 받아 score에 더함, 이후 label 업데이트
        private void addScore(int value)
        {
            lock (_lockObject) // 이 블록은 한 스레드만 접근 가능
            {
                score += value;
                lblScoreValue.Text = score.ToString();
            }

        }

        private void InitializeButtons()
        {
            buttons = new List<Button>
            {
                button1, button2, button3,
                button4, button5, button6,
                button7, button8, button9
            };

            int btnSize = 125;      // 버튼 그림 크기
            int startX = 150, startY = 60;  // 첫번째 버튼의 X, Y좌표
            int gapX = 110, gapY = 35;      // 버튼 간 간격

            for (int i = 0; i < buttons.Count; i++)
            {
                var btn = buttons[i];
                btn.Size = new Size(btnSize, btnSize);

                int row = i / 3, col = i % 3;   // 행렬로 구분
                btn.Location = new Point(
                    startX + col * (btnSize + gapX),
                    startY + row * (btnSize + gapY)
                );

                btn.Image = emptyHole;      // 버튼 현재상태 초기화
                btn.Tag = "emptyHole";
            }
        }
        private void InitializeHearts()
        {
            //초기 하트를 늘릴려면 여기서 추가해줄것
            try
            {
                Hearts = new List<PictureBox> { ptHeart1, ptHeart2, ptHeart3 };
                nHearts = INITNHEARTS;
                if (Hearts.Count != INITNHEARTS) throw new Exception("초기하트개수와 실제 리스트내 하트개수가 다르다.");
                PrintHearts(Hearts.Count);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                this.DialogResult = DialogResult.Abort;
            }


        }

        private void InitializeClickedFlags() // 버튼 그림 구분 변수 초기화
        {
            for (int i = 0; i < 9; i++)
            {
                clickedFlags[i] = false;
            }
        }

        //입력으로 받은 n만큼 정상적인 하트를 출력하고 나머지는 broken hearts로 출력
        private void PrintHearts(int n)
        {
            const int heartSize = 70;   // 하트 그림 크기
            const int startX = 30;    // 첫 번째 하트의 X좌표
            const int y = 520;    // 하트의 Y좌표
            const int gap = 15;    // 하트 간 가로 간격
            try
            {
                if (n > INITNHEARTS) throw new InvalidOperationException("출력할 하트의 수가 초기하트개수보다 많음");
                int i = 0;
                for (i = 0; i < n; i++)
                {
                    var pic = Hearts[i];
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Size = new Size(heartSize, heartSize);
                    pic.Location = new Point(
                        startX + i * (heartSize + gap),
                        y
                    );
                    pic.Image = heart;
                    // 나중에 Hearts[index].Image = brokenheart로  PictureBox의 Image만 바꾸면 깨진 하트로 전환가능
                }
                for (; i < Hearts.Count; i++)
                {
                    var pic = Hearts[i];
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Size = new Size(heartSize, heartSize);
                    pic.Location = new Point(
                        startX + i * (heartSize + gap),
                        y
                    );
                    pic.Image = brokenheart;
                }
            }
            catch (InvalidOperationException e)
            {
                System.Console.WriteLine(e.Message);
                this.DialogResult = DialogResult.Abort;
            }




        }

        private void InitializeTimers()
        {
            timers = new List<System.Windows.Forms.Timer>();
            timers.Add(timer1);
            timers.Add(timer2);
            timers.Add(timer3);
            timers.Add(timer4);
            timers.Add(timer5);
            timers.Add(timer6);
            timers.Add(timer7);
            timers.Add(timer8);
            timers.Add(timer9);

            for (int i = 0; i < timers.Count; ++i)
            {
                timers[i].Interval = rand.Next(1000, 5000); // 1초에서 5초 사이 랜덤 인터벌 설정
                timers[i].Tick += Timers_Tick;  // 공통 Tick 이벤트 핸들러 연결
            }
        }


        //주영님이 하시는걸로...
        private void Timers_Tick(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer tmr = sender as System.Windows.Forms.Timer;
            tmr.Stop(); // btn에 대한 조작 중에는 tmr을 정지
            for (int i = 0; i < timers.Count; ++i)
            {
                if (tmr == timers[i])
                {
                    int index = i;
                    Thread utilizerThread = new Thread(() => btnUtilizer(index));
                    Thread unutilizerThread = new Thread(() => btnUnUtilizer(index));

                    utilizerThread.IsBackground = true;     // 해당 스레드들이 프로세스 종료 시 같이 종료하도록 설정
                    unutilizerThread.IsBackground = true;

                    utilizerThread.Start();
                    unutilizerThread.Start();

                    break;
                }
            }
        }

        private void btnUtilizer(int index)    // btnUtilizer의 매개변수 수정
        {
            //얘를 멀티쓰레드로 돌려요
            //btnUnUtilizer(sender, e);
            if (buttons[index].InvokeRequired)  // main thread면 true, main thread면 false
            {
                buttons[index].Invoke(new Action(() =>
                {
                    buttons[index].Image = dodugiHole;
                    buttons[index].Tag = "dodugiHole";
                }));
            }
            else
            {
                buttons[index].Image = dodugiHole;
                buttons[index].Tag = "dodugiHole";
            }
        }

        private void btnUnUtilizer(int index)   // btnUnutilizer 매개변수 수정
        {
            Thread.Sleep(2000);
            if (clickedFlags[index]) return;
            
                if (buttons[index].InvokeRequired)      // main thread면 true, main thread면 false
            {
                buttons[index].Invoke(new Action(() =>
                {
                    buttons[index].Image = emptyHole;
                    buttons[index].Tag = "emptyHole";

                    timers[index].Start();
                }));
            }
            else
            {
                buttons[index].Image = emptyHole;
                buttons[index].Tag = "emptyHole";

                timers[index].Start();
            }
        }

        private void btnGameStart_Click(object sender, EventArgs e)
        {
            isGameStarted = true;
            btnGameStart.Enabled = false;   // 재시작 방지
            for (int i = 0; i < timers.Count; i++)
            {
                timers[i].Start();
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (!isGameStarted) return;     // 게임시작 false일시 무시
            
            Button clicked = sender as Button;

            int index = buttons.IndexOf(clicked);

            if (index == -1) return; // 리스트에 없는 버튼일 시 무시

            if (clicked.Tag.ToString().Equals("emptyHole"))
            {

                PrintHearts(--nHearts);
                if (nHearts == 0) gameFinish();
            }
            else if (clicked.Tag.ToString().Equals("dodugiHole"))
            {
                addScore(10);

                clicked.Image = hammer;   // 망치 이미지로 교체
                clicked.Tag = "hammer";
                clickedFlags[index] = true;
                clicked.Refresh();

                timers[index].Stop(); // 뿅망치 사진 동안 타이머 중지

                var delayTimer = new System.Windows.Forms.Timer(); // 뿅망치 그림 0.5초간 나오게 하기 위한 타이머
                delayTimer.Interval = 500;
                delayTimer.Tick += (object tickSender, EventArgs tickE) =>
                {
                    delayTimer.Stop(); //중복 실행 방지 위해 중지
                    delayTimer.Dispose();

                    clicked.Image = emptyHole;
                    clicked.Tag = "emptyHole";

                    timers[index].Interval = rand.Next(1000, 5000); // 두더지 클릭 후 출현 간격 재설정
                    Debug.WriteLine($"[Timer {index}] New Interval = {timers[index].Interval} ms"); // 재설정 확인용
                    // 빈 구멍으로 바꾸고 원래 타이머 재시작
                    timers[index].Start();
                    clickedFlags[index] = false;
                };

                delayTimer.Start();

            }
            //기윤님이 
            //@한명이 클릭했을때 score 더하기
            //@이후 쓰레드 종료시키고 이미지 업데이트
        }
        

        private void gameFinish()
        {
            isGameStarted = false;
            GameFinishWriteScore gfws = new GameFinishWriteScore();
            gfws.Owner = this;
            DialogResult dr= gfws.ShowDialog();
            this.DialogResult = dr;
        }

        
    }
}
