using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToAI
{
    class Path
    {
        private static long _id = 0;

        public long id;
        static Node goal;
        public Path parent;
        public Node me;
        public double distanceCov = 0;
        public double distanceRem;
        public Path (Node node)
        {
            id = _id++;
            me = node;
            distanceRem = me.getdistance(goal);
        }
        public string getStreetName(Node node)
        {
            return me.getstreetname(node);
        }
        public Path (Path parent, Node node) : this(node)
        {
            distanceCov = parent.me.getdistance(node) + parent.distanceCov;
            this.parent = parent;
        }
        public static void setgoal(Node goal)
        {
            Path.goal = goal;
        }
        public bool isGoal()
        {
            return (goal.point.X == me.point.X && goal.point.Y == me.point.Y);
        }
        public List<Node> getAllConnections()
        {
            return me.getconnections();
        }
    }
}
