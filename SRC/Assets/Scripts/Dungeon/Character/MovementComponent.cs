using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dungeon.Character
{
	public class MovementComponent : BaseCharacterComponent
	{
		private EDirection m_dir;

		public Point CurrentPos { get; private set; }

		public MovementComponent(BaseCharacter character, Point pos) : base(character)
		{
			CurrentPos = pos;
			FloorManager.SetCharToCell(pos, character);
		}

		public void Move(EDirection dir)
		{
			m_dir = dir;
			FloorManager.MoveToCell(CurrentPos, m_dir, m_char);
		}

        public void Move(Point nextPos)
        {
            FloorManager.MoveToCell(CurrentPos, nextPos, m_char);
        }

		public void SetPosition(Point newPos)
		{
			Debug.LogFormat("SetPosition {0} => {1}", CurrentPos, newPos);
			CurrentPos = newPos;
			m_char.UiComponent.UpdatePos(CurrentPos);
		}
	}
}
