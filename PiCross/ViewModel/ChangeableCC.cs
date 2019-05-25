using Cells;
using DataStructures;
using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    class ChangeableCC 
    {
        private IPlayablePuzzleConstraints columnConstraints;
        public ChangeableCC(IPlayablePuzzleConstraints constraints)
        {
            this.columnConstraints = constraints;
            //constraints hebben een value, dus ik moet deze ook hebben om te zien als ik een match heb
            //om te zien als deze matchen   
            this.Values = this.columnConstraints.Values.Map(value => new ChangeableValue(value, IsSatisfied));


        }
        public ISequence<ChangeableValue> Values { get; }
       
       
        public Cell<bool> IsSatisfied
        {
            get
            {
                return this.columnConstraints.IsSatisfied;

            }
        }


    }
}
