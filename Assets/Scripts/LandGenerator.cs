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
    public TileBase[] SandTiles;
    /*
     * Created Dictionary as Vector3 because .transform.position returns Vector3 instead a Vector2
     * so that we can manage it in code in the future 
     */
    private float nx;
    private float ny;
    private Tilemap tilemap;
    private float levelOfWater = 0.2f;
    private float levelOfSand = 0.35f;
    private float levelOfForest = 0.5f;
    private float levelOfHills = 0.7f;

    private const string WATER = "Water";
    private const string SAND = "Sand";
    private const string FOREST = "Forest";
    private const string HILLS = "Hills";
    private const string MOUNTAINS = "Mountains";
   
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
            case FOREST:
                tile = GetTile(ForestTiles);
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

    private TileBase GetTile(TileBase[] tileArray)
    {
        return tileArray[Random.Range(0, 1/* tileArray.Length*/)];
    }
    private string GetBiomFromPoint (float point)
    {
        if (point < levelOfWater)
            return WATER;
        else if (point < levelOfSand)
            return SAND; 
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
        TileSetup();
    }
}
