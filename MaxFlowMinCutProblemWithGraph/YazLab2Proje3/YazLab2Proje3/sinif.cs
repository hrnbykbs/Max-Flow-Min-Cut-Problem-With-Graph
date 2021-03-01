using System;
using System.Collections.Generic;

namespace YazLab2Proje3
{
    public static class sinif
    {
        public static string[] muslukliste = new string[10];
        public static string[] MuslukListe
        {
            get
            {
                return muslukliste;
            }
            set
            {
                muslukliste = value;
            }
        }

        public static string[] dizi = new string[50];
        public static string[] Dizi
        {
            get
            {
                return dizi;
            }
            set
            {
                dizi = value;
            }
        }

        public static int secilenler;
        public static int Secilenler
        {
            get
            {
                return secilenler;
            }
            set
            {
                secilenler = value;
            }
        }

        public static string[] secilenlertxt=new string[50];
        public static string[] SecilenlerTxt
        {
            get
            {
                return secilenlertxt;
            }
            set
            {
                secilenlertxt = value;
            }
        }


        public static int muslukSay;
        public static int[,] kenar;
        public static bool bfs(int[,] rGraph, int s, int t, int[] parent, int V)
        {
            bool[] ziyaret_edilen = new bool[V];
            for (int i = 0; i < V; ++i)
            {
                ziyaret_edilen[i] = false;
            }
            List<int> kuyruk = new List<int>();
            kuyruk.Add(s);
            ziyaret_edilen[s] = true;
            parent[s] = -1;
            while (kuyruk.Count != 0)
            {
                int u = kuyruk[0];
                kuyruk.RemoveAt(0);
                for (int v = 0; v < V; v++)
                {
                    if (ziyaret_edilen[v] == false && rGraph[u, v] > 0)
                    {
                        kuyruk.Add(v);
                        parent[v] = u;
                        ziyaret_edilen[v] = true;
                    }
                }
            }
            return (ziyaret_edilen[t] == true);
        }
        public static int fordFulkerson(int[,] graph, int s, int t, int V)
        {
            int u, v;
            int[,] rGraph = new int[V, V];
            for (u = 0; u < V; u++)
                for (v = 0; v < V; v++)
                    rGraph[u, v] = graph[u, v];
            int[] parent = new int[V];
            int max_flow = 0;
            while (bfs(rGraph, s, t, parent, V))
            {
                int path_flow = int.MaxValue;
                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    path_flow = Math.Min(path_flow, rGraph[u, v]);
                }
                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    rGraph[u, v] -= path_flow;
                    rGraph[v, u] += path_flow;
                }
                max_flow += path_flow;
            }
            return max_flow;
        }
        private static bool bfs(int[,] rGraph, int s, int t, int[] parent)
        {
            bool[] ziyaret_edilen = new bool[rGraph.Length];
            Queue<int> kuyruk = new Queue<int>();
            kuyruk.Enqueue(s);
            ziyaret_edilen[s] = true;
            parent[s] = -1;
            while (kuyruk.Count != 0)
            {
                int v = kuyruk.Dequeue();
                for (int i = 0; i < rGraph.GetLength(0); i++)
                {
                    if (rGraph[v, i] > 0 && !ziyaret_edilen[i])
                    {
                        kuyruk.Enqueue(i);
                        ziyaret_edilen[i] = true;
                        parent[i] = v;
                    }
                }
            }
            return (ziyaret_edilen[t] == true);
        }
        private static void dfs(int[,] rGraph, int s, bool[] ziyaret_edilen)
        {
            ziyaret_edilen[s] = true;
            for (int i = 0; i < rGraph.GetLength(0); i++)
            {
                if (rGraph[s, i] > 0 && !ziyaret_edilen[i])
                {
                    dfs(rGraph, i, ziyaret_edilen);
                }
            }
        }
        public static string minCut(int[,] graph, int s, int t)
        {
            int u, v;
            int[,] rGraph = new int[graph.Length, graph.Length];
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    rGraph[i, j] = graph[i, j];
                }
            }
            int[] parent = new int[graph.Length];
            while (bfs(rGraph, s, t, parent))
            {
                int pathFlow = int.MaxValue;
                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    pathFlow = Math.Min(pathFlow, rGraph[u, v]);
                }
                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    rGraph[u, v] = rGraph[u, v] - pathFlow;
                    rGraph[v, u] = rGraph[v, u] + pathFlow;
                }
            }
            bool[] isziyaret_edilen = new bool[graph.Length];
            dfs(rGraph, s, isziyaret_edilen);
            string yolla = "";
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    if (graph[i, j] > 0 && isziyaret_edilen[i] && !isziyaret_edilen[j])
                    {
                        yolla = yolla + sinif.MuslukListe[i] + "-" + sinif.MuslukListe[j] + "\n";
                    }
                }
            }
            return yolla;
        }
    }
}