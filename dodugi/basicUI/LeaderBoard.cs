using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace basicUI
{
    public partial class LeaderBoard : Form
    {
        public LeaderBoard()
        {
            InitializeComponent();
            this.Load += LeaderBoard_Load;
            ConfigureListView();
        }

        private void ConfigureListView()
        {
            listView1.View = View.Details;
            listView1.Columns.Clear();
            listView1.Columns.Add("순위", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("이름", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("점수", 80, HorizontalAlignment.Right);
        }

        private void LeaderBoard_Load(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Application.StartupPath, @"..\..\LeaderBoard.txt");
            var entries = new List<(string Name, int Score)>();

            if (File.Exists(filePath))
            {
                foreach (var line in File.ReadAllLines(filePath, Encoding.UTF8))
                {
                    var parts = line
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length < 2)
                        continue;

                    // C#7.3 호환 인덱싱
                    int len = parts.Length;
                    if (!int.TryParse(parts[len - 1], out int scoreVal))
                        continue;

                    // 마지막 토큰 전까지가 이름
                    string nameVal = string.Join(" ", parts, 0, len - 1);

                    entries.Add((nameVal, scoreVal));
                }
            }

            // 점수 내림차순, 동점 처리
            entries = entries
                .OrderByDescending(t => t.Score)
                .ToList();

            listView1.BeginUpdate();
            listView1.Items.Clear();

            int prevScore = int.MinValue;
            int prevRank = 0;

            for (int i = 0; i < entries.Count; i++)
            {
                var (name, score) = entries[i];
                int rank;

                if (score == prevScore)
                {
                    // 동점: 이전 사람과 같은 순위
                    rank = prevRank;
                }
                else
                {
                    // 점수 변경 시, (인덱스 + 1) 등수
                    rank = i + 1;
                }

                prevScore = score;
                prevRank = rank;

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
