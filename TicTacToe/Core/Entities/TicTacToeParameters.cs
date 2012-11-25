using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe.Core.Entities
{
    public class TicTacToeParameters
    {
        private int _linewidth = 10;
        private int _outerMargin = 20;
        private int _innerMargin = 20;
        private int _square = 100;

        public int linewidth
        {
            get
            {
                return _linewidth;
            }
            set
            {
                _linewidth = value;
            }
        }

        public int outerMargin
        {
            get
            {
                return _outerMargin;
            }
            set
            {
                _outerMargin = value;
            }
        }

        public int innerMargin
        {
            get
            {
                return _innerMargin;
            }
            set
            {
                _innerMargin = value;
            }
        }
        public int square
        {
            get
            {
                return _square;
            }
            set
            {
                _square = value;
            }
        }
    }
}
