using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donjon
{
	public class UiManager : MonoBehaviour
	{
		[SerializeField]
		private UiCharacterManager m_characterManager;
		public UiCharacterManager CharacterManager { get { return m_characterManager; } }

		public static UiManager Instance { get; private set; }

		public void Awake()
		{
			Instance = this;
			m_characterManager.Init();
		}
	}
}
