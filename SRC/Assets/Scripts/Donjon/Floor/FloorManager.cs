using Donjon.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donjon
{
	public class FloorManager
	{
		private Floor m_floor;

		private static FloorManager m_instance;

		public FloorManager()
		{
			m_instance = this;
		}

		public void InitFloor(Floor floor)
		{
			m_floor = floor;
		}

		public static Cell GetCell(Vector2Int currentPos)
		{
			return m_instance.m_floor.GetCell(currentPos);
		}

		public static Cell GetCell(Vector2Int currentPos, EDirection dir)
		{
			var newPos = CharacterRuntimeUtils.GetPositionWithDir(currentPos, dir);
			Debug.LogFormat("GetCell result {0} + {1} = {2}", currentPos, dir, newPos);
			return GetCell(newPos);
		}

		public static bool MoveToCell(Vector2Int currentPos, EDirection dir, BaseCharacter character)
		{
			var previousCell = GetCell(currentPos);
			var cell = GetCell(currentPos, dir);

			if (cell == null || previousCell == null)
				return false;

			if (!cell.CanMoveOnIt())
				return false;

			cell.CurrentChar = character;
			previousCell.CurrentChar = null;

			character.SetPosition(cell.Position);
			return true;
		}

		public static bool SetCharToCell(Vector2Int pos, BaseCharacter character, bool updatePositionChar = false)
		{
			var cell = GetCell(pos);

			if (cell == null)
				return false;

			if (!cell.CanMoveOnIt())
				return false;

			cell.CurrentChar = character;

			if (updatePositionChar)
				character.SetPosition(cell.Position);
			return true;
		}
	}
}