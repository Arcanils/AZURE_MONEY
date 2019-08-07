using Donjon.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donjon
{
	public class PlayerController : BaseController
	{
		public PlayerController(BaseCharacter player) : base(player)
		{
			m_char.CamComponent.FollowCharacter();
		}

		public override void ManualUpdate()
		{
			if (Input.GetKeyDown(KeyCode.DownArrow))
				m_char.AiComponent.Move(EDirection.Bottom);
			if (Input.GetKeyDown(KeyCode.UpArrow))
				m_char.AiComponent.Move(EDirection.Top);
			if (Input.GetKeyDown(KeyCode.RightArrow))
				m_char.AiComponent.Move(EDirection.Right);
			if (Input.GetKeyDown(KeyCode.LeftArrow))
				m_char.AiComponent.Move(EDirection.Left);
            if (Input.GetMouseButtonDown(0))
                m_char.AiComponent.Move(UiGridPlayerInput.ConvertInputUIIntoPoint(Input.mousePosition));
		}
	}
}
