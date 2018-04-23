using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip
{
    enum PanelPos
    {
        left,
        right
    }

    delegate void GameDelegate();

    class PlayerPanel : Panel
    {
        int cellSize;

        public Brain brain;
        GameDelegate turn;

        public PlayerType playerType;
        PanelPos panelPos;

        public PlayerPanel(PlayerType playerType, PanelPos panelPos, GameDelegate turn, GameDelegate over, GameDelegate check)
        {
            this.playerType = playerType;
            this.panelPos = panelPos;
            this.turn = turn;

            cellSize = 25;

            switch (panelPos)
            {
                case PanelPos.left:
                    Name = "player1";
                    break;
                case PanelPos.right:
                    Name = "player2";
                    break;
            }

            CreateBtns();

            brain = new Brain(DrawBtns, over, check, RedrawBtns, playerType);

            if (playerType == PlayerType.human)
                CreateSwitchBtn();

            if (playerType == PlayerType.bot)
                BotPlacement();
        }

        private void CreateSwitchBtn()
        {
            Button btn = new Button();

            btn.Name = "switcher";
            btn.Click += Btn_Click;
            btn.Size = new Size(3 * cellSize, cellSize);
            //btn.Location = new Point(0, 10 * cellSize + cellSize);
            //btn.BackColor = Color.DeepSkyBlue;
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            //btn.Text = "LeftToRight";

            Controls.Add(btn);
        }

        private void BotPlacement()
        {
            string switcher = "switcher";

            while (brain.index < brain.st.Length - 1)
            {
                int row = new Random().Next(0, 10);
                int column = new Random().Next(0, 10);
                string msg = string.Format("{0}_{1}", row, column);

                int random = new Random().Next(0, 2);

                if (random == 0)
                    brain.Switch(switcher);

                brain.Process(msg);
            }
        }

        private void CreateBtns()
        {
            Location = new Point(cellSize, 2 * cellSize);
            Size = new Size(10 * cellSize, 12 * cellSize);

            if (panelPos == PanelPos.right)
                Location = new Point(10 * cellSize + 2 * cellSize, 2 * cellSize);

            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    Button btn = new Button();

                    btn.Name = i + "_" + j;
                    btn.Size = new Size(cellSize, cellSize);
                    btn.Location = new Point(i * cellSize, j * cellSize);

                    btn.Click += Btn_Click;
                    btn.MouseEnter += Btn_Enter;
                    btn.MouseLeave += Btn_Leave;

                    Controls.Add(btn);
                }
            }
        }

        private void Btn_Enter(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            brain.Enter(btn.Name);
        }

        private void Btn_Leave(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            brain.Leave(btn.Name);
        }

        private void DrawBtns(CellState[,] map)
        {
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    Color color = Color.White;
                    bool isEnabled = true;

                    switch (map[i, j])
                    {
                        case CellState.empty:
                        case CellState.adjacent:
                            color = Color.DarkGreen;
                            break;
                        case CellState.busy:
                            color = Color.Black;
                            break;
                        case CellState.striked:
                            isEnabled = false;
                            color = Color.Red;
                            break;
                        case CellState.missed:
                            isEnabled = false;
                            color = Color.DarkGoldenrod;
                            break;
                        case CellState.destroyed:
                            isEnabled = false;
                            color = Color.DarkRed;
                            break;
                    }

                    Controls[10 * i + j].BackColor = color;
                    Controls[10 * i + j].Enabled = isEnabled;
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.Name == "switcher")
            {
                brain.Switch(btn.Name);

                if (Controls[100].Text == "LeftToRight")
                    Controls[100].Text = "UpToDown";

                else
                    Controls[100].Text = "LeftToRight";
            }

            else if (brain.state == State.construction)
            {
                brain.Process(btn.Name);

                if (brain.alives == 10 && playerType == PlayerType.human)
                    Controls[100].Visible = false;
            }

            else if (brain.state == State.game)
            {
                if (!brain.Play(btn.Name))
                {
                    Thread.Sleep(500);
                    turn.Invoke();
                }
            }
        }

        private void RedrawBtns(List<Point> P, bool isGood, bool isBack)
        {
            Color color;

            //if (isGood) color = Color.Green;
            //else color = Color.White;

            for (int i = 0; i < P.Count; ++i)
            {
                if (isBack)
                {
                    switch (brain.map[P[i].X, P[i].Y])
                    {
                        case CellState.empty:
                        case CellState.adjacent:
                            color = Color.DarkGreen;
                            break;
                        case CellState.busy:
                            color = Color.Black;
                            break;
                    }
                }
                //Controls[P[i].X * 10 + P[i].Y].BackColor = color;
            }
        }

        private void Switch_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            brain.Switch(btn.Name);
        }

        public void Victory(string msg)
        {
            MessageBox.Show(msg + " win!");
        }
    }
}