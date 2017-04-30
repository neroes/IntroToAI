using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToAI
{
    class Map
    {
        List<Node> nodes;
        public static Dictionary<string, Collection<Node>> StreetLookup = new Dictionary<string, Collection<Node>>();
        public Map()
        {
            nodes = new List<Node>();
        }
        internal Node addnode(string v1, string v2)
        {
            int x = Convert.ToInt32(v1); int y = Convert.ToInt32(v2);
            foreach (Node node in nodes)
            {
                if (node.isAtPoint(x, y)){ return node; }
            }
            Node newnode = new Node(x, y);
            nodes.Add(newnode);
            return newnode;
        }

        internal void addconnection(string[] splitline)
        {
            Node node1 = addnode(splitline[0], splitline[1]);
            Node node2 = addnode(splitline[3], splitline[4]);
            node1.addConnection(node2, splitline[2]);
            if (!StreetLookup.ContainsKey(splitline[2]))
            {
                StreetLookup.Add(splitline[2], new Collection<Node>());
            }
            if (!StreetLookup[splitline[2]].Contains(node1))
            {
                StreetLookup[splitline[2]].Add(node1);
            }
            if (!StreetLookup[splitline[2]].Contains(node2))
            {
                StreetLookup[splitline[2]].Add(node2);
            }
        }
        public Node lookup (string street1, string street2)
        {
            foreach (Node n in StreetLookup[street1])
            {
                if (StreetLookup[street2].Contains(n)) { return n; }
            }
            return null;
        }
        public Node findNode (int x, int y)
        {
            foreach(Node node in nodes)
            {
                if (node.point.X == x && node.point.Y == y) { return node; }
            }
            throw (new Exception("none found"));
        }
    }
}
