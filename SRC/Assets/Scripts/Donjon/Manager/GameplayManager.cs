using Donjon.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Donjon
{
	public class GameplayManager 
	{
        private TurnManager m_turnManager;
		private CharacterManager m_characterManager;
		private FloorManager m_floorManager;
		private CameraManager m_camManager;


		public GameplayManager(Grid tileGrid)
		{
			Debug.Log("Init GameplayManager");
            m_floorManager = new FloorManager(tileGrid.cellSize, tileGrid.transform.position);
        }

		public void InitNewFloor(Tilemap tilemap, TileBase[] tiles)
		{
			FloorConstructor.Construct(m_characterManager, m_floorManager, null, null, null, tilemap, tiles);
            m_camManager = new CameraManager(Camera.main, -Camera.main.transform.position.z);
            m_characterManager = new CharacterManager(new List<BaseCharacter>()
            {
                new BaseCharacter(null, new Point(1,1), true),
            });
            m_turnManager = new TurnManager(m_characterManager);
        }

		public void ManualUpdate()
		{
            m_characterManager.ManualUpdate();
            m_turnManager.ManualUpdate();
        }
	}
}
