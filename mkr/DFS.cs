using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkr
{
    public class DFS_Class
    {
        public static Dictionary<List<GraphVertex>, int> DFS(Graph graph, GraphVertex startVertex, GraphVertex endVertex)
        {
          
            Dictionary<GraphVertex, bool> visited = new Dictionary<GraphVertex, bool>(); 
            List<GraphVertex> path = new List<GraphVertex>(); 
            List<List<GraphVertex>> allPaths = new List<List<GraphVertex>>(); 

            DFSUtil(startVertex, endVertex, visited, path, allPaths);

            Dictionary< List<GraphVertex>, int> allPathesAndRange = new Dictionary<List<GraphVertex>, int>();
            foreach (var p in allPaths)
            {
                int range = 0;
                for (int i = 0; i < p.Count - 1; i++)
                {
                    range += graph.GetEdgeWeight(p[i], p[i + 1]);
                }
                allPathesAndRange.Add(p, range);
            }
            return allPathesAndRange;

        }

        private static void DFSUtil(GraphVertex current, GraphVertex end, Dictionary<GraphVertex, bool> visited, List<GraphVertex> path, List<List<GraphVertex>> allPaths)
        {
            visited[current] = true; 
            path.Add(current); 

            if (current == end)
            {
                allPaths.Add(new List<GraphVertex>(path)); 
            }
            else
            {
                foreach (GraphEdge edge in current.Edges)
                {
                    GraphVertex neighbor = edge.ConnectedVertex;
                    if (!visited.ContainsKey(neighbor) || !visited[neighbor])
                    {
                        DFSUtil(neighbor, end, visited, path, allPaths); 
                    }
                }
            }
            visited[current] = false;
            path.RemoveAt(path.Count - 1);
        }
    }
}
