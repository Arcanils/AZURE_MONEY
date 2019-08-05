using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar
{
    private class Tile
    {
        public int g;
        public int h;
        public int f { get { return g + h; } }

        public Vector2Int pos;
    }
    public void Search()
    {
        List<Tile> openList = new List<Tile>();
        List<Tile> closeList = new List<Tile>();

        // add starting node to open list

        while (openList.Count != 0)
        {
            //find node with the small f in openList
            Tile q = new Tile();

            openList.Remove(q);

            //generate q's 8 successors and set their parents to q
            Tile[] successors = new Tile[8];
            foreach (var successor in successors)
            {
                var isGoal = false; // IsSuccessorGoal
                if (isGoal)
                {
                    successor.g = q.g + distanceSuccessorQ;
                    successor.h = distanceGoalSuccessor;
                    return;
                }

                var hasNodeSamePos = openList.Find(item => item.pos == successor.pos && item.f <= successor.f) != null;

                if (hasNodeSamePos)
                    continue;


                hasNodeSamePos = closeList.Find(item => item.pos == successor.pos && item.f <= successor.f) != null;

                if (hasNodeSamePos)
                    continue;

                openList.Add(successor);
            }

            closeList.Add(q);
        }

        return;
    }
}
