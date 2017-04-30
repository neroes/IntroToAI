using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inference_Engine
{
    class Search
    {
        private static Heuristic h = new Heuristic();
        private SortedSet<Path> frontier = new SortedSet<Path>(h);
        private HashSet<KnowledgeBaseEntry> explored = new HashSet<KnowledgeBaseEntry>();

        public void addToFrontier(Path path)
        {
            System.Console.WriteLine(path.current.toString());
            if (!frontier.Add(path))
            {
                System.Console.WriteLine(path.current.toString());
            }

            explored.Add(path.current);
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
        
        public bool inFrontier(Path node)
        {
            foreach (Path path in frontier)
            {
                if (path == node) { return true; }
            }
            return false;
        }
        public bool inExplored(KnowledgeBaseEntry node)
        {
            return explored.Contains(node);
        }
    }
}
