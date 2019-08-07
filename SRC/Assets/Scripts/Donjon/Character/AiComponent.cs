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

        public void Move(Point destination)
        {
            Stack<Point> path;
            AStar.Search(FloorManager.GetFloor(), m_char.MoveComponent.CurrentPos, destination, out path);

            if (path == null || path.Count == 0)
                return;

            var nextPos = path.Pop();
            m_char.MoveComponent.Move(nextPos);
        }
	}
}