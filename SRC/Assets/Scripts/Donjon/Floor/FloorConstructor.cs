using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Donjon
{
	public static class FloorConstructor
	{
		public static void Construct(
			CharacterManager characterManager,
			FloorManager floorManager,
			UiMapManager uiMapManager,
			CharacterData playerData,
			FloorData floorData,
			Tilemap tilemap,
			TileBase[] tiles
			)
		{
			// extract data from floorData
			// CharacterManager set character data => create characters
			// Player & ally update pos / create
			// Set player,

			var yLength = 7;
			var xLength = 7;
			var cells = new Cell[yLength, xLength];
			for (int i = 0; i < yLength; i++)
			{
				for (int j = 0; j < xLength; j++)
				{
					var wall = i == 0 || i == yLength - 1 || j == 0 || j == xLength - 1;
					cells[i, j] = new Cell(wall ? ECellType.Wall : ECellType.Floor, new Vector2Int(j, i));
					tilemap.SetTile(new Vector3Int(j, i, 0), tiles[wall ? 0 : 1]);
					//Debug.LogFormat("Wall [{0},{1}] {2}", i, j, wall);
				}
			}

			var floor = new Floor(cells, yLength, xLength);

			floorManager.InitFloor(floor);
		}
	}
}
