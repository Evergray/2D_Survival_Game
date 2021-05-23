using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ResourceManager resourceScript;

    void Awake()
    {
        resourceScript = GetComponent<ResourceManager>();
        InitGame();
    }

    void InitGame()
    {
        resourceScript.SetupResourcesOnScene();
    }
}
