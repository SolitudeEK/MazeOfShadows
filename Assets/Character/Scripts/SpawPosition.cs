using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawPosition : MonoBehaviour
{
    [SerializeField]
    private MazeGenerator _mazeGenerator;

    private void Awake()
        => this.transform.position = new Vector3( _mazeGenerator.GetStart.X * 2,
                                                  _mazeGenerator.GetStart.Y *2, 0);
}
