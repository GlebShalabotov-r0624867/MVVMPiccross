using Cells;
using DataStructures;
using PiCross;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ViewModel
{
   public class PuzzleGenerator
    {
      public PuzzleGenerator()
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

            playablePuzzle.Grid[new Vector2D(0, 0)].Contents.Value = Square.FILLED;
            playablePuzzle.Grid[new Vector2D(1, 0)].Contents.Value = Square.EMPTY;

            //Grid = playablePuzzle.Grid;
            //RowConstraints = playablePuzzle.RowConstraints;
            //ColumnConstraints = playablePuzzle.ColumnConstraints;
        }
        
    }

    public class SquareConverter : IValueConverter
    {
        public object Filled { get; set; }
        public object Empty { get; set; }
        public object Unknown { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var square = (Square)value;
            if (square == Square.EMPTY)
            {
                return Empty;
            }
            else if (square == Square.FILLED)
            {
                return Filled;
            }
            else
            {
                return Unknown;
            }
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

      }
    
}
