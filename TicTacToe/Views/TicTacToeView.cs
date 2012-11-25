﻿using System;
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
            NewGame();
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
            int sumVertical = 0;
            int sumHorizontal = 0;
            int sumDiagonal1 = 0;
            int sumDiagonal2 = 0;
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    sumVertical += _tictactoe[i * 3 + j];
                    sumHorizontal += _tictactoe[j * 3 + i];
                    
                }
                if (Math.Abs(sumVertical) == 3) { GameOver(sumVertical); return; }
                if (Math.Abs(sumHorizontal) == 3) { GameOver(sumHorizontal); return; }
                sumDiagonal1 += _tictactoe[j * 4];
                sumDiagonal2 += _tictactoe[j * 2 + 2];
                sumVertical = 0;
                sumHorizontal = 0;
            }
            if (Math.Abs(sumDiagonal1) == 3) { GameOver(sumDiagonal1); return; }
            if (Math.Abs(sumDiagonal2) == 3) { GameOver(sumDiagonal2); return; }
            if (_tictactoe.All(element => Math.Abs(element) == 1)) { GameOver(0); return; }
        }

        private void GameOver(int sum)
        {
            if (sum < 0)
            {
                MessageBox.Show("Siggi vann");
            }
            if (sum > 0)
            {
                MessageBox.Show("Davíð vann");
            }
            if (sum == 0)
            {
                MessageBox.Show("Jafntefli");
            }
            NewGame();
        }

        private void NewGame()
        {
            Array.Clear(_tictactoe, 0, _tictactoe.Length);
            Invalidate();
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
