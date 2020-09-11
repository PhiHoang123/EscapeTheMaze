﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Flags]
public enum WallState
{
    //0000 -> No Wall
    //1111 -> Left,Right,Up,Down

    LEFT = 1,  //0001
    RIGHT = 2, //0010
    UP = 4,    //0100
    DOWN = 8,  //1000
}

public static class MazeGenerator
{
    public static WallState[,] Generate(int width, int height)
    {
        //creates a two - dimensional array of (width) rows and (height) columns.
        WallState[,] maze = new WallState[width, height];

        // the collection of possible values of enum, not a single value
        WallState initial = WallState.RIGHT | WallState.LEFT | WallState.UP | WallState.DOWN; 

        for (int i = 0; i < width; ++i)
        {
            for(int j = 0; j < height; ++j)
            {
                maze[i, j] = initial; //1111
            }
        }
        return maze;
    }
    
}