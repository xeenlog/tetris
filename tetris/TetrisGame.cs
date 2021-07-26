using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{
    class TetrisGame
    {
        private int gameFieldHeightInCells;
        private int gameFieldWidthInCells;
        private int cellSize;

        public TetrisGame(int gameFieldHeightInCells, int gameFieldWidthInCells, int cellSize)
        {
            this.gameFieldHeightInCells = gameFieldHeightInCells;
            this.gameFieldWidthInCells = gameFieldWidthInCells;
            this.cellSize = cellSize;
        }

        public void Drow(Graphics graphics)
        {
            for (int i = 0; i <= gameFieldHeightInCells; i++)
            {
                graphics.DrawLine(Pens.Black, 0, cellSize * i, cellSize * gameFieldWidthInCells, cellSize * i);
            }

            for (int j = 0; j <= gameFieldWidthInCells; j++)
            {
                graphics.DrawLine(Pens.Black, cellSize * j, 0, cellSize * j, cellSize * gameFieldHeightInCells);
            }
        }
    }
}
