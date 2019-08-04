using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Donjon
{
	public class MainManager : MonoBehaviour
	{
		public FloorData FloorDataTMP;
		public TileBase[] Tiles;
		public Tilemap Tilemap;

		private GameplayManager m_gameplayManager;

		private void Awake()
		{
			InitMain();
		}

		private void Start()
		{
			StartCoroutine(DonjonEnum());
		}

		private void InitMain()
		{
			m_gameplayManager = new GameplayManager();
		}

		public void InitFloor()
		{
			m_gameplayManager.InitNewFloor(Tilemap, Tiles);
		}

		public void ClearFloor()
		{

		}

		public void EndDonjon()
		{

		}

		public IEnumerator DonjonEnum()
		{
			InitFloor();
			while(true)
			{
				m_gameplayManager.ManualUpdate();
				yield return null;
			}
		}
	}
}
