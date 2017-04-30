using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToAI
{
    class Search
    {
        private static Heuristic<Path> h = new Heuristic<Path>();
        private SortedSet<Path> frontier = new SortedSet<Path>(h);
        private HashSet<Node> explored = new HashSet<Node>();

        public void addToFrontier(Path path)
        {

            frontier.Add(path);
            explored.Add(path.me);
        }
        public bool frontierIsEmpty()
        {
            return (frontier.Count == 0);
        }
        public Path getFromFrontier()
        {
            Path first = frontier.First();
            frontier.Remove(first);
            return first;
        }
        
        public bool inFrontier(Node node)
        {
            foreach (Path path in frontier)
            {
                if (path.me == node) { return true; }
            }
            return false;
        }
        public bool inExplored(Node node)
        {
            return explored.Contains(node);
        }
    }
}
