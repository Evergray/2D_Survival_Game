using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LandGenerator : MonoBehaviour
{
    public int height = 10;
    public int width = 10;
    public static Dictionary<Vector3Int, string> pointsToSpawn = new Dictionary<Vector3Int, string>();
   /*
   * Created Dictionary as Vector3 because .transform.position returns Vector3 instead a Vector2
   * so that we can manage it in code in the future 
   */
    public TileBase[] MountainsTiles;
    public TileBase[] ForestTiles;
    public TileBase[] GrassTiles;
    public TileBase[] WaterTiles;
    public TileBase[] DeepWaterTiles;
    public TileBase[] SandTiles;
    public const string DEEPWATER = "DeepWater";
    public const string WATER = "Water";
    public const string SAND = "Sand";
    public const string FOREST = "Forest";
    public const string GRASS = "Grass";
    public const string HILLS = "Hills";
    public const string MOUNTAINS = "Mountains";
  
    private float nx;
    private float ny;
    private Tilemap tilemap;
    private float levelOfDeepWater = 0.1f;
    private float levelOfWater = 0.2f;
    private float levelOfSand = 0.35f;
    private float levelOfGrass = 0.45f;
    private float levelOfForest = 0.6f;
    private float levelOfHills = 0.7f;

    [SerializeField] private float frequency = 0.06f;
    [SerializeField] private float intensity = 0.63f;
    [SerializeField] private float vignetteIntensity = 0.005f;
    [SerializeField] private Vector2 offset = new Vector2(1f, 1f);
    private void CalcNoise()
    {
        pointsToSpawn.Clear();
        for (int x = 0; x < height; x++)
        {
            for (int y = 0; y < width; y++)
            {
                 nx = (float)x / width - 0.5f;
                 ny = (float)y / height - 0.5f;
                Vector3Int position = new Vector3Int(x, y, 0);
                float vignette = 1.0f - new Vector2(width / 2 - x, height / 2 - y).magnitude * vignetteIntensity;
                float point = Mathf.PerlinNoise((nx + offset.x) / frequency, (ny + offset.y) / frequency) * intensity * vignette;
                string biom = GetBiomFromPoint(point);
                pointsToSpawn.Add(position, biom);
            }
        }
    }

    private void TileSetup()
    {
        CalcNoise();
        tilemap.ClearAllTiles();
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
                tile = GetTile(WaterTiles);
                break;
            case DEEPWATER:
                tile = GetTile(DeepWaterTiles);
                break;
            case FOREST:
                tile = GetTile(ForestTiles);
                break; 
            case GRASS:
                tile = GetTile(GrassTiles);
                break;
            case SAND:
                tile = GetTile(SandTiles);
                break;
            default:
                tile = GetTile(MountainsTiles);
                break;       
        }
        return tile;
    }

    private TileBase GetTile(TileBase[] tileArray) => tileArray[Random.Range(0, tileArray.Length)];
    private string GetBiomFromPoint (float point)
    {
        if (point < levelOfDeepWater)
            return DEEPWATER;
        else if (point < levelOfWater)
            return WATER;  
        else if (point < levelOfSand)
            return SAND; 
        else if (point < levelOfGrass)
            return GRASS;  
        else if (point < levelOfForest)
            return FOREST; 
        else if (point < levelOfHills)
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

    private void Update()
    {
       // TileSetup();
    }
}
