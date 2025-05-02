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
        event EventHandler e;


        List<Button> buttons;
        List<PictureBox> Hearts;
        List<System.Windows.Forms.Timer> timers;
        public GameWindow()
        {
            InitializeComponent();
            InitializeButtons();
            InitializeHearts();
            InitializeTimers();
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

        }
        private void InitializeHearts()
        {
            //위치 초기화 해줄것
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
        }
        private void GameWindow_Load(object sender, EventArgs e)
        {

        }

        //주영님이 하시는걸로...
        private void btnUtilizer(object sender, EventArgs e)
        {
            //얘를 멀티쓰레드로 돌려요
            btnUnUtilizer(sender, e);
            System.Windows.Forms.Timer tmr = sender as System.Windows.Forms.Timer;        
        }

        private void btnUnUtilizer(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
        }

        private void btnGameStart_Click(object sender, EventArgs e)
        {

        }
    }
}
