using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
        private int[,] map = new int[20, 10]; // 1 - заполненная клетка, 0 - пустая

        private int startPositionX = 4;
        private int startPositionY = 0;
        

        private int[,] shape = new int[3, 3]
        {
            {0, 0, 0},
            {0, 1, 0},
            {0, 0, 0}
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
                        map[startPositionY + i, startPositionX + j] = 1;
                }
            }

            for (int i = 0; i < gameFieldHeightInCells; i++)
            {
                for (int j = 0; j < gameFieldWidthInCells; j++)
                {
                    if (map[i, j] == 1)
                    {
                        graphics.FillRectangle(Brushes.BlueViolet, j * cellSize, i * cellSize, cellSize, cellSize);
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
            startPositionY++;
            ClearArea();
        }

        public void Move(Keys direction)
        {
            switch (direction)
            {
                case Keys.Left:
                    if (CheckLeftBorder())
                    {
                        startPositionX--;
                    }
                    ClearArea();
                    break;
                case Keys.Right:
                    startPositionX++;
                    ClearArea();
                    break;
                case Keys.Down:
                    startPositionY++;
                    ClearArea();
                    break;
            }
        }

        private void ClearArea()
        {
            for (int i = 0; i < gameFieldHeightInCells; i++)
            {
                for (int j = 0; j < gameFieldWidthInCells; j++)
                {
                    if (map[i, j] == 1)
                    {
                        map[i, j] = 0;
                    }
                }
            }
        }

        private bool CheckLeftBorder()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    switch (x)
                    {
                        case 0:
                            if (shape[y, x] == 1 && startPositionX > 0)
                            {
                                return true;
                            }
                            break;
                        case 1:
                            if (shape[y, x] == 1 && startPositionX + 1 > 0 && CheckColumnOne())
                            {
                                return true;
                            }
                            break;
                        case 2:
                            if (shape[y, x] == 1 && startPositionX + 2 > 0 && CheckColumnTwo())
                            {
                                return true;
                            }
                            break;
                    }
                }
            }
            return false;
        }

        private bool CheckColumnOne()
        {
            return shape[0, 0] == 0 && 
                   shape[1, 0] == 0 && 
                   shape[2, 0] == 0;
        }

        private bool CheckColumnTwo()
        {
            return shape[0, 1] == 0 &&
                   shape[1, 1] == 0 &&
                   shape[2, 1] == 0 &&
                   CheckColumnOne();
        }
    }
}