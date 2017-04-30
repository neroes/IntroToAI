using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inference_Engine
{
    class Heuristic : IComparer<Path>
    {
        int gm;
        int hm;

        public int Compare(Path x, Path y)
        {
            int res = f(x).CompareTo(f(y));
            if (res == 0) { return x.id.CompareTo(y.id); }
            return res;
        }

        private int f(Path p)
        {
            return  h(p) +g(p);
        }
        
        private int h(Path p)
        {
            return p.current.h()*hm;
        }

        private int g(Path p)
        {
            return p.g*gm;
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
