using Cells;
using PiCross;

namespace ViewModel
{
    internal class ChangeableValue 
    {
        private IPlayablePuzzleConstraintsValue _value;

        public ChangeableValue(IPlayablePuzzleConstraintsValue value)
        {
            this._value = value;
        }

        public int Value
        {
            get
            {
                return this._value.Value;
            }
        }
        //een cell is iets dat de anders voorwerpen automatisch gaat update aangezien hier ze aan gesubscribed zijn 
        public Cell<bool> IsSatisfied
        {
            get
            {
                return this._value.IsSatisfied;
            }
        }

    }
}