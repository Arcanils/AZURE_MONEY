using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donjon
{
	public class Floor
    {
        public readonly int YLength;
        public readonly int XLength;

        private readonly Cell[,] Cells;

		public Floor(Cell[,] cells, int yLength, int xLength)
		{
			Cells = cells;
			YLength = yLength;
			XLength = xLength;
			Debug.Log("Init Floor");
		}

		public Cell GetCell(Point pos)
		{
			return IsValidPosition(pos) ? Cells[pos.Y, pos.X] : null;
		}

        public bool IsValidPosition(Point posToTest)
        {
            return posToTest.Y < YLength && posToTest.Y >= 0 && posToTest.X < XLength && posToTest.X >= 0;
        }

        public bool IsBlocked(Point posToTest)
        {
            var cell = GetCell(posToTest);
            return cell == null || cell.IsCellBlocked();
        }

    }
}
