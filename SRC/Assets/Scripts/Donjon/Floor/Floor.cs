using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donjon
{
	public class Floor
	{
		private readonly Cell[,] Cells;
		private readonly int m_yLength;
		private readonly int m_xLength;

		public Floor(Cell[,] cells, int yLength, int xLength)
		{
			Cells = cells;
			m_yLength = yLength;
			m_xLength = xLength;
			Debug.Log("Init Floor");
		}

		public Cell GetCell(Vector2Int pos)
		{
			if (pos.y >= m_yLength || pos.y < 0)
				return null;
			if (pos.x >= m_xLength || pos.x < 0)
				return null;
			//Debug.LogFormat("GetCell {0} {1} {2}", pos, m_yLength, m_xLength);
			return Cells[pos.y, pos.x];
		}
	}
}
