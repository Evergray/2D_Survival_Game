using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandGenerator : MonoBehaviour
{
    public int height = 10;
    public int width = 10;
    public List<string> listOfNoises = new List<string>(); // created just for cheking  list in editor
    public Dictionary<Vector3, string> pointsToSpawn = new Dictionary<Vector3, string>();
    /*
     * Created Dictionary as Vector3 because .transform.position returns Vector3 instead a Vector2
     * so that we can manage it in code in the future 
     */
    private float nx;
    private float ny;

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
                Vector3 position = new Vector3(x, y, 0);
                float point = Mathf.PerlinNoise(nx * frequency, ny * frequency);
                string biom = GetTileFromePoint(point);
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
            // do something with item.Value or item.Key
            GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
            GameObject instance = Instantiate(toInstantiate, item.Key, Quaternion.identity) as GameObject;
            instance.transform.SetParent(this.gameObject.transform);
        }
    }

    private string GetTileFromePoint (float point)
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
        TileSetup();
    }
}
