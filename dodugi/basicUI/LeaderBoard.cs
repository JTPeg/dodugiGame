using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace basicUI
{
    public partial class LeaderBoard : Form
    {
        public LeaderBoard()
        {
            InitializeComponent();
        }

        private void LeaderBoard_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.Columns.Clear();
            listView1.Columns.Add("Rank", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Name", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Score", 80, HorizontalAlignment.Right);

            string filePath = Path.Combine(Application.StartupPath, @"..\..\LeaderBoard.txt");
            var entries = new List<(string Name, int Score)>();

            if (File.Exists(filePath))
            {
                foreach (string line in File.ReadAllLines(filePath, Encoding.UTF8))
                {
                    var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length < 2) continue;
                    if (!int.TryParse(parts[parts.Length - 1], out int scoreVal)) continue;
                    string nameVal = string.Join(" ", parts.Take(parts.Length - 1));
                    entries.Add((nameVal, scoreVal));
                }
            }

            // 점수 내림차순 정렬
            entries = entries.OrderByDescending(ee => ee.Score).ToList();

            // 3) ListView에 “순위, 이름, 점수”로 뿌리기
            listView1.BeginUpdate();
            listView1.Items.Clear();
            for (int i = 0; i < entries.Count; i++)
            {
                int rank = i + 1;
                var (name, score) = entries[i];
                var lvi = new ListViewItem(new[]
                {
            $"{rank}등",
            name,
            score.ToString()
        });
                listView1.Items.Add(lvi);
            }
            listView1.EndUpdate();
        }
    }
}
