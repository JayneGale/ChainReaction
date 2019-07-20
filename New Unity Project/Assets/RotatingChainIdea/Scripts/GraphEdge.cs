using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphEdge
{
    public readonly int node1;
    public readonly int node2;

    public GraphEdge(int n1, int n2)
    {
        node1 = n1;
        node2 = n2;
    }
}
