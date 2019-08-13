using Donjon.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donjon
{
	public class PlayerController : BaseController
	{
        private Stack<Point> m_path;
		public PlayerController(BaseCharacter player) : base(player)
		{
			m_char.CamComponent.FollowCharacter();
		}

        public override void Think()
        {
        }

        public override void Execute()
        {
            if (m_path == null || m_path.Count == 0)
                return;

            m_char.AiComponent.Move(m_path.Pop());
        }

        public override void ManualUpdate()
		{
            if (!Input.GetMouseButtonDown(0))
                return;
            SetPath();
        }

        private void SetPath()
        {
            var destination = UiGridPlayerInput.ConvertInputUIIntoPoint(Input.mousePosition);
            AStar.Search(FloorManager.GetFloor(), m_char.MoveComponent.CurrentPos, destination, out m_path);
        }
	}
}
