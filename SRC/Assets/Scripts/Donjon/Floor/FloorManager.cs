using Donjon.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donjon
{
	public class FloorManager
	{
		private Floor m_floor;
        private Vector2 m_cellSize;
        private Vector2 m_gridOrigin;

		private static FloorManager m_instance;

        public static Vector2 CellSize { get { return m_instance.m_cellSize; } }
        public static Vector2 GridOrigin { get { return m_instance.m_gridOrigin; } }

        public FloorManager(Vector3 cellSize, Vector3 gridOrigin)
		{
			m_instance = this;
            m_cellSize = new Vector2(cellSize.x, cellSize.y);
            m_gridOrigin = new Vector2(gridOrigin.x, gridOrigin.y);
        }

		public void InitFloor(Floor floor)
		{
			m_floor = floor;
		}

        public static Floor GetFloor()
        {
            return m_instance.m_floor;
        }


        public static Cell GetCell(Point currentPos)
		{
			return m_instance.m_floor.GetCell(currentPos);
		}

		public static Cell GetCell(Point currentPos, EDirection dir)
		{
			var newPos = CharacterRuntimeUtils.GetPositionWithDir(currentPos, dir);
			Debug.LogFormat("GetCell result {0} + {1} = {2}", currentPos, dir, newPos);
			return GetCell(newPos);
		}

		public static bool MoveToCell(Point currentPos, EDirection dir, BaseCharacter character)
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
        public static bool MoveToCell(Point currentPos, Point nextPos, BaseCharacter character)
        {
            var previousCell = GetCell(currentPos);
            var cell = GetCell(nextPos);

            if (cell == null || previousCell == null)
                return false;

            if (!cell.CanMoveOnIt())
                return false;

            cell.CurrentChar = character;
            previousCell.CurrentChar = null;

            character.SetPosition(cell.Position);
            return true;
        }

        public static bool SetCharToCell(Point pos, BaseCharacter character, bool updatePositionChar = false)
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