using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Dungeon
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
            var data = floorData.Data;
			var yLength = data.YSize;
			var xLength = data.XSize;
			var cells = new Cell[yLength, xLength];
			for (int y = 0; y < yLength; y++)
			{
				for (int x = 0; x < xLength; x++)
				{
                    var indexTile = x + y * xLength;
                    var wall = data.TilesData[indexTile] == 0;
                    cells[y, x] = new Cell(wall ? ECellType.Wall : ECellType.Floor, new Point(x, y));
					tilemap.SetTile(new Vector3Int(x, y, 0), tiles[wall ? 0 : 1]);
					//Debug.LogFormat("Wall [{0},{1}] {2}", i, j, wall);
				}
			}

			var floor = new Floor(cells, yLength, xLength);

			floorManager.InitFloor(floor);
		}
	}
}
