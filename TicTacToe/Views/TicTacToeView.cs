using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TicTacToe.Core.ExtensionMethods;

namespace TicTacToe
{
    public partial class TicTacToeView : Form
    {
        private int[] _tictactoe = new int[9];
        private int _linewidth = 10;
        private int _margin = 20;
        private int _margin1 = 20;
        private int _square = 100;
        private Panel[] _panels = new Panel[9];
        private bool player;
                
        public TicTacToeView()
        {
            InitializeComponent();
            PopulatePanels();
            DrawPanels();
        }

        private void ClearBoard(object sender, EventArgs e)
        {
            Array.Clear(_tictactoe, 0, _tictactoe.Length);
            Invalidate();
        }

        private void tictactoePainter(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen _pen = new Pen(Color.Black, _linewidth);
            g.DrawLine(_pen, new Point(_margin + _square + _linewidth / 2, _margin), new Point(_margin + _square + _linewidth / 2, _margin + 3 * _square + 2 * _linewidth));
            g.DrawLine(_pen, new Point(_margin + 2 * _square + _linewidth + _linewidth / 2, _margin), new Point(_margin + 2 * _square + _linewidth + _linewidth / 2, _margin + 3 * _square + 2 * _linewidth));
            g.DrawLine(_pen, new Point(_margin, _margin + _square + _linewidth / 2), new Point(_margin + 3 * _square + 2 * _linewidth, _margin + _square + _linewidth / 2));
            g.DrawLine(_pen, new Point(_margin, _margin + 2 * _square + _linewidth + _linewidth / 2), new Point(_margin + 3 * _square + 2 * _linewidth, _margin + 2 * _square + _linewidth + _linewidth / 2));
        }
    
        private void play(Panel panel)
        {
            var panelName = panel.Name;
            var i = Convert.ToInt32(panelName.Substring(0, 1));
            
            if (player)
            {
                _tictactoe[i] = 1;
                DrawCross(panel);
            }
            else
            {
                _tictactoe[i] = -1;
                DrawCircle(panel);
            }
            CheckGameStatus();
            player = !player;
        }

        private void CheckGameStatus()
        {
            int sum = 0;
            for (int i = 0; i < 3; i++)
            {
                sum += _tictactoe[i];
            }
            if (Math.Abs(sum) == 3) { GameOver(); return; }
            sum = 0;
            for (int i = 0; i < 3; i++)
            {
                sum += _tictactoe[i+3];
            }
            if (Math.Abs(sum) == 3) { GameOver(); return; }
            sum = 0;
            for (int i = 0; i < 3; i++)
            {
                sum += _tictactoe[i+6];
            }
            if (Math.Abs(sum) == 3) { GameOver(); return; }
            sum = 0;
            for (int i = 0; i < 3; i++)
            {
                sum += _tictactoe[i*3];
            }
            if (Math.Abs(sum) == 3) { GameOver(); return; }
            sum = 0;
            for (int i = 0; i < 3; i++)
            {
                sum += _tictactoe[i*3 + 1];
            }
            if (Math.Abs(sum) == 3) { GameOver(); return; }
            sum = 0;
            for (int i = 0; i < 3; i++)
            {
                sum += _tictactoe[i*3 + 2];
            }
            if (Math.Abs(sum) == 3) { GameOver(); return; }
            sum = 0;
            for (int i = 0; i < 3; i++)
            {
                sum += _tictactoe[i*4];
            }
            if (Math.Abs(sum) == 3) { GameOver(); return; }
            sum = 0;
            for (int i = 0; i < 3; i++)
            {
                sum += _tictactoe[i*2 + 2];
            }
            if (Math.Abs(sum) == 3) { GameOver(); return; }
            sum = 0;
        
        }

        private void GameOver()
        {
            MessageBox.Show("Game Over");
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

        private void DrawCross(Panel panel)
        {
            
            Graphics g = panel.CreateGraphics();
            Pen _pen = new Pen(Color.Black, _linewidth);
            g.DrawLine(_pen, new Point(_margin1, _margin1), new Point(_square - _margin1, _square - _margin1));
            g.DrawLine(_pen, new Point(_margin1, _square - _margin1), new Point(_square - _margin1, _margin1));
           
        }

        private void DrawCircle(Panel panel)
        {
            Graphics g = panel.CreateGraphics();
            Pen _pen = new Pen(Color.Black, _linewidth);
            g.DrawEllipse(_pen, _margin1, _margin, _square - 2*_margin1, _square - 2*_margin1);
        }

        private void PopulatePanels()
        {

            for (int i = 0; i < 9; i++)
            {
                _panels[i] = new Panel 
                    {
                        
                        Name = i.ToString(),
                        Size = new System.Drawing.Size(_square, _square),
                        Location = new Point(_margin + i % 3 * (_square + _linewidth), _margin + (i/3) * (_square + _linewidth)),
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

       


        

    }
}
