using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishSpawner : MonoBehaviour
{
    [SerializeField]
    private MazeGenerator _mazeGenerator;

    private void Start()
    {
        var pos = _mazeGenerator.GetFinish;
        var xLimit = _mazeGenerator.GetMazeGrid.GetLength(0);

        if (pos.X == 0)
        { }
        else if (pos.X == xLimit-1)
            this.transform.eulerAngles = new Vector3(0, 0, 180);
        else if (pos.Y == 0)
            this.transform.eulerAngles = new Vector3(0, 0, 90);
        else
            this.transform.eulerAngles = new Vector3(0, 0, -90);

        this.transform.position = new Vector3(pos.X*2, pos.Y*2, 0);
    }
}