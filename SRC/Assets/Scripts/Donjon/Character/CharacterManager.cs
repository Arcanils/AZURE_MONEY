using Donjon.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donjon
{
	public class CharacterManager
	{
		private List<BaseCharacter> m_charactersAlive;
		private List<BaseCharacter> m_charactersDead;

		private Dictionary<int, List<BaseCharacter>> m_charactersBySide;

		public CharacterManager()
		{
			Debug.Log("Init CharacterManager");
			m_charactersAlive = new List<BaseCharacter>();
			m_charactersDead = new List<BaseCharacter>();
		}

		public void InitNewFloor(List<BaseCharacter> characters)
		{
			m_charactersAlive.Clear();
			m_charactersDead.Clear();

			m_charactersAlive.AddRange(characters);
		}

		public bool HasSideAlives(ECharacterSide side)
		{
			var iSide = (int)side;

			List<BaseCharacter> tmpList;

			return m_charactersBySide.TryGetValue(iSide, out tmpList) && tmpList.Count != 0;
		}
	}
}