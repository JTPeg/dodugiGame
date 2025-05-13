using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace basicUI
{
    public partial class BasicUi : Form
    {

        public BasicUi()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            GameWindow gw = new GameWindow();
            if(gw.ShowDialog() == DialogResult.OK)
            {

            }
        }

        //@leader보드 버튼 클릭시 이벤트헨들러
        private void btnLB_Click(object sender, EventArgs e)
        {
            LeaderBoard lb = new LeaderBoard();
            if (lb.ShowDialog() == DialogResult.OK)
            {

            }
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
