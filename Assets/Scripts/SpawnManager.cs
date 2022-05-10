using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject cubeTargetPrefab;
    public GameObject wallPrefab;
    private PlayerController playerController;

    public List<Vector3> cubes = new List<Vector3>();
    private float roadXYrange = 4.5f; 
    private float roadRangeZ = 20.0f;
    public float randomPrefabScale;
    private void Start() 
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        for(int i =0;i<5;i++)
        {
            //RandomSpawnWall();
        }
        //InvokeRepeating("RandomSpawnCubeTarget",1.0f,0.2f);
    }
    private void RandomSpawnCubeTarget()
    {
        if(playerController.gameIsStopped==false)
        {
            Vector3 cubeSpawnPosition = new Vector3(randomRangeX(),TargetPositionY(),randomRangeZ());
            cubes.Add(cubeSpawnPosition);

            if(!cubes.Contains(cubeSpawnPosition) == false)
            {
                Instantiate(cubeTargetPrefab,cubeSpawnPosition,cubeTargetPrefab.transform.rotation);
            }
        }
    }
    private void RandomSpawnWall()
    {
        wallPrefab.transform.position = new Vector3(0,0,0);
        randomPrefabScale = Random.Range(1,8);
        wallPrefab.transform.localScale = new Vector3(wallPrefab.transform.localScale.x,randomPrefabScale,wallPrefab.transform.localScale.z);
        if(randomPrefabScale ==1)
        {
            wallPrefab.transform.position = new Vector3(wallPrefab.transform.position.x,0.6f,wallPrefab.transform.position.z);
        }
        else
        {
            for(int i =0;i<randomPrefabScale;i++)
            {
                wallPrefab.transform.position = new Vector3(wallPrefab.transform.position.x,wallPrefab.transform.position.y + 0.5f,wallPrefab.transform.position.z);
            }
        }
        Instantiate(wallPrefab,new Vector3(0f,wallPrefab.transform.position.y+0.1f,randomRangeZ()),wallPrefab.transform.rotation);
    }
    private float randomRangeX()
    { 
        return Random.Range(-roadXYrange,roadXYrange);
    }
    private float TargetPositionY()
    {
        return cubeTargetPrefab.transform.position.y;
    }
    private float randomRangeZ()
    {
        return Random.Range(roadRangeZ,roadRangeZ*10);
    }   
}