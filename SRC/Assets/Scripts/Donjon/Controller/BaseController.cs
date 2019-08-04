using Donjon.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Donjon
{
	public abstract class BaseController
	{
		protected BaseCharacter m_char;

		public BaseController(BaseCharacter character)
		{
			m_char = character;
		}

		public virtual void ManualUpdate()
		{

		}
	}
}