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

        public void Move(Point nextPos)
        {
            Debug.LogFormat("[AIComponent]: Move to {0}", nextPos);
            
            m_char.MoveComponent.Move(nextPos);
        }
	}
}