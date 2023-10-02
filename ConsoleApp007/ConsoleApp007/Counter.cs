using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp007
{
    internal class Counter
    {
        private int _min;
        private int _max;
        private int _current;

        public Counter(){}
        public Counter(int min,int max)
        {
            Min=min; 
            Max=max;
            _current = min;
        }

        public int Min { get { return _min; } set { _min = value; } }
        public int Max { get { return _max; }set { _max = value; } }
        public int getCurrent { get { return _current; }}

        public void increment() => _current++;
        public void decrement() => _current--;

    }
}
