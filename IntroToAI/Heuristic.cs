using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToAI
{
    class Heuristic<Map> : IComparer<Path>
    {
        int gm;
        int hm;

        public int Compare(Path x, Path y)
        {
            return f(x).CompareTo(f(y));
        }

        private double f(Path p)
        {
            return h(p) * hm + g(p) * gm;
        }
        
        private double h(Path p)
        {
            return p.distanceRem;
        }

        private double g(Path p)
        {
            return p.distanceCov;
        }

        private void astar()
        {
            gm = 1;
            hm = 1;
        }

        private void wastar()
        {
            gm = 1;
            hm = 5;
        }

        private void greedy()
        {
            gm = 0;
            hm = 1;
        }

        private void bfs()
        {
            gm = 1;
            hm = 0;
        }

        private void dfs()
        {

        }
    }
}
