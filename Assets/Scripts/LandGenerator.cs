using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LandGenerator : MonoBehaviour
{
    public int height = 10;
    public int width = 10;
    public List<string> listOfNoises = new List<string>(); // created just for cheking  list in editor
    public Dictionary<Vector3Int, string> pointsToSpawn = new Dictionary<Vector3Int, string>();
    public TileBase[] MountainsTiles;
    public TileBase[] ForestTiles;
    public TileBase[] WaterTiles;
    /*
     * Created Dictionary as Vector3 because .transform.position returns Vector3 instead a Vector2
     * so that we can manage it in code in the future 
     */
    private float nx;
    private float ny;
    private Tilemap tilemap;

    private const string WATER = "Water";
    private const string FOREST = "Forest";
    private const string HILLS = "Hills";
    private const string MOUNTAINS = "Mountains";
   
    [SerializeField] private float frequency = 1.5f;
    [SerializeField] private GameObject[] floorTiles;
    private void CalcNoise()
    {
        for (int x = 0; x < height; x++)
        {
            for (int y = 0; y < width; y++)
            {
                 nx = (float)x / width - 0.5f;
                 ny = (float)y / height - 0.5f;
                Vector3Int position = new Vector3Int(x, y, 0);
                float point = Mathf.PerlinNoise(nx * frequency, ny * frequency);
                string biom = GetBiomFromPoint(point);
                pointsToSpawn.Add(position, biom);
                listOfNoises.Add(pointsToSpawn[position]);

            }
        }
    }

    private void TileSetup()
    {
        CalcNoise();
        foreach (var item in pointsToSpawn)
        {
            Vector3Int position = item.Key;
            TileBase tile = GetTileFromBiomType(item.Value);
            tilemap.SetTile(position, tile);
        }
    }
    private TileBase GetTileFromBiomType(string biomType)
    {
        TileBase tile;
        switch (biomType)
        {
            case WATER:
                tile = WaterTiles[Random.Range(0, WaterTiles.Length)];
                break;
            case FOREST:
                tile = ForestTiles[Random.Range(0, ForestTiles.Length)];
                break;
            default:
                tile = MountainsTiles[Random.Range(0, MountainsTiles.Length)];
                break;       
        }
        return tile;
    }
    private string GetBiomFromPoint (float point)
    {
        if (point < 0.2f)
            return WATER;
        else if (point < 0.5f)
            return FOREST; 
        else if (point < 0.7f)
            return HILLS;
        else
            return MOUNTAINS;
    }

    private void Awake()
    {
        GameObject gameobject =  GameObject.Find("Tilemap");
        tilemap = gameobject.GetComponent<Tilemap>();
        TileSetup();
    }
}
