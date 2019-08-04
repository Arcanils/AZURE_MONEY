using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donjon.Character
{
	public class MovementComponent : BaseCharacterComponent
	{
		private EDirection m_dir;

		public Vector2Int CurrentPos { get; private set; }

		public MovementComponent(BaseCharacter character, Vector2Int pos) : base(character)
		{
			CurrentPos = pos;
			FloorManager.SetCharToCell(pos, character);
		}

		public void Move(EDirection dir)
		{
			m_dir = dir;
			FloorManager.MoveToCell(CurrentPos, m_dir, m_char);
		}

		public void SetPosition(Vector2Int newPos)
		{
			Debug.LogFormat("SetPosition {0} => {1}", CurrentPos, newPos);
			CurrentPos = newPos;
			m_char.UiComponent.UpdatePos(CurrentPos);
		}
	}
}
