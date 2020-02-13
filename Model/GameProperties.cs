using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeProject
{
    public class GameProperties : IDataErrorInfo
    {
        
        public int NeighboursToReproduce
        {
            get; set;
        }

        public int Width
        {
            get; set;
        }

        public int Height
        {
            get; set;
        }

        public int Degree
        {
            get; set;
        }

        public GameProperties()
        {
            
        }

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error
        {
            get { return null; }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                if (columnName == "NeighboursToReproduce")
                {
                    // Validate property and return a string if there is an error
                    if (NeighboursToReproduce <= 0)
                        return "Liczb sasiadow > 0";
                }

                // If there's no error, null gets returned
                return null;
            }
        }
        #endregion


    }
}
