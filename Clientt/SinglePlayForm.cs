using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clientt
{
    public partial class SinglePlayForm : Form
    {
        private const int rectSize = 33; // *오목판의 셀 크기*
        private const int edgeCount = 15; // *오목판의 선 개수*

        private enum Horse {  none = 0, BLACK, WHITE };
        private Horse[,] board = new Horse[edgeCount, edgeCount];
        private Horse nowPlayer = Horse.BLACK;

        private bool playing = false; // 현재 게임이 진행중인 상태인지 체크하기위해 playing변수를 만들어줌

        public SinglePlayForm()
        {
            InitializeComponent();
        }

        private bool judge() // *승리 판정 함수* // 5개의 위치에서 모두확인하여 해당위치에서 오목이 형성이 되었는지 확인
        {
            for (int i = 0; i < edgeCount - 4; i++) // *가로*
                for (int j = 0; j < edgeCount; j++)
                    if (board[i, j] == nowPlayer && board[i + 1, j] == nowPlayer && board[i + 2, j] == nowPlayer &&
                        board[i + 3, j] == nowPlayer && board[i + 4, j] == nowPlayer)  // 현재 플레이어가 특정한 위치에 연속적으로 5개의 돌을 놓았다면, return true로 승리라고 판정함 
                        return true;
            for (int i = 0; i < edgeCount; i++) // *세로*
                for (int j = 4; j < edgeCount; j++)
                    if (board[i, j] == nowPlayer && board[i, j - 1] == nowPlayer && board[i, j - 2] == nowPlayer &&
                        board[i, j - 3] == nowPlayer && board[i, j - 4] == nowPlayer)
                        return true;
            for (int i = 0; i < edgeCount - 4; i++) // *Y = X  직선*
                for (int j = 0; j < edgeCount - 4; j++)
                    if (board[i, j] == nowPlayer && board[i + 1, j + 1] == nowPlayer && board[i + 2, j + 2] == nowPlayer &&
                        board[i + 3, j + 3] == nowPlayer && board[i + 4, j + 4] == nowPlayer)
                        return true;
            for (int i = 4; i < edgeCount; i++) // *Y = -X 직선*
                for (int j = 0; j < edgeCount - 4; j++)
                    if (board[i, j] == nowPlayer && board[i - 1, j + 1] == nowPlayer && board[i - 2, j + 2] == nowPlayer &&
                        board[i - 3, j + 3] == nowPlayer && board[i - 4, j + 4] == nowPlayer)
                        return true;
            return false;
        }

        private void refresh() // 게임 끝나면 refresh함수(게임을 다시 초기화 한다는 특징이 있음)를 수행
        {
            this.boardPicture.Refresh();
            for (int i = 0; i < edgeCount; i++)
                for (int j = 0; j < edgeCount; j++)
                    board[i, j] = Horse.none;
        }

        private void playButton_Cilk(object sender, EventArgs e)
        {
            if(!playing) // 현재 게임진행 중이 아니라면,
            {
                refresh(); // 화면을 초기화하고
                playing = true; // 게임을 시작 중인 상태로 바꾸어줌
                playButton.Text = "재시작";
                status.Text = nowPlayer.ToString() + "플레이어의 차례입니다.";
            }
            else // 게임실행 중이면, 재시작 버튼을 눌렀다는 것임으로
            {
                refresh(); // 초기화되게 한 후,
                status.Text = "게임이 재시작되었습니다."; // 재시작하였음을 출력해줌
            }
        }

        private void boardPicture_MouseDown(object sender, MouseEventArgs e) // 사용자가 오목판을 클릭했을때, 클릭이벤트 처리함수
        {
            if (!playing)
            {
                MessageBox.Show("게임을 실행해주세요.");
                return;
            }
            Graphics g = this.boardPicture.CreateGraphics();
            int x = e.X / rectSize;
            int y = e.Y / rectSize;
            if (x < 0 || y < 0 || x >= edgeCount || y >= edgeCount)
            {
                MessageBox.Show("테두리를 벗어날 수 없습니다.");
                return;
            }
            if (board[x, y] != Horse.none) return; // 사용자가 돌을 놓으려 할때, 그 위치에는 어떠한 돌도 놓아져있지 않은 상태여야 돌을 놓을 수 있음
            board[x, y] = nowPlayer;
            if(nowPlayer == Horse.BLACK) // 현재플레이어가 검은색돌이면 검은색돌을 바둑판에 놓음
            {
                SolidBrush brush = new SolidBrush(Color.Black);
                g.FillEllipse(brush, x * rectSize, y * rectSize, rectSize, rectSize); // 오목판크기33만큼 셀지름을 가지는 원을 그리도록함
            }
            else
            {
                SolidBrush brush = new SolidBrush(Color.White);
                g.FillEllipse(brush, x * rectSize, y * rectSize, rectSize, rectSize); // 검은색돌을 사용자가 찍지않았다면, 하얀색 돌을 사용하도록 함
            }
            if (judge())
            { //특정 플레이어가 돌을 둔 이후에는, 이 플레이어를 기점으로 judge()함수를 불러와서 오목을 형성했다면
                status.Text = nowPlayer.ToString() + "플레이어가 승리했습니다."; // 플레이어 승리 메세지를 출력함
                playing = false; // 승리와 동시에 게임을 멈춤
                playButton.Text = "게임 시작";
            }
            else 
            { // 아직 오목이 만들어지지 않은 상태라면,
                nowPlayer = ((nowPlayer == Horse.BLACK) ? Horse.WHITE : Horse.BLACK); // 다음 플레이어를 내가 아닌 다른사람에게 넘김
                status.Text = nowPlayer.ToString() + "플레이어의 차례입니다.";
            }


            /*MessageBox.Show(x + "," + y);
            if (nowPlayer == Horse.BLACK) // 기본적으로 검은색돌이 놓아짐
            {
                SolidBrush brush = new SolidBrush(Color.Black);
                g.FillEllipse(brush, x * rectSize, y * rectSize, rectSize, rectSize); // 오목판크기33만큼 셀지름을 가지는 원을 그리도록함
            }
            else
            {
                SolidBrush brush = new SolidBrush(Color.White);  // 검은색돌을 사용자가 찍지않았다면, 하얀색 돌을 사용하도록 함
                g.FillEllipse(brush, x * rectSize, y * rectSize, rectSize, rectSize);
            }*/

        }

        //Picture박스는 위의 refresh()를 수행했을 때, 바로자동으로 수행됨 => 검은색/하얀색돌은 게임이 끝나면 사라짐으로 다시 초기화해줌(Paint함수가 수행)
        private void boardPicture_Paint(object sender, PaintEventArgs e) // 처음에 오목판이 어떻게 구성되는지 Paint함수
        {
            Graphics gp = e.Graphics;
            Color lineColor = Color.Black; // *오목판의 선 색깔*
            Pen p = new Pen(lineColor, 2); // 선굵기는 2
            gp.DrawLine(p, rectSize / 2, rectSize / 2, rectSize / 2, rectSize * edgeCount - rectSize / 2); // 좌측
            gp.DrawLine(p, rectSize / 2, rectSize / 2, rectSize * edgeCount - rectSize / 2, rectSize / 2); // 상측
            gp.DrawLine(p, rectSize / 2, rectSize * edgeCount - rectSize / 2, rectSize * edgeCount - rectSize / 2, rectSize * edgeCount - rectSize / 2); 
            gp.DrawLine(p, rectSize * edgeCount - rectSize / 2, rectSize * edgeCount - rectSize / 2, rectSize * edgeCount - rectSize / 2, rectSize / 2); 
            p = new Pen(lineColor, 1);
            // *대각선 방향으로 이동하면서 십자가 모양의 선 그리기*
            for(int i = rectSize + rectSize / 2; i < rectSize * edgeCount - rectSize / 2; i += rectSize) // 오목판 내부를 반복적으로 선을 그어서, 전체 오목판의 디자인을 형성
            {
                gp.DrawLine(p, rectSize / 2, i, rectSize * edgeCount - rectSize / 2, i);
                gp.DrawLine(p, i, rectSize / 2, i, rectSize * edgeCount - rectSize / 2);
            }
        } // 오목판의 초기구성 완료

        private void status_Click(object sender, EventArgs e)
        {

        }
    }
}
