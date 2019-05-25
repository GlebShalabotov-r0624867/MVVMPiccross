using Cells;
using PiCross;

namespace ViewModel
{
    internal class ChangeableValue 
    {
        private IPlayablePuzzleConstraintsValue _value;
        private Cell<bool> higherSatisfaction;
        public ChangeableValue(IPlayablePuzzleConstraintsValue value, Cell<bool> IsSatisfiedConstrain)
        {
            this._value = value;
            
            this.higherSatisfaction = IsSatisfiedConstrain;
            this.wholecount = Cell.Derived(higherSatisfaction,  IsSatisfied, (cc, v) => cc && v ? 2 : 0);
            
        }

        public int Value
        {
            get
            {
                return this._value.Value;
            }
        }
        //een cell is iets dat de anders voorwerpen automatisch gaat update aangezien hier ze aan gesubscribed zijn 
        public int ok
        {
            get
            {
                return wholecount.Value;
                
            }
            set
            {
                if (higherSatisfaction.Value && IsSatisfied.Value) wholecount.Value = 2;
                else if( IsSatisfied.Value ) wholecount.Value = 1;
                else wholecount.Value = 0;


            }
        }
        public Cell<int> wholecount { get; }

    
        public Cell<bool> IsSatisfied
        {
            get
            {
                return this._value.IsSatisfied;
            }
        }

        
        

    }
}