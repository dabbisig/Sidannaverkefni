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
        private int[,] _tictactoe = new int[3, 3];
        private int _linewidth = 10;
        private int _margin = 20;
        private int _margin1 = 20;
        private int _square = 100;
        private Panel[,] _panels = new Panel[3,3];
        private bool player;
                
        public TicTacToeView()
        {
            InitializeComponent();
            PopulatePanels();
            DrawPanels();
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
            var j = Convert.ToInt32(panelName.Substring(1, 1));
            
            if (player)
            {
                _tictactoe[i, j] = 1;
                DrawCross(panel);
            }
            else
            {
                _tictactoe[i, j] = -1;
                DrawCircle(panel);
            }

            player = !player;
        }

        private void ComputerPlay()
        {
            int sumHor = 0;
            int sumVer = 0;
            int sumDia1 = 0;
            int sumDia2 = 0;
            for (int i = 0; i < 3; i++)
            {
                sumDia1 += _tictactoe[i, i];
                sumDia2 += _tictactoe[i, 2 - i];
                sumHor = 0;
                sumVer = 0;
                for (int j = 0; j < 3; j++)
                {
                    sumHor += _tictactoe[i, j];
                    if (Math.Abs(sumHor) == 3)
                    sumVer += _tictactoe[j, i];

                }
                
            }
            
            //DrawCross();
        }

        private void TicTacToeView_Click(object sender, MouseEventArgs e)
        {
            var panelName = (sender as Panel).Name;
            var i = Convert.ToInt32(panelName.Substring(0, 1));
            var j = Convert.ToInt32(panelName.Substring(1, 1));
            if (_tictactoe[i,j] == 0)
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
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _panels[i, j] = new Panel 
                    {
                        Name = i.ToString() + j.ToString(),
                        Size = new System.Drawing.Size(_square, _square),
                        Location = new Point(_margin + i * (_square + _linewidth), _margin + j * (_square + _linewidth)),
                        BackColor = System.Drawing.Color.Transparent,

                    };
                }
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
