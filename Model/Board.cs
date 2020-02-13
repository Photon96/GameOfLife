using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeProject
{
    class Board
    {
        private Cell[,] _Cells;
        public Cell[,] Cells
        {
            get
            {
                return _Cells;
            }
            set
            {
                _Cells = value;
            }
        }

        public (int Height, int Width) Dimension { get; set; }

        public Board(int height, int width)
        {
            Dimension = (height, width);
            _Cells = new Cell[height, width];
        }

       public void FillCells(Int32 degree)
       {
            
            degree = (degree * Dimension.Width * Dimension.Height) / 100;
            Random random = new Random();

            for (int i = 0; i < Dimension.Height; i++)
            {
                for (int j = 0; j < Dimension.Width; j++)
                {
                    String name = $"{i}_{j}";
                    _Cells[i, j] = new Cell(name);
                }
            }
                
            /*int x, y;
            while (degree > 0)
            {

                x = random.Next(0, Dimension.Height);
                y = random.Next(0, Dimension.Width);

                if (_Cells[x, y].GetState() != Cell.CellState.Allive)
                {
                    _Cells[x, y].Live();
                    degree--;
                }
            }*/

        }
    }


}
