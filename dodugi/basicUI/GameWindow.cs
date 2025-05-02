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

namespace basicUI
{
    public partial class GameWindow : Form
    {
        //@leader board만들때 쓸것
        event EventHandler e;
        private readonly object _lockObject = new object();
        private int score = 0;
        private bool isGameStarted = false;     // 게임 시작했는지 확인
        Image emptyHole, dodugiHole, heart, brokenheart;    // 이미지 선언을 여기서

        List<Button> buttons;
        List<PictureBox> Hearts;
        List<System.Windows.Forms.Timer> timers;

        // timer 객체와 각 버튼 활성화 스레드 공유 랜덤 객체를 global하게 생성
        Random rand = new Random();

        public GameWindow()
        {
            InitializeComponent();
            InitializeImages();
            InitializeButtons();
            InitializeHearts();
            InitializeTimers();
        }
        private void InitializeImages()     // resource 폴더 안의 이미지 가져옴
        {
            string basePath = Path.Combine(Application.StartupPath, @"..\..\resource");

            emptyHole = new Bitmap(Image.FromFile(Path.Combine(basePath, "emptyHole.png")), 150, 135);
            dodugiHole = new Bitmap(Image.FromFile(Path.Combine(basePath, "dodugiHole.png")), 150, 135);
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
            Hearts = new List<PictureBox> { ptHeart1, ptHeart2, ptHeart3 };

            int heartSize = 70;   // 하트 그림 크기
            int startX = 30;    // 첫 번째 하트의 X좌표
            int y = 520;    // 하트의 Y좌표
            int gap = 15;    // 하트 간 가로 간격

            for (int i = 0; i < Hearts.Count; i++)
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
        private void GameWindow_Load(object sender, EventArgs e)
        {

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
            if(clicked.Tag.ToString().Equals("emptyHole"))
            {
                addScore(-10);
            }
            else if(clicked.Tag.ToString().Equals( "dodugiHole"))
            {
                //기윤님이 
                //@한명이 클릭했을때 score 더하기
                //@이후 쓰레드 종료시키고 이미지 업데이트
            }
        }
    }
}
