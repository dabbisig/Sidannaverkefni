using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using TicTacToe.Core.Entities;

namespace TicTacToe.Core
{
    public class DrawTicTacToe
    {
        private int _linewidth = new TicTacToeParameters().linewidth;
        private int _outerMargin = new TicTacToeParameters().outerMargin;
        private int _innerMargin = new TicTacToeParameters().innerMargin;
        private int _square = new TicTacToeParameters().square;

        public void DrawCross(Panel panel)
        {
            Graphics g = panel.CreateGraphics();
            Pen _pen = new Pen(Color.Black, _linewidth);
            g.DrawLine(_pen, new Point(_innerMargin, _innerMargin), new Point(_square - _innerMargin, _square - _innerMargin));
            g.DrawLine(_pen, new Point(_innerMargin, _square - _innerMargin), new Point(_square - _innerMargin, _innerMargin));

        }

        public void DrawCircle(Panel panel)
        {
            Graphics g = panel.CreateGraphics();
            Pen _pen = new Pen(Color.Black, _linewidth);
            g.DrawEllipse(_pen, _innerMargin, _innerMargin, _square - 2 * _innerMargin, _square - 2 * _innerMargin);
        }

        public void DrawBoard(Form form)
        {
            Graphics g = form.CreateGraphics();
            Pen _pen = new Pen(Color.Black, _linewidth);
            g.DrawLine(_pen, new Point(_outerMargin + _square + _linewidth / 2, _outerMargin), new Point(_outerMargin + _square + _linewidth / 2, _outerMargin + 3 * _square + 2 * _linewidth));
            g.DrawLine(_pen, new Point(_outerMargin + 2 * _square + _linewidth + _linewidth / 2, _outerMargin), new Point(_outerMargin + 2 * _square + _linewidth + _linewidth / 2, _outerMargin + 3 * _square + 2 * _linewidth));
            g.DrawLine(_pen, new Point(_outerMargin, _outerMargin + _square + _linewidth / 2), new Point(_outerMargin + 3 * _square + 2 * _linewidth, _outerMargin + _square + _linewidth / 2));
            g.DrawLine(_pen, new Point(_outerMargin, _outerMargin + 2 * _square + _linewidth + _linewidth / 2), new Point(_outerMargin + 3 * _square + 2 * _linewidth, _outerMargin + 2 * _square + _linewidth + _linewidth / 2));
        }
    }
}
