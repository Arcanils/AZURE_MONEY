using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dungeon.Character
{
	public class BaseCharacter
	{
		public MovementComponent MoveComponent { get; private set; }
		public UiComponent UiComponent { get; private set; }
		public AiComponent AiComponent { get; private set; }
		public CameraComponent CamComponent { get; private set; }



        public bool IsPlayer { get; private set; }

		private EDirection m_currentDir;

		public BaseCharacter(CharacterData data, Point pos, bool isPlayer)
		{
            IsPlayer = isPlayer;
			UiComponent = new UiComponent(this);
			MoveComponent = new MovementComponent(this, pos);
			AiComponent = new AiComponent(this);
			CamComponent = new CameraComponent(this);
			SetPosition(MoveComponent.CurrentPos);
		}

		public TurnAction Execute()
		{


			return null;
		}

		public void UpdateUI()
		{

		}

		public void SetPosition(Point pos)
		{
			MoveComponent.SetPosition(pos);
		}
	}
}
