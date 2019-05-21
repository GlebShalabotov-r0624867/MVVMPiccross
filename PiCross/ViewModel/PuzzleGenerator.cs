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
using System.Windows.Input;

namespace ViewModel
{
    public class PuzzleGenerator : PiCrossWindow
    {
        public PuzzleGenerator(Navigator navigator) : base(navigator)
        {
            var facade = new PiCrossFacade();

            var puzzle1 = Puzzle.FromRowStrings(
                ".......xx.xxxx.",
                ".....xxx.xxxxxx",
                "...xxxx.xxxxx.x",
                "..xxxx.xxxxxxxx",
                ".xxxx.xxxxx.xxx",
                "xx...x...x.xxxx",
                "x.........xxxx.",
                "x.........xxxx.",
                ".x.......xxxxx.",
                ".x.......xxxx..",
                ".x.......xxxx..",
                ".x.......xxx...",
                ".x.......xxx...",
                ".x.......xx....",
                ".xxxxxxxxx....."
            );

            var puzzle2 = Puzzle.FromRowStrings(
                ".x...",
                "xx.xx",
                ".xxx.",
                ".xxx.",
                "..x.."
                );

            var puzzle3 = Puzzle.FromRowStrings(
                ".xx....xx.",
                "...xxxx...",
                "x.xxxxxx.x",
                ".xx.xx.xx.",
                ".xxxxxxxx.",
                ".x.xxxx.x.",
                ".xxxxxxxx.",
                ".xx.xx.xx.",
                "x.xxxxxx.x",
                "...xxxx..."
                );
            this.Puzzles = new PlayablePuzzles[3];
            this.Puzzles[0] = new PlayablePuzzles(navigator, puzzle1, "Bread");
            this.Puzzles[1] = new PlayablePuzzles(navigator, puzzle2, "Chicken");
            this.Puzzles[2] = new PlayablePuzzles(navigator, puzzle3, "LadyBug");

        }
    
        public PlayablePuzzles[] Puzzles { get; }
    }

    public class PlayablePuzzles : PiCrossWindow
    {
        
       
       
        public PlayablePuzzles(Navigator navigator, Puzzle puzzle, String title) : base(navigator)
        {
            this.Size = puzzle.Size.ToString();
            this.Title = title;
            SelectPuzzle = new EasyCommand(() => SwitchTo(new PlayableWindow(navigator, puzzle)));
        }

        public String Size { get; }
        public String Title { get; }
        public ICommand SelectPuzzle { get; }
    }



}
