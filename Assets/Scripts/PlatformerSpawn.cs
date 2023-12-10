using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerSpawn : MonoBehaviour
{
    public GameObject platformPrefab; 
    public int numberOfPlatform; 
    public float LevelWidth = 3f;
    public float minY = 1.3f; 
    public float maxY = 3.0f; 
    private Vector3 _spawnPosition = new Vector3();

    public GameObject prefabJewel;
    private Vector3 _spawnPositionJewel = new Vector3();
    public GameObject BoostPlatform; //**********************************************

    void Start()
    {  
        for (int i = 0; i < numberOfPlatform; i++)
        {
            SpawnPlatform();
        }

        Spawn(prefabJewel, _spawnPositionJewel, 15, 2);
        Spawn(BoostPlatform, Vector3.zero, 15, 8); //********************************
    }

    private void SpawnPlatform()
    {
        _spawnPosition.y += Random.Range(minY, maxY);
        _spawnPosition.x = Random.Range(LevelWidth, -LevelWidth);
        Instantiate(platformPrefab, _spawnPosition, Quaternion.identity);
    }

    private void Spawn(GameObject prefab, Vector3 startPos, int numberObjects, int frequence)
    {
        for(int i = 0; numberObjects >= 0; i++)
        {
            startPos.y += Random.Range(minY, maxY); 
            if(i % frequence == 0)
            {
                startPos.x = Random.Range(LevelWidth, -LevelWidth);
                Instantiate(prefab, startPos, Quaternion.identity);
                numberObjects--;
            }
        }
    }
}
