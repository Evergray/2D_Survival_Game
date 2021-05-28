using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandGenerator : MonoBehaviour
{
    public int height = 10;
    public int width = 10;
    public List<float> listOfNoises = new List<float>(); // created just for cheking  list in editor
    public Dictionary<Vector3, float> pointsToSpawn = new Dictionary<Vector3, float>();
    /*
     * Created Dictionary as Vector3 because .transform.position returns Vector3 instead a Vector2
     * so that we can manage it in code in the future 
     */
    private float nx;
    private float ny;

    [SerializeField] private float frequency = 1f;
    private void CalcNoise()
    {
        for (int x = 0; x < height; x++)
        {
            for (int y = 0; y < width; y++)
            {
                 nx = (float)x / width - 0.5f;
                 ny = (float)y / height - 0.5f;
                Vector3 position = new Vector3(x, y, 0);
                pointsToSpawn.Add(position, Mathf.PerlinNoise(nx * frequency, ny * frequency));
                listOfNoises.Add(pointsToSpawn[position]);

            }
        }
    }
    private void Awake()
    {
        CalcNoise();
    }
}
