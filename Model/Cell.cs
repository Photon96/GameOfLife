using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeProject
{
    public class Cell
    {
        public enum CellState
        {
            Allive,
            Dead,
            Empty
        }

        private CellState _State;

        public string Name { get; set; }
        public Cell(String name)
        {
            _State = CellState.Empty;
            Name = name;
        }

        public Boolean IsDead()
        {
            return _State == CellState.Dead ? true : false;
        }

        public Boolean IsAllive()
        {
            return _State == CellState.Allive ? true : false;
        }

        public Boolean IsEmpty()
        {
            return _State == CellState.Empty ? true : false;
        }

        public void Die()
        {
            _State = CellState.Dead;
        }

        public void Live()
        {
            _State = CellState.Allive;
        }

        public CellState GetState()
        {
            return _State;
        }

        public void SetState(CellState cellState)
        {
            _State = cellState;
        }

        public void ReverseState()
        {
            if (IsDead() || IsEmpty())
                Live();
            else
                Die();
        }
    }
}
