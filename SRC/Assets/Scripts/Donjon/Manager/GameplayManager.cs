﻿using Donjon.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Donjon
{
	public class GameplayManager 
	{
		private CharacterManager m_characterManager;
		private FloorManager m_floorManager;
		private CameraManager m_camManager;
		private BaseCharacter m_player;
		private BaseController m_playerController;

		private BaseCharacter m_enemy;
		private BaseController m_enemyController;


		public GameplayManager(Grid tileGrid)
		{
			Debug.Log("Init GameplayManager");
			m_characterManager = new CharacterManager();
			m_floorManager = new FloorManager(tileGrid.cellSize, tileGrid.transform.position);
			m_camManager = new CameraManager(Camera.main, -Camera.main.transform.position.z);
		}

		public void InitNewFloor(Tilemap tilemap, TileBase[] tiles)
		{
			FloorConstructor.Construct(m_characterManager, m_floorManager, null, null, null, tilemap, tiles);

			m_player = new BaseCharacter(null, new Point(1,1));
			m_playerController = new PlayerController(m_player);

			m_enemy = new BaseCharacter(null, new Point(3, 3));
			m_enemyController = new EnemyController(m_enemy);
		}

		public void ManualUpdate()
		{
			m_playerController.ManualUpdate();
		}
	}
}
