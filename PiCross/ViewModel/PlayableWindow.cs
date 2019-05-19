using DataStructures;
using PiCross;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace ViewModel
{
    public class PlayableWindow
    {
        public PlayableWindow()
        {
            var puzzle = Puzzle.FromRowStrings(
                        "xxxxx",
                        "x...x",
                        "x...x",
                        "x...x",
                        "xxxxx"
           );
            var facade = new PiCrossFacade();
            var playablePuzzle = facade.CreatePlayablePuzzle(puzzle);

            

            this.Grid = playablePuzzle.Grid.Map(square => new ChangeableSquare(square));
            this.ColumnConstraints = playablePuzzle.ColumnConstraints;
            this.RowConstraints = playablePuzzle.RowConstraints;
        }

        public IGrid<object> Grid { get; }
        public ISequence<object> RowConstraints { get; }
        public ISequence<object> ColumnConstraints { get; }

    }
}
