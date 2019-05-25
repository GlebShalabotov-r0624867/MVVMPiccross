using Cells;
using DataStructures;
using PiCross;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace ViewModel
{
    public class PlayableWindow : PiCrossWindow
    {
        public PlayableWindow(Navigator navigator, Puzzle puzzle = null) : base(navigator)
        {

            
            if (puzzle == null) { 
                puzzle = Puzzle.FromRowStrings(
                        "xxx",
                        "x..",
                        "x.x"
                );
            }
            var facade = new PiCrossFacade();
            playablePuzzle = facade.CreatePlayablePuzzle(puzzle);



            this.Grid = playablePuzzle.Grid.Map(square => new ChangeableSquare(square)).Copy();
            this.ColumnConstraints = playablePuzzle.ColumnConstraints/*.Map(constraints => new ChangeableCC(constraints)).Copy()*/;
            this.RowConstraints = playablePuzzle.RowConstraints/*.Map(constraints => new ChangeableCC(constraints)).Copy()*/;

            BackToStart = new EasyCommand(() => SwitchTo(new StartScreen(navigator)));
            Refresh = new EasyCommand(() => SwitchTo(new PlayableWindow(navigator,puzzle)));
            ChooseOther = new EasyCommand(() => SwitchTo(new PuzzleGenerator(navigator)));
        }

        public IPlayablePuzzle playablePuzzle;
        public IGrid<object> Grid { get; }
        public ISequence<object> RowConstraints { get; }
        public ISequence<object> ColumnConstraints { get; }
        public ICommand BackToStart { get; }
        public ICommand Refresh { get; }
        public ICommand ChooseOther { get; }
        public Cell<bool> IsSolved
        {
            get
            {
                return playablePuzzle.IsSolved;
            }

        }
        
    }


}
