using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe.Controllers
{
    public class TicTacToeController
    {
        private int[,] _tictactoe = new int[3,3];
        int sum = 0;
        private void trall()
        {
            for (int i = 0; i < 3; i++)
            {
                sum += _tictactoe[i,i];
                sum += _tictactoe[i,2-i];
                for (int j = 0; j < 3; j++)
                {
                    sum += _tictactoe[i,j];
                    sum += _tictactoe[j,i];
                    
                }
            }
        
        }

    }
}
