using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkr
{
    public class Graph
    {
       
        public List<GraphVertex> Vertices { get; }

        public Graph()
        {
            Vertices = new List<GraphVertex>();
        }
        public void AddVertex(string vertexName)
        {
            Vertices.Add(new GraphVertex(vertexName));
        }

      
        public GraphVertex FindVertex(string vertexName)
        {
            foreach (var v in Vertices)
            {
                if (v.Name.Equals(vertexName))
                {
                    return v;
                }
            }

            return null;
        }

       
        public void AddEdge(string firstName, string secondName, int weight)
        {
            var v1 = FindVertex(firstName);
            var v2 = FindVertex(secondName);
            if (v2 != null && v1 != null)
            {
                v1.AddEdge(v2, weight);
                v2.AddEdge(v1, weight);
            }
        }

        public int GetEdgeWeight(GraphVertex v1, GraphVertex v2)
        {
            foreach (var edge in v1.Edges)
            {
                if (edge.ConnectedVertex == v2)
                {
                    return edge.EdgeWeight;
                }
            }

            return 0;
        }
    }

    public class GraphVertex
    {
       
        public string Name { get; }

        
        public List<GraphEdge> Edges { get; }

        
        public GraphVertex(string vertexName)
        {
            Name = vertexName;
            Edges = new List<GraphEdge>();
        }

       
        public void AddEdge(GraphEdge newEdge)
        {
            Edges.Add(newEdge);
        }

       
        public void AddEdge(GraphVertex vertex, int edgeWeight)
        {
            AddEdge(new GraphEdge(vertex, edgeWeight));
        }
        public override string ToString() => Name;
    }


    public class GraphEdge
    {
        public GraphVertex ConnectedVertex { get; }

        public int EdgeWeight { get; }

        public GraphEdge(GraphVertex connectedVertex, int weight)
        {
            ConnectedVertex = connectedVertex;
            EdgeWeight = weight;
        }
    }
}
