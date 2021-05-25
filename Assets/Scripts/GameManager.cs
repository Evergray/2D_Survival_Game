using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ResourceContainerSpawner resourceScript;

    void Awake()
    {
        resourceScript = GetComponent<ResourceContainerSpawner>();
        InitGame();
    }

    void InitGame()
    {
        resourceScript.SetupResourcesOnScene();
    }
}
