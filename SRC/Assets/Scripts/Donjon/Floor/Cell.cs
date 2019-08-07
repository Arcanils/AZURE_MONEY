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

		public readonly Point Position;
		//Item on it ?

		public Cell(ECellType cellType, Point position)
		{
			CellType = cellType;
			Position = position;
		}

        public bool IsCellBlocked()
        {
            return CellType != ECellType.Floor;
        }

		public bool IsAvailable()
		{
			//Debug.LogFormat("CanMoveOnIt => {0} | {1}", CellType == ECellType.Floor, CurrentChar != null);
			return !IsCellBlocked() && CurrentChar == null;
		}

		public bool CanMoveOnIt()
		{
			return IsAvailable();
		}
	}
}
