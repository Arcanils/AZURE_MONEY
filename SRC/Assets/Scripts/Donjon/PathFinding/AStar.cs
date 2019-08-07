using Donjon;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AStar
{
    private struct Tile
    {
        public float g, h, f;
        public Point parentPos;
    }

    public struct FandPos
    {
        public float f;
        public Point pos;
    }

    
    public static void Search( 
        Floor floor,
        Point startPos,
        Point endPos,
        out Stack<Point> path)
    {
        path = null;
        if (!floor.IsValidPosition(startPos))
            return;

        if (!floor.IsValidPosition(endPos))
            return;

        //Test start end blocked

        var closedList = new bool[floor.YLength, floor.XLength];
        var cellDetails = new Tile[floor.YLength, floor.XLength];
        for (int i = 0; i < floor.YLength; i++)
        {
            for (int j = 0; j < floor.XLength; j++)
            {
                cellDetails[i, j] = new Tile()
                {
                    f = float.MaxValue,
                    g = float.MaxValue,
                    h = float.MaxValue,
                    parentPos = new Point(-1, -1),
                };
            }
        }


        cellDetails[startPos.Y, startPos.X] = new Tile() { g = 0.0f, h = 0.0f, parentPos = startPos };

        var openList = new HashSet<FandPos>();
        openList.Add(new FandPos() { f = 0f, pos = startPos });

        // add starting node to open list

        while (openList.Count != 0)
        {
            //find node with the small f in openList
            var enumerator = openList.GetEnumerator();
            enumerator.MoveNext();
            var q = enumerator.Current;
            if (!openList.Remove(q))
            {
                throw new Exception();
            }
            startPos = q.pos;
            closedList[startPos.Y, startPos.X] = true;

            //generate q's 8 successors and set their parents to q
            Tile[] successors = new Tile[8];

             if (IterateSideCell(floor, q.pos.Y + 1, q.pos.X, q.pos, endPos, cellDetails, closedList, openList) ||
                 IterateSideCell(floor, q.pos.Y - 1, q.pos.X, q.pos, endPos, cellDetails, closedList, openList) ||
                 IterateSideCell(floor, q.pos.Y, q.pos.X + 1, q.pos, endPos, cellDetails, closedList, openList) ||
                 IterateSideCell(floor, q.pos.Y, q.pos.X - 1, q.pos, endPos, cellDetails, closedList, openList))
            {
                // finished
                path = new Stack<Point>();

                var itY = endPos.Y;
                var itX = endPos.X;
                while (cellDetails[itY, itX].parentPos != endPos)
                {
                    path.Push(endPos);
                    endPos = cellDetails[itY, itX].parentPos;
                    itY = endPos.Y;
                    itX = endPos.X;
                }

                //path.Push(endPos);

                return;
            }
        }

        return;
    }

    private static bool IterateSideCell(
        Floor floor, int yPos, int xPos,
        Point currentPos, Point endPos, 
        Tile[,] cellDetails, bool[,] closedList,
        HashSet<FandPos> openList)
    {
        var pos = new Point(xPos, yPos);
        if (!floor.IsValidPosition(pos))
            return false;

        // If the destination cell is the same as the 
        // current successor 
        if (pos == endPos)
        {
            // Set the Parent of the destination cell 
            cellDetails[pos.Y, pos.X].parentPos = currentPos;
            return true;
        }
        // If the successor is already on the closed 
        // list or if it is blocked, then ignore it. 
        // Else do the following 
        if (closedList[pos.Y, pos.X] != false || floor.IsBlocked(pos))
            return false;

        var gNew = cellDetails[currentPos.Y, currentPos.X].g + 1f;
        var hNew = CalculateHeuresticValue(pos, endPos);
        var fNew = gNew + hNew;

        // If it isn’t on the open list, add it to 
        // the open list. Make the current square 
        // the parent of this square. Record the 
        // f, g, and h costs of the square cell 
        //                OR 
        // If it is on the open list already, check 
        // to see if this path to that square is better, 
        // using 'f' cost as the measure. 
        if (cellDetails[pos.Y, pos.X].f != float.MaxValue && cellDetails[pos.Y, pos.X].f <= fNew)
            return false;

        openList.Add(new FandPos() { f = fNew, pos = pos });

        // Update the details of this cell 
        cellDetails[pos.Y, pos.X] = new Tile() { f = fNew, g = gNew, h = hNew, parentPos = currentPos };

        return false;
    }

    private static float CalculateHeuresticValue(Point posA, Point posB)
    {
        return Mathf.Abs(posA.X - posB.X) + Mathf.Abs(posA.Y - posB.Y);
    }
}
