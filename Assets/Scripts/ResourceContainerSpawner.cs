using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using utils;
using Random = UnityEngine.Random;     

public class ResourceContainerSpawner : MonoBehaviour
{
    [SerializeField] private int columns = 8;
    [SerializeField] private int rows = 8;                                           
    public Count stoneCount = new Count(4, 6);                       
    public Count treeCount = new Count(1, 3);                       
    public Count greeneryCount = new Count(5, 9);                       
    public GameObject[] stoneTiles;                                   
    public GameObject[] treeTiles;                                                                 
    public GameObject[] greeneryTiles;

    [SerializeField] private Transform resourceHolder;                         
    private List<Vector2> gridPositions = new List<Vector2>();

    private void InitialiseList()
    {
        gridPositions.Clear();
        for (float x = 1; x < columns - 1; x += 0.32f)
        {
            for (float y = 1; y < rows - 1; y += 0.32f)
            {
                gridPositions.Add(new Vector2(x, y));
            }
        }
    }

    private Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }

    private void LayoutObjectAtRandom(GameObject[] objectArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum + 1);
        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            if (LandGenerator.pointsToSpawn[Vector3Int.FloorToInt(randomPosition)] == LandGenerator.WATER)
                continue;

            GameObject tileChoice = objectArray[Random.Range(0, objectArray.Length)];
            GameObject instance = Instantiate(tileChoice, randomPosition, Quaternion.identity) as GameObject;
            RandomFlipSide(instance);
            instance.transform.SetParent(resourceHolder);
        }
    }

    private void RandomFlipSide(GameObject gameObject)
    {
        gameObject.GetComponent<SpriteRenderer>().flipX = Random.Range(0, 2) < 1 ? false : true;
    }

    public void SetupResourcesOnScene()
    {
        InitialiseList();
        LayoutObjectAtRandom(stoneTiles, stoneCount.minimum, stoneCount.maximum);
        LayoutObjectAtRandom(treeTiles, treeCount.minimum, treeCount.maximum);
        LayoutObjectAtRandom(greeneryTiles, greeneryCount.minimum, greeneryCount.maximum);
    }
}
