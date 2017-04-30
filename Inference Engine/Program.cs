using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;

namespace Inference_Engine
{
    public class Program
    {
        static void Main(string[] args)
        {
            run();

        }
        public static void run()
        {
            Collection<KnowledgeBaseEntry> knowledge = new Collection<KnowledgeBaseEntry>();
            foreach (string s in File.ReadLines("KnowledgeBase.txt"))
            {
                knowledge.Add(new KnowledgeBaseEntry(s));
            }
            Path solution = solver(knowledge, new KnowledgeBaseEntry("~a"));
            while (solution.parent != null)
            {
                System.Console.WriteLine(solution.toString());
                solution = solution.parent;
            }
        }
        public static Path solver(Collection<KnowledgeBaseEntry> knowledge, KnowledgeBaseEntry start)
        {
            Path startpath = new Path(start);

            Search search = new Search();
            search.addToFrontier(startpath);
            System.Console.WriteLine("haps");
            while (!search.frontierIsEmpty())
            {
                Path current = search.getFromFrontier();
                if (current.current.isgoal()) { return current; }
                foreach (KnowledgeBaseEntry knowentry in knowledge)
                {
                    KnowledgeBaseEntry newKnow = new KnowledgeBaseEntry(current.current, knowentry);
                    Path next = new Path(current, newKnow, knowentry);
                    if (!search.inExplored(next.current))
                    {
                        search.addToFrontier(next);
                    }
                }
            }
            System.Console.WriteLine("haps");
            return null;
        }
        
    }
    public class Path
    {
        private static long _id = 0;

        public long id;
        public Path parent;
        public KnowledgeBaseEntry combiner;
        public KnowledgeBaseEntry current;
        public int g;
        public Path(KnowledgeBaseEntry current)
        {
            id = _id++;
            g = 0;
            this.current = current;
        }
        public Path(Path parent,KnowledgeBaseEntry current, KnowledgeBaseEntry combiner)
        {
            id = _id++;
            this.parent = parent;
            this.current = current;
            this.combiner = combiner;
            g = this.parent.g + 1;
        }
        public string toString()
        {
            string basestring = "( " + parent.current.toString() + " ) && (" + combiner.toString() + " ) -> " + current.toString();
            string functionstring = "\t | H = " + current.h() + "\t | G = " + g + "\t | F = " + (current.h()+g);
            return basestring + functionstring;
        }
        public override bool Equals(Object obj)
        {
            return obj is Path && current.Equals(((Path)obj).current);
        }
        public override int GetHashCode()
        {
            return current.GetHashCode();
        }
    }
}
