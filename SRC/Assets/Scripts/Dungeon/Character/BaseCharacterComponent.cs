using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dungeon.Character
{
	public abstract class BaseCharacterComponent
	{
		protected BaseCharacter m_char;

		public BaseCharacterComponent(BaseCharacter character)
		{
			m_char = character;
		}
	}
}