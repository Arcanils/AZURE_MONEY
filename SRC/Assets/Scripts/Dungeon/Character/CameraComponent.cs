using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dungeon.Character
{
	public class CameraComponent : BaseCharacterComponent
	{
		public CameraComponent(BaseCharacter character) : base(character)
		{

		}

		public void FollowCharacter()
		{
			CameraManager.FollowThisChar(m_char);
		}
	}
}