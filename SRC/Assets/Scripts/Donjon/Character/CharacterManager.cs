using Donjon.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donjon
{
	public class CharacterManager
	{
		private List<BaseController> m_charactersAlive;
		private List<BaseController> m_charactersDead;

		private Dictionary<int, List<BaseController>> m_charactersBySide;

		public CharacterManager(List<BaseCharacter> baseCharacters)
		{
			Debug.Log("Init CharacterManager");
			m_charactersAlive = new List<BaseController>();
			m_charactersDead = new List<BaseController>();
            InitNewFloor(baseCharacters);
        }

        public void ManualUpdate()
        {
            foreach (var charIt in m_charactersAlive)
            {
                charIt.ManualUpdate();
            }
        }

        private BaseController CreateController(BaseCharacter data)
        {
            return data.IsPlayer ?  new PlayerController(data) as BaseController : new EnemyController(data) as BaseController;
        }

		public void InitNewFloor(List<BaseCharacter> characters)
		{
			m_charactersAlive.Clear();
			m_charactersDead.Clear();

            for (int i = 0; i < characters.Count; i++)
            {
                m_charactersAlive.Add(CreateController(characters[i]));
            }
		}

		public bool HasSideAlives(ECharacterSide side)
		{
			var iSide = (int)side;

			List<BaseController> tmpList;

			return m_charactersBySide.TryGetValue(iSide, out tmpList) && tmpList.Count != 0;
		}

        public List<BaseController> GetCharacterControllerList()
        {
            return m_charactersAlive;
        }
	}
}