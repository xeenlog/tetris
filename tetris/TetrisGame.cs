using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tetris
{
    class TetrisGame
    {
        private readonly int gameFieldHeightInCells;
        private readonly int gameFieldWidthInCells;
        private readonly int cellSize;
        private int[,] map = new int[10, 20]; // 1 - заполненная клетка, 0 - пустая

        private int startPositionX = 4;
        private int startPositionY = 0;

        private int[,] shape = new int[2, 2]
        {
            {1, 1},
            {1, 1}
        };

        public TetrisGame(int gameFieldHeightInCells, int gameFieldWidthInCells, int cellSize)
        {
            this.gameFieldHeightInCells = gameFieldHeightInCells;
            this.gameFieldWidthInCells = gameFieldWidthInCells;
            this.cellSize = cellSize;
        }

        public void Restart()
        {

        }

        public void Draw(Graphics graphics)
        {
            for (int i = 0; i < shape.GetLength(0); i++)
            {
                for (int j = 0; j < shape.GetLength(1); j++)
                {
                    if (shape[i, j] == 1)
                        map[startPositionX + i, startPositionY + j] = 1;
                }
            }

            for (int i = 0; i < gameFieldWidthInCells; i++)
            {
                for (int j = 0; j < gameFieldHeightInCells; j++)
                {
                    if (map[i, j] == 1)
                    {
                        graphics.FillRectangle(Brushes.BlueViolet, i * cellSize, j * cellSize, cellSize, cellSize);
                    }
                }
            }

            for (int i = 0; i <= gameFieldHeightInCells; i++)
            {
                graphics.DrawLine(Pens.Black, 0, cellSize * i, cellSize * gameFieldWidthInCells, cellSize * i);
            }

            for (int j = 0; j <= gameFieldWidthInCells; j++)
            {
                graphics.DrawLine(Pens.Black, cellSize * j, 0, cellSize * j, cellSize * gameFieldHeightInCells);
            }
        }

        public void Update()
        {
            startPositionY += 1;
            ClearArea();
        }

        public void Move(Keys direction)
        {
            switch (direction)
            {
                case Keys.Left:
                    startPositionX--;
                    ClearArea();
                    break;
                case Keys.Right:
                    startPositionX++;
                    ClearArea();
                    break;
            }
        }

        private void ClearArea()
        {
            for (int i = 0; i < gameFieldWidthInCells; i++)
            {
                for (int j = 0; j < gameFieldHeightInCells; j++)
                {
                    if (map[i, j] == 1)
                    {
                        map[i, j] = 0;
                    }
                }
            }
        }
    }
}