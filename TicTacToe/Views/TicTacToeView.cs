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
        private Panel _panel = new Panel();
                
        public TicTacToeView()
        {
            InitializeComponent();
            
            _panel.Name = "tictactoePanel";
            _panel.Location = new Point(_margin, _margin);
            _panel.BackColor = System.Drawing.Color.Transparent;
            _panel.Size = new System.Drawing.Size(3 * _square + 2 * _linewidth, 3 * _square + 2 * _linewidth);
            _panel.Paint += new PaintEventHandler(tictactoePainter);
            _panel.MouseDown += new MouseEventHandler(TicTacToeView_Click);
            Controls.Add(_panel);
        }

        private void tictactoePainter(object sender, PaintEventArgs e)
        {
            Graphics g = _panel.CreateGraphics();
            Pen _pen = new Pen(Color.Black, _linewidth);
            g.DrawLine(_pen, new Point(_square + _linewidth/2, 0), new Point(_square + _linewidth/2, 3 * _square + 2 * _linewidth));
            g.DrawLine(_pen, new Point(2 * _square + _linewidth + _linewidth / 2, 0), new Point(2 * _square + _linewidth + _linewidth / 2, 3 * _square + 2 * _linewidth));
            g.DrawLine(_pen, new Point(0, _square + _linewidth / 2), new Point(3 * _square + 2 * _linewidth, _square + _linewidth / 2));
            g.DrawLine(_pen, new Point(0, 2 * _square + _linewidth + _linewidth / 2), new Point(3 * _square + 2 * _linewidth, 2 * _square + _linewidth + _linewidth / 2));
        }
    
        private void play(int i, int j)
        {
            _tictactoe[i, j] = 1;

        }

        private void TicTacToeView_Click(object sender, MouseEventArgs e)
        {
            if (e.Location.ToTopLeft(e.Location.ToSquareNumber()) != null)
            {
                DrawCircle(e.Location.ToTopLeft(e.Location.ToSquareNumber()).Value);
            }
        }

        private void DrawCross(Point topLeft)
        {
            if (topLeft != null)
            {
                Graphics g = _panel.CreateGraphics();
                Pen _pen = new Pen(Color.Black, _linewidth);
                g.DrawLine(_pen, new Point(topLeft.X + _margin1, topLeft.Y + _margin1), new Point(topLeft.X + _square - _margin1, topLeft.Y + _square - _margin1));
                g.DrawLine(_pen, new Point(topLeft.X + _margin1, topLeft.Y + _square - _margin1), new Point(topLeft.X + _square - _margin1, topLeft.Y + _margin1));
            }
        }

        private void DrawCircle(Point topLeft)
        {
            Graphics g = _panel.CreateGraphics();
            Pen _pen = new Pen(Color.Black, _linewidth);
            g.DrawEllipse(_pen, topLeft.X + _margin1, topLeft.Y + _margin, _square - 2*_margin1, _square - 2*_margin1);
        }

    }
}
