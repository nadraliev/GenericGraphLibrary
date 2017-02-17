using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphLibrary
{
    public class Graph<V,E>
    {
        private IList<V> vertexes;
        private E[,] edges;

        public V[] Vertexes
        {
            get
            {
                return vertexes.ToArray<V>();
            }
        }

        public E[,] Edges { get; }

        public Graph() {}
        public Graph(IList<V> vertexes) { this.vertexes = vertexes; edges = new E[vertexes.Count, vertexes.Count]; }
        public Graph(IList<V> vertexes, E[,] edges) { this.vertexes = vertexes; this.edges = edges; }

        public void AddVertex(V vertex)
        {
            vertexes.Add(vertex);
            edges = ArraysUtils.ResizeArray<E>(edges, edges.GetLength(0) + 1, edges.GetLength(1) + 1);
        }

        public void RemoveVertexAt(int index)
        {
            vertexes[index] = default(V);
            edges = ArraysUtils.TrimArray(index, index, edges);
        } 

        public void ClearEdge(int from, int to)
        {
            edges[from, to] = default(E);
        }

        public void ClearAllEdges()
        {
            for (int i = 0; i < edges.GetLength(0); i++)
                for (int k = 0; k < edges.GetLength(1); k++)
                    ClearEdge(i, k);
        }

        public bool IsEdgeSet(int from, int to)
        {
            return edges[from, to].Equals(default(E));
        }

        public void ClearGraph()
        {
            vertexes = null;
            edges = null;
        }

        public override string ToString()
        {
            string result = String.Empty;
            result += vertexes.GetType().Name;
            vertexes.ToList<V>().ForEach(x => result += x.ToString() + " ");
            result += Environment.NewLine + edges.GetType().Name;
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                result += Environment.NewLine;
                for (int k = 0; k < edges.GetLength(1); k++)
                    result += i + "," + k + ":" + edges[i,k].ToString() + " ";
            }
            return result;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(vertexes, edges).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Graph<V,E>))
                return false;
            else
                return vertexes.Equals(((Graph<V, E>)obj).vertexes) && edges.Equals(((Graph<V, E>)obj).edges);
        }
    }
}
