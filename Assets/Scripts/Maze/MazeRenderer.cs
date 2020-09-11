using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{
    [SerializeField]
    [Range(1,20)]
    private int _width = 10;

    [SerializeField]
    [Range(1, 20)]
    private int _height = 10;

    [SerializeField]
    private float _size = 1f;

    [SerializeField]
    private Transform _wallPrefab = null;



    // Start is called before the first frame update
    void Start()
    {
        var maze = MazeGenerator.Generate(_width, _height);
        Draw(maze);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void Draw(WallState[,] maze)
    {
        for(int i = 0; i < _width; ++i)
        {
            for (int j = 0; j < _height; ++j)
            {
                var cell = maze[i, j];
                var position = new Vector3(-_width / 2 + i, 0, -_height / 2 + j);

                if (cell.HasFlag(WallState.UP))
                {
                    var topWall = Instantiate(_wallPrefab, transform) as Transform;
                    topWall.position = position + new Vector3(0, 0, _size/2);
                    topWall.localScale = new Vector3(_size, topWall.localScale.y, topWall.localScale.z);
                }

                if (cell.HasFlag(WallState.LEFT))
                {
                    var leftWall = Instantiate(_wallPrefab, transform) as Transform;
                    leftWall.position = position + new Vector3(-_size/2, 0, 0);
                    leftWall.eulerAngles = new Vector3(0, 90, 0);
                }
            }
            
        }
    }
}
