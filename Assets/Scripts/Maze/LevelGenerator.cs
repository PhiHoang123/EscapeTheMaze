using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelGenerator : MonoBehaviour
{
    public NavMeshSurface navMeshSurface;

    [SerializeField]
    private int _width = 3;

    [SerializeField]
    private int _height = 3;

    //random position for the finishline spawning
    public static int randPos;

    //check if player has spawned
    private bool _playerSpawned;
    //check if finishline has spawned
    private bool _finishLineSpawned;

    #region GameObjects
    [SerializeField]
    private GameObject _wall;

    [SerializeField]
    private GameObject _finishLine;

    [SerializeField]
    private GameObject[] _finishLineSpawnPoints;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        //begin generating level
        GeneratorLevel();

        //bake the NavMesh after the level's generated
        navMeshSurface.BuildNavMesh();
    }

    //created a grid base level
    void GeneratorLevel()
    {
        //Loop over the grid
        for(int i = 0; i <= _width; i+=2)
        {
            //Spawn Walls
            for(int j = 0; j <= _height; j+=2)
            {
                //condition to spawn wall. if the random value is not greater than 0.7 , it will not spawn wall 
                if(Random.value > .7f)
                {
                    //i-width/2f offset
                    Vector3 position = new Vector3(i - _width/ 2f, 0.5f, j - _height /2f);

                    //Debug
                    Debug.Log(position);

                    //spawn wall at defined position
                    Instantiate(_wall, position, Quaternion.identity, transform);
                }
                else if (!_finishLineSpawned)
                {
                    //pick a random number from 0 - array length
                    randPos = Random.Range(0, _finishLineSpawnPoints.Length);

                    //Instantiate finishline at random position of a spawnpoint on gamescene
                    Instantiate(_finishLine, _finishLineSpawnPoints[randPos].transform.position, Quaternion.identity);

                    _finishLineSpawned = true;
                }
            }
        }
    }
}
