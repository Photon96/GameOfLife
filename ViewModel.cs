using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace GameOfLifeProject
{
    public class ViewModel : System.ComponentModel.INotifyPropertyChanged
    {

        #region Fields and Properties

        private int _generation = 0;
        public int Generation
        {
            get { return _generation; }
            set
            {
               _generation = value;
               OnPropertyChanged("Generation");
        
            }
        }

        private GameOfLife GOL;
        private ObservableCollection<ObservableCollection<Cell>> _cells;

        public ObservableCollection<ObservableCollection<Cell>> Cells
        {
            get
            {
                return _cells;
            }

            set
            {
                
                _cells = value;
                OnPropertyChanged("Cells");
            }
        }

        # endregion

        #region Constructor

        public ViewModel()
        {
            Cells = new ObservableCollection<ObservableCollection<Cell>>();

        }

        # endregion

        #region Methods

        public void Next()
        {
            GOL.GenerateNextState();
            Cells = GOL.ConvertArrayToList();
            Generation++;
            
        }

        public void CreateNewGame(int width, int height, int degree, GameProperties gameProperties)
        {
            Generation = 0;
            Cells.Clear();
            CreateNextStateCommand();
            GOL = new GameOfLife(height, width, degree, gameProperties);
            Cells = GOL.ConvertArrayToList();
        }

        public void ChangeCellState(int y, int x)
        {
            GOL.ChangeCellState(y, x);
            Cells = GOL.ConvertArrayToList();
        }

        #endregion

        #region NotifyPropertyChanged Items

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));

        }

        #endregion

        #region Commands
        public ICommand NextStateCommand
        {
            get;
            internal set;
        }

        private bool CanExecuteNestStateCommand()
        {
            return true;
        }

        private void CreateNextStateCommand()
        {
            NextStateCommand = new RelayCommand(NextStateExecute, CanExecuteNestStateCommand);
        }

        public void NextStateExecute()
        {
            Next();
        }

        #endregion
    }
}
