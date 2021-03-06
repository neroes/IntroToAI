﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inference_Engine;

namespace IntroToAI
{
    class Program
    {
        static void Main(string[] args)
        {
            Map map = DataReader.ReadMap("copenhagen.txt");

            Node start = map.lookup("Studiestraede", "Larsbjoernsstraede");
            Node stop = map.lookup("Noerrevoldgade", "Noerregade");
            //Node start = map.findNode(0, 0);
            //Node stop = map.findNode(1, 5);


            Path Route = solver(start, stop, map);
            LinkedList<Mapreadout> readout = new LinkedList<Mapreadout>();
            Mapreadout currentstreet = new Mapreadout(Route.parent.me,Route.parent.getStreetName(Route.me),Route.me, Route.distanceRem, Route.distanceCov);
            while (Route.parent != null)
            {
                if (currentstreet.isStreetName(Route.parent.getStreetName(Route.me)))
                {
                    currentstreet.updateStart(Route.parent.me);
                }
                else
                {
                    readout.AddFirst(currentstreet);
                    currentstreet = new Mapreadout(Route.parent.me, Route.parent.getStreetName(Route.me), Route.me, Route.distanceRem, Route.distanceCov);
                }
                Route = Route.parent;
            }
            readout.AddFirst(currentstreet);
            foreach (Mapreadout read in readout)
            {
                System.Console.WriteLine(read.toString());
            }
            Inference_Engine.Program.run();

            System.Console.Write("pizza");
        }
        public static Path solver(Node start, Node finish, Map map)
        {
            Path.setgoal(finish);
            Path startPath = new Path(start);
            
            Search search = new Search(new Astar());
            search.addToFrontier(startPath);

            while (!search.frontierIsEmpty())
            {
                Path spath = search.getFromFrontier();
                if (spath.isGoal()) {
                    search.frontierIsEmpty(); // This is for the debugger to access search and see the amount of explored nodes.
                    return spath;
                } 
                List<Node> connectionlist = spath.getAllConnections();
                foreach (Node nnode in connectionlist)
                {
                    if (!search.inExplored(nnode))
                    {
                        Path npath = new Path(spath, nnode);
                        search.addToFrontier(npath);
                    }
                    
                }
            }
            return null;
        }
    }
    public struct Mapreadout
    {
        Node start;
        string roadName;
        Node stop;
        double h;
        double g;

        public Mapreadout(Node start, string roadName, Node stop, double h, double g)
        {
            this.start = start;
            this.roadName = roadName;
            this.stop = stop;
            this.h = h;
            this.g = g;
        }
        public void updateStart(Node newStart)
        {
            start = newStart;
        }
        public bool isStreetName(string streetname)
        {
            return (roadName == streetname);
        }
        public double f()
        {
            return g + h;
        }
        public string toString()
        {
            return start.point.X + " " + start.point.Y + " " + roadName + " " + stop.point.X + " " + stop.point.Y + "\t| G: " + Math.Round(g, 3) + "\t| H: " + Math.Round(h, 3) + "\t| F: "+ Math.Round(f(), 3);
        }
    }
}
