using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeProject
{
    class GameOfLife
    {
        private Board _WorkingBoard, _FinalBoard;

        private int [] _NrOfAlliveCellsToSurvive = { 2, 3 };
        private int _NrOfCellsToReproduce = 3;
        
        
        public GameOfLife(int height, int width, int degree, GameProperties gameProperties)
        {
            _WorkingBoard = new Board(height, width);
            _FinalBoard = new Board(height, width);
            _NrOfCellsToReproduce = gameProperties.NeighboursToReproduce;
            FillBoard(degree);    
        }

        private void FillBoard(int degree)
        {
            _FinalBoard.FillCells(degree);
            CopyBoard();
        }

        public bool GenerateNextState()
        {
            bool end = false;
            for (int i = 0; i < _WorkingBoard.Dimension.Height; i++)
            {
                for (int j = 0; j < _WorkingBoard.Dimension.Width; j++)
                {
                    if (ApplyRuleToCell(i, j))
                        end = true;
                }
            }
            CopyBoard();
            return end;
        }

        public void ChangeCellState(int y, int x)
        {
            _FinalBoard.Cells[y, x].ReverseState();
        }

        private Boolean ApplyRuleToCell(int y, int x)
        {
            int count = CountAlliveNeighbours(y, x);
            bool changed = false;
            if ((_WorkingBoard.Cells[y,x].GetState() == Cell.CellState.Allive) && (count < _NrOfAlliveCellsToSurvive[0] || count > _NrOfAlliveCellsToSurvive[1]))
            {
                _FinalBoard.Cells[y, x].Die();
                changed = true;
                
            }
            else if ((_WorkingBoard.Cells[y, x].GetState() == Cell.CellState.Dead || _WorkingBoard.Cells[y, x].GetState() == Cell.CellState.Empty) && count == _NrOfCellsToReproduce)
            {
                _FinalBoard.Cells[y, x].Live();
                changed = true;
                
            } else if ((_WorkingBoard.Cells[y, x].GetState() == Cell.CellState.Allive))
            {
               
            }
            return changed;
        }

        private int CountAlliveNeighbours(int y, int x)
        {
            int count = 0;
            if ((y - 1) > -1)
            {
                if (_WorkingBoard.Cells[y-1,x].GetState() == Cell.CellState.Allive)
                {
                    count++;
                }
            }
            if (((y - 1) > -1) && ((x-1) > -1))
            {
                if (_WorkingBoard.Cells[y - 1, x-1].GetState() == Cell.CellState.Allive)
                {
                    count++;
                }
            }
            if ((y - 1) > -1 && ((x + 1) < _WorkingBoard.Dimension.Width))
            {
                if (_WorkingBoard.Cells[y - 1, x + 1].GetState() == Cell.CellState.Allive)
                {
                    count++;
                }
            }
            if ((x - 1) > - 1)
            {
                if (_WorkingBoard.Cells[y , x - 1].GetState() == Cell.CellState.Allive)
                {
                    count++;
                }
            }
            if ((x + 1) < _WorkingBoard.Dimension.Width)
            {
                if (_WorkingBoard.Cells[y, x + 1].GetState() == Cell.CellState.Allive)
                {
                    count++;
                }
            }
            if ((y+1) < _WorkingBoard.Dimension.Height)
            {
                if (_WorkingBoard.Cells[y + 1, x].GetState() == Cell.CellState.Allive)
                {
                    count++;
                }
            }
            if (((y + 1) < _WorkingBoard.Dimension.Height) && ((x - 1) > -1))
            {
                if (_WorkingBoard.Cells[y + 1, x-1].GetState() == Cell.CellState.Allive)
                {
                    count++;
                }
            }
            
            if (((y + 1) < _WorkingBoard.Dimension.Height) && ((x + 1) < _WorkingBoard.Dimension.Height))
            {
                if (_WorkingBoard.Cells[y + 1, x + 1].GetState() == Cell.CellState.Allive)
                {
                    count++;
                }
            }

            return count;

        }

        public ObservableCollection<ObservableCollection<Cell>> ConvertArrayToList()
        {
            ObservableCollection<ObservableCollection<Cell>> lsts = new ObservableCollection<ObservableCollection<Cell>>();

            for (int i = 0; i < _FinalBoard.Dimension.Height; i++)
            {

                lsts.Add(new ObservableCollection<Cell>());
                for (int j = 0; j < _FinalBoard.Dimension.Width; j++)
                {
                    lsts[i].Add(_FinalBoard.Cells[i, j]);
                }
            }
            return lsts;

        }

        private void CopyBoard()
        {
           for (int i = 0; i < _FinalBoard.Dimension.Height; i++)
            {
                for (int j = 0; j < _FinalBoard.Dimension.Width; j++)
                {
                    Cell cell = new Cell(_FinalBoard.Cells[i,j].Name);
                    cell.SetState(_FinalBoard.Cells[i, j].GetState());
                    _WorkingBoard.Cells[i, j] = cell;
                }
            }
        }
    }
}
