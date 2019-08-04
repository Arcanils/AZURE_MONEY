using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donjon.Character
{
	public class AiComponent : BaseCharacterComponent
	{
		public AiComponent(BaseCharacter character) : base(character)
		{

		}

		public void Move(EDirection dir)
		{
			m_char.MoveComponent.Move(dir);
		}
	}
}