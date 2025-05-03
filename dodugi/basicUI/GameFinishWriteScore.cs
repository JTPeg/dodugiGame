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
    public partial class GameFinishWriteScore : Form
    {
        GameWindow gw;

        //생성자가 Load보다 먼저 실행
        public GameFinishWriteScore()
        {
            InitializeComponent();
        }
        private void GameFinishWriteScore_Load(object sender, EventArgs e)
        {
            gw = Owner as GameWindow;
            if (gw != null)
            {
                lbl_score.Text = gw.Score.ToString();
                IblRank_load();
            }
        }

        private void IblRank_load()
        {
            //다시
            List<int> tuples = new List<int>();
            string filePath = Path.Combine(Application.StartupPath, @"..\..\LeaderBoard.txt");
            try
            {
                using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8)) // UTF-8 인코딩 명시적 지정 예시
                {
                    string line; // 읽어온 한 줄을 저장할 변수
                    // reader.ReadLine()이 null을 반환하면 파일 끝에 도달한 것입니다.
                    while ((line = reader.ReadLine()) != null)
                    {
                        // 읽어온 한 줄(line)을 처리
                        string[] words = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                        tuples.Add(int.Parse(words[1]));
                    }

                    tuples.Sort((x, y) => y.CompareTo(x));
                    int rank = 1;
                    for(int i=0; i<tuples.Count; i++)
                    {
                        if (gw.Score < tuples[i]) rank++;
                        else break;
                    }

                    lbl_RankValue.Text = rank.ToString();


                } // using 블록 끝: reader가 자동으로 Dispose됨 (파일 닫힘)
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"오류: 파일을 찾을 수 없습니다 - {filePath}");
            }
            catch (IOException ex) // 파일 접근 오류 등
            {
                Console.WriteLine($"파일 읽기 중 오류 발생: {ex.Message}");
            }
            catch (Exception ex) // 기타 예상치 못한 오류
            {
                Console.WriteLine($"알 수 없는 오류 발생: {ex.Message}");
            }

            
        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txt_name.Text == string.Empty) MessageBox.Show("이름을 입력하세요");
            else
            {
                string filePath = Path.Combine(Application.StartupPath, @"..\..\LeaderBoard.txt");
                try
                {
                    using (StreamWriter writer = new StreamWriter(filePath, true, Encoding.UTF8)) // true: Append 모드                                              
                    {
                        if (writer == null) throw new Exception("파일 열기 실패");
                        writer.Write(txt_name.Text);
                        writer.WriteLine(" " + lbl_score.Text);
                        DialogResult = DialogResult.OK;
                    } // 자동 Dispose 및 파일 닫기
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"오류 발생: {ex.Message}");
                }

            }

        }


    }
}

