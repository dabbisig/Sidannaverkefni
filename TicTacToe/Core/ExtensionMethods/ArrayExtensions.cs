using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe.Core.ExtensionMethods
{
    public static class ArrayExtensions
    {
        public static int? CheckStatus(this int[] self)
        {
            int sumVertical = 0;
            int sumHorizontal = 0;
            int sumDiagonal1 = 0;
            int sumDiagonal2 = 0;
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    sumVertical += self[i * 3 + j];
                    sumHorizontal += self[j * 3 + i];

                }
                if (Math.Abs(sumVertical) == 3) { return sumVertical; }
                if (Math.Abs(sumHorizontal) == 3) { return sumHorizontal; }
                sumDiagonal1 += self[j * 4];
                sumDiagonal2 += self[j * 2 + 2];
                sumVertical = 0;
                sumHorizontal = 0;
            }
            if (Math.Abs(sumDiagonal1) == 3) { return sumDiagonal1; }
            if (Math.Abs(sumDiagonal2) == 3) { return sumDiagonal2; }
            if (self.All(element => Math.Abs(element) == 1)) { return 0; }
            return null;
        
        }
    }
}
