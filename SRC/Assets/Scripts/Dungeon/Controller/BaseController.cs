using Dungeon.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Dungeon
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

        public virtual void Think()
        {

        }

        public virtual void Execute()
        {

        }

        public float GetCharacterSpeed()
        {
            return 1f;
        }
	}
}