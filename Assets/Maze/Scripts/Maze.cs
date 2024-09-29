using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{


    [SerializeField]
    private MazeGenerator _mazeGenerator;

    private int[,] _maze;

    private void Awake()
    {
        _maze = _mazeGenerator.GetMazeGrid();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
