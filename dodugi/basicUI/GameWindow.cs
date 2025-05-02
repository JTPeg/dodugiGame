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

namespace basicUI
{
    public partial class GameWindow : Form
    {
        //@leader board만들때 쓸것
        event EventHandler e;
        private readonly object _lockObject = new object();
        private int score = 0;


        List<Button> buttons;
        List<PictureBox> Hearts;
        List<System.Windows.Forms.Timer> timers;

        // timer 객체와 각 버튼 활성화 스레드 공유 랜덤 객체를 global하게 생성
        Random rand = new Random();

        // 이미지 초기화 - 각 버튼 활성화 스레드에서 공유
        static Image original_emptyHole = Image.FromFile("emptyHole.png");
        static Image emptyHole = new Bitmap(original_emptyHole, 195, 200);  // 버튼 크기만큼 새로 그리기
        static Image original_dodugiHole = Image.FromFile("dodugiHole.png");
        static Image dodugiHole = new Bitmap(original_dodugiHole, 195, 200);
        //@하트 이미지 추가해줄것
        //@크기 초기화 해줄것


        public GameWindow()
        {
            InitializeComponent();
            InitializeButtons();
            InitializeHearts();
            InitializeTimers();
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
            //버튼 위치 초기화 해줄것
            buttons = new List<Button>();
            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            buttons.Add(button7);
            buttons.Add(button8);
            buttons.Add(button9);

            /*
             * 버튼 사이즈 및 위치 초기화 코드 필요
            */

            // 버튼 초기 이미지 설정
            for (int i = 0; i < 9; ++i)
            {
                buttons[i].Image = emptyHole;
                //  버튼을 빈 구멍 상태로 태그 설정 - 후에 버튼 클릭 이벤트 시 태그로 분기 판별 가능
                // 버튼의 별명(현재 버튼 이미지 상태)
                buttons[i].Tag = "emptyHole";   
                
            }
        }
        private void InitializeHearts()
        {
            Hearts = new List<PictureBox>();
            Hearts.Add(ptHeart1);
            Hearts.Add(ptHeart2);
            Hearts.Add(ptHeart3);
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
            for (int i = 0; i < timers.Count; i++)
            {
                timers[i].Start();
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button clicked = sender as Button;
            if(clicked.ToString().Equals("emptyHole"))
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
