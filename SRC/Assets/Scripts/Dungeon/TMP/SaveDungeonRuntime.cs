using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;

public class SaveDungeonRuntime : MonoBehaviour
{
    public Tilemap RefTileMap;
    public string DonjonName = "Test_Donjon";
    public bool SaveData;
    public int[][] test;
    public List<int>[] test2;
    public List<int[]> test3;
    public List<TileBase> BlockTile;
    public List<TileBase> FloorTile;

    public const string LocalPath = "/Datas/Dungeons/";

    private void Awake()
    {
        SaveData = false;
    }

    public void Update()
    {
        if (SaveData)
        {
            SaveCurrentDungeon();
            SaveData = false;
        }
    }

    private void SaveCurrentDungeon()
    {
        var name = DonjonName + System.DateTime.Now.ToString("yyyy_MM_dd_HH_mm", CultureInfo.InvariantCulture);
        var bounds = RefTileMap.cellBounds;
        var allTiles = RefTileMap.GetTilesBlock(bounds);
        var convertedTiles = new int[bounds.size.y * bounds.size.x];

        for (int y = 0; y < bounds.size.y; y++)
        {
            for (int x = 0; x < bounds.size.x; x++)
            {
                var index = x + y * bounds.size.x;
                var tile = allTiles[index];
                var indexTypeTile = FloorTile.FindIndex(item => item == tile);
                convertedTiles[index] = indexTypeTile + 1;
            }
        }
        var path = Application.dataPath + LocalPath + name;
        using (FileStream fs = File.Create(path))
        {
            var strJson = JsonUtility.ToJson(new DungeonData() { XSize = bounds.size.x, YSize = bounds.size.y, TilesData = convertedTiles });
            var info = new UTF8Encoding(true).GetBytes(strJson.ToString());
            // Add some information to the file.
            fs.Write(info, 0, info.Length);
        }
    }

    public static Dungeon.FloorData GetFloorData(TextAsset file)
    {
        var str = file.text;
        var data = JsonUtility.FromJson<DungeonData>(str);
        return new Dungeon.FloorData() { Data = data };
    }
}

[System.Serializable]
public class DungeonData
{
    public int YSize;
    public int XSize;
    public int[] TilesData;
}
