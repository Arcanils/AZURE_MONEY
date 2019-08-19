using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dungeon
{
	public class UiManager : MonoBehaviour
	{
		[SerializeField]
		private UiCharacterManager m_characterManager;
		public UiCharacterManager CharacterManager { get { return m_characterManager; } }
		[SerializeField]
		private UiPlayerManager m_uiPlayerManager;
		public UiPlayerManager PlayerManager { get { return m_uiPlayerManager; } }

		public static UiManager Instance { get; private set; }

		public void Awake()
		{
			Instance = this;
			m_characterManager.Init();
			//m_uiPlayerManager.Init();
		}
	}
}
