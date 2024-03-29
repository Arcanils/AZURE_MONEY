﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dungeon.Character
{
	public class UiComponent : BaseCharacterComponent
	{
		public Transform UiTrans { get; private set; }
		private UiCharacter m_uiCharacter;

		public UiComponent(BaseCharacter character) : base(character)
		{
			m_uiCharacter = UiCharacterManager.CreateAndInitUiCharacter(null);
			UiTrans = m_uiCharacter.transform;
		}

		public void UpdatePos(Point pos)
		{
			m_uiCharacter.UpdatePos(pos);
		}
	}
}