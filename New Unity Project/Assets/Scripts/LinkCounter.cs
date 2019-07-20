using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkCounter : MonoBehaviour
{
    List<List<int>> paths = new List<List<int>>();
    List<GameObject> links = new List<GameObject>();
    List<GraphEdge> neighbours = new List<GraphEdge>();
    public static LinkCounter instance;
    //Up, Down, Left, Right Bounds for board
    public List<float> boardBounds;
    // Start is called before the first frame update
    bool foundLoop = false;
    void Start()
    {
        instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddLinksAndCheckNeighbours(GameObject link)
    {
        Collider linkCollider = link.GetComponent<Collider>();
        for(int i = 0; i < links.Count; i++)
        {
            if (linkCollider.bounds.Contains(links[i].transform.position))
            {
                neighbours.Add(new GraphEdge(i, links.Count));
                print(i.ToString() + " is linked to " + links.Count.ToString());
                paths.Add(new List<int> { neighbours.Count - 1 });
            }
        }
        AddLinkToList(link);
        CheckLoop();
    }

    void AddLinkToList(GameObject link)
    {
        links.Add(link);
    }

    public void SetBoardBounds(List<float> bounds)
    {
        boardBounds = bounds;
    }

    void CheckLoop()
    {
        for (int i = 0; i < neighbours.Count; i++)
        {
            paths = CheckAllNeighbours(paths);
        }
        foundLoop = CheckPaths(paths);
    }

    List<List<int>> CheckAllNeighbours(List<List<int>> paths)
    {
        List<List<int>> newPaths = new List<List<int>>();
        foreach (List<int> path in paths)
        {
            for(int i = 0; i < neighbours.Count; i++)
            {
                List<int> newPath = new List<int>();
                newPath.AddRange(path);
                print(path);
                if ( neighbours[i].node1 == path[path.Count - 1] && (path.Count < 2 || neighbours[i].node2 != path[path.Count - 2]))
                {
                    newPath.Add(i);
                }
                else if (neighbours[i].node2 == path[path.Count - 1] && (path.Count < 2 || neighbours[i].node1 != path[path.Count - 2]))
                {
                    newPath.Add(i);
                }
                newPaths.Add(newPath);
            }
        }
        return newPaths;
    }
    bool CheckPaths(List<List<int>> paths)
    {
        foreach (List<int> path in paths)
        {
            int i = 0;
            foreach (int node in path)
            {
                if(path.IndexOf(node,i+1) != -1)
                {
                    print(path);
                    return true;
                }
                i++;
            }
        }
        return false;
    }
}
