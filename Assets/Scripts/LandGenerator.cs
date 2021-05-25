using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandGenerator : MonoBehaviour
{
    public int height = 10;
    public int width = 10;
    public List<float> listOfNoise = new List<float>();

    private float nx;
    private float ny;

    [SerializeField] private float frequency = 1f;
    private void CalcNoise()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                 nx = (float)x / width - 0.5f;
                 ny = (float)y / height - 0.5f;
                listOfNoise.Add(Mathf.PerlinNoise(nx * frequency, ny * frequency));
            }
        }
    }
    private void Awake()
    {
        CalcNoise();
    }
}
