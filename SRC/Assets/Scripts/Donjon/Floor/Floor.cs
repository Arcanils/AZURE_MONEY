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

		public Cell GetCell(Vector2Int pos)
		{
			return IsValidPosition(pos) ? Cells[pos.y, pos.x] : null;
		}

        public bool IsValidPosition(Vector2Int posToTest)
        {
            return posToTest.y < YLength && posToTest.y >= 0 && posToTest.x < XLength && posToTest.x >= 0;
        }

    }
}
