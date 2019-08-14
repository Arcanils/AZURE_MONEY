using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Dungeon
{
	public class MainManager : MonoBehaviour
	{
		public FloorData FloorDataTMP;
		public TileBase[] Tiles;
		public Tilemap Tilemap;
        public Grid TileGrid;
        public TextAsset DongeonData;
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
			m_gameplayManager = new GameplayManager(TileGrid);
		}

		public void InitFloor()
		{
			m_gameplayManager.InitNewFloor(Tilemap, Tiles, SaveDungeonRuntime.GetFloorData(DongeonData));
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
