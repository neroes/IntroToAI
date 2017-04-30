using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToAI
{
    abstract class Heuristic : IComparer<Path>
    {        
        public virtual int Compare(Path x, Path y)
        {
            int comp = f(x).CompareTo(f(y));
            if (comp == 0) { return x.id.CompareTo(y.id); }
            return comp;
        }

        internal double h(Path p)
        {
            return p.distanceRem;
        }

        internal double g(Path p)
        {
            return p.distanceCov;
        }
        
        public virtual double f(Path p) { return 0; }
    }

    class Astar : Heuristic
    {
        public override double f(Path m)
        {
            return g(m) + h(m);
        }
    }

    class WAstar : Heuristic
    {
        private int W;

        public WAstar(int W)
        {
            this.W = W;
        }

        public override double f(Path m)
        {
            return g(m) + h(m) * W;
        }
    }

    class Greedy : Heuristic
    {
        public override double f(Path m)
        {
            return h(m);
        }
    }

    class BFS : Heuristic {
        public override int Compare(Path x, Path y)
        {
            return x.id.CompareTo(y.id);
        }
    }

    class DFS : Heuristic
    {
        public override int Compare(Path x, Path y)
        {
            return y.id.CompareTo(x.id);
        }
    }
}
