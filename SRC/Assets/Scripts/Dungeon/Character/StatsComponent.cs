using UnityEngine;
using System.Collections;

namespace Dungeon.Character
{
	public class StatsComponent : BaseCharacterComponent
	{
		public float CurrentHP;
		public float Damage;

		private float m_maxHP;

		public StatsComponent(BaseCharacter character) : base(character)
		{
		}

		public bool IsDead()
		{
			return CurrentHP <= 0f;
		}

		public void Hit(float Damage)
		{
			UpdateHP(Damage);

			if (IsDead())
			{
				m_char.StartDeath();
			}
		}

		private void UpdateHP(float valueToAdd)
		{
			CurrentHP = Mathf.Min(CurrentHP + valueToAdd, m_maxHP);
		}
	}
}
