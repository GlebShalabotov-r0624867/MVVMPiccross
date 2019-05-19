using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cells;
using PiCross;

namespace ViewModel
{
    class ChangeableSquare 
    {
        private IPlayablePuzzleSquare changeableSquare;
    


        public ChangeableSquare(IPlayablePuzzleSquare square)
        {
            this.changeableSquare = square;
            ChangeColor = new ClickCommand(this);

        }
        public ICommand ChangeColor { get; }
        public Cell<Square> CellContents
        {
            get
            {
                return this.changeableSquare.Contents;
            }
        }

        private class ClickCommand : ICommand
        {
            private ChangeableSquare _cs;

            public ClickCommand(ChangeableSquare cs)
            {
                this._cs = cs;
            }
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                if (_cs.CellContents.Value == Square.UNKNOWN)
                {
                    _cs.CellContents.Value = Square.FILLED;
                }
                else if (_cs.CellContents.Value == Square.FILLED)
                {
                    _cs.CellContents.Value = Square.EMPTY;
                }
                else if (_cs.CellContents.Value == Square.EMPTY)
                {
                    _cs.CellContents.Value = Square.UNKNOWN;
                }
            }
        }
    }
}
