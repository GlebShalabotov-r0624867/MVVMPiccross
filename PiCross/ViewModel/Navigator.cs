using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class Navigator : INotifyPropertyChanged
    {
        private PiCrossWindow currentWindow;

        public Navigator()
        {
            this.currentWindow = new StartScreen(this);
        }

        public PiCrossWindow CurrentWindow
        {
            get
            {
                return currentWindow;
            }
            set
            {
                this.currentWindow = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentWindow)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public abstract class PiCrossWindow
    {
        protected readonly Navigator navigator;

        protected PiCrossWindow(Navigator navigator)
        {
            this.navigator = navigator;
        }

        protected void SwitchTo(PiCrossWindow piCrossWindow)
        {
            this.navigator.CurrentWindow = piCrossWindow;
        }
    }

    public class StartScreen : PiCrossWindow
    {
        public StartScreen(Navigator navigator) : base(navigator)
        {
            Start = new EasyCommand(() => SwitchTo(new PlayableWindow(navigator)));
            ChoosePuzzle = new EasyCommand(() => SwitchTo(new PuzzleGenerator(navigator)));
        }

        public ICommand Start { get; }
        public ICommand ChoosePuzzle { get; }
    }


    public class EasyCommand : ICommand
    {
        private readonly Action action;

        public EasyCommand(Action action)
        {
            this.action = action;
        }

        // The add { } remove { } gets rid of annoying warning
        public event EventHandler CanExecuteChanged { add { } remove { } }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action();
        }
    }
}
