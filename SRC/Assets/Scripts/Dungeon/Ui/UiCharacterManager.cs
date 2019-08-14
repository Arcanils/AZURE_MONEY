using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dungeon
{
	[System.Serializable]
	public class UiCharacterManager
	{
		[SerializeField]
		private Transform m_container;
		[SerializeField]
		private GameObject m_uiCharacterPrefab;

		private List<UiCharacter> m_uiCharactersAlives;

		private static UiCharacterManager m_instance;

		public void Init()
		{
			m_instance = this;
			m_uiCharactersAlives = new List<UiCharacter>();
		}

		public static UiCharacter CreateAndInitUiCharacter(CharacterData data)
		{
			return m_instance._CreateAndInitUiCharacter(data);
		}

		private UiCharacter _CreateAndInitUiCharacter(CharacterData data)
		{
			var instance = GameObject.Instantiate(m_uiCharacterPrefab, m_container, true);
			var trans = instance.transform;

			trans.position = UiUtils.GetWorldPositionFromCellPosition(new Point());

			var script = instance.GetComponent<UiCharacter>();
			script.InitGraph();

			m_uiCharactersAlives.Add(script);

			return script;
		}
	}
}
