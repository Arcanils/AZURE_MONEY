using Donjon;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar
{
    private struct Tile
    {
        public float g, h, f;

        public Vector2Int parentPos;
    }

    public struct FandPos
    {
        public float f;
        public Vector2Int pos;
    }

    
    public void Search(
        Func<Vector2Int> isCellValid, 
        Floor floor, 
        Vector2Int startPos,
        Vector2Int endPos)
    {
        if (!floor.IsValidPosition(startPos))
            return;

        if (!floor.IsValidPosition(endPos))
            return;

        //Test start end blocked

        var closeList = new bool[floor.YLength, floor.XLength];
        var cellDetails = new Tile[floor.YLength, floor.XLength];
        for (int i = 0; i < floor.YLength; i++)
        {
            for (int j = 0; j < floor.XLength; j++)
            {
                cellDetails[i,j].f = float.MaxValue;
                cellDetails[i,j].g = float.MaxValue;
                cellDetails[i,j].h = float.MaxValue;
                cellDetails[i, j].parentPos = new Vector2Int(-1, -1);
            }
        }

        // add starting node to open list

        var yIndex = startPos.y;
        var xIndex = startPos.x;
        cellDetails[yIndex,xIndex].f = 0.0f;
        cellDetails[yIndex,xIndex].g = 0.0f;
        cellDetails[yIndex,xIndex].h = 0.0f;
        cellDetails[yIndex, xIndex].parentPos = startPos;

        var openList = new HashSet<FandPos>();

        while (openList.Count != 0)
        {
            //find node with the small f in openList
            var q = openList.GetEnumerator().Current;
            openList.Remove(q);
            startPos = q.pos;
            closeList[startPos.y, startPos.x] = true;

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

                var hasNodeSamePos = openList.Find(item => item.pos == successor.parentPos && item.f <= successor.f) != null;

                if (hasNodeSamePos)
                    continue;


                hasNodeSamePos = closeList.Find(item => item.pos == successor.parentPos && item.f <= successor.f) != null;

                if (hasNodeSamePos)
                    continue;

                openList.Add(successor);
            }

            closeList.Add(q);
        }

        return;
    }

    private static bool IsNValid(
        Floor floor, int yPos, int xPos,
        Vector2Int currentPos, Vector2Int endPos, 
        Tile[,] cellDetails, bool[,] closedList,
        HashSet<FandPos> openList)
    {
        var pos = new Vector2Int(xPos, yPos);
        if (!floor.IsValidPosition(pos))
            return false;

        // If the destination cell is the same as the 
        // current successor 
        if (pos == endPos)
        {
            // Set the Parent of the destination cell 
            cellDetails[pos.y, pos.x].parentPos = currentPos;
            return true;
        }
        // If the successor is already on the closed 
        // list or if it is blocked, then ignore it. 
        // Else do the following 
        if (closedList[pos.y, pos.x] != false || !floor.isUnBlocked(pos))
            return false;

        var gNew = cellDetails[currentPos.y, currentPos.x].g + 1.0;
        var hNew = calculateHValue(pos, endPos);
        var fNew = gNew + hNew;

        // If it isn’t on the open list, add it to 
        // the open list. Make the current square 
        // the parent of this square. Record the 
        // f, g, and h costs of the square cell 
        //                OR 
        // If it is on the open list already, check 
        // to see if this path to that square is better, 
        // using 'f' cost as the measure. 
        if (cellDetails[pos.y, pos.x].f != float.MaxValue && cellDetails[pos.y, pos.x].f <= fNew)
            return false;

        openList.Add(new FandPos() { f = fNew, pos = pos });

        // Update the details of this cell 
        cellDetails[pos.y, pos.x].f = fNew;
        cellDetails[pos.y, pos.x].g = gNew;
        cellDetails[pos.y, pos.x].h = hNew;
        cellDetails[pos.y, pos.x].parentPos = currentPos;
    }
}
