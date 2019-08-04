using Donjon.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donjon
{
	public class Cell
	{
		public ECellType CellType;
		public BaseCharacter CurrentChar;

		public readonly Vector2Int Position;
		//Item on it ?

		public Cell(ECellType cellType, Vector2Int position)
		{
			CellType = cellType;
			Position = position;
		}

		public bool IsAvailable()
		{
			//Debug.LogFormat("CanMoveOnIt => {0} | {1}", CellType == ECellType.Floor, CurrentChar != null);
			return CellType == ECellType.Floor && CurrentChar == null;
		}

		public bool CanMoveOnIt()
		{
			return IsAvailable();
		}
	}
}
