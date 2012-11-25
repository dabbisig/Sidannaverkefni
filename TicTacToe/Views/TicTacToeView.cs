using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TicTacToe.Core;
using TicTacToe.Core.Entities;
using TicTacToe.Core.ExtensionMethods;

namespace TicTacToe
{
    public partial class TicTacToeView : Form
    {
        private DrawTicTacToe draw = new DrawTicTacToe();
        private int[] _tictactoe = new int[9];
        private Panel[] _panels = new Panel[9];
        private bool _player;
        private string _player1;
        private string _player2;
        private int _player1Score = 0;
        private int _player2Score = 0;
        private int _draws = 0;
                
        public TicTacToeView()
        {
            InitializeComponent();
            PopulatePanels();
            DrawPanels();
            EnablePanels(false);
        }

        private void tictactoePainter(object sender, PaintEventArgs e)
        {
            draw.DrawBoard(sender as Form);
        }
    
        private void play(Panel panel)
        {
            var panelName = panel.Name;
            var i = Convert.ToInt32(panelName.Substring(0, 1));
            
            if (_player)
            {
                _tictactoe[i] = 1;
                draw.DrawCross(panel);
            }
            else
            {
                _tictactoe[i] = -1;
                draw.DrawCircle(panel);
            }
            CheckGameStatus();
            _player = !_player;
        }

        private void CheckGameStatus()
        {
            var status = _tictactoe.CheckStatus();
            if (status != null) { GameOver(Convert.ToInt32(status)); };
        }

        private void GameOver(int sum)
        {
            if (sum < 0)
            {
                MessageBox.Show(_player1 + " vann");
                _player1Score++;
            }
            if (sum > 0)
            {
                MessageBox.Show(_player2 + " vann");
                _player2Score++;
            }
            if (sum == 0)
            {
                MessageBox.Show("Jafntefli");
                _draws++;
            }
            RenderScore();
            NewGame();
        }

        private void NewGame()
        {
            Array.Clear(_tictactoe, 0, _tictactoe.Length);
            Invalidate();
            _player = true;
            EnablePanels(true);
        }

        private void TicTacToeView_Click(object sender, MouseEventArgs e)
        {
            var panelName = (sender as Panel).Name;
            var i = Convert.ToInt32(panelName.Substring(0, 1));
            if (_tictactoe[i] == 0)
            {
                play(sender as Panel);
            }
        }

        private void PopulatePanels()
        {
            var param = new TicTacToeParameters();
            var margin = param.outerMargin;
            var square = param.square;
            var linewidth = param.linewidth;
            for (int i = 0; i < 9; i++)
            {
                _panels[i] = new Panel 
                    {
                        
                        Name = i.ToString(),
                        Size = new System.Drawing.Size(square, square),
                        Location = new Point(margin + i % 3 * (square + linewidth), margin + (i/3) * (square + linewidth)),
                        BackColor = System.Drawing.Color.Transparent,

                    };
            
            }
            
        }

        private void DrawPanels()
        {
            foreach (var panel in _panels)
            {
                panel.MouseDown += new MouseEventHandler(TicTacToeView_Click);
                Controls.Add(panel);
            }
        }

        private void EnablePanels(bool enable)
        {
            for(int i = 0; i < _tictactoe.Length; i++)
            {
                _tictactoe[i] = enable ? 0 : 1;
            }
        }

        private void PlayerConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPlayer1.Text) || string.IsNullOrEmpty(txtPlayer2.Text))
            {
                MessageBox.Show("Sláðu inn bæði nöfn keppenda");
                return;
            }
            _player1 = txtPlayer1.Text;
            _player2 = txtPlayer2.Text;
            pnlPlayers.Visible = false;
            pnlScoreBoard.Visible = true;
            RenderScore();
            EnablePanels(true);
            
        }

        private void RenderScore()
        {
            lblPlayer1.Text = _player1 + ": " + _player1Score;
            lblPlayer2.Text = _player2 + ": " + _player2Score;
            lblDraws.Text = "Jafntefli: " + _draws;
            
        }
        
    }
}
