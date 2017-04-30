using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IntroToAI
{
    public class Node
    {
        List<Node> connections;
        Dictionary<Node,String> connectionNames;
        public Vector point;
        public bool visited;
        public Node(int nx, int ny)
        {
            point.X = nx;
            point.Y = ny;
            visited = false;
            connections = new List<Node>();
            connectionNames = new Dictionary<Node, String>();
        }
        public void addConnection ( Node newCon, String newConName)
        {
            connections.Add(newCon);
            connectionNames.Add(newCon,newConName);
        }
        public string getstreetname (Node node)
        {
            return connectionNames[node];
        }
        public bool isAtPoint(int x, int y)
        {
            return (point.X == x && point.Y == y);
        }
        public double getdistance(Node node2)
        {
            return (point - node2.point).Length;
        }
        public List<Node> getconnections() { return connections; }
    }
}
