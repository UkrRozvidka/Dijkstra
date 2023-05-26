using System;
using System.Collections.Generic;

namespace mkr
{
    class Program
    {
        static void Main(string[] args)
        {
            var g = new Graph();

            for(int i = 1; i <=30; i++)
                g.AddVertex(i.ToString());



            g.AddEdge("1", "19", 5);
            g.AddEdge("1", "2",  7);
            g.AddEdge("1", "3",  3);
            g.AddEdge("2", "3",  3);
            g.AddEdge("2", "4",  2);
            g.AddEdge("2", "13", 3);
            g.AddEdge("2", "15", 11);
            g.AddEdge("3", "30", 11);
            g.AddEdge("3", "29", 2);
            g.AddEdge("3", "12", 1);
            g.AddEdge("4", "5", 3);
            g.AddEdge("4", "6", 3);
            g.AddEdge("5", "23", 8);
            g.AddEdge("5", "7", 3);
            g.AddEdge("5", "6", 5);
            g.AddEdge("6", "15",3);
            g.AddEdge("7", "8", 1);
            g.AddEdge("7", "9", 1);
            g.AddEdge("7", "10", 2);
            g.AddEdge("7", "11", 5);
            g.AddEdge("7", "15", 2);
            g.AddEdge("12", "13",1);
            g.AddEdge("13", "14", 5);
            g.AddEdge("13", "27", 2);
            g.AddEdge("15", "16", 3);
            g.AddEdge("15", "17", 1);
            g.AddEdge("15", "18", 2);
            g.AddEdge("19", "20", 4);
            g.AddEdge("19", "30", 3);
            g.AddEdge("20", "21", 4);
            g.AddEdge("20", "23", 8);
            g.AddEdge("21", "23", 2);
            g.AddEdge("22", "23", 3);
            g.AddEdge("24", "23", 5);
            g.AddEdge("29", "30", 5);
            g.AddEdge("26", "27", 1);
            g.AddEdge("25", "27", 3);
            g.AddEdge("27", "28", 2);

            var dijkstra = new Dijkstra(g);
            Console.WriteLine("Ведіть вершину з якої почати: ");
            var startVertex = g.FindVertex(Console.ReadLine());

            Console.WriteLine("Початкова вершина\tКінцева вершина\t\tДовжина маршруту\tМаршрут");
            foreach (var endVertex in g.Vertices)
            {
                if (endVertex == startVertex) continue;

                Console.Write("\t"+startVertex.Name + "\t   -->\t\t" + endVertex.Name + "\t\t\t");
                var path = dijkstra.FindShortestPath(startVertex, endVertex);
                var range = dijkstra.GetRange(path);
                Console.Write(range.ToString()+"\t\t");
                foreach (var v in path)
                {
                    Console.Write(v + " ");
                }
                Console.WriteLine();            
            }   
        }
    }
}