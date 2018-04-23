using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip
{
    public partial class main : Form
    {
        Game game;

        public main()
        {
            InitializeComponent();
        }

        private void StartGame(object sender, EventArgs e)
        {
            game = new Game(PlayerType.human, PlayerType.bot);

            Controls.RemoveByKey(game.player1.Name);
            Controls.RemoveByKey(game.player2.Name);

            Controls.Add(game.player1);
            Controls.Add(game.player2);
        }
    }
}